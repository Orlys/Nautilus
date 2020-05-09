// Author: Orlys
// Github: https://github.com/Orlys

namespace Nautilus.Windows.Firewall
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal static class EnumHelper<TEnum> where TEnum : struct, Enum
    {
        private static readonly TEnum[] s_values = (TEnum[])Enum.GetValues(typeof(TEnum));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string ValuesToStr(TEnum flags)
        {
            return string.Join(",", s_values.Where(x => flags.HasFlag(x)));
        }
    }
}