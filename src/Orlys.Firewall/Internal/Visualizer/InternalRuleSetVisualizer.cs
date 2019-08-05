// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Internal.Visualizers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal class InternalRuleSetVisualizer
    {
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public IEnumerable<IRule> List { get; }

        internal InternalRuleSetVisualizer(RuleSet t)
        {
            this.List = t.InternalList.Values.ToArray();
        }
    }
}