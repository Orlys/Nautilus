// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Net;
    using System.Runtime.CompilerServices;

    internal class FirewallRule : IFirewallRule
    {
        internal FirewallRule(Guid id, string groupName,
            string localAddrs,
            string localPorts,
            string remoteAddrs,
            string remotePorts)
        {
            this.Id = id;
            this.GroupName = groupName;

            this._localAddresses = IPAddressRangeList.CreateFrom(localAddrs);
            this._remoteAddresses = IPAddressRangeList.CreateFrom(remoteAddrs);

            this._localPorts = PortRangeList.CreateFrom(localPorts);
            this._remotePorts = PortRangeList.CreateFrom(remotePorts);
        }

        private IPAddressRangeList _localAddresses;
        public ICollection<IPAddressRange> LocalAddresses => _localAddresses;

        private IPAddressRangeList _remoteAddresses;
        public ICollection<IPAddressRange> RemoteAddresses => _remoteAddresses;

        private PortRangeList _localPorts;
        public ICollection<PortRange> LocalPorts => ReadOrDead(this._localPorts);

        private PortRangeList _remotePorts;
        public ICollection<PortRange> RemotePorts => ReadOrDead(this._remotePorts);

        private ICollection<PortRange> ReadOrDead(ICollection<PortRange> range)
        {
            if (SupportedPortRange)
                return range;

            return Array.Empty<PortRange>();
        }

        public bool SupportedPortRange => this.Protocol == ProtocolTypes.UDP || this.Protocol == ProtocolTypes.TCP;

        public string ServiceName { get; set; }

        public Actions Action { get; set; } = Actions.Allow;

        public string ApplicationName { get; set; }

        public string Description { get; set; }

        public Directions Direction { get; set; } = Directions.Incoming;

        public bool Enabled { get; set; } = false;

        public Profiles Profiles { get; set; } = Profiles.All;

        public ProtocolTypes Protocol { get; set; } = ProtocolTypes.TCP;

        public InterfaceTypes InterfaceTypes { get; set; } = InterfaceTypes.All;

        private string _icmpTypesAndCodes;
        public string IcmpTypesAndCodes
        {
            get
            {
                if (!this.Protocol.SupportedIcmpConfig)
                    return null; // not supported 
                return _icmpTypesAndCodes;
            }
            set
            {
                if (!this.Protocol.SupportedIcmpConfig)
                    return; // not supported
                _icmpTypesAndCodes = value;
            }
        }

        public Guid Id { get; }
        public string GroupName { get; }
    }
}