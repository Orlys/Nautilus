// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;

    internal class PortRangeList : CommaSeparatedList<PortRange, ushort, PortRangeList> { }

    internal class IPAddressRangeList : CommaSeparatedList<IPAddressRange, IPAddress, IPAddressRangeList>
    {
        protected override IPAddressRange ParseSingleRange(string segment)
        {
            if (segment == "*")
            {
                return new IPAddressRange(IPAddress.IPv6Any, 0);
            }


            return base.ParseSingleRange(segment);
        }
    }

    internal class CommaSeparatedList<TFixedRange, TUnit, T> : ICollection<TFixedRange> where TFixedRange : IFixedRange<TUnit>
        where T : CommaSeparatedList<TFixedRange, TUnit, T>, new()
    {
        private readonly ConcurrentDictionary<TFixedRange, object> _list;
        private static readonly string[] s_comma = { "," };
         

        protected virtual TFixedRange ParseSingleRange(string segment)
        {
            var parsed = GenericParser<TFixedRange>.Parse(segment);
            return parsed;
        }

        public static T CreateFrom(string str)
        {
            var list = new T();
            if (string.IsNullOrWhiteSpace(str))
                return list;

            var segs = str.Split(s_comma, StringSplitOptions.RemoveEmptyEntries);

            foreach (var seg in segs)
            {
                var parsed = list.ParseSingleRange(seg);
                list.Add(parsed);
            }

            return list;
        }

        public override string ToString()
        {
            return string.Join(s_comma[default], this);
        }


        protected CommaSeparatedList()
        {
            this._list = new ConcurrentDictionary<TFixedRange, object>();
        }

        public void Add(TFixedRange range)
        {
            this._list.TryAdd(range, null);
        }

        public bool Remove(TFixedRange range)
        {
            var flag = this._list.TryRemove(range, out _); 
            return flag;
        }

        public void Clear()
        {
            this._list.Clear(); 
        }

        public bool Contains(TFixedRange item)
        {
            return this._list.ContainsKey(item);
        }

        public void CopyTo(TFixedRange[] array, int arrayIndex)
        {
            this._list.Keys.CopyTo(array, arrayIndex);
        }

        public int Count => this._list.Count;
        public bool IsReadOnly { get; }

        public IEnumerator<TFixedRange> GetEnumerator()
        {
            return this._list.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}