
namespace Orlys.Firewall.Models
{
    using Orlys.Firewall.Collections;
    using Orlys.Firewall.Internal.Visualizers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [DefaultValue(null)]
    [DebuggerTypeProxy(typeof(InternalRangeTypeVisualizer))]
    public sealed class RemotePortRange : IFixedRange<ushort>, IEquatable<RemotePortRange>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort Begin { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort End { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly bool _isSinglePort;


        public RemotePortRange(ushort first, ushort second)
        {
            if (first > second)
            {
                this.Begin = second;
                this.End = first;
            }
            else
            {
                this.Begin = first;
                this.End = second;
            }
            this._isSinglePort = this.Begin == this.End;
        }

        public RemotePortRange(ushort singlePort) : this(singlePort, singlePort)
        {
        }

        public bool Contains(ushort port)
        {
            if (this._isSinglePort)
            {
                return port == this.Begin;
            }
            return this.Begin <= port && this.End >= port;
        }

        public bool Contains(RemotePortRange range)
        {
            if (range._isSinglePort)
            {
                return range.Begin == this.Begin;
            }
            return this.Begin <= range.Begin && this.End >= range.End;
        }

        public override string ToString()
        {

            if (this._isSinglePort)
                return this.Begin.ToString();

            return string.Format("{0}-{1}", this.Begin, this.End);
        }


        public static bool TryParse(string rangeString, out RemotePortRange range)
        {
            range = null;
            if (string.IsNullOrWhiteSpace(rangeString))
                return false;

            var from = -1;
            var to = default(int);
            for (int i = 0; i < rangeString.Length; i++)
            {
                var c = rangeString[i];
                if (c >= '0' && c <= '9')
                {
                    to = to * 10 + (c - '0');
                }
                else if (c == '-' && to >= 0 && from == -1)
                {
                    from = to;
                    to ^= to;
                }
                else if (char.IsWhiteSpace(c))
                    continue;
                else
                {
                    return false;
                }
            }

            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                range = new RemotePortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    return false;
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                if (from > to)
                    from ^= to ^= from ^= to;
                range = new RemotePortRange((ushort)from, (ushort)to);
            }
            return true;
        }


        public static RemotePortRange Parse(string rangeString)
        {
            if (string.IsNullOrWhiteSpace(rangeString))
                throw new ArgumentNullException(nameof(rangeString));
            var from = -1;
            var to = default(int);
            for (int i = 0; i < rangeString.Length; i++)
            {
                var c = rangeString[i];
                if (c >= '0' && c <= '9')
                {
                    to = to * 10 + (c - '0');
                }
                else if (c == '-' && to >= 0 && from == -1)
                {
                    from = to;
                    to ^= to;
                }
                else if (char.IsWhiteSpace(c))
                    continue;
                else
                {
                    throw new FormatException($"Format error: '{rangeString}'");
                }
            }

            var range = default(RemotePortRange);
            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("single");

                range = new RemotePortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("first");
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("sencond");

                if (from > to)
                    range = new RemotePortRange((ushort)to, (ushort)from);
                else
                    range = new RemotePortRange((ushort)from, (ushort)to);
            }
            return range;
        }

        public IEnumerator<ushort> GetEnumerator()
        {
            if (this._isSinglePort)
            {
                yield return this.Begin;
                yield break;
            }

            for (ushort i = this.Begin; i < this.End; i++)
                yield return i;
            yield return this.End;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is RemotePortRange fp)
            {
                return this.Equals(fp);
            }
            return false;
        }

        public bool Equals(RemotePortRange range)
        {
            return this.GetHashCode() == range.GetHashCode();
        }

        public static explicit operator RemotePortRange(string str)
        {
            if (TryParse(str, out var v))
                return v;
            throw new FormatException();
        }

        public static implicit operator RemotePortRange(ushort port)
        {
            return new RemotePortRange(port);
        }

        public static implicit operator LocalPortRange(RemotePortRange range)
        { 
            return new LocalPortRange(range.Begin, range.End);
        }
    }
} 