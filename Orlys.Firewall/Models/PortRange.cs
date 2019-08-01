
namespace Orlys.Firewall.Models
{
    using Orlys.Firewall.Collections;
    using System;
    using System.Collections.Generic;

    public sealed class PortRange : IFixedRange<ushort> , IEquatable<PortRange>
    { 
        public ushort Begin { get; }

        public ushort End { get; }

        private readonly bool _isSinglePort;

        public PortRange(ushort first, ushort second)
        {
            if (first > second)
            {
                first ^= second ^= first ^= second;
            }

            this.Begin = first;
            this.End = second;
            this._isSinglePort = this.Begin == this.End;
        }

        public PortRange(ushort singlePort) : this(singlePort, singlePort)
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

        public bool Contains(PortRange range)
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

            if (this.Begin == 0 && this.End == 65535)
                return "*";
            return string.Format("{0}-{1}", this.Begin, this.End);
        }

        public static bool TryParse(string rangeString, out PortRange range)
        {
            range = null;
            if (string.IsNullOrWhiteSpace(rangeString))
                return false;
             
            var from = -1;
            var to = default(int);
            for (int i = 0; i < rangeString.Length; i++)
            {
                var c = rangeString[i];
                if(c == '*')
                {
                    range = All;
                    return true;
                }
                else if (c >= '0' && c <= '9')
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
                    return false;
            }

            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                range = new PortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    return false;
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    return false;

                if (from > to)
                    from ^= to ^= from ^= to;
                range = new PortRange((ushort)from, (ushort)to);
            }
            return true;
        }

        public readonly static PortRange All = new PortRange(0, 65535);

        public static PortRange Parse(string rangeString)
        {
            if (string.IsNullOrWhiteSpace(rangeString))
                throw new ArgumentNullException(nameof(rangeString));
            var from = -1;
            var to = default(int);
            for (int i = 0; i < rangeString.Length; i++)
            {
                var c = rangeString[i];
                if (c == '*')
                {
                    return All;
                }
                else if (c >= '0' && c <= '9')
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
                    throw new FormatException($"Format error: '{rangeString}'");
            }

            var range = default(PortRange);
            if (from == -1)
            {
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("single");

                range = new PortRange((ushort)to);
            }
            else
            {
                if (from > ushort.MaxValue || from < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("first");
                if (to > ushort.MaxValue || to < ushort.MinValue)
                    throw new ArgumentOutOfRangeException("sencond");

                if (from > to)
                    range = new PortRange((ushort)to, (ushort)from);
                else
                    range = new PortRange((ushort)from, (ushort)to);
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

        public static implicit operator PortRange(ushort port)
        {
            return new PortRange(port);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is PortRange fp)
            {
                return this.Equals(fp);
            }
            return false;
        }

        public bool Equals(PortRange range)
        {
            return this.GetHashCode() == range.GetHashCode();
        }
    }
} 