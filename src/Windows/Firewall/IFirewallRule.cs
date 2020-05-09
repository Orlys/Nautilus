// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Firewall
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IFirewallRule : IEquatable<IFirewallRule>
    {
        /// <summary>
        /// Gets or sets the action of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the action of the firewall rule.")]
        [DefaultValue(Actions.Block)]
        Actions Action { get; set; }

        /// <summary>
        /// Gets or sets the application name of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the application name of the firewall rule.")]
        string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a description of the firewall rule.
        /// </summary>
        [Summary("Gets or sets a description of the firewall rule.")]
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the direction of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the direction of the firewall rule.")]
        [DefaultValue(Directions.Incoming)]
        Directions Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the firewall rule activation.
        /// </summary>
        [Summary("Gets or sets a value indicating whether the firewall rule activation.")]
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the ICMP types and codes of the firewall rule when protocol type supported
        /// ICMP config.
        /// </summary>
        [Summary("Gets or sets the ICMP types and codes of the firewall rule when protocol type supported ICMP config.")]
        string IcmpTypesAndCodes { get; set; }

        /// <summary>
        /// Gets the unique identifier of the specific firewall rule.
        /// </summary>
        [Summary("Gets the unique identifier of the specific firewall rule.")]
        Guid Id { get; }

        /// <summary>
        /// Gets or sets the interface types of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the interface types  of the firewall rule.")]
        [DefaultValue(InterfaceTypes.All)]
        InterfaceTypes InterfaceTypes { get; set; }

        /// <summary>
        /// Gets the local address list of the firewall rule.
        /// </summary>
        [Summary("Gets the local address list of the firewall rule.")]
        IList<IPAddressRange> LocalAddresses { get; }

        /// <summary>
        /// Gets the local port list of the firewall rule when the protocol is <see
        /// cref="SlimProtocolTypes.UDP"/> or <see cref="SlimProtocolTypes.TCP"/>, otherwise empty list.
        /// </summary>
        [Summary("Gets the local port list of the firewall rule when the protocol is 'SlimProtocolTypes.UDP' or'SlimProtocolTypes.TCP', otherwise empty list.")]
        IList<PortRange> LocalPorts { get; }

        /// <summary>
        /// Gets or sets the profiles of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the profiles of the firewall rule.")]
        [DefaultValue(Profiles.All)]
        Profiles Profiles { get; set; }

        /// <summary>
        /// Gets or sets the network protocol of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the network protocol  of the firewall rule.")]
        [DefaultValue(SlimProtocolTypes.Any)]
        ProtocolTypes Protocol { get; set; }

        /// <summary>
        /// Gets the remote address list of the firewall rule.
        /// </summary>
        [Summary("Gets the remote address list of the firewall rule.")]
        IList<IPAddressRange> RemoteAddresses { get; }

        /// <summary>
        /// Gets the remote port list of the firewall rule when the protocol is <see
        /// cref="SlimProtocolTypes.UDP"/> or <see cref="SlimProtocolTypes.TCP"/>, otherwise empty list.
        /// </summary>
        [Summary("Gets the remote port list of the firewall rule when the protocol is 'SlimProtocolTypes.UDP' or'SlimProtocolTypes.TCP', otherwise empty list.")]
        IList<PortRange> RemotePorts { get; }

        /// <summary>
        /// Gets or sets the service name of the firewall rule.
        /// </summary>
        [Summary("Gets or sets the service name of the firewall rule.")]
        string ServiceName { get; set; }
    }
}