namespace NetFwTypeLib
{
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("9C4C6277-5027-441E-AFAE-CA1F542DA009")]
	
	public interface INetFwRules : IEnumerable
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
		void Add([In][MarshalAs(UnmanagedType.Interface)] INetFwRule rule);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(3)]
		void Remove([In][MarshalAs(UnmanagedType.BStr)] string Name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwRule Item([In][MarshalAs(UnmanagedType.BStr)] string Name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(-4)]
		[TypeLibFunc(1)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}
}
