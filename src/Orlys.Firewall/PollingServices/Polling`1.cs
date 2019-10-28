namespace Orlys.PollingServices
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class Polling<T> : IDisposable
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly PollingOptions<T> _options;
        private bool _running;

        public Polling(PollingOptions<T> options) : this(options, null)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Polling(PollingOptions<T> options, IEnumerable<T> collection)
        {
            this._queue = collection is null ? new ConcurrentQueue<T>() : new ConcurrentQueue<T>(collection);
            this.Removed += this.OnRemoved;
            this.Joined += this.OnJoined;
            this.Processed += this.OnProcessed;
            this._options = options;
        }

        public event EventHandler<PollingEventArgs<T>> Removed;

        public event EventHandler<PollingEventArgs<T>> Joined;

        public event EventHandler<PollingEventArgs<T>> Processed;

        public virtual bool Join(T value)
        {
            this._queue.Enqueue(value);
            this.Joined?.Invoke(this, new PollingEventArgs<T>(value));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RemoveNotifier(T value)
        {
            this.Removed?.Invoke(this, new PollingEventArgs<T>(value));
        }

        protected virtual void OnRemoved(object sender, PollingEventArgs<T> e)
        {
        }

        protected virtual void OnJoined(object sender, PollingEventArgs<T> e)
        {
        }

        protected virtual void OnProcessed(object sender, PollingEventArgs<T> e)
        {
        }


        public async Task PollAsync()
        {
            this._running = true;
            await Task.Factory.StartNew(() =>
            {
                var timeSpan = default(TimeSpan);
                do
                {
                    this._options.Cycle.Adjust(this._queue.Count, out timeSpan);
                    Console.WriteLine("Cycle: " + timeSpan);
                    if (this._queue.TryDequeue(out var current))
                    {
                        if (this._options.Decision.Invoke(current))
                        {
                            this._queue.Enqueue(current);
                            this.Processed?.Invoke(this, new PollingEventArgs<T>(current));
                        }
                        else
                            this.RemoveNotifier(current);
                    }
                }
                while (!SpinWait.SpinUntil(() => !this._running, timeSpan));
            }, TaskCreationOptions.LongRunning);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Suspend()
        {
            this._running = false;
        }

        public void Dispose()
        {
            this.Suspend();
        }

        public static Polling<T> operator +(Polling<T> polling, T value)
        {
            polling.Join(value);
            return polling;
        }

        public static Polling<T> operator -(Polling<T> polling, T value)
        {
            for (int i = 0; i < polling._queue.Count; i++)
            {
                if (polling._queue.TryDequeue(out var peek))
                {
                    if ((value is IEquatable<T> eq && eq.Equals(peek)) ||
                        value.Equals(peek) ||
                        ReferenceEquals(peek, value))
                    {
                        polling.RemoveNotifier(peek);
                        break;
                    }
                    else
                        polling._queue.Enqueue(peek);
                }
                else
                    break;
            }
            return polling;
        }
    }
}

