// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using Orlys.Firewall.Models;

    using System;
    using System.Diagnostics;
    using System.Net;

    internal class Program
    {
        private readonly static RuleSet rs;
        private readonly static IRule rule;
        static Program()
        {
            rs = new RuleSet();
            rule = rs.AddOrGet("#test");
        }

        private static void Main(string[] args)
        {
            rule.RemoteAddresses.Add(new IPAddress(12));

            Console.ReadKey();
        }
        ~Program()
        {
            rule.Dispose();
        }
    }
}