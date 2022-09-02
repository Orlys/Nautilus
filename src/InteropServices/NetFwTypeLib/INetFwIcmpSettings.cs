namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	[Guid("A6207B2E-7CDD-426A-951E-5E1CBC5AFEAD")]
	
	public interface INetFwIcmpSettings
	{
		[DispId(1)]
		bool AllowOutboundDestinationUnreachable
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
		bool AllowRedirect
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
		bool AllowInboundEchoRequest
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
		bool AllowOutboundTimeExceeded
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
		bool AllowOutboundParameterProblem
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
		bool AllowOutboundSourceQuench
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		bool AllowInboundRouterRequest
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
		bool AllowInboundTimestampRequest
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[param: In]
			set;
		}

		[DispId(9)]
		bool AllowInboundMaskRequest
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(9)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(9)]
			[param: In]
			set;
		}

		[DispId(10)]
		bool AllowOutboundPacketTooBig
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(10)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(10)]
			[param: In]
			set;
		}
	}
}
