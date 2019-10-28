// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network
{
    using System;
    using System.ComponentModel;
    using System.Net.Sockets;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IQuerySelector
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        int RowSize { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        AddressFamily AddressFamily { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<IntPtr, uint> CalculateEntries { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<IntPtr, ITcpConnectionInformation> Adapt { get; }
    }
}