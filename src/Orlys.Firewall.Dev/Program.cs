// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Orlys.PollingServices.Traffic;
    using PollingServices;
    internal class Program
    {
        private static void Main(string[] args)
        {
            var opt = new TrafficOptions(PollingCycle.Fixed(TimeSpan.FromSeconds(1)), x => false);
            var tr = TrafficPolling.Create(opt);

            tr.Removed += (sender, e) => Console.WriteLine("Removed: " + e.Value.Local + " | " + Process.GetProcessById(e.Value.Pid).ProcessName);

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

    public class Traffic
    {
        internal Traffic(IPEndPoint local, int pid)
        {
            this.Local = local;
            this.Pid = pid;
        }
        public IPEndPoint Local { get; }
        public int Pid { get; }
    }

    public class TrafficOptions : PollingOptions<Traffic>
    {
        public TrafficOptions(PollingCycle cycle, PollingDecision<Traffic> decision) : base(cycle, decision)
        {
        }
    }

    public class TrafficPolling : Polling<Traffic>
    {
        public static TrafficPolling Create(TrafficOptions options)
        {
            var current = from tcp in Query.Execute(QuerySelectors.IPv4).Concat(Query.Execute(QuerySelectors.IPv6))
                          where tcp.State == TcpState.Established
                          select new Traffic(tcp.LocalEndPoint, tcp.ProcessIdentifier);

            return new TrafficPolling(options, current);
        }


        private TrafficPolling(PollingOptions<Traffic> options, IEnumerable<Traffic> collection) : base(options, collection)
        {
        }
    }
}
