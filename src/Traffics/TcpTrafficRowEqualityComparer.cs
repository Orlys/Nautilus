/// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System.Collections.Generic;

    public sealed class TcpTrafficRowEqualityComparer : IEqualityComparer<TcpTrafficRow>
    {
        public static IEqualityComparer<TcpTrafficRow> Default { get; } = new TcpTrafficRowEqualityComparer();
        private TcpTrafficRowEqualityComparer()
        {

        }

        public bool Equals(TcpTrafficRow x, TcpTrafficRow y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode(TcpTrafficRow obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }

}