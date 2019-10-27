// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Collections
{
    using Orlys.Firewall.Internal.Visualizers;
    using Orlys.Firewall.Internal.ExpressionCache;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;

    [DebuggerDisplay("{_debugString}")]
    [DebuggerTypeProxy(typeof(InternalListVisualizer<>))]
    public class SeparatedList<T> : IReadOnlyCollection<T> where T : IEquatable<T>
    {
        private string _debugString => this.ToString();

        public class HydraBuilder
        {
            protected readonly string[] Separator;

            public HydraBuilder(string separator)
            {
                if (separator == null)
                    throw new ArgumentNullException(nameof(separator));

                this.Separator = new string[1] { separator };
            }

            protected internal virtual string[] Split(string payload)
            {
                if (string.IsNullOrWhiteSpace(payload))
                    return null;
                return payload.Split(this.Separator, StringSplitOptions.RemoveEmptyEntries);
            }

            protected internal virtual string Join(IEnumerable<T> payload)
            {
                return string.Join(this.Separator[0], payload);
            }
        }

        public event Action<string> OnStringUpdated;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly HydraBuilder DefaultSeparator = new HydraBuilder(",");
          

        internal static readonly string Default;

        static SeparatedList()
        {
            var defaultValue = typeof(T).GetCustomAttribute<DefaultValueAttribute>();
            Default = defaultValue?.Value?.ToString();
        }

        public static SeparatedList<T> Parse(string str, HydraBuilder hydra = null, Action<string> onStringUpdated = null)
        {

            hydra = hydra ?? DefaultSeparator;

            var sep = new SeparatedList<T>(hydra);
            if (onStringUpdated != null)
                sep.OnStringUpdated += onStringUpdated;

           
            if (!(string.IsNullOrWhiteSpace(str) || string.Equals(str.Trim(), Default)))
            {
                var splited = hydra.Split(str);
                if (splited == null)
                    return sep;

                if (TryParseHelper<T>.TryGetParser(out var tryParse))
                {
                    foreach (var segment in splited)
                    {
                        if (tryParse.Invoke(segment, out var item))
                        {
                            sep.Add(item, false);
                        }
                    }
                }
                else if (ParseHelper<T>.TryGetParser(out var parse))
                {
                    foreach (var segment in splited)
                    {
                        try
                        {
                            sep.Add(parse.Invoke(segment), false);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException($"Can not parse type '{typeof(T)}' bacause method 'Parse'/'TryParse' not found.");
                }
            }
            sep.Flush();
            return sep;
        }

        private readonly ReaderWriterLockSlim _padlock = new ReaderWriterLockSlim();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly HashSet<T> InternalList;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<IEnumerable<T>, string> _joinHandler;

        public SeparatedList(HydraBuilder hydra = null)
        {
            this.InternalList = new HashSet<T>();
            this._joinHandler = (hydra ?? DefaultSeparator).Join;
        }

        public bool Add(T item, bool flush = true)
        {
            var a = this.InternalList.Add(item);
            if (a && flush)
                this.Flush();
            return a;
        }

        public bool BulkAdd(IEnumerable<T> items, bool flush = true)
        {
            var f = false;
            foreach (var item in items)
            {
                f |= this.InternalList.Add(item);
            }
            if (f && flush)
                this.Flush();
            return f;
        }

        public bool Contains(T item)
        {
            return this.InternalList.Contains(item);

        }

        public bool Remove(T item, bool flush = false)
        {
            var r = this.InternalList.Remove(item);
            if (r && flush)
                this.Flush();
            return r;

        }

        public void Clear(bool flush = false)
        {

            this.InternalList.Clear();
            if (flush)
                this.Flush();

        }

        public override string ToString()
        {

            if (this.Count == 0)
                return Default;

            return this._joinHandler.Invoke(this.InternalList);

        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count
        {
            get
            {
                return this.InternalList.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {

            var e = this.InternalList.GetEnumerator();
            switch (this.Count)
            {
                case 0:
                    break;

                case 1:
                    e.MoveNext();
                    yield return e.Current;
                    break;

                case 2:
                    e.MoveNext();
                    yield return e.Current;
                    e.MoveNext();
                    yield return e.Current;
                    break;

                case 3:
                    e.MoveNext();
                    yield return e.Current;
                    e.MoveNext();
                    yield return e.Current;
                    e.MoveNext();
                    yield return e.Current;
                    break;

                default:
                    while (e.MoveNext())
                    {
                        yield return e.Current;
                    }
                    break;
            }

            yield break;

        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Flush()
        {
            this.OnStringUpdated?.Invoke(this.ToString());
        }
    }
}