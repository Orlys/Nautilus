
namespace Orlys.Firewall.Dev
{
    
    using NetFwTypeLib;
    using Orlys.Firewall.Internal;
    using Orlys.Firewall.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            var rs = new RuleSet();

            var rule = rs.AddOrGet("test");
            rule.
            

            rule.RemoteAddresses.Add(IPAddressRange.Parse("10.0.0.1-10.0.0.5"));

        }
    }

}
