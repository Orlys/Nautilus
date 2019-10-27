// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Internal.Visualizers
{
    using Orlys.Firewall.Models;

    using System.Diagnostics;

    internal sealed class InternalRangeTypeVisualizer
    {
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public IPrivateRange Range { get; }

        internal InternalRangeTypeVisualizer(IPAddressRange t)
        {
            if (t.Begin.Equals(t.End))
                this.Range = new SingleObject(t.Begin.ToString());
            else
                this.Range = new LimitedObject(t.Begin.ToString(), t.End.ToString());
        }

        internal InternalRangeTypeVisualizer(LocalPortRange t)
        {
            if (t.SpecificPort.HasValue)
                this.Range = new SpecificObject(t.ToString());
            else if (t.Begin.Equals(t.End))
                this.Range = new SingleObject(t.Begin.ToString());
            else
                this.Range = new LimitedObject(t.Begin.ToString(), t.End.ToString());
        }

        internal InternalRangeTypeVisualizer(RemotePortRange t)
        {
            if (t.Begin.Equals(t.End))
                this.Range = new SingleObject(t.Begin.ToString());
            else
                this.Range = new LimitedObject(t.Begin.ToString(), t.End.ToString());
        }

        public interface IPrivateRange
        {
        }

        private class SpecificObject : IPrivateRange
        {
            public SpecificObject(string specific)
            {
                this.Specific = specific;
            }

            public string Specific { get; }
        }

        private class SingleObject : IPrivateRange
        {
            public SingleObject(string single)
            {
                this.Single = single;
            }

            public string Single { get; }
        }

        private class LimitedObject : IPrivateRange
        {
            public LimitedObject(string begin, string end)
            {
                this.Begin = begin;
                this.End = end;
            }

            public string Begin { get; }
            public string End { get; }
        }
    }
}