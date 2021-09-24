namespace Nautilus.Tests
{
    using NUnit.Framework;

    using System.Net;

    public class Tests
    {
        private IFirewallService _fw;

        [SetUp]
        public void Setup()
        {
            this._fw = Firewall.GetService("@__Test");
        }


        //[Test]
        //public void Set()
        //{
        //    var rule = _fw.Create();
        //    rule.Enabled = true;
        //    _fw.Update(rule);

        //    _fw[Profiles.Domain] = false;
        //}

        [Test]
        public void Acid()
        {
            var rule = _fw.Create();
            rule.Enabled = true;
            rule.Protocol = ProtocolTypes.TCP;
            rule.Profiles = Profiles.Domain | Profiles.Private;
            rule.RemoteAddresses.Add(IPAddress.Parse("8.8.8.8"));

            _fw.Update(rule);


            rule = _fw.Get(rule.Id);
            Assert.NotNull(rule);


            _fw.Delete(rule.Id);

            CollectionAssert.DoesNotContain(_fw.Rules, rule);

            _fw.Clear();
            CollectionAssert.IsEmpty(_fw.Rules);
        }
    }
}