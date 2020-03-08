


namespace Nautilus.Windows.Network.Polling
{
    public static class Connection
    {
        private readonly static object s_lock = new object();
        private static volatile ConnectionWatcher s_instance;
        public static IConnectionWatcher Watcher
        {
            get
            {
                if (s_instance is null)
                {
                    lock (s_lock)
                    {
                        if (s_instance is null)
                        {
                            s_instance = new ConnectionWatcher(s_lock);
                        }
                    }
                }
                return s_instance;
            }
        }
        
    }
}