namespace NetFwTypeLib
{
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("39EB36E0-2097-40BD-8AF2-63A13B525362")]
	
	public interface INetFwProducts : IEnumerable
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
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object Register([In][MarshalAs(UnmanagedType.Interface)] INetFwProduct product);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwProduct Item([In] int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[TypeLibFunc(1)]
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}
}
