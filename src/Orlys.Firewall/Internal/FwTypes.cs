// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Internal
{
    using NetFwTypeLib;

    using System;

    internal static class FwTypes
    {
        private static T Create<T>(string progId)
        {
            var typef = Type.GetTypeFromProgID(progId);
            return (T)Activator.CreateInstance(typef);
        }

        internal static INetFwPolicy2 CreatePolicy2() => Create<INetFwPolicy2>("HNetCfg.FwPolicy2");

        internal static INetFwRule CreateRule() => Create<INetFwRule>("HNetCfg.FwRule");
    }
}