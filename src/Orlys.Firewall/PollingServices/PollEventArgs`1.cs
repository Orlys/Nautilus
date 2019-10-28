namespace Orlys.PollingServices
{
    using System;

    public class PollEventArgs<T> : EventArgs
    {
        internal PollEventArgs(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}

