// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Network.Polling
{
    using System;

    public delegate void NotifyConnectionListChangedEventHandler(object sender, ConnectionListChangedEventArgsBase e);

    public sealed class ConnectionListAddedEventArgs : ConnectionListChangedEventArgsBase
    {
        public ITrafficRow Added { get; }

        internal ConnectionListAddedEventArgs()
        {
        }

        internal ConnectionListAddedEventArgs(ITrafficRow added)
        {
            this.Added = added;
        }
    }

    public abstract class ConnectionListChangedEventArgsBase : EventArgs
    {
        protected ConnectionListChangedEventArgsBase()
        {
        }
    }

    public sealed class ConnectionListRemovedEventArgs : ConnectionListChangedEventArgsBase
    {
        public ITrafficRow Removed { get; }

        internal ConnectionListRemovedEventArgs()
        {
        }

        internal ConnectionListRemovedEventArgs(ITrafficRow removed)
        {
            this.Removed = removed;
        }
    }

    public sealed class ConnectionListUpdatedEventArgs : ConnectionListChangedEventArgsBase
    {
        public ITrafficRow Origin { get; }

        public ITrafficRow Updated { get; }

        internal ConnectionListUpdatedEventArgs()
        {
        }

        internal ConnectionListUpdatedEventArgs(ITrafficRow origin, ITrafficRow updated)
        {
            this.Origin = origin;
            this.Updated = updated;
        }

        public void Deconstruct(out ITrafficRow origin, out ITrafficRow updated)
        {
            origin = this.Origin;
            updated = this.Updated;
        }
    }
}