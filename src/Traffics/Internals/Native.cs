// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    internal static class Native
    {

        // https://docs.microsoft.com/zh-tw/windows/win32/api/iprtrmib/ne-iprtrmib-tcp_table_class
        private const int TCP_TABLE_OWNER_PID_ALL = 5;
        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern uint GetExtendedTcpTable(
            IntPtr tcpTable,
            ref int tcpTableLength,
            bool sort,
            AddressFamily ipVersion,
            int tcpTableType = TCP_TABLE_OWNER_PID_ALL,
            int reserved = 0);

        // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcptable_owner_pid
        [StructLayout(LayoutKind.Sequential)]
        public struct IPv4Table : ITcpTableContract
        {
            private uint _dwNumEntries;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
            private IPv4Row[] _table;
        }
        // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcprow_owner_pid
        [StructLayout(LayoutKind.Sequential)]
        public partial struct IPv4Row 
        {
            private uint _state;

            private uint _localAddr;

            private byte _localPort1;
            private byte _localPort0;

            [Obsolete("unused field", true)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] __localPortDummy;

            private uint _remoteAddr;

            private byte _remotePort1;
            private byte _remotePort0;

            [Obsolete("unused field", true)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] __remotePortDummy;

            private uint _owningPid;

            
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcp6table_owner_pid
        [StructLayout(LayoutKind.Sequential)]
        public struct IPv6Table : ITcpTableContract
        {
            private uint _dwNumEntries;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
            private IPv6Row[] _table;
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcp6row_owner_pid
        [StructLayout(LayoutKind.Sequential)]
        public partial struct IPv6Row : ITcpRowContract
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            private byte[] _localAddr;

            private uint _localScopeId;

            private byte _localPort1;
            private byte _localPort0;

            [Obsolete("unused field", true)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] __localPortDummy;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            private byte[] _remoteAddr;

            private uint _remoteScopeId;

            private byte _remotePort1;
            private byte _remotePort0;

            [Obsolete("unused field", true)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            private byte[] __remotePortDummy;

            private uint _state;
            private uint _owningPid; 
        }



        public partial struct IPv6Row : ITcpRowContract
        {
            TcpTrafficRow ITcpRowContract.ToRow()
            {
                var local = new IPEndPoint(
                    new IPAddress(this._localAddr, this._localScopeId),
                    (ushort)(this._remotePort0 + (this._remotePort1 << 8)));

                var remote = new IPEndPoint(
                    new IPAddress(this._remoteAddr, this._remoteScopeId),
                    (ushort)(this._remotePort0 + (this._remotePort1 << 8)));

                return new TcpTrafficRow(local, remote, this._state, this._owningPid);
            }
        }
        public partial struct IPv4Row : ITcpRowContract
        {
            TcpTrafficRow ITcpRowContract.ToRow()
            {
                var local = new IPEndPoint(
                    new IPAddress(this._localAddr),
                    (ushort)(this._remotePort0 + (this._remotePort1 << 8)));

                var remote = new IPEndPoint(
                    new IPAddress(this._remoteAddr),
                    (ushort)(this._remotePort0 + (this._remotePort1 << 8)));

                return new TcpTrafficRow(local, remote, this._state, this._owningPid);
            }
        }
    }
}