// Author: Orlys
// Github: https://github.com/Orlys

namespace System.Net
{
    using Nautilus;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    [Serializable]
    public class PortRange : IFixedRange<ushort>, IEquatable<PortRange>
    {
        private readonly bool _isSinglePort;
        private readonly SpecificLocalPort? _specificLocalPort;
        public ushort Begin { get; }
        public ushort End { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected PortRange(SerializationInfo info, StreamingContext context)
        {
            var names = new List<string>();
            foreach (var item in info) names.Add(item.Name);

            Func<string, ushort> deserialize = (name) => names.Contains(name) ?
                 ushort.Parse(info.GetValue(name, typeof(object)).ToString()) :
                 (ushort)0;

            this.Begin = deserialize(nameof(Begin));
            this.End = deserialize(nameof(End));
            this._specificLocalPort = info.GetValue(nameof(SpecificLocalPort), typeof(string)) is string lp
                ? (SpecificLocalPort)Enum.Parse(typeof(SpecificLocalPort), lp)
                : default(SpecificLocalPort?);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(Begin), this.Begin.ToString());
            info.AddValue(nameof(End), this.End.ToString());
            info.AddValue(nameof(SpecificLocalPort), this._specificLocalPort?.ToString());
        }


        public PortRange(SpecificLocalPort specificLocalPort)
        {
            this._specificLocalPort = specificLocalPort;
        }

        public PortRange(ushort first, ushort second)
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
            this._specificLocalPort = null;
        }

        public PortRange(ushort singlePort) : this(singlePort, singlePort)
        {
        }

        public static implicit operator PortRange(SpecificLocalPort specificLocalPort)
        {
            return new PortRange(specificLocalPort);
        }

        public static implicit operator PortRange(ushort port)
        {
            return new PortRange(port);
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
                    if (TryParseSpecificLocalPort(rangeString, out var sp))
                    {
                        range = new PortRange(sp.Value);
                        return true;
                    }
                    return false;
                }
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

        public bool Contains(ushort port)
        {
            if (this._specificLocalPort.HasValue)
                return false;

            if (this._isSinglePort)
            {
                return port == this.Begin;
            }
            return this.Begin <= port && this.End >= port;
        }

        public bool Contains(PortRange range)
        {
            if (this._specificLocalPort.HasValue)
                return this.Equals(range);

            if (range._isSinglePort)
            {
                return range.Begin == this.Begin;
            }
            return this.Begin <= range.Begin && this.End >= range.End;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PortRange);
        }

        public bool Equals(PortRange range)
        {
            if (this._specificLocalPort.HasValue)
                return this._specificLocalPort.Equals(range._specificLocalPort);

            return this.GetHashCode() == range.GetHashCode();
        }

        public IEnumerator<ushort> GetEnumerator()
        {
            if (this._specificLocalPort.HasValue)
                yield break;

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

        public override string ToString()
        {
            if (this._specificLocalPort.HasValue)
                return this._specificLocalPort.ToString();

            if (this._isSinglePort)
                return this.Begin.ToString();

            return string.Format("{0}-{1}", this.Begin, this.End);
        }

        private static bool TryParseSpecificLocalPort(string value, out SpecificLocalPort? specific)
        {
            switch (value)
            {
                case "RPC": specific = SpecificLocalPort.RPC; return true;
                case "RPC-EPMap": specific = SpecificLocalPort.RPC_EPMap; return true;
                case "IPHTTPS": specific = SpecificLocalPort.IPHTTPS; return true;

                default: specific = null; return false;
            }
        }
    }
}