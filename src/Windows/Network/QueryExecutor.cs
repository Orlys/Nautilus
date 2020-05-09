// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    public static class QueryExecutor
    {
        // https://docs.microsoft.com/zh-tw/windows/win32/api/iprtrmib/ne-iprtrmib-tcp_table_class
        private const int TCP_TABLE_OWNER_PID_ALL = 5;

        /// <summary>
        /// </summary>
        /// <param name="queryBuilder">
        /// Using <see cref="QueryBy.IPv4"/> or <see cref="QueryBy.IPv6"/> to query tcp status.
        /// </param>
        /// <returns></returns>
        public static IReadOnlyList<ITrafficRow> Execute(IRowAdapter queryBuilder)
        {
            return Execute(queryBuilder, x => true);
        }

        /// <summary>
        /// </summary>
        /// <param name="queryBuilder">
        /// Using <see cref="QueryBy.IPv4"/> or <see cref="QueryBy.IPv6"/> to query tcp status.
        /// </param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IReadOnlyList<ITrafficRow> Execute(IRowAdapter queryBuilder, Predicate<ITrafficRow> filter)
        {
            if (queryBuilder == null)
                throw new ArgumentNullException(nameof(queryBuilder));
            if (filter == null)
                return Execute(queryBuilder);

            var result = new List<ITrafficRow>();
            var buffSize = default(int);
            var tcpTablePtr = IntPtr.Zero;

            try
            {
                var ret = GetExtendedTcpTable(
                    tcpTablePtr,
                    ref buffSize,
                    true,
                    queryBuilder.AddressFamily);

                tcpTablePtr = Marshal.AllocHGlobal(buffSize);

                ret = GetExtendedTcpTable(
                    tcpTablePtr,
                    ref buffSize,
                    true,
                    queryBuilder.AddressFamily);
                if (ret != 0)
                    return result;

                var numEntries = queryBuilder.CalculateEntries(tcpTablePtr);

                var rowPtr = tcpTablePtr + 4;
                for (int i = 0; i < numEntries; i++)
                {
                    var row = queryBuilder.Adapt(rowPtr);
                    if (filter.Invoke(row))
                        result.Add(row);
                    rowPtr += queryBuilder.RowSize;
                }
            }
            finally
            {
                if (tcpTablePtr != IntPtr.Zero)
                    Marshal.FreeHGlobal(tcpTablePtr);
            }
            return result;
        }

        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern uint GetExtendedTcpTable(
            IntPtr tcpTable,
            ref int tcpTableLength,
            bool sort,
            AddressFamily ipVersion,
            int tcpTableType = TCP_TABLE_OWNER_PID_ALL,
            int reserved = 0);
    }
}