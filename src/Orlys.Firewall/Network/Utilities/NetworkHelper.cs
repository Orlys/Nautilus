namespace Orlys.Network.Utilities
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class NetworkHelper
    {
        // https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetconnectedstate
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out ConnectedState Description, int ReservedValue = 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsConnectedToInternet(out ConnectedState state)
        {
            return InternetGetConnectedState(out state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsConnectedToInternet()
        {
            return InternetGetConnectedState(out _);
        }

        [Flags]
        public enum ConnectedState
        {
            Configured = 0x40,
            Lan = 0x2,
            Modem = 0x1,
            ModemBusy = 0x8,
            Offline = 0x20,
            Proxy = 0x4,
            RasInstalled = 0x10
        }
    }
}