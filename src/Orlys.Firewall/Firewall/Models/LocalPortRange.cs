// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Models
{
    using Orlys.Firewall.Collections;
    using Orlys.Firewall.Internal.Visualizers;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public enum SpecificPort : byte
    {
        RPC,
        RPC_EPMap,
        IPHTTPS
    }

    [DefaultValue(null)]
    [DebuggerTypeProxy(typeof(InternalRangeTypeVisualizer))]
    public sealed class LocalPortRange : IFixedRange<ushort>, IEquatable<LocalPortRange>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort Begin { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ushort End { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly bool _isSinglePort;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public readonly SpecificPort? SpecificPort;

        private LocalPortRange(SpecificPort specificPort)
        {
            this.SpecificPort = specificPort;
        }

        public LocalPortRange(ushort first, ushort second)
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

        public LocalPortRange(ushort singlePort) : this(singlePort, singlePort)
        {
        }

        public bool Contains(ushort port)
        {
            if (this.SpecificPort.HasValue)
                return false;

            if (this._isSinglePort)
            {
                return port == this.Begin;
            }
            return this.Begin <= port && this.End >= port;
        }

        public bool Contains(LocalPortRange range)
        {
            if (this.SpecificPort.HasValue)
                return false;

            if (range._isSinglePort)
            {
                return range.Begin == this.Begin;
            }
            return this.Begin <= range.Begin && this.End >= range.End;
        }

        public override string ToString()
        {
            if (this.SpecificPort.HasValue)
                return this.SpecificPort.Value.ToString();

            if (this._isSinglePort)
                return this.Begin.ToString();

            return string.Format("{0}-{1}", this.Begin, this.End);
        }

        private static bool TryParseSpecific(string value, out SpecificPort? specific)
        {
            switch (value)
            {
                case "RPC": specific = Models.SpecificPort.RPC; return true;
                case "RPC-EPMap": specific = Models.SpecificPort.RPC_EPMap; return true;
                case "IPHTTPS": specific = Models.SpecificPort.IPHTTPS; return true;

                default: specific = null; return false;
            }
        }

        public static bool TryParse(string rangeString, out LocalPortRange range)
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
                    if (TryParseSpecific(rangeString, out var sp))
                    {
                        range = new LocalPortRange(sp.Value);
                        return true;
                    }
                    return false;
                }
            }

            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                range = new LocalPortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    return false;
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                if (from > to)
                    from ^= to ^= from ^= to;
                range = new LocalPortRange((ushort)from, (ushort)to);
            }
            return true;
        }

        public static LocalPortRange Parse(string rangeString)
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
                    if (TryParseSpecific(rangeString, out var sp))
                    {
                        return new LocalPortRange(sp.Value);
                    }
                    throw new FormatException($"Format error: '{rangeString}'");
                }
            }

            var range = default(LocalPortRange);
            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("single");

                range = new LocalPortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("first");
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("sencond");

                if (from > to)
                    range = new LocalPortRange((ushort)to, (ushort)from);
                else
                    range = new LocalPortRange((ushort)from, (ushort)to);
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
            if (obj is LocalPortRange fp)
            {
                return this.Equals(fp);
            }
            return false;
        }

        public bool Equals(LocalPortRange range)
        {
            return this.GetHashCode() == range.GetHashCode();
        }

        public static explicit operator LocalPortRange(string str)
        {
            if (TryParse(str, out var v))
                return v;
            throw new FormatException();
        }

        public static implicit operator LocalPortRange(SpecificPort specific)
        {
            return new LocalPortRange(specific);
        }

        public static implicit operator LocalPortRange(ushort port)
        {
            return new LocalPortRange(port);
        }

        public static explicit operator RemotePortRange(LocalPortRange range)
        {
            if (range.SpecificPort.HasValue)
            {
                throw new InvalidCastException();
            }

            return new RemotePortRange(range.Begin, range.End);
        }
    }
}