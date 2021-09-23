// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using NetFwTypeLib;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;
     

    internal class FirewallServiceImpl : IFirewallService
    {
        private readonly INetFwPolicy2 _netFwPolicy2;
        private readonly string _serviceName;
        private readonly ConcurrentDictionary<Guid, IFirewallRule> _rules;
        public IEnumerable<IFirewallRule> Rules => this._rules.Values;

        public FirewallServiceImpl(string name)
        {
            this._serviceName = name;
            this._netFwPolicy2 = NetFwUtils.CreateNetFwPolicy2();
            this._rules = new ConcurrentDictionary<Guid, IFirewallRule>();

            Initialize();
        }

        private void Initialize()
        {
            foreach (INetFwRule rule in this._netFwPolicy2.Rules)
            {
                if (!string.Equals(this._serviceName, rule.Grouping))
                    continue;

                var fwRule = NetFwUtils.Convert(rule);
                this._rules[fwRule.Id] = fwRule;
            }
        }

        public void Clear()
        {
            lock (this._netFwPolicy2)
            {
                var keys = this._rules.Keys;
                foreach (var key in keys)
                {
                    this.Delete(key);
                }
            }
        }

        public IFirewallRule Create()
        {
            lock (this._netFwPolicy2)
            {
                var fwRule = NetFwUtils.Create(this._serviceName, out var netFwRule);
                this._netFwPolicy2.Rules.Add(netFwRule);
                this._rules[fwRule.Id] = fwRule;
                return fwRule;
            }
        }

        public void Delete(Guid id)
        {
            lock (this._netFwPolicy2)
            {
                var result = this._rules.TryRemove(id, out var _);
                if (result)
                    this._netFwPolicy2.Rules.Remove(id.ToString()); 
            }
        }
    }
}