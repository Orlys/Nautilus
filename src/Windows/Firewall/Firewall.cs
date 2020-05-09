// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Firewall
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;

    public static class Firewall
    {
        private static readonly object s_lock = new object();
        private static volatile FirewallController s_controller;

        /// <summary>
        /// Gets the singleton firewall controller.
        /// </summary>
        /// <exception cref="SecurityException"/>
        [Summary("Gets the singleton firewall controller.")]
        [Exception(typeof(SecurityException))]
        public static IFirewallController Controller
        {
            get
            {
                if (!RunningAsAdmin())
                    throw new SecurityException("You should running in administrator permission.");

                if (s_controller is null)
                    lock (s_lock)
                        if (s_controller is null)
                            s_controller = new FirewallController();
                return s_controller;
            }
        }

        [DllImport("libc")]
        private static extern uint getuid(); // Only used on Linux but causes no issues on Windows

        private static bool RunningAsAdmin()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using var identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return getuid() == 0;
            else
                throw new PlatformNotSupportedException();
        }
    }
}