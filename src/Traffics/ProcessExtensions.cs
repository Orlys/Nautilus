// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class ProcessExtensions
    {
        public static Process WithProcess(this TcpTrafficRow row)
        {
            return Process.GetProcessById(row.Pid);
        }

    }
}