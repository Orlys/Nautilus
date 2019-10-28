// Author: Orlys
// Github: https://github.com/Orlys

namespace Orlys.Firewall.Enums
{
    using System;

    /// <summary>
    /// 防火牆規則動作
    /// </summary>
    public enum Action : byte
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
    public enum Direction : byte
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
    public enum InterfaceTypes : byte
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
    /// 防火牆設定檔。
    /// </summary>
    [Flags]
    public enum Profiles : int
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = int.MaxValue,

        /// <summary>
        /// 公用。
        /// 當網路介面卡連線至公用網路 (例如在機場以及咖啡店)，則會套用至網路介面卡。
        /// 公用網路是指電腦與網際網路之間沒有安全性裝置的網路。
        /// 由於電腦連線至公用網路時並無法控制其安全性，因此公用設定檔設定應最為嚴格。
        /// </summary>
        Public = 4,

        /// <summary>
        /// 私人。
        /// 當網路介面卡連接的網路被系統管理員認定為私人網路，則會套用至網路介面卡。
        /// 私人網路是指未直接連線至網際網路的網路，但是它是在某些安全性裝置後面，例如網路位址轉譯 (NAT) 路由器或硬體防火牆。
        /// 私人設定檔的設定應該比網域設定檔的設定限制更多。
        /// </summary>
        Private = 2,

        /// <summary>
        /// 網域。
        /// 當網路介面卡連接至某個網路，同時可以在這個網路偵測到電腦所加入網域中的網域控制站，則會套用至網路介面卡。
        /// </summary>
        Domain = 1
    }
}