## Nautilus
Dynamic firewall API for Windows platform written in C#.

## Usage
```csharp
// required COM+ component 'NetFwTypeLib' and admin permission.
using Nautilus; 

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
```

## License
[Mozilla Public License 2.0](./LICENSE.txt)
