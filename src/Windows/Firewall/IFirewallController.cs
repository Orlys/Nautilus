
namespace Nautilus.Windows.Firewall
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
     
    public interface IFirewallController
    {
        /// <summary>
        /// Gets all of the firewall rules.
        /// </summary>
        [Summary("Gets the firewall rules.")]
        IEnumerable<IFirewallRule> Rules { get; }

        /// <summary>
        /// Removes all of the firewall rules.
        /// </summary>
        /// <returns></returns>
        [Summary("Removes all of the firewall rules.")]
        Task Clear();

        /// <summary>
        /// Creates a new firewall rule.
        /// </summary>
        /// <returns></returns>
        [Summary("Creates a new firewall rule.")]
        Task<IFirewallRule > Create();

        /// <summary>
        /// Deletes the firewall rule by <see cref="IFirewallRule.Id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [Summary("Deletes the firewall rule by 'IFirewallRule.Id'.")]
        Task<bool> Delete([Summary("IFirewallRule's Id property.")]Guid id);
    }
}