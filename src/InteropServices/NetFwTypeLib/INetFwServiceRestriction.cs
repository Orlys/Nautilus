namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("8267BBE3-F890-491C-B7B6-2DB1EF0E5D2B")]
	public interface INetFwServiceRestriction
	{
		[DispId(3)]
		INetFwRules Rules
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1)]
		void RestrictService([In][MarshalAs(UnmanagedType.BStr)] string serviceName, [In][MarshalAs(UnmanagedType.BStr)] string appName, [In] bool RestrictService, [In] bool serviceSidRestricted);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(2)]
		bool ServiceRestricted([In][MarshalAs(UnmanagedType.BStr)] string serviceName, [In][MarshalAs(UnmanagedType.BStr)] string appName);
	}
}
