
namespace Orlys.Network
{
    using System;
    using System.Net.Sockets;
    using System.ComponentModel;

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
        Func<IntPtr, ITcpConnection> Adapt { get; }
    }
}