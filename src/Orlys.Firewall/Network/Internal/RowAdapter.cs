// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network.Internal
{
    using Orlys.Network;
    using System.Net;

    internal sealed class RowAdapter : ITcpConnection
    {
        internal RowAdapter(IPEndPoint local, IPEndPoint remote, uint state, uint owningPid)
        {
            this.Local = local;
            this.Remote = remote;
            this.State = (TcpState)state;
            this.ProcessIdentifier = (int)owningPid;
        }


        public TcpState State { get; }

        public IPEndPoint Local { get; }

        public IPEndPoint Remote { get; }

        public int ProcessIdentifier { get; }

    }

}
