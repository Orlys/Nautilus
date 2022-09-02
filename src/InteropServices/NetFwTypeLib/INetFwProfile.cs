namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("174A0DDA-E9F9-449D-993B-21AB667CA456")]
	
	public interface INetFwProfile
	{
		[DispId(1)]
		NET_FW_PROFILE_TYPE_ Type
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			get;
		}

		[DispId(2)]
		bool FirewallEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(2)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		bool ExceptionsNotAllowed
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		bool NotificationsDisabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			[param: In]
			set;
		}

		[DispId(5)]
		bool UnicastResponsesToMulticastBroadcastDisabled
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
		INetFwRemoteAdminSettings RemoteAdminSettings
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(7)]
		INetFwIcmpSettings IcmpSettings
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(8)]
		INetFwOpenPorts GloballyOpenPorts
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(9)]
		INetFwServices Services
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(10)]
		INetFwAuthorizedApplications AuthorizedApplications
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}
}
