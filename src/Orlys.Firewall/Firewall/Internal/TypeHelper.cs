// Author: Orlys
// Github: https://github.com/Orlys

// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Internal
{
    using System;
    using System.Collections.Generic;

    internal static class TypeHelper
    {
        private static readonly Dictionary<Enum, Enum> s_enumCache = new Dictionary<Enum, Enum>();

        public static T CastByValue<T>(this Enum value) where T : Enum
        {
            lock (s_enumCache)
            {
                if (!s_enumCache.TryGetValue(value, out var v))
                {
                    switch (value.GetTypeCode())
                    {
                        case TypeCode.SByte: v = (T)Enum.ToObject(typeof(T), Convert.ToSByte(value)); break;
                        case TypeCode.Byte: v = (T)Enum.ToObject(typeof(T), Convert.ToByte(value)); break;
                        case TypeCode.Int16: v = (T)Enum.ToObject(typeof(T), Convert.ToInt16(value)); break;
                        case TypeCode.UInt16: v = (T)Enum.ToObject(typeof(T), Convert.ToUInt16(value)); break;
                        case TypeCode.Int32: v = (T)Enum.ToObject(typeof(T), Convert.ToInt32(value)); break;
                        case TypeCode.UInt32: v = (T)Enum.ToObject(typeof(T), Convert.ToUInt32(value)); break;
                        case TypeCode.Int64: v = (T)Enum.ToObject(typeof(T), Convert.ToInt64(value)); break;
                        case TypeCode.UInt64: v = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(value)); break;

                        default: throw new NotSupportedException();
                    }

                    s_enumCache.Add(value, v);
                    s_enumCache.Add(v, value);
                }
                return (T)v;
            }
        }

        public static string Explode<T>(this T enums) where T : struct, Enum
        {
            return EnumHelper<T>.Explore(enums);
        }

        public static T Implode<T>(this string str) where T : struct, Enum
        {
            return EnumHelper<T>.Implode(str);
        }

        private static class EnumHelper<T> where T : struct, Enum
        {
            static EnumHelper()
            {
                Array = (T[])Enum.GetValues(typeof(T));
            }

            public static T[] Array { get; }

            public static IList<T> Filter(T value)
            {
                var list = new List<T>();
                foreach (var item in Array)
                {
                    if (value.HasFlag(item))
                        list.Add(item);
                }
                return list;
            }

            public static string Explore(T value, string separator = ",")
            {
                var filter = Filter(value);
                return string.Join(separator, filter);
            }

            public static T Implode(string str, string separator = ",")
            {
                var data = str.Split(new string[1] { separator }, StringSplitOptions.RemoveEmptyEntries);
                dynamic flag = default(T);
                var x = false;
                foreach (var item in data)
                {
                    if (Enum.TryParse(item, out T v))
                    {
                        if (!x)
                        {
                            x = true;
                            flag = v;
                        }
                        else
                        {
                            flag |= v;
                        }
                    }
                }
                return flag;
            }
        }
    }
}