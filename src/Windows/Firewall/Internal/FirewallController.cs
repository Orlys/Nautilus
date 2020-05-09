// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Firewall
{
    using Iridium.Callee;

    using NetFwTypeLib;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;

    internal sealed class FirewallController : IFirewallController
    {
        private readonly INetFwPolicy2 _netFwPolicy2;
        private readonly string _productName;
        private readonly ConcurrentDictionary<Guid, IFirewallRule> _rules;
        public IEnumerable<IFirewallRule> Rules => this._rules.Values;

        internal FirewallController()
        {
            CalleeChecker.Allow(typeof(Firewall));
            var asm = Assembly.GetEntryAssembly();
            this._productName = asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            this._netFwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            this._rules = new ConcurrentDictionary<Guid, IFirewallRule>();

            foreach (INetFwRule rule in this._netFwPolicy2.Rules)
            {
                if (!string.Equals(this._productName, rule.Grouping))
                    continue;

                var fwRule = FirewallRule.Adapt(rule);
                if (!this._rules.TryAdd(fwRule.Id, fwRule))
                {
                    Debug.WriteLine("rule '" + rule.Name + "' was not added");
                }
            }
        }

        public Task Clear()
        {
            lock (this._netFwPolicy2)
            {
                var keys = this._rules.Keys;
                var task = new List<Task>();
                foreach (var key in keys)
                {
                    task.Add(this.Delete(key));
                }
                return Task.WhenAll(task.ToArray());
            }
        }

        public Task<IFirewallRule> Create()
        {
            lock (this._netFwPolicy2)
            {
                IFirewallRule fwRule = FirewallRule.Create(this._productName, out var netFwRule);
                fwRule.Protocol = ProtocolTypes.TCP;
                this._netFwPolicy2.Rules.Add(netFwRule);
                this._rules.TryAdd(fwRule.Id, fwRule);
                return Task.FromResult(fwRule);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            lock (this._netFwPolicy2)
            {
                var result = this._rules.TryRemove(id, out var _);
                if (result)
                    this._netFwPolicy2.Rules.Remove(id.ToString());
                return Task.FromResult(result);
            }
        }
    }
}