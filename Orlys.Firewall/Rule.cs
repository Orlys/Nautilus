﻿
namespace Orlys.Firewall
{


    using NetFwTypeLib;
    using Orlys.Firewall.Internal;
    using System.Collections;
    using Orlys.Firewall.Collections; 
    using Orlys.Firewall.Enums;
    using Guid = System.Guid; 
    using NotSupported = System.NotSupportedException;
    using Orlys.Firewall.Models;

    /// <summary>
    /// 規則物件
    /// </summary>
    public sealed class Rule : IRule, IAdvanceRule
    {
        private readonly INetFwRule _r;

        /// <summary>
        /// 唯一識別 ID
        /// </summary>
        public Guid Id { get; }

        internal Rule(System.Action<string> removeDelegate, INetFwRule rule, Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
            this._r = rule;
            this.Enabled = true;

            this.RemotePorts = SeparatedList<PortRange>.Parse(_r.RemotePorts, onStringUpdated: x => _r.RemotePorts = x);
            this.LocalPorts = SeparatedList<PortRange>.Parse(_r.LocalPorts, onStringUpdated: x => _r.LocalPorts = x);
            this.LocalAddresses = SeparatedList<IPAddressRange>.Parse(_r.LocalAddresses, onStringUpdated: x => _r.LocalAddresses = x);
            this.RemoteAddresses = SeparatedList<IPAddressRange>.Parse(_r.RemoteAddresses, onStringUpdated: x => _r.RemoteAddresses = x);
        }

        /// <summary>
        /// 遠端連接埠
        /// </summary>
        public SeparatedList<PortRange> RemotePorts { get; }

        /// <summary>
        /// 本地連接埠
        /// </summary>
        public SeparatedList<PortRange> LocalPorts { get; }

        /// <summary>
        /// 本地位置
        /// </summary>
        public SeparatedList<IPAddressRange> LocalAddresses { get; }

        /// <summary>
        /// 遠端位置
        /// </summary>
        public SeparatedList<IPAddressRange> RemoteAddresses { get; }

        #region Properties
        /// <summary>
        /// 規則動作
        /// </summary>
        public Action Action
        {
            get { return _r.Action.CastByValue<Action>(); }
            set { _r.Action = value.CastByValue<NET_FW_ACTION_>(); }
        }

        /// <summary>
        /// 連線流向
        /// </summary>
        public Direction Direction
        {
            get { return _r.Direction.CastByValue<Direction>(); }
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
        public Protocol Protocol { get => _r.Protocol; set => _r.Protocol = value; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get => this._r.Description; set => this._r.Description = value; }

        /// <summary>
        /// 應用程式名稱
        /// </summary>
        string IAdvanceRule.ApplicationName { get => this._r.ApplicationName; set => this._r.ApplicationName = value; }

        /// <summary>
        /// 服務名稱
        /// </summary>
        string IAdvanceRule.ServiceName { get => this._r.serviceName; set => this._r.serviceName = value; }

        /// <summary>
        /// ICMP 協定設定
        /// </summary>
        /// <see cref="http://bit.ly/2Ytw71t"/>
        string IAdvanceRule.IcmpTypesAndCodes
        {
            get
            {
                if (!this.Protocol?.SupportedIcmpConfig ?? false)
                    throw new NotSupported();
                return this._r.IcmpTypesAndCodes;
            }
            set
            {
                if (!this.Protocol?.SupportedIcmpConfig ?? false)
                    throw new NotSupported();
                this._r.IcmpTypesAndCodes = value;
            }
        }

        /// <summary>
        /// 介面類型
        /// </summary>
        public InterfaceTypes InterfaceTypes
        {
            get => this._r.InterfaceTypes.Implode<InterfaceTypes>();
            set
            {
                if (value == InterfaceTypes.All)
                    this._r.InterfaceTypes = value.ToString();
                else
                    this._r.InterfaceTypes = string.Join(",", value.Explode());
            }
        }

        /// <summary>
        /// 設定檔
        /// </summary>
        public Profiles Profiles { get => (Profiles)this._r.Profiles; set => this._r.Profiles = (int)value; }

        /// <summary>
        /// 群組
        /// </summary>
        public string Grouping => _r.Grouping;

        /// <summary>
        /// 群組
        /// </summary>
        string IAdvanceRule.Grouping
        {
            get => _r.Grouping;
            set => _r.Grouping = value;
        }

        #endregion
    }
}