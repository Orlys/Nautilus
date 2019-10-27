
namespace Orlys.Network
{
    using System.Net.Sockets;
    using Orlys.Network.Internal;

    public static class QuerySelectors
    {
        public static readonly IQuerySelector IPv4 = new InternalQuerySelector<IPv4Table, IPv4Row>(AddressFamily.InterNetwork);
        public static readonly IQuerySelector IPv6 = new InternalQuerySelector<IPv6Table, IPv6Row>(AddressFamily.InterNetworkV6);
    }
}