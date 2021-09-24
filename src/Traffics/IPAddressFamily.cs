/// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System;

    [Flags]
    public enum IPAddressFamily
    {
        v4 = 1,
        v6 =2,
        Both = v4 | v6
    }

}