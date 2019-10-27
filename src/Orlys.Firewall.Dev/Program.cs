// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using Orlys.Network;
    using Orlys.Firewall.Models;

    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Principal;



    internal class Program
    { 
        private static void Main(string[] args)
        {
            try
            {
                foreach (var ipv4 in Query.Execute(QuerySelectors.IPv4).Concat(Query.Execute(QuerySelectors.IPv6)))
                {
                    Console.WriteLine(ipv4.State + ": " + ipv4.Local + " <-> " + ipv4.Remote + ": " + ipv4.ProcessIdentifier);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } 
    }
}

