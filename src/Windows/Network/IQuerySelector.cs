// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network
{
    using System;
    using System.ComponentModel;
    using System.Net.Sockets;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRowAdapter
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<IntPtr, ITrafficRow> Adapt { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        AddressFamily AddressFamily { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<IntPtr, uint> CalculateEntries { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        int RowSize { get; }
    }
}