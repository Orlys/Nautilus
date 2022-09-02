namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("D4BECDDF-6F73-4A83-B832-9C66874CD20E")]
	public interface INetFwRemoteAdminSettings
	{
		[DispId(1)]
		NET_FW_IP_VERSION_ IpVersion
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		NET_FW_SCOPE_ Scope
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
		string RemoteAddresses
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
		bool Enabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(4)]
			[param: In]
			set;
		}
	}
}
