namespace Orlys.PollingServices
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IAddMethodHide<T> : IEnumerable<T>
    {
        void Add(T item);
    }

    public class Polling<T> : IReadOnlyCollection<T>, IAddMethodHide<T>, IDisposable
    {
        private readonly ConcurrentQueue<T> _queue;
        private readonly PollingOptions<T> _options;
        private bool _running;

        public Polling(PollingOptions<T> options)
        { 
            this._queue = new ConcurrentQueue<T>();
            this.Detached += this.OnDetached;
            this.Attached += this.OnAttached;
            this.Pushbacked += this.OnPushbacked;
            this._options = options;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(T item)
        {
            this.Attach(item);
        }

        public event EventHandler<PollingEventArgs<T>> Detached;

        public event EventHandler<PollingEventArgs<T>> Attached;

        public event EventHandler<PollingEventArgs<T>> Pushbacked;

        public virtual bool Attach(T item)
        {
            this._queue.Enqueue(item);
            this.Attached?.Invoke(this, new PollingEventArgs<T>(item));
            return true;
        }

        protected virtual bool Detach(out T item)
        {
            var result = this._queue.TryDequeue(out item);
            if (result)
            {
                this.Detached?.Invoke(this, new PollingEventArgs<T>(item));
            }
            return result;
        }

        protected virtual void OnDetached(object sender, PollingEventArgs<T> e)
        {
        }

        protected virtual void OnAttached(object sender, PollingEventArgs<T> e)
        {
        }

        protected virtual void OnPushbacked(object sender, PollingEventArgs<T> e)
        {
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void BeforeMoveNext()
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool MoveNext(out T item)
        {
            return this._queue.TryDequeue(out item);
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
                    if (this.MoveNext(out var current))
                    {
                        if (this._options.Decision.Invoke(current))
                        {
                            this._queue.Enqueue(current);
                            this.Pushbacked?.Invoke(this, new PollingEventArgs<T>(current));
                        }
                        else
                            this.Detached?.Invoke(this, new PollingEventArgs<T>(current));

                        this.BeforeMoveNext();
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

        public int Count => this._queue.Count;

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => this._queue.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this._queue.GetEnumerator();
    }
}

