
namespace Nautilus.Windows.Network.Polling
{
    using System;

    public interface IConnectionWatcher
    {
        bool IsRunning { get; }

        event NotifyConnectionListChangedEventHandler ConnectionListChanged;

        bool Start(TimeSpan period);
        void Stop();
    }

}