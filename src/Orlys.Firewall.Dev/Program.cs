// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Orlys.PollingServices.Traffic;
    using PollingServices;
    using Network.ModelBinding;
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tr = TrafficPolling.Create(PollingCycle.Fixed(TimeSpan.FromMilliseconds(50)));

            tr.Removed += (sender, e) => Console.WriteLine("Removed: " + e.Value.LocalEndPoint + " | " + e.Value.Bind().ProcessName);
            tr.Joined += (sender, e) => Console.WriteLine("Joined: " + e.Value.LocalEndPoint + " | " + e.Value.Bind().ProcessName);

            _ = tr.PollAsync();

            Console.ReadKey();
        }
    }

}

namespace Orlys.PollingServices.Traffic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Orlys.Network;
    using System.Net.NetworkInformation;

    public class TcpConnectionInfoEqualityComparer : EqualityComparer<ITcpConnectionInformation>
    {
        public override bool Equals(ITcpConnectionInformation x, ITcpConnectionInformation y)
        {
            return x.Equals(y);
        }
        public override int GetHashCode(ITcpConnectionInformation obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.LocalEndPoint.GetHashCode();
                hash = hash * 23 + obj.RemoteEndPoint.GetHashCode();
                hash = hash * 23 + obj.ProcessIdentifier.GetHashCode();
                return hash;
            }
        }
    }

    public class TrafficPolling : Polling<ITcpConnectionInformation>
    {
        public static TrafficPolling Create(PollingCycle cycle )
        {
            IEnumerable<ITcpConnectionInformation> fetch()
            {
                foreach (var p in Query.Execute(QuerySelectors.IPv4).Concat(Query.Execute(QuerySelectors.IPv6)))
                {
                        yield return p;
                    
                }
            }
            var current = fetch();

            bool decision(ITcpConnectionInformation x)
            {

                var k = fetch().Contains(x, TcpConnectionInfoEqualityComparer.Default );
                System.Console.WriteLine(k);
                return k;
            }

            var options = new PollingOptions<ITcpConnectionInformation>(cycle, decision);
            

            return new TrafficPolling(options, current);
        }


        private TrafficPolling(PollingOptions<ITcpConnectionInformation> options, IEnumerable<ITcpConnectionInformation> collection)
            : base(options, collection)
        {
        }
    }
}
