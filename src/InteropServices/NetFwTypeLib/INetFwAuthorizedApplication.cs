namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("B5E64FFA-C2C5-444E-A301-FB5E00018050")]
	public interface INetFwAuthorizedApplication
	{
		[DispId(1)]
		string Name
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
		string ProcessImageFileName
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
		NET_FW_IP_VERSION_ IpVersion
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
		NET_FW_SCOPE_ Scope
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
		string RemoteAddresses
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(5)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(6)]
		bool Enabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			[param: In]
			set;
		}
	}
}
