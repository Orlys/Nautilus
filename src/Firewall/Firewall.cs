// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;

    public static class Firewall
    { 
        static Firewall()
        {
            EnsureFirewallControllerCanCreate();
        }
         
        private static void EnsureFirewallControllerCanCreate()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using (var identity = WindowsIdentity.GetCurrent())
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    if(!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        throw new SecurityException("You should running in administrator permission.");
                    }

                    return;
                }
            }

            throw new PlatformNotSupportedException();
        }


        /// <summary>
        /// Gets the firewall service from advance firewall rule list.
        /// </summary> 
        public static IFirewallService GetService(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return new FirewallServiceImpl(name);
        }
    }
}