// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using Orlys.Firewall.Models;

    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Principal;

    internal class Program
    { 
        private static void Main(string[] args)
        {
            var admin = WindowsIdentity.GetCurrent();
            var isAdmin = new WindowsPrincipal(admin).IsInRole(WindowsBuiltInRole.Administrator);
            Console.WriteLine(isAdmin);

            try
            {
               var rs = new RuleSet();
                Console.WriteLine("OK");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Fail");
            }

            Console.ReadKey();

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            try
            {
                var rs = new RuleSet();
                Console.WriteLine("OK");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Fail");
            }

        } 
    }
}