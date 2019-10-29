// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network.Internal
{
    using Orlys.Network;

    using System;
    using System.Net;
    using System.Net.NetworkInformation;

    internal sealed class RowAdapter : TcpConnectionInformation, ITcpConnectionInformation
    {
        internal RowAdapter(IPEndPoint local, IPEndPoint remote, uint state, uint owningPid)
        {
            this.LocalEndPoint = local;
            this.RemoteEndPoint = remote;
            this.State = (TcpState)state;
            this.ProcessIdentifier = (int)owningPid;
        }

        public override TcpState State { get; }

        public override IPEndPoint LocalEndPoint { get; }

        public override IPEndPoint RemoteEndPoint { get; }

        public int ProcessIdentifier { get; }

        public string ToString(string format, params Func<ITcpConnectionInformation, object>[] selector)
        {
            var objs = new object[selector.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = selector[i]?.Invoke(this);
            }
            return string.Format(format, objs);
        }
         


        public bool Equals(ITcpConnectionInformation other)
        {
            return other.LocalEndPoint.Equals(this.LocalEndPoint) &&
               other.RemoteEndPoint.Equals(this.RemoteEndPoint) &&
               other.ProcessIdentifier.Equals(this.ProcessIdentifier);
        }

        public override bool Equals(object obj)
        {
            return obj is ITcpConnectionInformation t ? this.Equals(t) : false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.LocalEndPoint.GetHashCode();
                hash = hash * 19 + this.RemoteEndPoint.GetHashCode();
                hash = hash * 23 + this.ProcessIdentifier.GetHashCode();
                return hash;
            }
        }

    }
}