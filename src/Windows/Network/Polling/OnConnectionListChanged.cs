


namespace Nautilus.Windows.Network.Polling
{
    using System;

    public delegate void NotifyConnectionListChangedEventHandler(object sender, ConnectionListChangedEventArgsBase e);

    public abstract class ConnectionListChangedEventArgsBase : EventArgs
    {
        protected ConnectionListChangedEventArgsBase()
        { 
        } 
    }


    public sealed class ConnectionListUpdatedEventArgs : ConnectionListChangedEventArgsBase
    {
        internal ConnectionListUpdatedEventArgs()
        {

        }

        internal ConnectionListUpdatedEventArgs(ITrafficRow origin, ITrafficRow updated)
        {
            this.Origin = origin;
            this.Updated = updated;
        }

        public ITrafficRow Origin { get; }
        public ITrafficRow Updated { get; }

        public   void Deconstruct(out ITrafficRow origin, out ITrafficRow updated)
        {
            origin = this.Origin;
            updated = this.Updated;
        }
    }

    public sealed class ConnectionListAddedEventArgs : ConnectionListChangedEventArgsBase
    {
        internal ConnectionListAddedEventArgs()
        {

        }
        internal ConnectionListAddedEventArgs(ITrafficRow added)
        {
            this.Added = added;
        }

        public ITrafficRow Added { get; }
    }
    public sealed class ConnectionListRemovedEventArgs : ConnectionListChangedEventArgsBase
    {
        internal ConnectionListRemovedEventArgs()
        {

        }
        internal ConnectionListRemovedEventArgs(ITrafficRow removed)
        {
            this.Removed = removed;
        }

        public ITrafficRow Removed { get; }
    }

}
