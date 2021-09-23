// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using NetFwTypeLib;

    using System;
    using System.Data;

    internal static class NetFwUtils
    {
        public static INetFwRule CreateNetFwRule()
        {
            return (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
        }

        public static INetFwPolicy2 CreateNetFwPolicy2()
        {
            return (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
        }



        public static IFirewallRule Convert(INetFwRule netFwRule)
        {
            if (!Guid.TryParse(netFwRule.Name, out var id))
            {
                id = Guid.NewGuid();
                netFwRule.Description = netFwRule.Name;
                netFwRule.Name = id.ToString();
            }
            return new FirewallRule(id, netFwRule);
        }


        public static IFirewallRule Create(string groupName, out INetFwRule netFwRule)
        {
            netFwRule = CreateNetFwRule();
            var id = Guid.NewGuid();
            netFwRule.Name = id.ToString();
            netFwRule.Grouping = groupName;
            var rule = new FirewallRule(id, netFwRule)
            {
                Protocol = ProtocolTypes.TCP
            };
            return rule;
        }

    }
}