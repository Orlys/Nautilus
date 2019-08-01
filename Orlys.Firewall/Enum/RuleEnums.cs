// Author: Orlys
// Github: https://github.com/Orlys

namespace SyncTyrant.Firewall.Enum
{   
    using System;

    /// <summary>
    /// 防火牆規則動作
    /// </summary>
    public enum RuleAction : byte
    {
        /// <summary>
        /// 封鎖
        /// </summary>
        Block,
        /// <summary>
        /// 允許
        /// </summary>
        Allow
    }

    /// <summary>
    /// 防火牆流向
    /// </summary>
    public enum RuleDirection : byte
    {
        /// <summary>
        /// 輸入
        /// </summary>
        Incoming = 1,
        /// <summary>
        /// 輸出
        /// </summary>
        Outgoing
    }

    /// <summary>
    /// 套用規則的介面類型
    /// </summary>
    [Flags]
    public enum RuleInterfaceTypes : byte
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = RemoteAccess | Wireless | Lan,
        /// <summary>
        /// 遠端存取
        /// </summary>
        RemoteAccess = 1,
        /// <summary>
        /// 無線網路
        /// </summary>
        Wireless = 2,
        /// <summary>
        /// 區域網路
        /// </summary>
        Lan = 4
    } 

    /// <summary>
    /// 設定檔
    /// </summary>
    [Flags]
    public enum RuleProfiles : int
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = int.MaxValue,
        /// <summary>
        /// 網域
        /// </summary>
        Domain = 1,
        /// <summary>
        /// 私人
        /// </summary>
        Private = 2,
        /// <summary>
        /// 公用
        /// </summary>
        Public = 4
    }

}