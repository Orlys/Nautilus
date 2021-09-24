// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using NetFwTypeLib;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class FirewallServiceImpl : IFirewallService
    {
        private readonly INetFwPolicy2 _netFwPolicy2;
        private readonly string _groupName;
        private readonly ConcurrentDictionary<Guid, RuleBag> _rules;

        private class RuleBag
        {
            public IFirewallRule FirewallRule { get; set; }
            public INetFwRule NetFwRule { get; set; }
        }
        public FirewallServiceImpl(string groupName)
        {
            this._netFwPolicy2 = NetFwUtils.CreateNetFwPolicy2();
            this._groupName = groupName;
            this._rules = new ConcurrentDictionary<Guid, RuleBag>();
            this.Init();
        }

        public IEnumerable<IFirewallRule> Rules
        {
            get
            {
                foreach (var v in _rules.Values)
                    yield return v.FirewallRule;
            }
        }


        //public bool this[Profiles profiles]
        //{
        //    get
        //    {
        //        return this._netFwPolicy2.IsRuleGroupEnabled((int)profiles, _groupName);
        //    }
        //    set
        //    {
        //        this._netFwPolicy2.EnableRuleGroup((int)profiles, _groupName, value);
        //    }
        //}

        private void Init()
        {
            foreach (INetFwRule netFwRule in _netFwPolicy2.Rules)
            {
                if (!string.Equals(netFwRule.Grouping, this._groupName))
                {
                    continue;
                }

                if (!Guid.TryParse(netFwRule.Name, out var id))
                {
                    continue;
                }

                var r = CreateCore(id);
                r.Action = (Actions)netFwRule.Action;
                r.ApplicationName = netFwRule.ApplicationName;
                r.Description = netFwRule.Description;
                r.Direction = (Directions)netFwRule.Direction;
                r.Enabled = netFwRule.Enabled;
                r.IcmpTypesAndCodes = netFwRule.IcmpTypesAndCodes;
                r.InterfaceTypes = (InterfaceTypes)Enum.Parse(typeof(InterfaceTypes), netFwRule.InterfaceTypes);
                r.Profiles = (Profiles)netFwRule.Profiles;
                r.Protocol = netFwRule.Protocol;
                r.ServiceName = netFwRule.serviceName;

                _rules[id] = new RuleBag { FirewallRule = r, NetFwRule = netFwRule };
            }
        }


        public IFirewallRule Get(Guid id)
        {
            if (_rules.TryGetValue(id, out var ruleBag))
            {
                return ruleBag.FirewallRule;
            }
            return null;
        }

        private IFirewallRule CreateCore(Guid id)
        {
            return new FirewallRule(id, this._groupName, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public IFirewallRule Create()
        {
            return CreateCore(Guid.NewGuid());
        }

        public void Update(IFirewallRule rule)
        {
            if (!_rules.TryGetValue(rule.Id, out var bag))
            {
                // new rule, not existed in windows firewall

                var netFwRule = NetFwUtils.CreateNetFwRule();

                netFwRule.Name = GetIdString(rule.Id);
                netFwRule.Grouping = this._groupName;
                bag = new RuleBag
                {
                    FirewallRule = rule,
                    NetFwRule = netFwRule
                };
                _rules.TryAdd(rule.Id, bag);
                _netFwPolicy2.Rules.Add(netFwRule);
            }

            bag.NetFwRule.Action = (NET_FW_ACTION_)rule.Action;
            bag.NetFwRule.ApplicationName = rule.ApplicationName;
            bag.NetFwRule.Description = rule.Description;
            bag.NetFwRule.Direction = (NET_FW_RULE_DIRECTION_)rule.Direction;
            bag.NetFwRule.Enabled = rule.Enabled;
            if (rule.Protocol.SupportedIcmpConfig)
                bag.NetFwRule.IcmpTypesAndCodes = rule.IcmpTypesAndCodes;
            bag.NetFwRule.InterfaceTypes = rule.InterfaceTypes.ToString();
            bag.NetFwRule.Profiles = (int)rule.Profiles;
            bag.NetFwRule.Protocol = rule.Protocol;
            bag.NetFwRule.serviceName = rule.ServiceName;

            bag.NetFwRule.LocalAddresses = rule.LocalAddresses.ToString();
            bag.NetFwRule.RemoteAddresses = rule.RemoteAddresses.ToString();
            if (rule.SupportedPortRange)
            {
                bag.NetFwRule.LocalPorts = rule.LocalPorts.ToString();
                bag.NetFwRule.RemotePorts = rule.RemotePorts.ToString();
            }
        }

        private string GetIdString(Guid id)
        {
            return id.ToString("N");
        }

        public bool Delete(Guid id)
        {
            var flag = _rules.TryRemove(id, out _);

            _netFwPolicy2.Rules.Remove(GetIdString(id));
            return flag;
        }


        public void Clear()
        {
            foreach (var id in _rules.Keys)
            {
                this.Delete(id);
            }
        }
    }
}