namespace NetFwTypeLib
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport]
	
	[Guid("98325047-C671-4174-8D81-DEFCD3F03186")]
	public interface INetFwPolicy2
	{
		[DispId(1)]
		int CurrentProfileTypes
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1)]
			get;
		}

		[DispId(2)]
		bool FirewallEnabled
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
		object ExcludedInterfaces
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
		}

		[DispId(4)]
		bool BlockAllInboundTraffic
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
		bool NotificationsDisabled
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
		bool UnicastResponsesToMulticastBroadcastDisabled
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
		INetFwRules Rules
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(8)]
		INetFwServiceRestriction ServiceRestriction
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(12)]
		NET_FW_ACTION_ DefaultInboundAction
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(12)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(12)]
			[param: In]
			set;
		}

		[DispId(13)]
		NET_FW_ACTION_ DefaultOutboundAction
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(13)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(13)]
			[param: In]
			set;
		}

		[DispId(14)]
		bool IsRuleGroupCurrentlyEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(14)]
			get;
		}

		[DispId(15)]
		NET_FW_MODIFY_STATE_ LocalPolicyModifyState
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(15)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(9)]
		void EnableRuleGroup([In] int profileTypesBitmask, [In][MarshalAs(UnmanagedType.BStr)] string group, [In] bool enable);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(10)]
		bool IsRuleGroupEnabled([In] int profileTypesBitmask, [In][MarshalAs(UnmanagedType.BStr)] string group);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(11)]
		void RestoreLocalFirewallDefaults();
	}
}
