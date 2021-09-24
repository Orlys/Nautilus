/// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System.Collections.Generic;
    using System;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    using static Native;
    using System.Collections;

    public sealed class TcpTrafficTracker
    {
        private readonly RowBinderInfo _info;
        private TcpTrafficTracker(RowBinderInfo info)
        {
            this._info = info;
        }

        private readonly static TcpTrafficTracker s_v4 = new TcpTrafficTracker(RowBinderInfo.Create<IPv4Table, IPv4Row>(AddressFamily.InterNetwork));
        private readonly static TcpTrafficTracker s_v6   = new TcpTrafficTracker(RowBinderInfo.Create<IPv6Table, IPv6Row>(AddressFamily.InterNetworkV6));

        public static IReadOnlyCollection<TcpTrafficRow> Track(IPAddressFamily family = IPAddressFamily.Both)
        { 
            var result = new HashSet<TcpTrafficRow>(TcpTrafficRowEqualityComparer.Default);
            if (family.HasFlag(IPAddressFamily.v4))
                s_v4.TrackCore(result);
            if (family.HasFlag(IPAddressFamily.v6))
                s_v6.TrackCore(result);
            return result;
        }


        private void TrackCore(HashSet<TcpTrafficRow> result)
        {
            var buffSize = default(int);
            var tcpTablePtr = IntPtr.Zero;

            try
            {
                var ret = GetExtendedTcpTable(
                    tcpTablePtr,
                    ref buffSize,
                    true,
                    _info.Family);

                tcpTablePtr = Marshal.AllocHGlobal(buffSize);

                ret = GetExtendedTcpTable(
                    tcpTablePtr,
                    ref buffSize,
                    true,
                    _info.Family);

                if (ret == 0)
                {
                    var numEntries = _info.CalculateEntries(tcpTablePtr);

                    var rowPtr = tcpTablePtr + 4;
                    for (int i = 0; i < numEntries; i++)
                    {
                        var row = _info.Adapt(rowPtr);
                        result.Add(row);
                        rowPtr += _info.PerRowSize;
                    }
                }
            }
            finally
            {
                if (tcpTablePtr != IntPtr.Zero)
                    Marshal.FreeHGlobal(tcpTablePtr);
            } 
        }
    }

}