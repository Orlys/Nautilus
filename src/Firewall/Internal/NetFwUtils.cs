// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus
{

    using NetFwTypeLib;

    using System;
    using System.Data;

    internal static class NetFwUtils
    {
        public static INetFwRule CreateNetFwRule()
        {
            return (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
        }

        public static INetFwPolicy2 CreateNetFwPolicy2()
        {
            return (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
        }

    }
}