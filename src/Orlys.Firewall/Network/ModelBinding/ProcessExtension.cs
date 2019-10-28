// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Network.ModelBinding
{
    using System.Diagnostics;

    public static class ProcessExtension
    {
        public static Process Bind(this ITcpConnectionInformation connection)
        {
            return Process.GetProcessById(connection.ProcessIdentifier + 8);
        }
    }
}