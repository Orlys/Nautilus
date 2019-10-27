
namespace Orlys.Network
{
    using System.Net;

    public interface ITcpConnection
    {
        TcpState State { get; }

        IPEndPoint Local { get; }

        IPEndPoint Remote { get; }

        int ProcessIdentifier { get; }
    }
}