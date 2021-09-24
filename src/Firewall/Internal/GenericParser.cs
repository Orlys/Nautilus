// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class GenericParser<T>
    {
        private delegate bool TryParseDelegate(string s, out T result);  
        private static Lazy<TryParseDelegate> s_tryParse = new Lazy<TryParseDelegate>(GetTryParseMethod); 
        public static bool TryParse(string str, out T value) => s_tryParse.Value(str, out value); 
        private static TryParseDelegate GetTryParseMethod()
        {  
            var type = typeof(T);
            var s = Expression.Parameter(typeof(string));
            var refType = type.MakeByRefType();
            var result = Expression.Parameter(refType);
            var tryParseMethod = type.GetMethod(nameof(TryParse), BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder, new[] { s.Type, refType }, null);

            if (tryParseMethod == null)
                throw new MissingMethodException(type.FullName, nameof(TryParse));

            var caller = Expression.Call(tryParseMethod, s, result) as Expression; 
            return Expression.Lambda<TryParseDelegate>(caller, s, result).Compile();
        }


        private delegate T ParseDelegate(string s);
        private static Lazy<ParseDelegate> s_parse = new Lazy<ParseDelegate>(Parse);
        public static T Parse(string str) => s_parse.Value(str);
        private static ParseDelegate Parse()
        {
            var type = typeof(T);
            var para = Expression.Parameter(typeof(string));

            var parseMethod = type.GetMethod(nameof(Parse), BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder, new[] { para.Type }, null);

            if (parseMethod == null)
                throw new MissingMethodException(type.FullName, nameof(Parse));


            var caller = Expression.Call(parseMethod, para) as Expression;
            return Expression.Lambda<ParseDelegate>(caller, para).Compile();
        }
    }
}