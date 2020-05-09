// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Network.Polling
{
    using System;

    public interface IConnectionWatcher
    {
        event NotifyConnectionListChangedEventHandler ConnectionListChanged;

        bool IsRunning { get; }

        bool Start(TimeSpan period);

        void Stop();
    }
}