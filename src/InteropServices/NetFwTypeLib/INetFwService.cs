namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("79FD57C8-908E-4A36-9888-D5B3F0A444CF")]
	public interface INetFwService
	{
		[DispId(1)]
		string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		NET_FW_SERVICE_TYPE_ Type
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(2)]
			get;
		}

		[DispId(3)]
		bool Customized
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			get;
		}

		[DispId(4)]
		NET_FW_IP_VERSION_ IpVersion
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
		NET_FW_SCOPE_ Scope
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
		string RemoteAddresses
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
		bool Enabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			[param: In]
			set;
		}

		[DispId(8)]
		INetFwOpenPorts GloballyOpenPorts
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}
}
