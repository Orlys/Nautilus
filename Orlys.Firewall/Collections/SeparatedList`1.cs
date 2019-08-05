
namespace Orlys.Firewall.Collections
{
    using Orlys.Firewall.Internal.Visualizers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
     
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

            internal protected virtual string[] Split(string payload)
            {
                if (string.IsNullOrWhiteSpace(payload))
                    return null;
                return payload.Split(this.Separator, StringSplitOptions.RemoveEmptyEntries);
            }

            internal protected virtual string Join(IEnumerable<T> payload)
            {
                return string.Join(this.Separator[0], payload);
            }
        }

        public event Action<string> OnStringUpdated;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static readonly HydraBuilder DefaultSeparator = new HydraBuilder(",");

        private delegate T ParseDelegate(string str);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ParseDelegate s_parse; 
          
        internal static readonly string Default;

        static SeparatedList()
        {
            var defaultValue = typeof(T).GetCustomAttribute<DefaultValueAttribute>();
            Default = defaultValue?.Value?.ToString();
        }

        public static SeparatedList<T> Parse(string str, HydraBuilder hydra = null, Action<string> onStringUpdated = null)
        {

            if (s_parse == null)
            {
                var type = typeof(T);
                var arg = typeof(string);
                var method = type.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
                if (method == null)
                    throw new ArgumentException("Can not found static method 'Parse' in type '" + type + "'.");

                var pars = method.GetParameters();
                if (!(pars.Length == 1 && pars[0].ParameterType == arg && method.ReturnType == type))
                {
                    throw new ArgumentException("Method signature not matched.");
                }

                var parameter = Expression.Parameter(arg);
                var call = Expression.Call(method, parameter);
                var lambda = Expression.Lambda<ParseDelegate>(call, parameter);
                s_parse = lambda.Compile();
            }
            hydra = hydra ?? DefaultSeparator;


            var sep = new SeparatedList<T>(hydra);
            if (onStringUpdated != null)
                sep.OnStringUpdated += onStringUpdated;

            if (!(string.IsNullOrWhiteSpace(str) || string.Equals(str.Trim(), Default)))
            {
                var split = hydra.Split(str);
                if (split == null)
                    return sep;
                for (int i = 0; i < split.Length; i++)
                {
                    var segment = split[i];
                    try
                    {
                        var item = s_parse.Invoke(segment);
                        sep.Add(item, false);
                    }
                    catch
                    {

                    }
                }
            }

            sep.Notify();
            return sep;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly HashSet<T> InternalList;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<IEnumerable<T>, string> _joinHandler;

        public SeparatedList(HydraBuilder hydra = null)
        {
            this.InternalList = new HashSet<T>();
            this._joinHandler = (hydra ?? DefaultSeparator).Join;
        }

        public bool Add(T item, bool raise = true)
        {
            var a = this.InternalList.Add(item);
            if (a && raise)
                this.Notify();
            return a;
        }

        public bool BulkAdd(IEnumerable<T> items, bool raise = true)
        {
            var f = false;
            foreach (var item in items)
            {
                f |= this.InternalList.Add(item);
            }
            if (f && raise)
                this.Notify();
            return f;
        }

        public bool Contains(T item)
        {
            return this.InternalList.Contains(item);
        }

        public bool Remove(T item, bool raise = false)
        {
            var r = this.InternalList.Remove(item);
            if (r && raise)
                this.Notify();
            return r;
        }

        public void Clear(bool raise = false)
        {
            this.InternalList.Clear();
            if (raise)
                this.Notify();
        }

        public override string ToString()
        {
            if (this.Count == 0)
                return Default;

            return this._joinHandler.Invoke(this.InternalList);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count => this.InternalList.Count;

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

        public void Notify()
        { 
            this.OnStringUpdated?.Invoke(this.ToString());
        }
    }
}