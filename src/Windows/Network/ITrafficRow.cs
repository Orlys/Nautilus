﻿// Author: Orlys
// Github: https://github.com/Orlys
namespace Nautilus.Windows.Network
{
    using System;
    using System.Net;
    using System.Net.NetworkInformation;

    public interface IEditableTrafficRow
    { 
        TcpState State {  set; }
    }

    public interface ITrafficRow : IEquatable<ITrafficRow>, IComparable<ITrafficRow>
    {
        TcpState State { get;  }

        IPEndPoint LocalEndPoint { get; }

        IPEndPoint RemoteEndPoint { get; }

        int Pid { get; }
         
    }
}