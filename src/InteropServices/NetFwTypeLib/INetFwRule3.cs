namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("B21563FF-D696-4222-AB46-4E89B73AB34A")]
	
	public interface INetFwRule3 : INetFwRule2
	{
		[DispId(1)]
		new string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(2)]
		new string Description
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(2)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(3)]
		new string ApplicationName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(4)]
		new string serviceName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(5)]
		new int Protocol
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(5)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(5)]
			[param: In]
			set;
		}

		[DispId(6)]
		new string LocalPorts
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(7)]
		new string RemotePorts
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(8)]
		new string LocalAddresses
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(9)]
		new string RemoteAddresses
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(9)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(10)]
		new string IcmpTypesAndCodes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(10)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(11)]
		new NET_FW_RULE_DIRECTION_ Direction
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(11)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(11)]
			[param: In]
			set;
		}

		[DispId(12)]
		new object Interfaces
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(12)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(12)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
		}

		[DispId(13)]
		new string InterfaceTypes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(13)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(13)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(14)]
		new bool Enabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(14)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(14)]
			[param: In]
			set;
		}

		[DispId(15)]
		new string Grouping
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(15)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(16)]
		new int Profiles
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(16)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(16)]
			[param: In]
			set;
		}

		[DispId(17)]
		new bool EdgeTraversal
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(17)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(17)]
			[param: In]
			set;
		}

		[DispId(18)]
		new NET_FW_ACTION_ Action
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(18)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(18)]
			[param: In]
			set;
		}

		[DispId(19)]
		new int EdgeTraversalOptions
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(19)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(19)]
			[param: In]
			set;
		}

		[DispId(20)]
		string LocalAppPackageId
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(20)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(21)]
		string LocalUserOwner
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(21)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(21)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(22)]
		string LocalUserAuthorizedList
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(22)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(22)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(23)]
		string RemoteUserAuthorizedList
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(23)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(23)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(24)]
		string RemoteMachineAuthorizedList
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(24)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(24)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(25)]
		int SecureFlags
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(25)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(25)]
			[param: In]
			set;
		}
	}
}
