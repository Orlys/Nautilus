﻿// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network.Internal
{
    using System;
    using System.Net;
    using System.Runtime.InteropServices;

    // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcprow_owner_pid
    [StructLayout(LayoutKind.Sequential)]
    internal struct IPv4Row : IRowAdaptable
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

        RowAdapter IRowAdaptable.ToRowAdapter()
        {
            var local = new IPEndPoint(
                new IPAddress(this._localAddr),
                BitConverter.ToUInt16(new byte[2] { this._localPort0, this._localPort1 }, 0));

            var remote = new IPEndPoint(
                new IPAddress(this._remoteAddr),
                BitConverter.ToUInt16(new byte[2] { this._remotePort0, this._remotePort1 }, 0));

            return new RowAdapter(local, remote, this._state, this._owningPid);
        }
    }
}