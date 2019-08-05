// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Extensions
{
    using Orlys.Firewall.Enums;

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
    }
}