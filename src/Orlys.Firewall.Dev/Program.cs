// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using Orlys.Firewall.Models;

    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var rs = new RuleSet();

            using (var rule = rs.AddOrGet("#test"))
            {
                rule.LocalPorts.Add(SpecificPort.IPHTTPS);
                Console.ReadKey();
            }
        }
    }
}