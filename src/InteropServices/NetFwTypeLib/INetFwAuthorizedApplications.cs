namespace NetFwTypeLib
{
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("644EFD52-CCF9-486C-97A2-39F352570B30")]
	public interface INetFwAuthorizedApplications : IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(2)]
		void Add([In][MarshalAs(UnmanagedType.Interface)] INetFwAuthorizedApplication app);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(3)]
		void Remove([In][MarshalAs(UnmanagedType.BStr)] string imageFileName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwAuthorizedApplication Item([In][MarshalAs(UnmanagedType.BStr)] string imageFileName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[TypeLibFunc(1)]
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}
}
