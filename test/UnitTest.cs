namespace Nautilus.Tests
{
    using NUnit.Framework;

    using System.Net;

    public class Tests
    {
        private IFirewallRuleService _fw;

        [SetUp]
        public void Setup()
        {
            this._fw = Firewall.GetRuleService("@__Test");
        }


        [Test]
        public void Traffic()
        {
            var traffics = TcpTrafficTracker.Track(IPAddressFamily.v6);
            foreach (var traffic in traffics)
            {
                System.Console.WriteLine(traffic.LocalEndPoint + "  " + traffic.RemoteEndPoint + "  " + traffic.State + "  " + traffic.Pid + "  " + traffic.GetHashCode());
            }
        }

        [Test]
        public void FirewallRule_Acid()
        {
            var rule = _fw.CreateRule();
            rule.Enabled = true;
            rule.Protocol = ProtocolTypes.TCP;
            rule.Profiles = Profiles.Domain | Profiles.Private;
            rule.RemoteAddresses.Add(IPAddress.Parse("8.8.8.8"));

            _fw.UpdateRule(rule);


            rule = _fw.RetrieveRule(rule.Id);
            Assert.NotNull(rule);


            _fw.DeleteRule(rule.Id);

            CollectionAssert.DoesNotContain(_fw.Rules, rule);

            _fw.DropRules();
            CollectionAssert.IsEmpty(_fw.Rules);
        }
    }
}