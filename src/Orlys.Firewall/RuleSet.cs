// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall
{
    using NetFwTypeLib;

    using Orlys.Firewall.Internal;
    using Orlys.Firewall.Internal.Visualizers;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Security.Principal;
     
    [DebuggerDisplay("{s_grouping}")]
    [DebuggerTypeProxy(typeof(InternalRuleSetVisualizer))]
    public class RuleSet : IRuleSet
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly static string s_grouping = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly Dictionary<string, IRule> InternalList = new Dictionary<string, IRule>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly INetFwPolicy2 _policy;
         
        /// <summary>
        /// 防火牆規則集
        /// </summary>
        public RuleSet()
        {
        //    var user = WindowsIdentity.GetCurrent();
        //    WindowsPrincipal principal = new WindowsPrincipal(user);
        //    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);


            this._policy = FwTypes.CreatePolicy2();
            lock (this.InternalList)
            {
                foreach (INetFwRule rule in this._policy.Rules)
                {
                    if (string.Equals(rule.Grouping, s_grouping, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var r = new Rule(this.Remove, rule, null);
                        this.InternalList.Add(r.Name, r);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void IsNullOrEmpty(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
        }

        
        public IRule AddOrGet(string name)
        {
            IsNullOrEmpty(name);

            lock (this.InternalList)
            {

                if (!this.InternalList.TryGetValue(name, out var rule))
                {
                    var r = FwTypes.CreateRule();
                    r.Enabled = true;
                    r.Name = name;
                    r.Grouping = s_grouping;
                    this._policy.Rules.Add(r);

                    r = this._policy.Rules.Item(name);
                    rule = new Rule(this.Remove, r, null);
                    this.InternalList.Add(name, rule);
                }
                return rule;
            }
        }


        public bool Remove(string name)
        {
            IsNullOrEmpty(name);

            lock (this.InternalList)
            {
                if (this.InternalList.Remove(name))
                {
                    this._policy.Rules.Remove(name);
                    return true;
                }
                return false;
            }
        }

        public void Clear()
        {
            lock (this.InternalList)
            {
                var names = this.InternalList.Keys;
                foreach (var name in names)
                {
                    this.Remove(name);
                }
            }
        }

        public IEnumerable<IRule> GetList(Predicate<IRule> filter = null)
        {
            lock (this.InternalList)
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
}