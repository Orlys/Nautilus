namespace Orlys.Firewall
{
    using Orlys.Firewall.Collections;
    using Orlys.Firewall.Enums;
    using Orlys.Firewall.Models;

    using System;

    using Action = Enums.Action;

    public interface IRule : IDisposable
    {
        string Grouping { get; }
        Action Action { get; set; }
        string Description { get; set; }
        Direction Direction { get; set; }
        bool Enabled { get; set; } 
        Guid Id { get; }
        SeparatedList<IPAddressRange> LocalAddresses { get; }
        SeparatedList<PortRange> LocalPorts { get; }
        string Name { get; }
        Profiles Profiles { get; set; }
        RichProtocol Protocol { get; set; }
        SeparatedList<IPAddressRange> RemoteAddresses { get; }
        SeparatedList<PortRange> RemotePorts { get; }
    }

    public interface IAdvanceRule : IRule
    {
        string IcmpTypesAndCodes { get; set; }
        string ApplicationName { get; set; }
        InterfaceTypes InterfaceTypes { get; set; }
        string ServiceName { get; set; }
    }
}