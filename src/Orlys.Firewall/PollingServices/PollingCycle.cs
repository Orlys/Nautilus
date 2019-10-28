namespace Orlys.PollingServices
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class PollingCycle
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public delegate TimeSpan Builder(int queueCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PollingCycle Fixed(TimeSpan cycle)
        {
            return Create(x => cycle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PollingCycle Dynamically(TimeSpan maxCycle)
        {
            return Create(x => x > 0 ? new TimeSpan(maxCycle.Ticks / x) : maxCycle);
        }

        public static PollingCycle Create(Builder builder)
        {
            return new PollingCycleImpl(builder);
        }

        private sealed class PollingCycleImpl : PollingCycle
        {
            private readonly Builder _delegate;

            internal PollingCycleImpl(Builder @delegate)
            {
                this._delegate = @delegate;
            }

            protected override void AdjustCore(int count, out TimeSpan cycle) => cycle = this._delegate(count);
        }

        protected abstract void AdjustCore(int count, out TimeSpan cycle);

        [DebuggerNonUserCode]
        internal void Adjust(int count, out TimeSpan cycle)
        {
            this.AdjustCore(count, out cycle);
            if (cycle == Timeout.InfiniteTimeSpan)
                throw new ArgumentOutOfRangeException("cycle", "Cycle can't be infinite.");
        }
    }
}

