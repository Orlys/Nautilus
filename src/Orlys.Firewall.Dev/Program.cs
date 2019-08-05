
namespace Orlys.Firewall.Dev
{
    
    using NetFwTypeLib;
    using Orlys.Firewall.Internal;
    using Orlys.Firewall.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        { 
            var rs = new RuleSet(); 

            var rule = rs.AddOrGet("#test");


             
            Console.ReadKey();
        }
    }

}
