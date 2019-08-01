#pragma warning disable CS0612
namespace Orlys.Firewall.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// </summary>
    /// <see cref="https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xml"/>

    public sealed class RichProtocol
    {
        private static readonly RichProtocol[] s_protocols = new RichProtocol[257];

        /// <summary>
        /// IPv6 Hop-by-Hop Option
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RichProtocol HOPOPT => s_protocols[0];

        /// <summary>
        /// Internet Control Message
        /// </summary>
        /// <remarks>[RFC792]</remarks> 
        public static RichProtocol ICMP => s_protocols[1];

        /// <summary>
        /// Internet Group Management
        /// </summary>
        /// <remarks>[RFC1112]</remarks> 
        public static RichProtocol IGMP => s_protocols[2];

        /// <summary>
        /// Gateway-to-Gateway
        /// </summary>
        /// <remarks>[RFC823]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol GGP => s_protocols[3];

        /// <summary>
        /// IPv4 encapsulation
        /// </summary>
        /// <remarks>[RFC2003]</remarks> 
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPv4 => s_protocols[4];

        /// <summary>
        /// Stream
        /// </summary>
        /// <remarks>[RFC1190][RFC1819]</remarks> 
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ST => s_protocols[5];

        /// <summary>
        /// Transmission Control
        /// </summary>
        /// <remarks>[RFC793]</remarks> 
        public static RichProtocol TCP => s_protocols[6];

        /// <summary>
        /// CBT
        /// </summary>
        /// <remarks>[Tony_Ballardie]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CBT => s_protocols[7];

        /// <summary>
        /// Exterior Gateway Protocol
        /// </summary>
        /// <remarks>[RFC888][David_Mills]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol EGP => s_protocols[8];

        /// <summary>
        /// any private interior gateway (used by Cisco for their IGRP)
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IGP => s_protocols[9];

        /// <summary>
        /// BBN RCC Monitoring
        /// </summary>
        /// <remarks>[Steve_Chipman]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol BBN_RCC_MON => s_protocols[10];

        /// <summary>
        /// Network Voice Protocol
        /// </summary>
        /// <remarks>[RFC741][Steve_Casner]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol NVP_II => s_protocols[11];

        /// <summary>
        /// PUP
        /// </summary>
        /// <remarks>
        /// [Boggs, D., J. Shoch, E. Taft, and R. Metcalfe, PUP: An Internetwork Architecture, XEROX
        /// Palo Alto Research Center, CSL-79-10, July 1979; also in IEEE Transactions on
        /// Communication, Volume COM-28, Number 4, April 1980.][[XEROX]]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PUP => s_protocols[12];

        /// <summary>
        /// ARGUS
        /// </summary>
        /// <remarks>(deprecated) [Robert_W_Scheifler]</remarks>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RichProtocol ARGUS => s_protocols[13];

        /// <summary> EMCON </summary> <remarks> [<mystery contact>] </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol EMCON => s_protocols[14];

        /// <summary>
        /// Cross Net Debugger
        /// </summary>
        /// <remarks>
        /// [Haverty, J., XNET Formats for Internet Protocol Version 4, IEN 158, October 1980.][Jack_Haverty]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol XNET => s_protocols[15];

        /// <summary>
        /// Chaos
        /// </summary>
        /// <remarks>[J_Noel_Chiappa]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CHAOS => s_protocols[16];

        /// <summary>
        /// User Datagram
        /// </summary>
        /// <remarks>[RFC768][Jon_Postel]</remarks>
        public static RichProtocol UDP => s_protocols[17];

        /// <summary>
        /// Multiplexing
        /// </summary>
        /// <remarks>
        /// [Cohen, D. and J. Postel, Multiplexing Protocol, IEN 90, USC/Information Sciences
        /// Institute, May 1979.][Jon_Postel]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MUX => s_protocols[18];

        /// <summary>
        /// DCN Measurement Subsystems
        /// </summary>
        /// <remarks>[David_Mills]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DCN_MEAS => s_protocols[19];

        /// <summary>
        /// Host Monitoring
        /// </summary>
        /// <remarks>[RFC869][Bob_Hinden]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol HMP => s_protocols[20];

        /// <summary>
        /// Packet Radio Measurement
        /// </summary>
        /// <remarks>[Zaw_Sing_Su]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PRM => s_protocols[21];

        /// <summary>
        /// XEROX NS IDP
        /// </summary>
        /// <remarks>
        /// [The Ethernet, A Local Area Network: Data Link Layer and Physical Layer Specification,
        /// AA-K759B-TK, Digital Equipment Corporation, Maynard, MA. Also as: The Ethernet - A Local
        /// Area Network, Version 1.0, Digital Equipment Corporation, Intel Corporation, Xerox
        /// Corporation, September 1980. And: The Ethernet, A Local Area Network: Data Link Layer and
        /// Physical Layer Specifications, Digital, Intel and Xerox, November 1982.
        /// And: XEROX, The Ethernet, A Local Area Network: Data Link Layer and Physical Layer
        /// Specification, X3T51/80-50, Xerox Corporation, Stamford, CT., October 1980.][[XEROX]]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol XNS_IDP => s_protocols[22];

        /// <summary>
        /// Trunk-1
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TRUNK_1 => s_protocols[23];

        /// <summary>
        /// Trunk-2
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TRUNK_2 => s_protocols[24];

        /// <summary>
        /// Leaf-1
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol LEAF_1 => s_protocols[25];

        /// <summary>
        /// Leaf-2
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol LEAF_2 => s_protocols[26];

        /// <summary>
        /// Reliable Data Protocol
        /// </summary>
        /// <remarks>[RFC908][Bob_Hinden]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol RDP => s_protocols[27];

        /// <summary>
        /// Internet Reliable Transaction
        /// </summary>
        /// <remarks>[RFC938][Trudy_Miller]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IRTP => s_protocols[28];

        /// <summary> ISO Transport Protocol Class 4 </summary> <remarks> [RFC905][<mystery contact>] </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ISO_TP4 => s_protocols[29];

        /// <summary>
        /// Bulk Data Transfer Protocol
        /// </summary>
        /// <remarks>[RFC969][David_Clark]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol NETBLT => s_protocols[30];

        /// <summary>
        /// MFE Network Services Protocol
        /// </summary>
        /// <remarks>
        /// [Shuttleworth, B., A Documentary of MFENet, a National Computer Network, UCRL-52317,
        /// Lawrence Livermore Labs, Livermore, California, June 1977.][Barry_Howard]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MFE_NSP => s_protocols[31];

        /// <summary>
        /// MERIT Internodal Protocol
        /// </summary>
        /// <remarks>[Hans_Werner_Braun]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MERIT_INP => s_protocols[32];

        /// <summary>
        /// Datagram Congestion Control Protocol
        /// </summary>
        /// <remarks>[RFC4340]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DCCP => s_protocols[33];

        /// <summary>
        /// Third Party Connect Protocol
        /// </summary>
        /// <remarks>[Stuart_A_Friedberg]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ThirdPC => s_protocols[34];

        /// <summary>
        /// Inter-Domain Policy Routing Protocol
        /// </summary>
        /// <remarks>[Martha_Steenstrup]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IDPR => s_protocols[35];

        /// <summary>
        /// XTP
        /// </summary>
        /// <remarks>[Greg_Chesson]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol XTP => s_protocols[36];

        /// <summary>
        /// Datagram Delivery Protocol
        /// </summary>
        /// <remarks>[Wesley_Craig]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DDP => s_protocols[37];

        /// <summary>
        /// IDPR Control Message Transport Proto
        /// </summary>
        /// <remarks>[Martha_Steenstrup]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IDPR_CMTP => s_protocols[38];

        /// <summary>
        /// TP++ Transport Protocol
        /// </summary>
        /// <remarks>[Dirk_Fromhein]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TPplusplus => s_protocols[39];

        /// <summary>
        /// IL Transport Protocol
        /// </summary>
        /// <remarks>[Dave_Presotto]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IL => s_protocols[40];

        /// <summary>
        /// IPv6 encapsulation
        /// </summary>
        /// <remarks>[RFC2473]</remarks> 
        public static RichProtocol IPv6 => s_protocols[41];

        /// <summary>
        /// Source Demand Routing Protocol
        /// </summary>
        /// <remarks>[Deborah_Estrin]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SDRP => s_protocols[42];

        /// <summary>
        /// Routing Header for IPv6
        /// </summary>
        /// <remarks>[Steve_Deering]</remarks> 
        public static RichProtocol IPv6_Route => s_protocols[43];

        /// <summary>
        /// Fragment Header for IPv6
        /// </summary>
        /// <remarks>[Steve_Deering]</remarks> 
        public static RichProtocol IPv6_Frag => s_protocols[44];

        /// <summary>
        /// Inter-Domain Routing Protocol
        /// </summary>
        /// <remarks>[Sue_Hares]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IDRP => s_protocols[45];

        /// <summary>
        /// Reservation Protocol
        /// </summary>
        /// <remarks>[RFC2205][RFC3209][Bob_Braden]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol RSVP => s_protocols[46];

        /// <summary>
        /// Generic Routing Encapsulation
        /// </summary>
        /// <remarks>[RFC2784][Tony_Li]</remarks> 
        public static RichProtocol GRE => s_protocols[47];

        /// <summary>
        /// Dynamic Source Routing Protocol
        /// </summary>
        /// <remarks>[RFC4728]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DSR => s_protocols[48];

        /// <summary>
        /// BNA
        /// </summary>
        /// <remarks>[Gary Salamon]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol BNA => s_protocols[49];

        /// <summary>
        /// Encap Security Payload
        /// </summary>
        /// <remarks>[RFC4303]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ESP => s_protocols[50];

        /// <summary>
        /// Authentication Header
        /// </summary>
        /// <remarks>[RFC4302]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AH => s_protocols[51];

        /// <summary>
        /// Integrated Net Layer Security TUBA
        /// </summary>
        /// <remarks>[K_Robert_Glenn]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol I_NLSP => s_protocols[52];

        /// <summary>
        /// IP with Encryption
        /// </summary>
        /// <remarks>(deprecated) [John_Ioannidis]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RichProtocol SWIPE => s_protocols[53];

        /// <summary>
        /// NBMA Address Resolution Protocol
        /// </summary>
        /// <remarks>[RFC1735]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol NARP => s_protocols[54];

        /// <summary>
        /// IP Mobility
        /// </summary>
        /// <remarks>[Charlie_Perkins]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MOBILE => s_protocols[55];

        /// <summary>
        /// Transport Layer Security Protocol using Kryptonet key management
        /// </summary>
        /// <remarks>[Christer_Oberg]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TLSP => s_protocols[56];

        /// <summary>
        /// SKIP
        /// </summary>
        /// <remarks>[Tom_Markson]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SKIP => s_protocols[57];

        /// <summary>
        /// ICMP for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RichProtocol IPv6_ICMP => s_protocols[58];

        /// <summary>
        /// No Next Header for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RichProtocol IPv6_NoNxt => s_protocols[59];

        /// <summary>
        /// Destination Options for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RichProtocol IPv6_Opts => s_protocols[60];

        /// <summary>
        /// any host internal protocol
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AnyHostInternalProtocol => s_protocols[61];

        /// <summary>
        /// CFTP
        /// </summary>
        /// <remarks>
        /// [Forsdick, H., CFTP, Network Message, Bolt Beranek and
        ///Newman, January 1982.][Harry_Forsdick]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CFTP => s_protocols[62];

        /// <summary>
        /// any local network
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AnyLocalNetwork => s_protocols[63];

        /// <summary>
        /// SATNET and Backroom EXPAK
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SAT_EXPAK => s_protocols[64];

        /// <summary>
        /// Kryptolan
        /// </summary>
        /// <remarks>[Paul Liu]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol KRYPTOLAN => s_protocols[65];

        /// <summary>
        /// MIT Remote Virtual Disk Protocol
        /// </summary>
        /// <remarks>[Michael_Greenwald]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol RVD => s_protocols[66];

        /// <summary>
        /// Internet Pluribus Packet Core
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPPC => s_protocols[67];

        /// <summary>
        /// any distributed file system
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AnyDistributedFileSystem => s_protocols[68];

        /// <summary>
        /// SATNET Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SAT_MON => s_protocols[69];

        /// <summary>
        /// VISA Protocol
        /// </summary>
        /// <remarks>[Gene_Tsudik]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol VISA => s_protocols[70];

        /// <summary>
        /// Internet Packet Core Utility
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPCV => s_protocols[71];

        /// <summary>
        /// Computer Protocol Network Executive
        /// </summary>
        /// <remarks>[David Mittnacht]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CPNX => s_protocols[72];

        /// <summary>
        /// Computer Protocol Heart Beat
        /// </summary>
        /// <remarks>[David Mittnacht]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CPHB => s_protocols[73];

        /// <summary>
        /// Wang Span Network
        /// </summary>
        /// <remarks>[Victor Dafoulas]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol WSN => s_protocols[74];

        /// <summary>
        /// Packet Video Protocol
        /// </summary>
        /// <remarks>[Steve_Casner]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PVP => s_protocols[75];

        /// <summary>
        /// Backroom SATNET Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol BR_SAT_MON => s_protocols[76];

        /// <summary>
        /// SUN ND PROTOCOL-Temporary
        /// </summary>
        /// <remarks>[William_Melohn]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SUN_ND => s_protocols[77];

        /// <summary>
        /// WIDEBAND Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol WB_MON => s_protocols[78];

        /// <summary>
        /// WIDEBAND EXPAK
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol WB_EXPAK => s_protocols[79];

        /// <summary>
        /// ISO Internet Protocol
        /// </summary>
        /// <remarks>[Marshall_T_Rose]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ISO_IP => s_protocols[80];

        /// <summary>
        /// VMTP
        /// </summary>
        /// <remarks>[Dave_Cheriton]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol VMTP => s_protocols[81];

        /// <summary>
        /// SECURE-VMTP
        /// </summary>
        /// <remarks>[Dave_Cheriton]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SECURE_VMTP => s_protocols[82];

        /// <summary>
        /// VINES
        /// </summary>
        /// <remarks>[Brian Horn]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol VINES => s_protocols[83];

        /// <summary>
        /// Transaction Transport Protocol or Internet Protocol Traffic Manager
        /// </summary>
        /// <remarks>[Jim_Stevens]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TTP_or_IPTM => s_protocols[84];

        /// <summary>
        /// NSFNET-IGP
        /// </summary>
        /// <remarks>[Hans_Werner_Braun]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol NSFNET_IGP => s_protocols[85];

        /// <summary>
        /// Dissimilar Gateway Protocol
        /// </summary>
        /// <remarks>
        /// [M/A-COM Government Systems, Dissimilar Gateway Protocol
        ///Specification, Draft Version, Contract no.CS901145,
        ///November 16, 1987.][Mike_Little]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DGP => s_protocols[86];

        /// <summary>
        /// TCF
        /// </summary>
        /// <remarks>[Guillermo_A_Loyola]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol TCF => s_protocols[87];

        /// <summary>
        /// EIGRP
        /// </summary>
        /// <remarks>[RFC7868]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol EIGRP => s_protocols[88];

        /// <summary>
        /// OSPFIGP
        /// </summary>
        /// <remarks>[RFC1583][RFC2328][RFC5340][John_Moy]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol OSPFIGP => s_protocols[89];

        /// <summary>
        /// Sprite RPC Protocol
        /// </summary>
        /// <remarks>
        /// [Welch, B., The Sprite Remote Procedure Call System,
        ///Technical Report, UCB/Computer Science Dept., 86/302,
        ///University of California at Berkeley, June 1986.][Bruce Willins]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol Sprite_RPC => s_protocols[90];

        /// <summary>
        /// Locus Address Resolution Protocol
        /// </summary>
        /// <remarks>[Brian Horn]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol LARP => s_protocols[91];

        /// <summary>
        /// Multicast Transport Protocol
        /// </summary>
        /// <remarks>[Susie_Armstrong]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MTP => s_protocols[92];

        /// <summary>
        /// AX.25 Frames
        /// </summary>
        /// <remarks>[Brian_Kantor]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AX_25 => s_protocols[93];

        /// <summary>
        /// IP-within-IP Encapsulation Protocol
        /// </summary>
        /// <remarks>[John_Ioannidis]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPIP => s_protocols[94];

        /// <summary>
        /// Mobile Internetworking Control Pro.
        /// </summary>
        /// <remarks>(deprecated) [John_Ioannidis]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RichProtocol MICP => s_protocols[95];

        /// <summary>
        /// Semaphore Communications Sec. Pro.
        /// </summary>
        /// <remarks>[Howard_Hart]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SCC_SP => s_protocols[96];

        /// <summary>
        /// Ethernet-within-IP Encapsulation
        /// </summary>
        /// <remarks>[RFC3378]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ETHERIP => s_protocols[97];

        /// <summary>
        /// Encapsulation Header
        /// </summary>
        /// <remarks>[RFC1241][Robert_Woodburn]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ENCAP => s_protocols[98];

        /// <summary>
        /// any private encryption scheme
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AnyPrivateEncryptionScheme => s_protocols[99];

        /// <summary>
        /// GMTP
        /// </summary>
        /// <remarks>[[RXB5]]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol GMTP => s_protocols[100];

        /// <summary>
        /// Ipsilon Flow Management Protocol
        /// </summary>
        /// <remarks>[Bob_Hinden][November 1995, 1997.]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IFMP => s_protocols[101];

        /// <summary>
        /// PNNI over IP
        /// </summary>
        /// <remarks>[Ross_Callon]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PNNI => s_protocols[102];

        /// <summary>
        /// Protocol Independent Multicast
        /// </summary>
        /// <remarks>[RFC7761][Dino_Farinacci]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PIM => s_protocols[103];

        /// <summary>
        /// ARIS
        /// </summary>
        /// <remarks>[Nancy_Feldman]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ARIS => s_protocols[104];

        /// <summary>
        /// SCPS
        /// </summary>
        /// <remarks>[Robert_Durst]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SCPS => s_protocols[105];

        /// <summary>
        /// QNX
        /// </summary>
        /// <remarks>[Michael_Hunter]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol QNX => s_protocols[106];

        /// <summary>
        /// Active Networks
        /// </summary>
        /// <remarks>[Bob_Braden]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ActiveNetworks => s_protocols[107];

        /// <summary>
        /// IP Payload Compression Protocol
        /// </summary>
        /// <remarks>[RFC2393]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPComp => s_protocols[108];

        /// <summary>
        /// Sitara Networks Protocol
        /// </summary>
        /// <remarks>[Manickam_R_Sridhar]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SNP => s_protocols[109];

        /// <summary>
        /// Compaq Peer Protocol
        /// </summary>
        /// <remarks>[Victor_Volpe]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CompaqPeer => s_protocols[110];

        /// <summary>
        /// IPX in IP
        /// </summary>
        /// <remarks>[CJ_Lee]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPX_in_IP => s_protocols[111];

        /// <summary>
        /// Virtual Router Redundancy Protocol
        /// </summary>
        /// <remarks>[RFC5798]</remarks> 
        public static RichProtocol VRRP => s_protocols[112];

        /// <summary>
        /// PGM Reliable Transport Protocol
        /// </summary>
        /// <remarks>[Tony_Speakman]</remarks> 
        public static RichProtocol PGM => s_protocols[113];

        /// <summary>
        /// any 0-hop protocol
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol AnyZeroHopProtocol => s_protocols[114];

        /// <summary>
        /// Layer Two Tunneling Protocol
        /// </summary>
        /// <remarks>[RFC3931][Bernard_Aboba]</remarks> 
        public static RichProtocol L2TP => s_protocols[115];

        /// <summary>
        /// D-II Data Exchange (DDX)
        /// </summary>
        /// <remarks>[John_Worley]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol DDX => s_protocols[116];

        /// <summary>
        /// Interactive Agent Transfer Protocol
        /// </summary>
        /// <remarks>[John_Murphy]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IATP => s_protocols[117];

        /// <summary>
        /// Schedule Transfer Protocol
        /// </summary>
        /// <remarks>[Jean_Michel_Pittet]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol STP => s_protocols[118];

        /// <summary>
        /// SpectraLink Radio Protocol
        /// </summary>
        /// <remarks>[Mark_Hamilton]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SRP => s_protocols[119];

        /// <summary>
        /// UTI
        /// </summary>
        /// <remarks>[Peter_Lothberg]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol UTI => s_protocols[120];

        /// <summary>
        /// Simple Message Protocol
        /// </summary>
        /// <remarks>[Leif_Ekblad]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SMP => s_protocols[121];

        /// <summary>
        /// Simple Multicast Protocol
        /// </summary>
        /// <remarks>(deprecated) [Jon_Crowcroft][draft-perlman-simple-multicast]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RichProtocol SM => s_protocols[122];

        /// <summary>
        /// Performance Transparency Protocol
        /// </summary>
        /// <remarks>[Michael_Welzl]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PTP => s_protocols[123];

        /// <summary>
        /// ISIS over IPv4
        /// </summary>
        /// <remarks>[Tony_Przygienda]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ISIS_over_IPv4 => s_protocols[124];

        /// <summary>
        /// FIRE
        /// </summary>
        /// <remarks>[Criag_Partridge]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol FIRE => s_protocols[125];

        /// <summary>
        /// Combat Radio Transport Protocol
        /// </summary>
        /// <remarks>[Robert_Sautter]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CRTP => s_protocols[126];

        /// <summary>
        /// Combat Radio User Datagram
        /// </summary>
        /// <remarks>[Robert_Sautter]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol CRUDP => s_protocols[127];

        /// <summary>
        /// SSCOPMCE
        /// </summary>
        /// <remarks>[Kurt_Waber]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SSCOPMCE => s_protocols[128];

        /// <summary>
        /// IPLT
        /// </summary>
        /// <remarks>[[Hollbach]]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol IPLT => s_protocols[129];

        /// <summary>
        /// Secure Packet Shield
        /// </summary>
        /// <remarks>[Bill_McIntosh]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SPS => s_protocols[130];

        /// <summary>
        /// Private IP Encapsulation within IP
        /// </summary>
        /// <remarks>[Bernhard_Petri]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol PIPE => s_protocols[131];

        /// <summary>
        /// Stream Control Transmission Protocol
        /// </summary>
        /// <remarks>[Randall_R_Stewart]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol SCTP => s_protocols[132];

        /// <summary>
        /// Fibre Channel
        /// </summary>
        /// <remarks>[Murali_Rajagopal][RFC6172]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol FC => s_protocols[133];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC3175]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol RSVP_E2E_IGNORE => s_protocols[134];

        /// <summary>
        /// Mobility Header
        /// </summary>
        /// <remarks>[RFC6275]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MobilityHeader => s_protocols[135];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC3828]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol UDPLite => s_protocols[136];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC4023]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol MPLS_in_IP => s_protocols[137];

        /// <summary>
        /// MANET Protocols
        /// </summary>
        /// <remarks>[RFC5498]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol manet => s_protocols[138];

        /// <summary>
        /// Host Identity Protocol
        /// </summary>
        /// <remarks>[RFC7401]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol HIP => s_protocols[139];

        /// <summary>
        /// Shim6 Protocol
        /// </summary>
        /// <remarks>[RFC5533]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol Shim6 => s_protocols[140];

        /// <summary>
        /// Wrapped Encapsulating Security Payload
        /// </summary>
        /// <remarks>[RFC5840]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol WESP => s_protocols[141];

        /// <summary>
        /// Robust Header Compression
        /// </summary>
        /// <remarks>[RFC5858]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RichProtocol ROHC => s_protocols[142];

        /// <summary>
        /// Reserved
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        public static RichProtocol Reserved => s_protocols[255];

        /// <summary>
        /// Any
        /// </summary>
        public static RichProtocol Any => s_protocols[256];

        static RichProtocol()
        {
            s_protocols[0] = new RichProtocol(nameof(HOPOPT), 0, true);
            s_protocols[1] = new RichProtocol(nameof(ICMP), 1, false, true);
            s_protocols[2] = new RichProtocol(nameof(IGMP), 2);
            s_protocols[3] = new RichProtocol(nameof(GGP), 3);
            s_protocols[4] = new RichProtocol(nameof(IPv4), 4);
            s_protocols[5] = new RichProtocol(nameof(ST), 5);
            s_protocols[6] = new RichProtocol(nameof(TCP), 6);
            s_protocols[7] = new RichProtocol(nameof(CBT), 7);
            s_protocols[8] = new RichProtocol(nameof(EGP), 8);
            s_protocols[9] = new RichProtocol(nameof(IGP), 9);

            s_protocols[10] = new RichProtocol(nameof(BBN_RCC_MON), 10);
            s_protocols[11] = new RichProtocol(nameof(NVP_II), 11);
            s_protocols[12] = new RichProtocol(nameof(PUP), 12);
            s_protocols[13] = new RichProtocol(nameof(ARGUS), 13);
            s_protocols[14] = new RichProtocol(nameof(EMCON), 14);
            s_protocols[15] = new RichProtocol(nameof(XNET), 15);
            s_protocols[16] = new RichProtocol(nameof(CHAOS), 16);
            s_protocols[17] = new RichProtocol(nameof(UDP), 17);
            s_protocols[18] = new RichProtocol(nameof(MUX), 18);
            s_protocols[19] = new RichProtocol(nameof(DCN_MEAS), 19);

            s_protocols[20] = new RichProtocol(nameof(HMP), 20);
            s_protocols[21] = new RichProtocol(nameof(PRM), 21);
            s_protocols[22] = new RichProtocol(nameof(XNS_IDP), 22);
            s_protocols[23] = new RichProtocol(nameof(TRUNK_1), 23);
            s_protocols[24] = new RichProtocol(nameof(TRUNK_2), 24);
            s_protocols[25] = new RichProtocol(nameof(LEAF_1), 25);
            s_protocols[26] = new RichProtocol(nameof(LEAF_2), 26);
            s_protocols[27] = new RichProtocol(nameof(RDP), 27);
            s_protocols[28] = new RichProtocol(nameof(IRTP), 28);
            s_protocols[29] = new RichProtocol(nameof(ISO_TP4), 29);

            s_protocols[30] = new RichProtocol(nameof(NETBLT), 30);
            s_protocols[31] = new RichProtocol(nameof(MFE_NSP), 31);
            s_protocols[32] = new RichProtocol(nameof(MERIT_INP), 32);
            s_protocols[33] = new RichProtocol(nameof(DCCP), 33);
            s_protocols[34] = new RichProtocol(nameof(ThirdPC), 34);
            s_protocols[35] = new RichProtocol(nameof(IDPR), 35);
            s_protocols[36] = new RichProtocol(nameof(XTP), 36);
            s_protocols[37] = new RichProtocol(nameof(DDP), 37);
            s_protocols[38] = new RichProtocol(nameof(IDPR_CMTP), 38);
            s_protocols[39] = new RichProtocol(nameof(TPplusplus), 39);

            s_protocols[40] = new RichProtocol(nameof(IL), 40);
            s_protocols[41] = new RichProtocol(nameof(IPv6), 41);
            s_protocols[42] = new RichProtocol(nameof(SDRP), 42);
            s_protocols[43] = new RichProtocol(nameof(IPv6_Route), 43, true);
            s_protocols[44] = new RichProtocol(nameof(IPv6_Frag), 44, true);
            s_protocols[45] = new RichProtocol(nameof(IDRP), 45);
            s_protocols[46] = new RichProtocol(nameof(RSVP), 46);
            s_protocols[47] = new RichProtocol(nameof(GRE), 47);
            s_protocols[48] = new RichProtocol(nameof(DSR), 48);
            s_protocols[49] = new RichProtocol(nameof(BNA), 49);

            s_protocols[50] = new RichProtocol(nameof(ESP), 50, true);
            s_protocols[51] = new RichProtocol(nameof(AH), 51, true);
            s_protocols[52] = new RichProtocol(nameof(I_NLSP), 52);
            s_protocols[53] = new RichProtocol(nameof(SWIPE), 53);
            s_protocols[54] = new RichProtocol(nameof(NARP), 54);
            s_protocols[55] = new RichProtocol(nameof(MOBILE), 55);
            s_protocols[56] = new RichProtocol(nameof(TLSP), 56);
            s_protocols[57] = new RichProtocol(nameof(SKIP), 57);
            s_protocols[58] = new RichProtocol(nameof(IPv6_ICMP), 58, false, true);
            s_protocols[59] = new RichProtocol(nameof(IPv6_NoNxt), 59);

            s_protocols[60] = new RichProtocol(nameof(IPv6_Opts), 60, true);
            s_protocols[61] = new RichProtocol(nameof(AnyHostInternalProtocol), 61);
            s_protocols[62] = new RichProtocol(nameof(CFTP), 62);
            s_protocols[63] = new RichProtocol(nameof(AnyLocalNetwork), 63);
            s_protocols[64] = new RichProtocol(nameof(SAT_EXPAK), 64);
            s_protocols[65] = new RichProtocol(nameof(KRYPTOLAN), 65);
            s_protocols[66] = new RichProtocol(nameof(RVD), 66);
            s_protocols[67] = new RichProtocol(nameof(IPPC), 67);
            s_protocols[68] = new RichProtocol(nameof(AnyDistributedFileSystem), 68);
            s_protocols[69] = new RichProtocol(nameof(SAT_MON), 69);

            s_protocols[70] = new RichProtocol(nameof(VISA), 70);
            s_protocols[71] = new RichProtocol(nameof(IPCV), 71);
            s_protocols[72] = new RichProtocol(nameof(CPNX), 72);
            s_protocols[73] = new RichProtocol(nameof(CPHB), 73);
            s_protocols[74] = new RichProtocol(nameof(WSN), 74);
            s_protocols[75] = new RichProtocol(nameof(PVP), 75);
            s_protocols[76] = new RichProtocol(nameof(BR_SAT_MON), 76);
            s_protocols[77] = new RichProtocol(nameof(SUN_ND), 77);
            s_protocols[78] = new RichProtocol(nameof(WB_MON), 78);
            s_protocols[79] = new RichProtocol(nameof(WB_EXPAK), 79);

            s_protocols[80] = new RichProtocol(nameof(ISO_IP), 80);
            s_protocols[81] = new RichProtocol(nameof(VMTP), 81);
            s_protocols[82] = new RichProtocol(nameof(SECURE_VMTP), 82);
            s_protocols[83] = new RichProtocol(nameof(VINES), 83);
            s_protocols[84] = new RichProtocol(nameof(TTP_or_IPTM), 84);
            s_protocols[85] = new RichProtocol(nameof(NSFNET_IGP), 85);
            s_protocols[86] = new RichProtocol(nameof(DGP), 86);
            s_protocols[87] = new RichProtocol(nameof(TCF), 87);
            s_protocols[88] = new RichProtocol(nameof(EIGRP), 88);
            s_protocols[89] = new RichProtocol(nameof(OSPFIGP), 89);

            s_protocols[90] = new RichProtocol(nameof(Sprite_RPC), 90);
            s_protocols[91] = new RichProtocol(nameof(LARP), 91);
            s_protocols[92] = new RichProtocol(nameof(MTP), 92);
            s_protocols[93] = new RichProtocol(nameof(AX_25), 93);
            s_protocols[94] = new RichProtocol(nameof(IPIP), 94);
            s_protocols[95] = new RichProtocol(nameof(MICP), 95);
            s_protocols[96] = new RichProtocol(nameof(SCC_SP), 96);
            s_protocols[97] = new RichProtocol(nameof(ETHERIP), 97);
            s_protocols[98] = new RichProtocol(nameof(ENCAP), 98);
            s_protocols[99] = new RichProtocol(nameof(AnyPrivateEncryptionScheme), 99);

            s_protocols[100] = new RichProtocol(nameof(GMTP), 100);
            s_protocols[101] = new RichProtocol(nameof(IFMP), 101);
            s_protocols[102] = new RichProtocol(nameof(PNNI), 102);
            s_protocols[103] = new RichProtocol(nameof(PIM), 103);
            s_protocols[104] = new RichProtocol(nameof(ARIS), 104);
            s_protocols[105] = new RichProtocol(nameof(SCPS), 105);
            s_protocols[106] = new RichProtocol(nameof(QNX), 106);
            s_protocols[107] = new RichProtocol(nameof(ActiveNetworks), 107);
            s_protocols[108] = new RichProtocol(nameof(IPComp), 108);
            s_protocols[109] = new RichProtocol(nameof(SNP), 109);

            s_protocols[110] = new RichProtocol(nameof(CompaqPeer), 110);
            s_protocols[111] = new RichProtocol(nameof(IPX_in_IP), 111);
            s_protocols[112] = new RichProtocol(nameof(VRRP), 112);
            s_protocols[113] = new RichProtocol(nameof(PGM), 113);
            s_protocols[114] = new RichProtocol(nameof(AnyZeroHopProtocol), 114);
            s_protocols[115] = new RichProtocol(nameof(L2TP), 115);
            s_protocols[116] = new RichProtocol(nameof(DDX), 116);
            s_protocols[117] = new RichProtocol(nameof(IATP), 117);
            s_protocols[118] = new RichProtocol(nameof(STP), 118);
            s_protocols[119] = new RichProtocol(nameof(SRP), 119);

            s_protocols[120] = new RichProtocol(nameof(UTI), 120);
            s_protocols[121] = new RichProtocol(nameof(SMP), 121);
            s_protocols[122] = new RichProtocol(nameof(SM), 122);
            s_protocols[123] = new RichProtocol(nameof(PTP), 123);
            s_protocols[124] = new RichProtocol(nameof(ISIS_over_IPv4), 124);
            s_protocols[125] = new RichProtocol(nameof(FIRE), 125);
            s_protocols[126] = new RichProtocol(nameof(CRTP), 126);
            s_protocols[127] = new RichProtocol(nameof(CRUDP), 127);
            s_protocols[128] = new RichProtocol(nameof(SSCOPMCE), 128);
            s_protocols[129] = new RichProtocol(nameof(IPLT), 129);

            s_protocols[130] = new RichProtocol(nameof(SPS), 130);
            s_protocols[131] = new RichProtocol(nameof(PIPE), 131);
            s_protocols[132] = new RichProtocol(nameof(SCTP), 132);
            s_protocols[133] = new RichProtocol(nameof(FC), 133);
            s_protocols[134] = new RichProtocol(nameof(RSVP_E2E_IGNORE), 134);
            s_protocols[135] = new RichProtocol(nameof(MobilityHeader), 135, true);
            s_protocols[136] = new RichProtocol(nameof(UDPLite), 136);
            s_protocols[137] = new RichProtocol(nameof(MPLS_in_IP), 137);
            s_protocols[138] = new RichProtocol(nameof(manet), 138);
            s_protocols[139] = new RichProtocol(nameof(HIP), 139, true);

            s_protocols[140] = new RichProtocol(nameof(Shim6), 140, true);
            s_protocols[141] = new RichProtocol(nameof(WESP), 141);
            s_protocols[142] = new RichProtocol(nameof(ROHC), 142);

            for (byte offset = 143; offset <= 252; offset++)
            {
                s_protocols[offset] = new RichProtocol("Unassigned", offset);
            }
            s_protocols[253] = new RichProtocol("ExperimentationOrTesting", 253);
            s_protocols[254] = new RichProtocol("ExperimentationOrTesting", 254);

            s_protocols[255] = new RichProtocol(nameof(Reserved), 255);
            s_protocols[256] = new RichProtocol(nameof(Any), 256);
        }

        private RichProtocol(string name, short value) : this(name, value, false, false)
        {
        }

        private RichProtocol(string name, short value, bool hasIPv6ExtensionHeader, bool supportedIcmpConfig = false)
        {
            this.Name = name.Replace('_', '-');
            this.Value = value;
            this.HasIPv6ExtensionHeader = hasIPv6ExtensionHeader;
            this.SupportedIcmpConfig = supportedIcmpConfig;
        }

        public string Name { get; }

        public short Value { get; }

        public static implicit operator short(RichProtocol protocol)
        {
            return protocol.Value;
        }

        public static implicit operator RichProtocol(int value)
        {
            if (value > byte.MaxValue + 1 || value < byte.MinValue)
                throw new ArgumentOutOfRangeException(nameof(value));
            return s_protocols[value];
        }

        public static implicit operator RichProtocol(Protocol protocol)
        {
            return (int)protocol;
        }

        public bool HasIPv6ExtensionHeader { get; }
        public bool SupportedIcmpConfig { get; }

        public override int GetHashCode() => this.Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is ValueType v)
            {
                return this.GetHashCode().Equals(v.GetHashCode());
            }
            return false;
        }

        public override string ToString() => this.Name.ToString();
    }
}
#pragma warning restore CS0612