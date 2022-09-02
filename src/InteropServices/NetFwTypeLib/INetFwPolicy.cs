namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("D46D2478-9AC9-4008-9DC7-5563CE5536CC")]
	public interface INetFwPolicy
	{
		[DispId(1)]
		INetFwProfile CurrentProfile
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwProfile GetProfileByType([In] NET_FW_PROFILE_TYPE_ profileType);
	}
}
