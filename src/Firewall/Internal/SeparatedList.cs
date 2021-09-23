// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;



    internal class SeparatedList<T> : IList<T>
    {
        private delegate bool TryParseDelegate(string s, out T result);

        private static TryParseDelegate s_deleCache;


        private readonly List<T> _list;
        private readonly object _lock = new object();
        private readonly string _separator;

        public event EventHandler ListChanged;

        public int Count
        {
            get
            {
                lock (this._lock)
                    return _list.Count;
            }
        }

        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get
            {
                lock (this._lock)
                {
                    return _list[index];
                }
            }
            set
            {
                lock (this._lock)
                {
                    _list[index] = value;
                    this.ListChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public SeparatedList(string value, string separator)
        {
            this._separator = separator;
            this._list = new List<T>();

            if (string.IsNullOrWhiteSpace(value))
                return;

            var parser = GetParser();
            var vSegs = value.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var vSeg in vSegs)
            {
                if (parser(vSeg, out var v))
                    this._list.Add(v);
            }
        }

        public virtual void Add(T value)
        {
            lock (this._lock)
            {
                this._list.Add(value);
                this.ListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public virtual void Clear()
        {
            lock (this._lock)
            {
                _list.Clear();
                this.ListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Contains(T item)
        {
            lock (this._lock)
                return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (this._lock)
                _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (this._lock)
                return ((IEnumerable<T>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (this._lock)
                return ((IEnumerable<T>)_list).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            lock (this._lock)
                return _list.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            lock (this._lock)
            {
                _list.Insert(index, item);
                this.ListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string Reduce()
        {
            lock (this._lock)
                return string.Join(this._separator, this);
        }

        public virtual bool Remove(T value)
        {
            lock (this._lock)
            {
                var v = this._list.Remove(value);
                if (v)
                    this.ListChanged?.Invoke(this, EventArgs.Empty);
                return v;
            }
        }

        public virtual void RemoveAt(int index)
        {
            lock (this._lock)
            {
                _list.RemoveAt(index);
                this.ListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return this.Reduce();
        }

        private static TryParseDelegate GetParser()
        {
            if (s_deleCache != null)
                return s_deleCache;

            var type = typeof(T);
            var s = Expression.Parameter(typeof(string));
            var refType = type.MakeByRefType();
            var result = Expression.Parameter(refType);
            var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static, null, new[] { s.Type, refType }, null);

            if (tryParseMethod == null)
                throw new MissingMethodException(type.FullName, "TryParse");

            var caller = Expression.Call(tryParseMethod, s, result) as Expression;
            s_deleCache = Expression.Lambda<TryParseDelegate>(caller, s, result).Compile();
            return s_deleCache;
        }
    }
}