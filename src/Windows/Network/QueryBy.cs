// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network
{
    using Nautilus.Windows.Network.Internal;

    using System.Net.Sockets;

    public static class QueryBy
    {
        public static readonly IRowAdapter IPv4 = new QuerySelectorBinder<IPv4Table, IPv4Row>(AddressFamily.InterNetwork);
        public static readonly IRowAdapter IPv6 = new QuerySelectorBinder<IPv6Table, IPv6Row>(AddressFamily.InterNetworkV6);
    }
}