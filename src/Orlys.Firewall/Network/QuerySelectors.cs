// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network
{
    using Orlys.Network.Internal;

    using System.Net.Sockets;

    public static class QuerySelectors
    {
        public static readonly IQuerySelector IPv4 = new InternalQuerySelector<IPv4Table, IPv4Row>(AddressFamily.InterNetwork);
        public static readonly IQuerySelector IPv6 = new InternalQuerySelector<IPv6Table, IPv6Row>(AddressFamily.InterNetworkV6);
    }
}