﻿// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network.Internal
{
    using System.Runtime.InteropServices;

    // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcptable_owner_pid
    [StructLayout(LayoutKind.Sequential)]
    internal struct IPv4Table
    {
        private uint _dwNumEntries;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        private IPv4Row[] _table;
    }
}