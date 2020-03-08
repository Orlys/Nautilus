
namespace Nautilus.Windows.Firewall
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFirewallController
    {
        /// <summary>
        /// Gets the firewall rules.
        /// </summary>
        IEnumerable<IFirewallRule> Rules { get; }

        /// <summary>
        /// Removes all firewall rules.
        /// </summary>
        /// <returns></returns>
        Task Clear();

        /// <summary>
        /// Creates a new firewall rule.
        /// </summary>
        /// <returns></returns>
        Task<IFirewallRule > Create();

        /// <summary>
        /// Deletes the firewall rule by <see cref="IFirewallRule.Id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}