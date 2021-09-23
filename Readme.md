## Nautilus
Dynamic firewall API for Windows platform written in C#.

## Usage
```csharp
// required COM+ component 'NetFwTypeLib' and admin permission.
using Nautilus; 

// Gets the firewall service from advance firewall rule list.
var service = Firewall.GetService("service name in fw panel");

// creates a new firewall rule.
IFirewallRule newRule = service.Create();
// updates firewall properties.
newRule.Enabled = true;
newRule.Direction = Directions.Incoming;
newRule.Protocol = ProtocolType.TCP;
newRule.LocalPorts.Add(8000..8008);
newRule.LocalPorts.Add(8009);
newRule.RemoteAddresses.Add(IPAddressRange.Parse("173.245.48.0/20"));
newRule.RemoteAddresses.Add(IPAddress.Parse("1.1.1.1"));

// gets the firewall rules.
IEnumerable<IFirewallRule> rules = service.Rules;

// deletes a firewall rule.
service.Delete(rule.Id);

// removes all firewall rules.
service.Clear();
```

## License
[Mozilla Public License 2.0](./LICENSE.txt)
