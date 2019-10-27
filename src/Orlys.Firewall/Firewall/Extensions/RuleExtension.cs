// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Extensions
{
    using Orlys.Firewall.Collections;
    using Orlys.Firewall.Enums;
    using System;
    using System.Collections.Generic;
    using Action = Enums.Action;

    public static class RuleExtension
    {
        public static IRule WithProtocol(this IRule rule, RichProtocol protocol)
        {
            rule.Protocol = protocol;
            return rule;
        }

        public static IRule WithAction(this IRule rule, Action action)
        {
            rule.Action = action;
            return rule;
        }

        public static IRule WithDirection(this IRule rule, Direction direction)
        {
            rule.Direction = direction;
            return rule;
        }

        public static IRule WithProfiles(this IRule rule, Profiles profiles)
        {
            rule.Profiles = profiles;
            return rule;
        }

        public static IRule WithDescription(this IRule rule, string description)
        {
            rule.Description = description;
            return rule;
        }

        public static IRule WithEnabled(this IRule rule, bool enabled)
        {
            rule.Enabled = enabled;
            return rule;
        }

        public static IRule WithApplicationName(this IRule rule, string appName)
        {
            rule.ApplicationName = appName;
            return rule;
        }
        public static IRule WithServiceName(this IRule rule, string serviceName)
        {
            rule.ServiceName = serviceName;
            return rule;
        }


        public static SeparatedList<T> Add<T>(this SeparatedList<T> sl, T value, bool flush = true) where T : IEquatable<T>
        {
            sl.Add(value, flush);
            return sl;
        }
        public static SeparatedList<T> BulkAdd<T>(this SeparatedList<T> sl, IEnumerable< T> values, bool flush = true) where T : IEquatable<T>
        {
            sl.BulkAdd(values, flush);
            return sl;
        }
        public static SeparatedList<T> Remove<T>(this SeparatedList<T> sl, T value, bool flush = false) where T : IEquatable<T>
        {
            sl.Remove(value, flush);
            return sl;
        }
        public static SeparatedList<T> Clear<T>(this SeparatedList<T> sl, bool flush = false) where T : IEquatable<T>
        {
            sl.Clear(flush);
            return sl;
        }
        public static SeparatedList<T> Flush<T>(this SeparatedList<T> sl) where T : IEquatable<T>
        {
            sl.Flush();
            return sl;
        }
    }
}