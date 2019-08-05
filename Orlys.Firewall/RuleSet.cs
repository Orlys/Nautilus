
namespace Orlys.Firewall
{
    using NetFwTypeLib;
    using Orlys.Firewall.Internal;
    using Orlys.Firewall.Internal.Visualizers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    [DebuggerTypeProxy(typeof(InternalRuleSetVisualizer))] 
    public class RuleSet
    {
        internal readonly static string Grouping = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly Dictionary<string, IRule> InternalList = new Dictionary<string, IRule>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly INetFwPolicy2 _policy;

        public RuleSet()
        {
            this._policy = FwTypes.CreatePolicy2();
            foreach (INetFwRule rule in this._policy.Rules)
            {
                if (string.Equals(rule.Grouping, Grouping, StringComparison.InvariantCultureIgnoreCase))
                {
                    var r = new Rule(this.Remove, rule, null);
                    this.InternalList.Add(r.Name, r);
                }
            }
        }

        private void IsNullOrEmpty(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
        }

        public IRule AddOrGet(string name)
        {
            this.IsNullOrEmpty(name);

            if (!this.InternalList.TryGetValue(name, out var rule))
            {
                var r = FwTypes.CreateRule();
                r.Name = name;
                r.Grouping = Grouping;
                this._policy.Rules.Add(r);

                r = this._policy.Rules.Item(name);
                rule = new Rule(this.Remove, r, null);
            }
            return rule;
        }

        public bool Remove(string name)
        {
            this.IsNullOrEmpty(name);

            if (this.InternalList.Remove(name))
            {
                this._policy.Rules.Remove(name);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            var names = this.InternalList.Keys;
            foreach (var name in names)
            {
                this.Remove(name);
            }
        }

        public IEnumerable<IRule> GetList(Predicate<IRule> filter = null)
        {
            if (filter == null)
                return this.InternalList.Values;

            IEnumerable<IRule> iterator()
            {
                foreach (var rule in this.InternalList.Values)
                {
                    if (filter(rule))
                        yield return rule;
                }
            }
            return iterator();

        }
    }
}
