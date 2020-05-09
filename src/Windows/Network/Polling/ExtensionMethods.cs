// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Network.Polling
{
    using System;
    using System.Diagnostics;

    public static class ExtensionMethods
    {
        public static Process GetProcess(this ITrafficRow row)
        {
            try
            {
                return Process.GetProcessById(row.Pid);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static IConnectionWatcher OnAdded(this IConnectionWatcher watcher, Action<ITrafficRow> onAdded)
        {
            if (onAdded is null) return watcher;

            watcher.ConnectionListChanged += (sender, e) => onAdded?.Invoke((e as ConnectionListAddedEventArgs).Added);
            return watcher;
        }

        public static IConnectionWatcher OnRemoved(this IConnectionWatcher watcher, Action<ITrafficRow> onRemoved)
        {
            if (onRemoved is null) return watcher;
            watcher.ConnectionListChanged += (sender, e) => onRemoved?.Invoke((e as ConnectionListRemovedEventArgs).Removed);
            return watcher;
        }

        public static IConnectionWatcher OnUpdated(this IConnectionWatcher watcher, Action<(ITrafficRow Origin, ITrafficRow Updated)> onUpdated)
        {
            if (onUpdated is null) return watcher;
            watcher.ConnectionListChanged += (sender, e) =>
            {
                var (org, upd) = e as ConnectionListUpdatedEventArgs;
                onUpdated?.Invoke((org, upd));
            };
            return watcher;
        }
    }
}