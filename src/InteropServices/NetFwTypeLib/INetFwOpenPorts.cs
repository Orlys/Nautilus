namespace NetFwTypeLib
{
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("C0E9D7FA-E07E-430A-B19A-090CE82D92E2")]
	
	public interface INetFwOpenPorts : IEnumerable
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
		void Add([In][MarshalAs(UnmanagedType.Interface)] INetFwOpenPort Port);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(3)]
		void Remove([In] int portNumber, [In] NET_FW_IP_PROTOCOL_ ipProtocol);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		INetFwOpenPort Item([In] int portNumber, [In] NET_FW_IP_PROTOCOL_ ipProtocol);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(-4)]
		[TypeLibFunc(1)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}
}
