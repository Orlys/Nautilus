
namespace Orlys.Firewall.Internal.Visualizers
{
    using Orlys.Firewall.Collections;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class InternalListVisualizer<T> where T : IEquatable<T>
    {
        public string Type { get; }
        //public int Count { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public IEnumerable<T> List { get; }
        internal InternalListVisualizer(SeparatedList<T> t)
        {
            //this.Count = t.Count;
            this.Type = typeof(T).FullName;
            this.List = t.InternalList.ToArray();
        }
    }
}