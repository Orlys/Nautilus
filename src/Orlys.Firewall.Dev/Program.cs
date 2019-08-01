
namespace Orlys.Firewall.Dev
{  

    using Orlys.Firewall.Internal;
    using System;
    using System.ComponentModel;
    using System.Security.Principal;
    using System.Text;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using NetFwTypeLib;

    class Program
    {
        static void Main(string[] args)
        {
            var rules = new Dictionary<Guid, IRule>();

            var policy = FwTypes.CreatePolicy2();
            foreach (INetFwRule fwRule in policy.Rules)
            {
                var rule = new Rule(policy.Rules.Remove, fwRule, null);
                rules.Add(rule.Id, rule);
            }


            var test = rules.First(x => x.Value.Name == "#TEST").Value;
            ((IAdvanceRule)test).Grouping = "#TEST";
            Console.ReadKey();

            ((IAdvanceRule)test).Grouping = "";

            Console.ReadKey();
        } 
    }
}
