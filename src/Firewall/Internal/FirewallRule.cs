// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using NetFwTypeLib;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    internal sealed class FirewallRule : IFirewallRule
    {
        private readonly SeparatedList<IPAddressRange> _localAddresses;

        private readonly SeparatedList<PortRange> _localPorts;

        private readonly SeparatedList<IPAddressRange> _remoteAddresses;

        private readonly SeparatedList<PortRange> _remotePorts;

        private readonly INetFwRule _rule;

        public Actions Action { get => (Actions)this._rule.Action; set => this._rule.Action = (NET_FW_ACTION_)value; }

        public string ApplicationName { get => this._rule.ApplicationName; set => this._rule.ApplicationName = value; }

        public string Description { get => this._rule.Description; set => this._rule.Description = value; }

        public Directions Direction { get => (Directions)this._rule.Direction; set => this._rule.Direction = (NET_FW_RULE_DIRECTION_)value; }

        public bool Enabled { get => this._rule.Enabled; set => this._rule.Enabled = value; }

        public string IcmpTypesAndCodes
        {
            get
            {
                if (!this.Protocol.SupportedIcmpConfig)
                    return null; // not supported
                return this._rule.IcmpTypesAndCodes;
            }
            set
            {
                if (!this.Protocol.SupportedIcmpConfig)
                    return; // not supported
                this._rule.IcmpTypesAndCodes = value;
            }
        }

        public Guid Id { get; }

        public InterfaceTypes InterfaceTypes
        {
            get =>  Enum.TryParse<InterfaceTypes>(this._rule.InterfaceTypes, out var @enum) ? @enum : throw new InvalidCastException();
            set => this._rule.InterfaceTypes = EnumHelper<InterfaceTypes>.ValuesToStr(value);
        }

        public IList<IPAddressRange> LocalAddresses
        {
            get
            {
                return this._localAddresses;
            }
        }

        public IList<PortRange> LocalPorts
        {
            get
            {
                if (this.Protocol == ProtocolTypes.UDP || this.Protocol == ProtocolTypes.TCP)
                    return this._localPorts;
                return EmptyArray<PortRange>.Default;
            }
        }

        public Profiles Profiles { get => (Profiles)this._rule.Profiles; set => this._rule.Profiles = (int)value; }

        public ProtocolTypes Protocol { get => this._rule.Protocol; set => this._rule.Protocol = value; }

        public IList<IPAddressRange> RemoteAddresses
        {
            get
            {
                return this._remoteAddresses;
            }
        }

        public IList<PortRange> RemotePorts
        {
            get
            {
                if (this.Protocol == ProtocolTypes.UDP || this.Protocol == ProtocolTypes.TCP)
                    return this._localPorts;
                return EmptyArray<PortRange>.Default;
            }
        }

        public string ServiceName { get => this._rule.serviceName; set => this._rule.serviceName = value; }

        internal FirewallRule(Guid id, INetFwRule rule)
        {
            this.Id = id;
            this._rule = rule;

            this._remotePorts = new SeparatedList<PortRange>(this._rule.RemotePorts, ",");
            this._remotePorts.ListChanged += (sender, e) => this._rule.RemotePorts = sender.ToString();

            this._remoteAddresses = new SeparatedList<IPAddressRange>(this._rule.RemoteAddresses, ",");
            this._remoteAddresses.ListChanged += (sender, e) => this._rule.RemoteAddresses = sender.ToString();

            this._localPorts = new SeparatedList<PortRange>(this._rule.LocalPorts, ",");
            this._localPorts.ListChanged += (sender, e) => this._rule.LocalPorts = sender.ToString();

            this._localAddresses = new SeparatedList<IPAddressRange>(this._rule.LocalAddresses, ",");
            this._localAddresses.ListChanged += (sender, e) => this._rule.LocalAddresses = sender.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as IFirewallRule);
        }

        public bool Equals(IFirewallRule other)
        {
            return this.GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }
}