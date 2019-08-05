
namespace Orlys.Firewall.Internal.Visualizers
{
    using System.Collections.Generic;

    internal class InternalRuleSetVisualizer
    {
        public IEnumerable<IRule> List { get; }

        internal InternalRuleSetVisualizer(RuleSet t)
        {
            this.List = t.InternalList.Values;
        }
    }
}
