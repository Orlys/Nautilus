namespace Orlys.PollingServices
{
    using System;

    public class PollingOptions<T>
    {
        public PollingOptions(PollingCycle cycle, PollingDecision<T> decision)
        {
            this.Cycle = cycle ?? throw new ArgumentNullException(nameof(cycle));
            this.Decision = decision ?? throw new ArgumentNullException(nameof(decision));
        }

        public PollingCycle Cycle { get; }

        public PollingDecision<T> Decision { get; }
    }


    public delegate bool PollingDecision<T>(T value);
}

