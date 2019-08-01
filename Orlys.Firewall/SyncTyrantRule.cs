// Author: Orlys
// Github: https://github.com/Orlys

namespace SyncTyrant
{
    using NetFwTypeLib;

    using SyncTyrant.Firewall.Collctions;
    using SyncTyrant.Firewall.Internal;
    using SyncTyrant.Firewall.Enum;
    using SyncTyrant.Firewall.Model; 

    using System;
    using System.Net;

    public sealed class SyncTyrantRule : IDisposable
    {
        private readonly INetFwRule _r;
        private readonly Action<string> _removeDelegate;


        internal SyncTyrantRule(Action<string> removeDelegate, INetFwRule rule)
        {
            this.CreatedTime = DateTime.Now;
            _removeDelegate = removeDelegate;
            _r = rule; 

            this.LocalPorts.OnStringUpdated += x => _r.LocalPorts = x;
            this.RemotePorts.OnStringUpdated += x => _r.RemotePorts = x; 
            this.LocalAddresses.OnStringUpdated += x => _r.LocalAddresses = x; 
            this.RemoteAddresses.OnStringUpdated += x => _r.RemoteAddresses = x; 
        }

        /// <summary>
        /// 遠端連接埠
        /// </summary>
        public Range<FixedPortRange> RemotePorts { get; } = new Range<FixedPortRange>();

        /// <summary>
        /// 本地位置
        /// </summary>
        public Range<FixedIPv4Range> LocalAddresses { get; } = new Range<FixedIPv4Range>();

        /// <summary>
        /// 本地連接埠
        /// </summary>
        public Range<FixedPortRange> LocalPorts { get; } = new Range<FixedPortRange>();

        /// <summary>
        /// 遠端位置
        /// </summary>
        public Range<FixedIPv4Range> RemoteAddresses { get; } = new Range<FixedIPv4Range>();

        /// <summary>
        /// 規則動作
        /// </summary>
        public RuleAction Action
        {
            get { return _r.Action.CastByValue<RuleAction>(); }
            set { _r.Action = value.CastByValue<NET_FW_ACTION_>(); }
        }

        /// <summary>
        /// 連線流向
        /// </summary>
        public RuleDirection Direction
        {
            get { return _r.Direction.CastByValue<RuleDirection>(); }
            set { _r.Direction = value.CastByValue<NET_FW_RULE_DIRECTION_>(); }
        }

        /// <summary>
        /// 啟用狀態
        /// </summary>
        public bool Enabled { get => _r.Enabled; set => _r.Enabled = value; }


        /// <summary>
        /// 規則名稱
        /// </summary>
        public string Name => _r.Name;

        /// <summary>
        /// 通訊協定
        /// </summary>
        public RuleProtocol Protocol { get => _r.Protocol; set => _r.Protocol = value; }


        /// <summary>
        /// 規則建立時間
        /// </summary>
        public DateTime CreatedTime { get; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get => this._r.Description; set => this._r.Description = value; }

        /// <summary>
        /// 應用程式名稱
        /// </summary>
        public string ApplicationName { get => this._r.ApplicationName; set => this._r.ApplicationName = value; }

        /// <summary>
        /// 服務名稱
        /// </summary>
        public string ServiceName { get => this._r.serviceName; set => this._r.serviceName = value; }

        /// <summary>
        /// ICMP 協定設定
        /// </summary>
        public string IcmpTypesAndCodes
        {
            get
            {
                if (!this.Protocol?.SupportedIcmpConfig ?? false)
                    throw new NotSupportedException();
                return this._r.IcmpTypesAndCodes;
            }
            set
            {
                if (!this.Protocol?.SupportedIcmpConfig ?? false)
                    throw new NotSupportedException();
                this._r.IcmpTypesAndCodes = value;
            }
        }

        /// <summary>
        /// 介面類型
        /// </summary>
        public RuleInterfaceTypes InterfaceTypes
        {
            get => this._r.InterfaceTypes.Implode<RuleInterfaceTypes>();
            set
            {
                if (value == RuleInterfaceTypes.All)
                    this._r.InterfaceTypes = value.ToString();
                else
                    this._r.InterfaceTypes = string.Join(",", value.Explode());
            }
        }

        /// <summary>
        /// 設定檔
        /// </summary>
        public RuleProfiles Profiles { get => (RuleProfiles)this._r.Profiles; set => this._r.Profiles = (int)value; }
        
        /// <summary>
        /// 刪除規則
        /// </summary>
        public void Dispose() => _removeDelegate.Invoke(_r.Name);

    }
}