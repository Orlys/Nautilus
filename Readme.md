<<<<<<< HEAD
## Nautilus
Dynamic firewall API for Windows platform written in C#.

## Usage
```csharp
// required COM+ component 'NetFwTypeLib' and admin permission.
using Nautilus; 
=======
## Nautilus 
![](https://img.shields.io/badge/Orlys.Nautilus-v2.0.0-blue?logo=nuget&style=flat&link=https://www.nuget.org/packages/Orlys.Nautilus/)  
Dynamic firewall API for Windows platform written in C#.

## Usage
### Firewall
```csharp
// required COM+ component 'NetFwTypeLib' and admin permission.
using Nautilus; 
using System.Net;
>>>>>>> pickback

// Gets the firewall service from advance firewall rule list.
var service = Firewall.GetService("service name in fw panel"); // type: IFirewallService

// creates a new firewall rule.
var newRule = service.CreateRule(); // type: IFirewallRule
// updates firewall properties.
newRule.Enabled = true;
newRule.Direction = Directions.Incoming;
newRule.Protocol = ProtocolType.TCP;
newRule.LocalPorts.Add(8000.To(8008));
newRule.LocalPorts.Add(8009);
newRule.RemoteAddresses.Add(IPAddressRange.Parse("173.245.48.0/20"));
newRule.RemoteAddresses.Add(IPAddress.Parse("1.1.1.1"));

// commits all changes.
service.UpdateRule(newRule);

// gets the firewall rules.
var rules = service.Rules; // type: IReadOnlyCollection<IFirewallRule>

// retrieves a firewall rule.
var singleRule = service.RetrieveRule(newRule.Id);

// deletes a firewall rule.
service.DeleteRule(rule.Id);

// removes all firewall rules.
service.DropRules();
<<<<<<< HEAD
=======
```

### Traffics
```csharp
using Nautilus; 

var families = IPAddressFamily.v4 | IPAddressFamily.v6;
var trafficRows = TcpTrafficTracker.Track(families); // type: IReadOnlyCollection<TcpTrafficRow>
>>>>>>> pickback
```

## License
[Mozilla Public License 2.0](./LICENSE.txt)
