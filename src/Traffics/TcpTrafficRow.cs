// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;

    public sealed class TcpTrafficRow
    {
        public IPEndPoint LocalEndPoint { get; }

        public int Pid { get; }

        public IPEndPoint RemoteEndPoint { get; }

        public IPAddressFamily IPAddressFamily { get; }

        public TcpState State { get; set; }

        internal TcpTrafficRow(IPEndPoint local, IPEndPoint remote, uint state, uint owningPid)
        {
            this.LocalEndPoint = local;
            this.RemoteEndPoint = remote;
            this.State = (TcpState)state;
            this.Pid = (int)owningPid;

            Debug.Assert(local.AddressFamily == remote.AddressFamily, "AddressFamily not same.");

            IPAddressFamily = local.AddressFamily == AddressFamily.InterNetwork
                ? IPAddressFamily.v4
                : local.AddressFamily == AddressFamily.InterNetworkV6
                    ? IPAddressFamily.v6
                    : IPAddressFamily.Both; // this shouldnt happened
        }

        public override int GetHashCode()
        {
            var hashCode = 1903003160;
            hashCode = hashCode * -1521134295 + LocalEndPoint.GetHashCode();
            hashCode = hashCode * -1521134295 + RemoteEndPoint.GetHashCode();
            hashCode = hashCode * -1521134295 + State.GetHashCode();
            hashCode = hashCode * -1521134295 + Pid.GetHashCode();
            hashCode = hashCode * -1521134295 + IPAddressFamily.GetHashCode(); 
            return hashCode;
        }
    }
}