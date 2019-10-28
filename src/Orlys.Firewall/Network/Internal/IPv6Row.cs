// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network.Internal
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Runtime.InteropServices;

    // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcp6row_owner_pid
    [StructLayout(LayoutKind.Sequential)]
    internal struct IPv6Row : IRowAdaptable
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] _localAddr;

        private uint _localScopeId;

        private byte _localPort1;
        private byte _localPort0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("unused field", true)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] __localPortDummy;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] _remoteAddr;

        private uint _remoteScopeId;

        private byte _remotePort1;
        private byte _remotePort0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("unused field", true)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] __remotePortDummy;

        private uint _state;
        private uint _owningPid;

        RowAdapter IRowAdaptable.ToRowAdapter()
        {
            var local = new IPEndPoint(
                new IPAddress(this._localAddr, this._localScopeId),
                BitConverter.ToUInt16(new byte[2] { this._localPort0, this._localPort1 }, 0));

            var remote = new IPEndPoint(
                new IPAddress(this._remoteAddr, this._remoteScopeId),
                BitConverter.ToUInt16(new byte[2] { this._remotePort0, this._remotePort1 }, 0));

            return new RowAdapter(local, remote, this._state, this._owningPid);
        }
    }
}