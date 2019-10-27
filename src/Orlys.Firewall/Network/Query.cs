// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network
{
    using System.Runtime.InteropServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Net;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class Query
    {
        // https://docs.microsoft.com/zh-tw/windows/win32/api/iprtrmib/ne-iprtrmib-tcp_table_class
        private const int TCP_TABLE_OWNER_PID_ALL = 5;


        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern uint GetExtendedTcpTable(
            IntPtr tcpTable,
            ref int tcpTableLength,
            bool sort,
            AddressFamily ipVersion,
            int tcpTableType = TCP_TABLE_OWNER_PID_ALL,
            int reserved = 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBuilder"> Using <see cref="QuerySelectors.IPv4"/> or <see cref="QuerySelectors.IPv6"/> to query tcp status.
        /// </param>
        /// <returns></returns>
        public static IReadOnlyList<ITcpConnection> Execute(IQuerySelector queryBuilder)
        {
            if (queryBuilder == null)
                throw new ArgumentNullException(nameof(queryBuilder));

            var result = new List<ITcpConnection>();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBuilder"> Using <see cref="QuerySelectors.IPv4"/> or <see cref="QuerySelectors.IPv6"/> to query tcp status.
        /// </param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IReadOnlyList<ITcpConnection> Execute(IQuerySelector queryBuilder, Predicate<ITcpConnection> filter)
        {
            if (queryBuilder == null)
                throw new ArgumentNullException(nameof(queryBuilder));
            if (filter == null)
                return Execute(queryBuilder);


            var result = new List<ITcpConnection>();
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
    }
}