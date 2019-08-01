
namespace Orlys.Firewall
{
    using NetFwTypeLib;
    using Orlys.Firewall.Internal;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class RuleSet
    {
        private readonly static string s_product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;

        private readonly Dictionary<string, IRule> _rules = new Dictionary<string, IRule>();

        private readonly INetFwPolicy2 _policy;

        public RuleSet()
        {
            this._policy = FwTypes.CreatePolicy2();
            foreach (INetFwRule rule in this._policy.Rules)
            {
                if (string.Equals(rule.Grouping, s_product, StringComparison.InvariantCultureIgnoreCase))
                {
                    var r = new Rule(this.Remove, rule, null);
                    this._rules.Add(r.Name, r);
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

            if (!this._rules.TryGetValue(name, out var rule))
            {
                var r = FwTypes.CreateRule();
                r.Name = name;
                r.Grouping = s_product;
                this._policy.Rules.Add(r);

                r = this._policy.Rules.Item(name);
                rule = new Rule(this.Remove, r, null);
            }
            return rule;
        }

        public bool Remove(string name)
        {
            this.IsNullOrEmpty(name);

            if (this._rules.Remove(name))
            {
                this._policy.Rules.Remove(name);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            var names = this._rules.Keys;
            foreach (var name in names)
            {
                this.Remove(name);
            }
        }

        public IEnumerable<IRule> GetList(Predicate<IRule> filter = null)
        {
            if (filter == null)
                return this._rules.Values;

            IEnumerable<IRule> iterator()
            {
                foreach (var rule in this._rules.Values)
                {
                    if (filter(rule))
                        yield return rule;
                }
            }
            return iterator();

        }
    }
}
