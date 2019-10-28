namespace Orlys.PollingServices
{
    using System;

    public class PollingEventArgs<T> : EventArgs
    {
        internal PollingEventArgs(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}

