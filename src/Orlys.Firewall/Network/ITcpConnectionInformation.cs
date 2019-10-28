// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network
{
    using System;
    using System.Net;
    using System.Net.NetworkInformation;

    public interface ITcpConnectionInformation : IEquatable<ITcpConnectionInformation>
    {
        TcpState State { get; }

        IPEndPoint LocalEndPoint { get; }

        IPEndPoint RemoteEndPoint { get; }

        int ProcessIdentifier { get; }

        string ToString(string format, params Func<ITcpConnectionInformation, object>[] selector);
    }
}