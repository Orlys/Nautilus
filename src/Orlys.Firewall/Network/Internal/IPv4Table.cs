namespace Orlys.Network.Internal
{
    using System.Runtime.InteropServices;

    // https://docs.microsoft.com/en-us/windows/win32/api/tcpmib/ns-tcpmib-mib_tcptable_owner_pid
    [StructLayout(LayoutKind.Sequential)]
    internal struct IPv4Table
    {
        internal uint dwNumEntries;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
        internal IPv4Row[] table;
    }

}
