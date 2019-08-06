
namespace Orlys.Firewall.Internal.ExpressionCache
{
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class ParseHelper<T>
    {
        public delegate T Delegate(string str);

        private static readonly Delegate s_parse;

        static ParseHelper()
        { 
            var type = typeof(T);
            var arg = typeof(string);
            var method = type.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                return;

            var pars = method.GetParameters();
            if (!(pars.Length == 1 && pars[0].ParameterType == arg && method.ReturnType == type))
            {
                return;
            }

            var parameter = Expression.Parameter(arg);
            var call = Expression.Call(method, parameter);
            var lambda = Expression.Lambda<Delegate>(call, parameter);
            s_parse = lambda.Compile(); 
        }

        public static bool TryGetParser(out Delegate parse)
        {
            parse = s_parse;
            return parse != null;
        }
    }

     
}
