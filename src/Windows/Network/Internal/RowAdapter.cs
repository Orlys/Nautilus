// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network.Internal
{
    using Nautilus.Windows.Network;

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.NetworkInformation;

    internal sealed class RowAdapter : ITrafficRow, IEditableTrafficRow
    {
        public IPEndPoint LocalEndPoint { get; }

        public int Pid { get; }

        public IPEndPoint RemoteEndPoint { get; }

        public TcpState State { get; set; }

        internal RowAdapter(IPEndPoint local, IPEndPoint remote, uint state, uint owningPid)
        {
            this.LocalEndPoint = local;
            this.RemoteEndPoint = remote;
            this.State = (TcpState)state;
            this.Pid = (int)owningPid;
        }

        public int CompareTo([AllowNull] ITrafficRow other)
        {
            return this.State - other.State;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ITrafficRow);
        }

        public bool Equals([AllowNull] ITrafficRow other)
        {
            return this.GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LocalEndPoint, this.RemoteEndPoint, this.Pid);
        }
    }
}