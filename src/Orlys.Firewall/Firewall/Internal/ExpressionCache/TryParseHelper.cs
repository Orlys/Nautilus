namespace Orlys.Firewall.Internal.ExpressionCache
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class TryParseHelper<T>
    {
        public delegate bool Delegate(string str, out T result);

        private static readonly Delegate s_tryParse;

        static TryParseHelper()
        {
            var targetMethodName = "TryParse";

            var type = typeof(T);
            var conditionType = typeof(bool);
            var resultRypeRef = type.MakeByRefType();
            var strType = typeof(string);
            var method = type.GetMethod(
                targetMethodName,
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                new[] { strType, resultRypeRef },
                null);

            if (method == null)
                return;

            var pars = method.GetParameters();
            if (!(pars.Length == 2 &&
                pars[0].ParameterType == strType &&
                pars[1].ParameterType == resultRypeRef &&
                method.ReturnType == conditionType))
            {
                return;
            }

            var expStr = Expression.Parameter(strType);
            var expRefResult = Expression.Parameter(resultRypeRef);
            var tryParseBody = Expression.Call(method, expStr, expRefResult);
            var lambda = Expression.Lambda<Delegate>(tryParseBody, expStr, expRefResult);

            s_tryParse = lambda.Compile();
        }

        public static bool TryGetParser(out Delegate parse)
        {
            parse = s_tryParse;
            return parse != null;
        }
    }
}