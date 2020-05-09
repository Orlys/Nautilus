// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Network.Polling
{
    using Iridium.Callee;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class ConnectionWatcher : IConnectionWatcher
    {
        private readonly HashSet<ITrafficRow> _holded;

        private readonly object _lock;

        private CancellationTokenSource _cts;

        private volatile bool _running;

        public event NotifyConnectionListChangedEventHandler ConnectionListChanged;

        public bool IsRunning
        {
            get
            {
                lock (_lock)
                {
                    return this._running;
                }
            }
        }

        internal ConnectionWatcher(object @lock)
        {
            CalleeChecker.Allow(typeof(Connection));

            this._holded = EnumerateConnections().ToHashSet();
            this._running = false;
            this._lock = @lock;
        }

        public bool Start(TimeSpan period)
        {
            if (this._running)
                return false;

            lock (_lock)
            {
                if (this._running)
                    return false;

                this._running = true;

                this._cts = new CancellationTokenSource();

                Task.Run(async () =>
                {
                    while (!this._cts.Token.IsCancellationRequested)
                    {
                        await Task.Delay(period, this._cts.Token);
                        lock (this._holded)
                        {
                            var current = EnumerateConnections().ToArray();

                            var removedRows = this._holded.Except(current).ToArray();
                            foreach (var row in removedRows)
                            {
                                if (this._holded.Remove(row))
                                {
                                    this.ConnectionListChanged?.Invoke(this, new ConnectionListRemovedEventArgs(row));
                                }
                            }

                            foreach (var row in current)
                            {
                                if (this._holded.Add(row))
                                {
                                    this.ConnectionListChanged?.Invoke(this, new ConnectionListAddedEventArgs(row));
                                }
                                else if (this._holded.TryGetValue(row, out var origin) && !row.State.Equals(origin.State))
                                {
                                    this.ConnectionListChanged?.Invoke(this, new ConnectionListUpdatedEventArgs(origin, row));
                                    ((IEditableTrafficRow)origin).State = row.State;
                                }
                            }
                        }
                    }
                    this._running = false;
                }, this._cts.Token);
                return true;
            }
        }

        public void Stop()
        {
            if (!this._running)
                return;

            lock (_lock)
            {
                if (!this._running)
                    return;

                this._cts.Cancel(false);
                this._cts.Dispose();
                this._running = false;
                this._holded.Clear();
            }
        }

        private static IEnumerable<ITrafficRow> EnumerateConnections()
        {
            foreach (var row in QueryExecutor.Execute(QueryBy.IPv4))
                yield return row;
            foreach (var row in QueryExecutor.Execute(QueryBy.IPv6))
                yield return row;
        }
    }
}