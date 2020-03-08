

namespace Nautilus.Windows.Firewall
{
    public static class Firewall
    {
        private static readonly object s_lock = new object();
        private static volatile FirewallController s_controller;
        /// <summary>
        /// Gets the singleton firewall controller.
        /// </summary>
        public static IFirewallController Controller
        {
            get
            {
                if (s_controller is null)
                    lock (s_lock)
                        if (s_controller is null)
                            s_controller = new FirewallController();
                return s_controller;
            }
        }

    }
}

