// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFirewallRuleService
    {
        /// <summary>
        /// Gets all of the firewall rules.
        /// </summary>
        IReadOnlyCollection<IFirewallRule> Rules { get; }

        /// <summary>
        /// Removes all of the firewall rules.
        /// </summary>
        /// <returns></returns>
        void DropRules();

        /// <summary>
        /// Updates the firewall rule.
        /// </summary>
        /// <param name="rule"></param>
        void UpdateRule(IFirewallRule rule);

        /// <summary>
        /// Creates a new firewall rule.
        /// </summary>
        /// <returns></returns>
        IFirewallRule CreateRule();
        
        /// <summary>
        /// Gets a firewall rule by <see cref="IFirewallRule.Id"/>.
        /// </summary>
        /// <returns></returns>
        IFirewallRule RetrieveRule(Guid id);

        /// <summary>
        /// Deletes the firewall rule by <see cref="IFirewallRule.Id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRule(Guid id);
    }
}