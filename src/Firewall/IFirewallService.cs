// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFirewallService
    {
        /// <summary>
        /// Gets all of the firewall rules.
        /// </summary>
        IEnumerable<IFirewallRule> Rules { get; }

        /// <summary>
        /// Removes all of the firewall rules.
        /// </summary>
        /// <returns></returns>
        void Clear();

        /// <summary>
        /// Creates a new firewall rule.
        /// </summary>
        /// <returns></returns>
        IFirewallRule Create();

        /// <summary>
        /// Deletes the firewall rule by <see cref="IFirewallRule.Id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(Guid id);
    }
}