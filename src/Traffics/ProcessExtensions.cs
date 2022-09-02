// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.ComponentModel;
    using System;
    using System.Linq;

    public static class ProcessExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Using 'GetRelatedProcess' method instead of this.")]
        public static Process WithProcess(this TcpTrafficRow row)
        {
            return GetRelatedProcess(row);
        }

        public static Process GetRelatedProcess(this TcpTrafficRow row)
        {
            return Process.GetProcessById(row.Pid);
        }

    }
}