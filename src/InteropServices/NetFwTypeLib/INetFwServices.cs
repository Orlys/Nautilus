namespace NetFwTypeLib
{
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("79649BB4-903E-421B-94C9-79848E79F6EE")]
	
	public interface INetFwServices : IEnumerable
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
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwService Item([In] NET_FW_SERVICE_TYPE_ svcType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[TypeLibFunc(1)]
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}
}
