// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Orlys.PollingServices.Traffic;
    using PollingServices;
    using Network;
    using Network.ModelBinding;
    using Orlys.Network.Internal;
    using System.Net;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel;

    internal static class Program
    {
        public static string Format(this IPEndPoint endpoint)
        {
            var bytes = endpoint.Address.GetAddressBytes();
            if (endpoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                return string.Format("{0}.{1}.{2}.{3}:{4}", 
                    bytes[0].ToString().PadLeft(3),
                    bytes[1].ToString().PadLeft(3),
                    bytes[2].ToString().PadLeft(3),
                    bytes[3].ToString().PadLeft(3), 
                    endpoint.Port.ToString().PadLeft(5)).PadRight(22);
            else if (endpoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                return endpoint.Address.ToString().PadRight(22) + ":"+endpoint.Port.ToString().PadLeft(5);
            }
            return null;
        }

        public static string Format(this ITcpConnectionInformation e)
        {
            var k = e.TryBind(out var p);
            return e.LocalEndPoint.Format() + " <-> " + e.RemoteEndPoint.Format() +" pid: "+ e.ProcessIdentifier + "[" + (k ? p.ProcessName : "<NA>")+ "]";
        }

        private static void Main(string[] args)
        {
            var sync = new object();

            foreach (var c in from info in Query.Execute(QuerySelectors.IPv4).Concat(Query.Execute(QuerySelectors.IPv6))
                              let p = info.TryBind(out var k) ? k : null
                              where p != null && p.ProcessName.Equals("chrome", StringComparison.InvariantCultureIgnoreCase)
                              select new { info, p })
            {
                Console.WriteLine(c.info.ProcessIdentifier + ": "+c.p.ProcessName);
                c.p.EnableRaisingEvents = true; 
                
                c.p.Exited += (object sender, EventArgs e) =>
                {
                    var p = (sender as Process);
                    Console.WriteLine(p.Id + ": "+p.ProcessName);
                };
            }

            Console.ReadKey();
            

            /*

            var tr = TrafficPolling.Create(PollingCycle.Dynamically(TimeSpan.FromSeconds(5)),
                attach: (sender, e) =>
                {
                    using (ConsoleColorHelper.Create(ConsoleColor.Green))
                        Console.WriteLine("+: "+e.Value.Format());
                },
                detach: (sender, e) =>
                {
                    using (ConsoleColorHelper.Create(ConsoleColor.Red))
                        Console.WriteLine("-: " + e.Value.Format());
                }
                //,
                //pushback: (sender, e) =>
                //{
                //    Console.WriteLine("#: " + e.Value.Format());
                //}
                );

            _ = tr.PollAsync();

            while (true)
            {
                Console.ReadKey();
                tr.Suspend();
                Console.ReadKey();
                _ = tr.PollAsync();
            }

    */
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
    using System.Runtime.CompilerServices;
    using System.Diagnostics;
    using System;
    using Orlys.Network.ModelBinding;

   

    public class TrafficPolling : Polling<ITcpConnectionInformation>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IEnumerable<ITcpConnectionInformation> Fetch()
        {
            foreach (var p in Query.Execute(QuerySelectors.IPv4).Concat(Query.Execute(QuerySelectors.IPv6)))
            {
                if ((p.State == TcpState.Listen || p.State == TcpState.Established) && 
                    !p.RemoteEndPoint.Address.Equals(IPAddress.Any) && 
                    !p.RemoteEndPoint.Address.Equals(IPAddress.Loopback) &&
                    !p.RemoteEndPoint.Address.Equals(IPAddress.IPv6Any) &&
                    !p.RemoteEndPoint.Address.Equals(IPAddress.IPv6Loopback))
                    yield return p;
            }
        }


        private readonly HashSet<ITcpConnectionInformation> _set;

        public override bool Attach(ITcpConnectionInformation value)
        {
            if (this._set.Contains(value))
                return false;
            else if (!this._set.Add(value))
                return false;
            return base.Attach(value);            
        }

        public static TrafficPolling Create(PollingCycle cycle, 
            EventHandler<PollingEventArgs<ITcpConnectionInformation>> attach = null,
            EventHandler<PollingEventArgs<ITcpConnectionInformation>> pushback = null,
            EventHandler<PollingEventArgs<ITcpConnectionInformation>> detach = null)
        { 
             
            bool decision(ITcpConnectionInformation x)
            { 
                var k = Fetch().Contains(x);
                return k;
            }

            var options = new PollingOptions<ITcpConnectionInformation>(cycle, decision);
             
            var tp = new TrafficPolling(options);
            tp.Attached += attach;
            tp.Pushbacked += pushback;
            tp.Detached += detach;

            foreach (var item in Fetch())
            {
                tp.Attach(item);
            }
            return tp;
        }


        private TrafficPolling(PollingOptions<ITcpConnectionInformation> options) : base(options)
        {
            this._set = new HashSet<ITcpConnectionInformation>();
        }

        protected override void BeforeMoveNext()
        { 
            foreach (var c in Fetch())
            {
                    this.Attach(c);
            }
        }

        protected override void OnDetached(object sender, PollingEventArgs<ITcpConnectionInformation> e)
        {
            this._set.Remove(e.Value);
        }
    }
}
