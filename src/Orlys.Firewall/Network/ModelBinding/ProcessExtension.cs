// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Network.ModelBinding
{
    using System;
    using System.Diagnostics;

    public static class ProcessExtension
    {
        public static bool TryBind(this ITcpConnectionInformation connection, out Process process)
        {
            try
            {
                process = Process.GetProcessById(connection.ProcessIdentifier);
                return true;
            }
            catch(ArgumentException)
            {
                process = null;
                return false;
            }
        }
    }
}