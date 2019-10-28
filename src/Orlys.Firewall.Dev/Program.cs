// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Dev
{
    using System;
    using System.Linq;
    using PollingServices;
    internal class Program
    {
        private static void Main(string[] args)
        {

            var opt = new PollingOptions<int>(
                PollingCycle.Create(x => {
                    var hz = TimeSpan.FromSeconds(1);
                    return x > 0 ? new TimeSpan(TimeSpan.FromSeconds(9).Ticks / x) + hz : hz;
                }),
                x => false
            );
            var polling = new Polling<int>(opt, Enumerable.Range(0,100));
            polling.Removed   += (s, e) => Console.WriteLine("Removed   " + e.Value);
            polling.Joined    += (s, e) => Console.WriteLine("Joined    " + e.Value);
            polling.Processed += (s, e) => Console.WriteLine("Processed " + e.Value);

            _ = polling.PollAsync();

            //Console.ReadKey();
            //for (int i = 0; i < 100; i++)
            //{
            //    polling.Join(i);
            //    Console.ReadKey();
            //}
            
            Console.ReadKey();
        }
    }
}

#if !dev

namespace Orlys.PollingServices
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

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

    public class PollingOptions<T>
    {
        public PollingOptions(PollingCycle cycle, PollingDecision<T> decision)
        {
            this.Cycle = cycle ?? throw new ArgumentNullException(nameof(cycle));
            this.Decision = decision ?? throw new ArgumentNullException(nameof(decision));
        }

        public PollingCycle Cycle { get; }

        public PollingDecision<T> Decision { get; }
    }

    public delegate bool PollingDecision<T>(T value);

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

        public event EventHandler<PollEventArgs<T>> Removed;

        public event EventHandler<PollEventArgs<T>> Joined;

        public event EventHandler<PollEventArgs<T>> Processed;

        public virtual bool Join(T value)
        {
            this._queue.Enqueue(value);
            this.Joined?.Invoke(this, new PollEventArgs<T>(value));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RemoveNotifier(T value)
        {
            this.Removed?.Invoke(this, new PollEventArgs<T>(value));
        }

        protected virtual void OnRemoved(object sender, PollEventArgs<T> e)
        {
        }

        protected virtual void OnJoined(object sender, PollEventArgs<T> e)
        {
        }

        protected virtual void OnProcessed(object sender, PollEventArgs<T> e)
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
                            this.Processed?.Invoke(this, new PollEventArgs<T>(current));
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

    public class PollEventArgs<T> : EventArgs
    {
        internal PollEventArgs(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }

    public sealed class IPPollEventArgs : PollEventArgs<IPAddress>
    {
        public IPPollEventArgs(IPAddress ip) : base(ip)
        {
        }
    }

    public class Poll : IDisposable
    {
        public uint Alive => (uint)this._queue.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<IPAddress> GetList()
        {
            return new HashSet<IPAddress>(
                from tcpConn in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections()
                where tcpConn.State == TcpState.Established && tcpConn.RemoteEndPoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                select tcpConn.RemoteEndPoint.Address);
        }

        private readonly Queue<IPAddress> _queue;

        private volatile bool _flag;

        public Poll()
        {
            this._queue = new Queue<IPAddress>();
            Dequeued += OnDequeued;
            Enqueued += OnEnqueued;
        }

        public event EventHandler<IPPollEventArgs> Dequeued;

        public event EventHandler<IPPollEventArgs> Enqueued;

        protected virtual void OnDequeued(object sender, IPPollEventArgs e)
        {
        }

        protected virtual void OnEnqueued(object sender, IPPollEventArgs e)
        {
        }

        public void Polling(TimeSpan interval)
        {
            this._flag = true;
            Task.Factory.StartNew(() =>
            {
                while (this._flag)
                {
                    var cycle = interval;
                    var ipg = GetList();
                    /*
                    if (this._queue.Count == 0)
                        goto LastBlock;
                    if (this._queue.Count == 1)
                    {
                        var single = this._queue.Peek();
                        if (!ipg.Contains(single))
                        {
                            this._queue.Dequeue();
                            Dequeued.Invoke(this, single);
                        }
                        goto LastBlock;
                    }*/

                    if (this._queue.Count > 0)
                    {
                        cycle = new TimeSpan(interval.Ticks / this._queue.Count);

                        var address = this._queue.Dequeue();
                        if (ipg.Contains(address))
                        {
                            this._queue.Enqueue(address);
                        }
                        else
                        {
                            // IP 不存在
                            Dequeued.Invoke(this, new IPPollEventArgs(address));
                        }
                    }
                    SpinWait.SpinUntil(() => !this._flag, cycle);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Join(IPAddress address)
        {
            if (this._queue.Contains(address))
                return;
            this._queue.Enqueue(address);
            Enqueued.Invoke(this, new IPPollEventArgs(address));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Press()
        {
            this._flag = false;
        }

        void IDisposable.Dispose()
        {
            this.Press();
        }
    }
}

#endif