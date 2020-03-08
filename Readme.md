## Nautilus
Fully-asynchronous programmable dynamic firewall API for Windows platform written in C#.

## Usage
Dynamic firewall APIs example.
```csharp
using Nautilus.Windows.Firewall;

// gets firewall controller. (singleton)
var controller = Firewall.Controller;

// creates a new firewall rule.
IFirewallRule newRule = await controller.Create();
// updates firewall properties.
newRule.Enabled = true;
newRule.Direction = Directions.Incoming;
newRule.Protocol = ProtocolType.TCP;
newRule.LocalPorts.Add(8000..8008);
newRule.LocalPorts.Add(8009);
newRule.RemoteAddresses.Add(IPAddressRange.Parse("173.245.48.0/20"));
newRule.RemoteAddresses.Add(IPAddress.Parse("1.1.1.1"));

// gets the firewall rules.
IEnumerable<IFirewallRule> rules = controller.Rules;

// deletes a firewall rule.
await controller.Delete(rule.Id);

// removes all firewall rules.
await controller.Clear();
```

## License
[Mozilla Public License 2.0](./LICENSE)