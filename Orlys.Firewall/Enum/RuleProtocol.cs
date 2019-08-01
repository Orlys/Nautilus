// Author: Orlys
// Github: https://github.com/Orlys
#pragma warning disable CS0612

namespace SyncTyrant.Firewall.Enum
{

    using System;
    using System.ComponentModel;

    /// <summary>
    /// </summary>
    /// <see cref="https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xml"/>

    public sealed class RuleProtocol
    {
        private static readonly RuleProtocol[] s_protocols = new RuleProtocol[257];

        /// <summary>
        /// IPv6 Hop-by-Hop Option
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RuleProtocol HOPOPT => s_protocols[0];

        /// <summary>
        /// Internet Control Message
        /// </summary>
        /// <remarks>[RFC792]</remarks> 
        public static RuleProtocol ICMP => s_protocols[1];

        /// <summary>
        /// Internet Group Management
        /// </summary>
        /// <remarks>[RFC1112]</remarks> 
        public static RuleProtocol IGMP => s_protocols[2];

        /// <summary>
        /// Gateway-to-Gateway
        /// </summary>
        /// <remarks>[RFC823]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)] 
        public static RuleProtocol GGP => s_protocols[3];

        /// <summary>
        /// IPv4 encapsulation
        /// </summary>
        /// <remarks>[RFC2003]</remarks> 
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPv4 => s_protocols[4];

        /// <summary>
        /// Stream
        /// </summary>
        /// <remarks>[RFC1190][RFC1819]</remarks> 
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ST => s_protocols[5];

        /// <summary>
        /// Transmission Control
        /// </summary>
        /// <remarks>[RFC793]</remarks> 
        public static RuleProtocol TCP => s_protocols[6];

        /// <summary>
        /// CBT
        /// </summary>
        /// <remarks>[Tony_Ballardie]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CBT => s_protocols[7];

        /// <summary>
        /// Exterior Gateway Protocol
        /// </summary>
        /// <remarks>[RFC888][David_Mills]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol EGP => s_protocols[8];

        /// <summary>
        /// any private interior gateway (used by Cisco for their IGRP)
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IGP => s_protocols[9];

        /// <summary>
        /// BBN RCC Monitoring
        /// </summary>
        /// <remarks>[Steve_Chipman]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol BBN_RCC_MON => s_protocols[10];

        /// <summary>
        /// Network Voice Protocol
        /// </summary>
        /// <remarks>[RFC741][Steve_Casner]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol NVP_II => s_protocols[11];

        /// <summary>
        /// PUP
        /// </summary>
        /// <remarks>
        /// [Boggs, D., J. Shoch, E. Taft, and R. Metcalfe, PUP: An Internetwork Architecture, XEROX
        /// Palo Alto Research Center, CSL-79-10, July 1979; also in IEEE Transactions on
        /// Communication, Volume COM-28, Number 4, April 1980.][[XEROX]]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PUP => s_protocols[12];

        /// <summary>
        /// ARGUS
        /// </summary>
        /// <remarks>(deprecated) [Robert_W_Scheifler]</remarks>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RuleProtocol ARGUS => s_protocols[13];

        /// <summary> EMCON </summary> <remarks> [<mystery contact>] </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol EMCON => s_protocols[14];

        /// <summary>
        /// Cross Net Debugger
        /// </summary>
        /// <remarks>
        /// [Haverty, J., XNET Formats for Internet Protocol Version 4, IEN 158, October 1980.][Jack_Haverty]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol XNET => s_protocols[15];

        /// <summary>
        /// Chaos
        /// </summary>
        /// <remarks>[J_Noel_Chiappa]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CHAOS => s_protocols[16];

        /// <summary>
        /// User Datagram
        /// </summary>
        /// <remarks>[RFC768][Jon_Postel]</remarks>
        public static RuleProtocol UDP => s_protocols[17];

        /// <summary>
        /// Multiplexing
        /// </summary>
        /// <remarks>
        /// [Cohen, D. and J. Postel, Multiplexing Protocol, IEN 90, USC/Information Sciences
        /// Institute, May 1979.][Jon_Postel]
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MUX => s_protocols[18];

        /// <summary>
        /// DCN Measurement Subsystems
        /// </summary>
        /// <remarks>[David_Mills]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DCN_MEAS => s_protocols[19];

        /// <summary>
        /// Host Monitoring
        /// </summary>
        /// <remarks>[RFC869][Bob_Hinden]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol HMP => s_protocols[20];

        /// <summary>
        /// Packet Radio Measurement
        /// </summary>
        /// <remarks>[Zaw_Sing_Su]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PRM => s_protocols[21];

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
        public static RuleProtocol XNS_IDP => s_protocols[22];

        /// <summary>
        /// Trunk-1
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TRUNK_1 => s_protocols[23];

        /// <summary>
        /// Trunk-2
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TRUNK_2 => s_protocols[24];

        /// <summary>
        /// Leaf-1
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol LEAF_1 => s_protocols[25];

        /// <summary>
        /// Leaf-2
        /// </summary>
        /// <remarks>[Barry_Boehm]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol LEAF_2 => s_protocols[26];

        /// <summary>
        /// Reliable Data Protocol
        /// </summary>
        /// <remarks>[RFC908][Bob_Hinden]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol RDP => s_protocols[27];

        /// <summary>
        /// Internet Reliable Transaction
        /// </summary>
        /// <remarks>[RFC938][Trudy_Miller]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IRTP => s_protocols[28];

        /// <summary> ISO Transport Protocol Class 4 </summary> <remarks> [RFC905][<mystery contact>] </remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ISO_TP4 => s_protocols[29];

        /// <summary>
        /// Bulk Data Transfer Protocol
        /// </summary>
        /// <remarks>[RFC969][David_Clark]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol NETBLT => s_protocols[30];

        /// <summary>
        /// MFE Network Services Protocol
        /// </summary>
        /// <remarks>
        /// [Shuttleworth, B., A Documentary of MFENet, a National Computer Network, UCRL-52317,
        /// Lawrence Livermore Labs, Livermore, California, June 1977.][Barry_Howard]
        /// </remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MFE_NSP => s_protocols[31];

        /// <summary>
        /// MERIT Internodal Protocol
        /// </summary>
        /// <remarks>[Hans_Werner_Braun]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MERIT_INP => s_protocols[32];

        /// <summary>
        /// Datagram Congestion Control Protocol
        /// </summary>
        /// <remarks>[RFC4340]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DCCP => s_protocols[33];

        /// <summary>
        /// Third Party Connect Protocol
        /// </summary>
        /// <remarks>[Stuart_A_Friedberg]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ThirdPC => s_protocols[34];

        /// <summary>
        /// Inter-Domain Policy Routing Protocol
        /// </summary>
        /// <remarks>[Martha_Steenstrup]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IDPR => s_protocols[35];

        /// <summary>
        /// XTP
        /// </summary>
        /// <remarks>[Greg_Chesson]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol XTP => s_protocols[36];

        /// <summary>
        /// Datagram Delivery Protocol
        /// </summary>
        /// <remarks>[Wesley_Craig]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DDP => s_protocols[37];

        /// <summary>
        /// IDPR Control Message Transport Proto
        /// </summary>
        /// <remarks>[Martha_Steenstrup]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IDPR_CMTP => s_protocols[38];

        /// <summary>
        /// TP++ Transport Protocol
        /// </summary>
        /// <remarks>[Dirk_Fromhein]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TPplusplus => s_protocols[39];

        /// <summary>
        /// IL Transport Protocol
        /// </summary>
        /// <remarks>[Dave_Presotto]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IL => s_protocols[40];

        /// <summary>
        /// IPv6 encapsulation
        /// </summary>
        /// <remarks>[RFC2473]</remarks> 
        public static RuleProtocol IPv6 => s_protocols[41];

        /// <summary>
        /// Source Demand Routing Protocol
        /// </summary>
        /// <remarks>[Deborah_Estrin]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SDRP => s_protocols[42];

        /// <summary>
        /// Routing Header for IPv6
        /// </summary>
        /// <remarks>[Steve_Deering]</remarks> 
        public static RuleProtocol IPv6_Route => s_protocols[43];

        /// <summary>
        /// Fragment Header for IPv6
        /// </summary>
        /// <remarks>[Steve_Deering]</remarks> 
        public static RuleProtocol IPv6_Frag => s_protocols[44];

        /// <summary>
        /// Inter-Domain Routing Protocol
        /// </summary>
        /// <remarks>[Sue_Hares]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IDRP => s_protocols[45];

        /// <summary>
        /// Reservation Protocol
        /// </summary>
        /// <remarks>[RFC2205][RFC3209][Bob_Braden]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol RSVP => s_protocols[46];

        /// <summary>
        /// Generic Routing Encapsulation
        /// </summary>
        /// <remarks>[RFC2784][Tony_Li]</remarks> 
        public static RuleProtocol GRE => s_protocols[47];

        /// <summary>
        /// Dynamic Source Routing Protocol
        /// </summary>
        /// <remarks>[RFC4728]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DSR => s_protocols[48];

        /// <summary>
        /// BNA
        /// </summary>
        /// <remarks>[Gary Salamon]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol BNA => s_protocols[49];

        /// <summary>
        /// Encap Security Payload
        /// </summary>
        /// <remarks>[RFC4303]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ESP => s_protocols[50];

        /// <summary>
        /// Authentication Header
        /// </summary>
        /// <remarks>[RFC4302]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AH => s_protocols[51];

        /// <summary>
        /// Integrated Net Layer Security TUBA
        /// </summary>
        /// <remarks>[K_Robert_Glenn]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol I_NLSP => s_protocols[52];

        /// <summary>
        /// IP with Encryption
        /// </summary>
        /// <remarks>(deprecated) [John_Ioannidis]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RuleProtocol SWIPE => s_protocols[53];

        /// <summary>
        /// NBMA Address Resolution Protocol
        /// </summary>
        /// <remarks>[RFC1735]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol NARP => s_protocols[54];

        /// <summary>
        /// IP Mobility
        /// </summary>
        /// <remarks>[Charlie_Perkins]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MOBILE => s_protocols[55];

        /// <summary>
        /// Transport Layer Security Protocol using Kryptonet key management
        /// </summary>
        /// <remarks>[Christer_Oberg]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TLSP => s_protocols[56];

        /// <summary>
        /// SKIP
        /// </summary>
        /// <remarks>[Tom_Markson]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SKIP => s_protocols[57];

        /// <summary>
        /// ICMP for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RuleProtocol IPv6_ICMP => s_protocols[58];

        /// <summary>
        /// No Next Header for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RuleProtocol IPv6_NoNxt => s_protocols[59];

        /// <summary>
        /// Destination Options for IPv6
        /// </summary>
        /// <remarks>[RFC8200]</remarks> 
        public static RuleProtocol IPv6_Opts => s_protocols[60];

        /// <summary>
        /// any host internal protocol
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AnyHostInternalProtocol => s_protocols[61];

        /// <summary>
        /// CFTP
        /// </summary>
        /// <remarks>
        /// [Forsdick, H., CFTP, Network Message, Bolt Beranek and
        ///Newman, January 1982.][Harry_Forsdick]
        /// </remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CFTP => s_protocols[62];

        /// <summary>
        /// any local network
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AnyLocalNetwork => s_protocols[63];

        /// <summary>
        /// SATNET and Backroom EXPAK
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SAT_EXPAK => s_protocols[64];

        /// <summary>
        /// Kryptolan
        /// </summary>
        /// <remarks>[Paul Liu]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol KRYPTOLAN => s_protocols[65];

        /// <summary>
        /// MIT Remote Virtual Disk Protocol
        /// </summary>
        /// <remarks>[Michael_Greenwald]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol RVD => s_protocols[66];

        /// <summary>
        /// Internet Pluribus Packet Core
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPPC => s_protocols[67];

        /// <summary>
        /// any distributed file system
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AnyDistributedFileSystem => s_protocols[68];

        /// <summary>
        /// SATNET Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SAT_MON => s_protocols[69];

        /// <summary>
        /// VISA Protocol
        /// </summary>
        /// <remarks>[Gene_Tsudik]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol VISA => s_protocols[70];

        /// <summary>
        /// Internet Packet Core Utility
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPCV => s_protocols[71];

        /// <summary>
        /// Computer Protocol Network Executive
        /// </summary>
        /// <remarks>[David Mittnacht]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CPNX => s_protocols[72];

        /// <summary>
        /// Computer Protocol Heart Beat
        /// </summary>
        /// <remarks>[David Mittnacht]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CPHB => s_protocols[73];

        /// <summary>
        /// Wang Span Network
        /// </summary>
        /// <remarks>[Victor Dafoulas]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol WSN => s_protocols[74];

        /// <summary>
        /// Packet Video Protocol
        /// </summary>
        /// <remarks>[Steve_Casner]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PVP => s_protocols[75];

        /// <summary>
        /// Backroom SATNET Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol BR_SAT_MON => s_protocols[76];

        /// <summary>
        /// SUN ND PROTOCOL-Temporary
        /// </summary>
        /// <remarks>[William_Melohn]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SUN_ND => s_protocols[77];

        /// <summary>
        /// WIDEBAND Monitoring
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol WB_MON => s_protocols[78];

        /// <summary>
        /// WIDEBAND EXPAK
        /// </summary>
        /// <remarks>[Steven_Blumenthal]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol WB_EXPAK => s_protocols[79];

        /// <summary>
        /// ISO Internet Protocol
        /// </summary>
        /// <remarks>[Marshall_T_Rose]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ISO_IP => s_protocols[80];

        /// <summary>
        /// VMTP
        /// </summary>
        /// <remarks>[Dave_Cheriton]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol VMTP => s_protocols[81];

        /// <summary>
        /// SECURE-VMTP
        /// </summary>
        /// <remarks>[Dave_Cheriton]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SECURE_VMTP => s_protocols[82];

        /// <summary>
        /// VINES
        /// </summary>
        /// <remarks>[Brian Horn]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol VINES => s_protocols[83];

        /// <summary>
        /// Transaction Transport Protocol or Internet Protocol Traffic Manager
        /// </summary>
        /// <remarks>[Jim_Stevens]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TTP_or_IPTM => s_protocols[84];

        /// <summary>
        /// NSFNET-IGP
        /// </summary>
        /// <remarks>[Hans_Werner_Braun]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol NSFNET_IGP => s_protocols[85];

        /// <summary>
        /// Dissimilar Gateway Protocol
        /// </summary>
        /// <remarks>
        /// [M/A-COM Government Systems, Dissimilar Gateway Protocol
        ///Specification, Draft Version, Contract no.CS901145,
        ///November 16, 1987.][Mike_Little]
        /// </remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DGP => s_protocols[86];

        /// <summary>
        /// TCF
        /// </summary>
        /// <remarks>[Guillermo_A_Loyola]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol TCF => s_protocols[87];

        /// <summary>
        /// EIGRP
        /// </summary>
        /// <remarks>[RFC7868]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol EIGRP => s_protocols[88];

        /// <summary>
        /// OSPFIGP
        /// </summary>
        /// <remarks>[RFC1583][RFC2328][RFC5340][John_Moy]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol OSPFIGP => s_protocols[89];

        /// <summary>
        /// Sprite RPC Protocol
        /// </summary>
        /// <remarks>
        /// [Welch, B., The Sprite Remote Procedure Call System,
        ///Technical Report, UCB/Computer Science Dept., 86/302,
        ///University of California at Berkeley, June 1986.][Bruce Willins]
        /// </remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol Sprite_RPC => s_protocols[90];

        /// <summary>
        /// Locus Address Resolution Protocol
        /// </summary>
        /// <remarks>[Brian Horn]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol LARP => s_protocols[91];

        /// <summary>
        /// Multicast Transport Protocol
        /// </summary>
        /// <remarks>[Susie_Armstrong]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MTP => s_protocols[92];

        /// <summary>
        /// AX.25 Frames
        /// </summary>
        /// <remarks>[Brian_Kantor]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AX_25 => s_protocols[93];

        /// <summary>
        /// IP-within-IP Encapsulation Protocol
        /// </summary>
        /// <remarks>[John_Ioannidis]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPIP => s_protocols[94];

        /// <summary>
        /// Mobile Internetworking Control Pro.
        /// </summary>
        /// <remarks>(deprecated) [John_Ioannidis]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RuleProtocol MICP => s_protocols[95];

        /// <summary>
        /// Semaphore Communications Sec. Pro.
        /// </summary>
        /// <remarks>[Howard_Hart]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SCC_SP => s_protocols[96];

        /// <summary>
        /// Ethernet-within-IP Encapsulation
        /// </summary>
        /// <remarks>[RFC3378]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ETHERIP => s_protocols[97];

        /// <summary>
        /// Encapsulation Header
        /// </summary>
        /// <remarks>[RFC1241][Robert_Woodburn]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ENCAP => s_protocols[98];

        /// <summary>
        /// any private encryption scheme
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AnyPrivateEncryptionScheme => s_protocols[99];

        /// <summary>
        /// GMTP
        /// </summary>
        /// <remarks>[[RXB5]]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol GMTP => s_protocols[100];

        /// <summary>
        /// Ipsilon Flow Management Protocol
        /// </summary>
        /// <remarks>[Bob_Hinden][November 1995, 1997.]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IFMP => s_protocols[101];

        /// <summary>
        /// PNNI over IP
        /// </summary>
        /// <remarks>[Ross_Callon]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PNNI => s_protocols[102];

        /// <summary>
        /// Protocol Independent Multicast
        /// </summary>
        /// <remarks>[RFC7761][Dino_Farinacci]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PIM => s_protocols[103];

        /// <summary>
        /// ARIS
        /// </summary>
        /// <remarks>[Nancy_Feldman]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ARIS => s_protocols[104];

        /// <summary>
        /// SCPS
        /// </summary>
        /// <remarks>[Robert_Durst]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SCPS => s_protocols[105];

        /// <summary>
        /// QNX
        /// </summary>
        /// <remarks>[Michael_Hunter]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol QNX => s_protocols[106];

        /// <summary>
        /// Active Networks
        /// </summary>
        /// <remarks>[Bob_Braden]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ActiveNetworks => s_protocols[107];

        /// <summary>
        /// IP Payload Compression Protocol
        /// </summary>
        /// <remarks>[RFC2393]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPComp => s_protocols[108];

        /// <summary>
        /// Sitara Networks Protocol
        /// </summary>
        /// <remarks>[Manickam_R_Sridhar]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SNP => s_protocols[109];

        /// <summary>
        /// Compaq Peer Protocol
        /// </summary>
        /// <remarks>[Victor_Volpe]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CompaqPeer => s_protocols[110];

        /// <summary>
        /// IPX in IP
        /// </summary>
        /// <remarks>[CJ_Lee]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPX_in_IP => s_protocols[111];

        /// <summary>
        /// Virtual Router Redundancy Protocol
        /// </summary>
        /// <remarks>[RFC5798]</remarks> 
        public static RuleProtocol VRRP => s_protocols[112];

        /// <summary>
        /// PGM Reliable Transport Protocol
        /// </summary>
        /// <remarks>[Tony_Speakman]</remarks> 
        public static RuleProtocol PGM => s_protocols[113];

        /// <summary>
        /// any 0-hop protocol
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol AnyZeroHopProtocol => s_protocols[114];

        /// <summary>
        /// Layer Two Tunneling Protocol
        /// </summary>
        /// <remarks>[RFC3931][Bernard_Aboba]</remarks> 
        public static RuleProtocol L2TP => s_protocols[115];

        /// <summary>
        /// D-II Data Exchange (DDX)
        /// </summary>
        /// <remarks>[John_Worley]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol DDX => s_protocols[116];

        /// <summary>
        /// Interactive Agent Transfer Protocol
        /// </summary>
        /// <remarks>[John_Murphy]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IATP => s_protocols[117];

        /// <summary>
        /// Schedule Transfer Protocol
        /// </summary>
        /// <remarks>[Jean_Michel_Pittet]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol STP => s_protocols[118];

        /// <summary>
        /// SpectraLink Radio Protocol
        /// </summary>
        /// <remarks>[Mark_Hamilton]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SRP => s_protocols[119];

        /// <summary>
        /// UTI
        /// </summary>
        /// <remarks>[Peter_Lothberg]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol UTI => s_protocols[120];

        /// <summary>
        /// Simple Message Protocol
        /// </summary>
        /// <remarks>[Leif_Ekblad]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SMP => s_protocols[121];

        /// <summary>
        /// Simple Multicast Protocol
        /// </summary>
        /// <remarks>(deprecated) [Jon_Crowcroft][draft-perlman-simple-multicast]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        [Obsolete]
        public static RuleProtocol SM => s_protocols[122];

        /// <summary>
        /// Performance Transparency Protocol
        /// </summary>
        /// <remarks>[Michael_Welzl]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PTP => s_protocols[123];

        /// <summary>
        /// ISIS over IPv4
        /// </summary>
        /// <remarks>[Tony_Przygienda]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ISIS_over_IPv4 => s_protocols[124];

        /// <summary>
        /// FIRE
        /// </summary>
        /// <remarks>[Criag_Partridge]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol FIRE => s_protocols[125];

        /// <summary>
        /// Combat Radio Transport Protocol
        /// </summary>
        /// <remarks>[Robert_Sautter]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CRTP => s_protocols[126];

        /// <summary>
        /// Combat Radio User Datagram
        /// </summary>
        /// <remarks>[Robert_Sautter]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol CRUDP => s_protocols[127];

        /// <summary>
        /// SSCOPMCE
        /// </summary>
        /// <remarks>[Kurt_Waber]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SSCOPMCE => s_protocols[128];

        /// <summary>
        /// IPLT
        /// </summary>
        /// <remarks>[[Hollbach]]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol IPLT => s_protocols[129];

        /// <summary>
        /// Secure Packet Shield
        /// </summary>
        /// <remarks>[Bill_McIntosh]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SPS => s_protocols[130];

        /// <summary>
        /// Private IP Encapsulation within IP
        /// </summary>
        /// <remarks>[Bernhard_Petri]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol PIPE => s_protocols[131];

        /// <summary>
        /// Stream Control Transmission Protocol
        /// </summary>
        /// <remarks>[Randall_R_Stewart]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol SCTP => s_protocols[132];

        /// <summary>
        /// Fibre Channel
        /// </summary>
        /// <remarks>[Murali_Rajagopal][RFC6172]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol FC => s_protocols[133];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC3175]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol RSVP_E2E_IGNORE => s_protocols[134];

        /// <summary>
        /// Mobility Header
        /// </summary>
        /// <remarks>[RFC6275]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MobilityHeader => s_protocols[135];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC3828]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol UDPLite => s_protocols[136];

        /// <summary>
        /// </summary>
        /// <remarks>[RFC4023]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol MPLS_in_IP => s_protocols[137];

        /// <summary>
        /// MANET Protocols
        /// </summary>
        /// <remarks>[RFC5498]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol manet => s_protocols[138];

        /// <summary>
        /// Host Identity Protocol
        /// </summary>
        /// <remarks>[RFC7401]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol HIP => s_protocols[139];

        /// <summary>
        /// Shim6 Protocol
        /// </summary>
        /// <remarks>[RFC5533]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol Shim6 => s_protocols[140];

        /// <summary>
        /// Wrapped Encapsulating Security Payload
        /// </summary>
        /// <remarks>[RFC5840]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol WESP => s_protocols[141];

        /// <summary>
        /// Robust Header Compression
        /// </summary>
        /// <remarks>[RFC5858]</remarks>
[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static RuleProtocol ROHC => s_protocols[142];

        /// <summary>
        /// Reserved
        /// </summary>
        /// <remarks>[Internet_Assigned_Numbers_Authority]</remarks>
        public static RuleProtocol Reserved => s_protocols[255];

        /// <summary>
        /// Any
        /// </summary>
        public static RuleProtocol Any => s_protocols[256];

        static RuleProtocol()
        {            
            s_protocols[0] = new RuleProtocol(nameof(HOPOPT), 0, true);
            s_protocols[1] = new RuleProtocol(nameof(ICMP), 1, false,true);
            s_protocols[2] = new RuleProtocol(nameof(IGMP), 2);
            s_protocols[3] = new RuleProtocol(nameof(GGP), 3);
            s_protocols[4] = new RuleProtocol(nameof(IPv4), 4);
            s_protocols[5] = new RuleProtocol(nameof(ST), 5);
            s_protocols[6] = new RuleProtocol(nameof(TCP), 6);
            s_protocols[7] = new RuleProtocol(nameof(CBT), 7);
            s_protocols[8] = new RuleProtocol(nameof(EGP), 8);
            s_protocols[9] = new RuleProtocol(nameof(IGP), 9);

            s_protocols[10] = new RuleProtocol(nameof(BBN_RCC_MON), 10);
            s_protocols[11] = new RuleProtocol(nameof(NVP_II), 11);
            s_protocols[12] = new RuleProtocol(nameof(PUP), 12);
            s_protocols[13] = new RuleProtocol(nameof(ARGUS), 13);
            s_protocols[14] = new RuleProtocol(nameof(EMCON), 14);
            s_protocols[15] = new RuleProtocol(nameof(XNET), 15);
            s_protocols[16] = new RuleProtocol(nameof(CHAOS), 16);
            s_protocols[17] = new RuleProtocol(nameof(UDP), 17);
            s_protocols[18] = new RuleProtocol(nameof(MUX), 18);
            s_protocols[19] = new RuleProtocol(nameof(DCN_MEAS), 19);

            s_protocols[20] = new RuleProtocol(nameof(HMP), 20);
            s_protocols[21] = new RuleProtocol(nameof(PRM), 21);
            s_protocols[22] = new RuleProtocol(nameof(XNS_IDP), 22);
            s_protocols[23] = new RuleProtocol(nameof(TRUNK_1), 23);
            s_protocols[24] = new RuleProtocol(nameof(TRUNK_2), 24);
            s_protocols[25] = new RuleProtocol(nameof(LEAF_1), 25);
            s_protocols[26] = new RuleProtocol(nameof(LEAF_2), 26);
            s_protocols[27] = new RuleProtocol(nameof(RDP), 27);
            s_protocols[28] = new RuleProtocol(nameof(IRTP), 28);
            s_protocols[29] = new RuleProtocol(nameof(ISO_TP4), 29);

            s_protocols[30] = new RuleProtocol(nameof(NETBLT), 30);
            s_protocols[31] = new RuleProtocol(nameof(MFE_NSP), 31);
            s_protocols[32] = new RuleProtocol(nameof(MERIT_INP), 32);
            s_protocols[33] = new RuleProtocol(nameof(DCCP), 33);
            s_protocols[34] = new RuleProtocol(nameof(ThirdPC), 34);
            s_protocols[35] = new RuleProtocol(nameof(IDPR), 35);
            s_protocols[36] = new RuleProtocol(nameof(XTP), 36);
            s_protocols[37] = new RuleProtocol(nameof(DDP), 37);
            s_protocols[38] = new RuleProtocol(nameof(IDPR_CMTP), 38);
            s_protocols[39] = new RuleProtocol(nameof(TPplusplus), 39);

            s_protocols[40] = new RuleProtocol(nameof(IL), 40);
            s_protocols[41] = new RuleProtocol(nameof(IPv6), 41);
            s_protocols[42] = new RuleProtocol(nameof(SDRP), 42);
            s_protocols[43] = new RuleProtocol(nameof(IPv6_Route), 43, true);
            s_protocols[44] = new RuleProtocol(nameof(IPv6_Frag), 44, true);
            s_protocols[45] = new RuleProtocol(nameof(IDRP), 45);
            s_protocols[46] = new RuleProtocol(nameof(RSVP), 46);
            s_protocols[47] = new RuleProtocol(nameof(GRE), 47);
            s_protocols[48] = new RuleProtocol(nameof(DSR), 48);
            s_protocols[49] = new RuleProtocol(nameof(BNA), 49);

            s_protocols[50] = new RuleProtocol(nameof(ESP), 50, true);
            s_protocols[51] = new RuleProtocol(nameof(AH), 51, true);
            s_protocols[52] = new RuleProtocol(nameof(I_NLSP), 52);
            s_protocols[53] = new RuleProtocol(nameof(SWIPE), 53);
            s_protocols[54] = new RuleProtocol(nameof(NARP), 54);
            s_protocols[55] = new RuleProtocol(nameof(MOBILE), 55);
            s_protocols[56] = new RuleProtocol(nameof(TLSP), 56);
            s_protocols[57] = new RuleProtocol(nameof(SKIP), 57);
            s_protocols[58] = new RuleProtocol(nameof(IPv6_ICMP), 58, false, true);
            s_protocols[59] = new RuleProtocol(nameof(IPv6_NoNxt), 59);

            s_protocols[60] = new RuleProtocol(nameof(IPv6_Opts), 60, true);
            s_protocols[61] = new RuleProtocol(nameof(AnyHostInternalProtocol), 61);
            s_protocols[62] = new RuleProtocol(nameof(CFTP), 62);
            s_protocols[63] = new RuleProtocol(nameof(AnyLocalNetwork), 63);
            s_protocols[64] = new RuleProtocol(nameof(SAT_EXPAK), 64);
            s_protocols[65] = new RuleProtocol(nameof(KRYPTOLAN), 65);
            s_protocols[66] = new RuleProtocol(nameof(RVD), 66);
            s_protocols[67] = new RuleProtocol(nameof(IPPC), 67);
            s_protocols[68] = new RuleProtocol(nameof(AnyDistributedFileSystem), 68);
            s_protocols[69] = new RuleProtocol(nameof(SAT_MON), 69);

            s_protocols[70] = new RuleProtocol(nameof(VISA), 70);
            s_protocols[71] = new RuleProtocol(nameof(IPCV), 71);
            s_protocols[72] = new RuleProtocol(nameof(CPNX), 72);
            s_protocols[73] = new RuleProtocol(nameof(CPHB), 73);
            s_protocols[74] = new RuleProtocol(nameof(WSN), 74);
            s_protocols[75] = new RuleProtocol(nameof(PVP), 75);
            s_protocols[76] = new RuleProtocol(nameof(BR_SAT_MON), 76);
            s_protocols[77] = new RuleProtocol(nameof(SUN_ND), 77);
            s_protocols[78] = new RuleProtocol(nameof(WB_MON), 78);
            s_protocols[79] = new RuleProtocol(nameof(WB_EXPAK), 79);

            s_protocols[80] = new RuleProtocol(nameof(ISO_IP), 80);
            s_protocols[81] = new RuleProtocol(nameof(VMTP), 81);
            s_protocols[82] = new RuleProtocol(nameof(SECURE_VMTP), 82);
            s_protocols[83] = new RuleProtocol(nameof(VINES), 83);
            s_protocols[84] = new RuleProtocol(nameof(TTP_or_IPTM), 84);
            s_protocols[85] = new RuleProtocol(nameof(NSFNET_IGP), 85);
            s_protocols[86] = new RuleProtocol(nameof(DGP), 86);
            s_protocols[87] = new RuleProtocol(nameof(TCF), 87);
            s_protocols[88] = new RuleProtocol(nameof(EIGRP), 88);
            s_protocols[89] = new RuleProtocol(nameof(OSPFIGP), 89);

            s_protocols[90] = new RuleProtocol(nameof(Sprite_RPC), 90);
            s_protocols[91] = new RuleProtocol(nameof(LARP), 91);
            s_protocols[92] = new RuleProtocol(nameof(MTP), 92);
            s_protocols[93] = new RuleProtocol(nameof(AX_25), 93);
            s_protocols[94] = new RuleProtocol(nameof(IPIP), 94);
            s_protocols[95] = new RuleProtocol(nameof(MICP), 95);
            s_protocols[96] = new RuleProtocol(nameof(SCC_SP), 96);
            s_protocols[97] = new RuleProtocol(nameof(ETHERIP), 97);
            s_protocols[98] = new RuleProtocol(nameof(ENCAP), 98);
            s_protocols[99] = new RuleProtocol(nameof(AnyPrivateEncryptionScheme), 99);

            s_protocols[100] = new RuleProtocol(nameof(GMTP), 100);
            s_protocols[101] = new RuleProtocol(nameof(IFMP), 101);
            s_protocols[102] = new RuleProtocol(nameof(PNNI), 102);
            s_protocols[103] = new RuleProtocol(nameof(PIM), 103);
            s_protocols[104] = new RuleProtocol(nameof(ARIS), 104);
            s_protocols[105] = new RuleProtocol(nameof(SCPS), 105);
            s_protocols[106] = new RuleProtocol(nameof(QNX), 106);
            s_protocols[107] = new RuleProtocol(nameof(ActiveNetworks), 107);
            s_protocols[108] = new RuleProtocol(nameof(IPComp), 108);
            s_protocols[109] = new RuleProtocol(nameof(SNP), 109);

            s_protocols[110] = new RuleProtocol(nameof(CompaqPeer), 110);
            s_protocols[111] = new RuleProtocol(nameof(IPX_in_IP), 111);
            s_protocols[112] = new RuleProtocol(nameof(VRRP), 112);
            s_protocols[113] = new RuleProtocol(nameof(PGM), 113);
            s_protocols[114] = new RuleProtocol(nameof(AnyZeroHopProtocol), 114);
            s_protocols[115] = new RuleProtocol(nameof(L2TP), 115);
            s_protocols[116] = new RuleProtocol(nameof(DDX), 116);
            s_protocols[117] = new RuleProtocol(nameof(IATP), 117);
            s_protocols[118] = new RuleProtocol(nameof(STP), 118);
            s_protocols[119] = new RuleProtocol(nameof(SRP), 119);

            s_protocols[120] = new RuleProtocol(nameof(UTI), 120);
            s_protocols[121] = new RuleProtocol(nameof(SMP), 121);
            s_protocols[122] = new RuleProtocol(nameof(SM), 122);
            s_protocols[123] = new RuleProtocol(nameof(PTP), 123);
            s_protocols[124] = new RuleProtocol(nameof(ISIS_over_IPv4), 124);
            s_protocols[125] = new RuleProtocol(nameof(FIRE), 125);
            s_protocols[126] = new RuleProtocol(nameof(CRTP), 126);
            s_protocols[127] = new RuleProtocol(nameof(CRUDP), 127);
            s_protocols[128] = new RuleProtocol(nameof(SSCOPMCE), 128);
            s_protocols[129] = new RuleProtocol(nameof(IPLT), 129);

            s_protocols[130] = new RuleProtocol(nameof(SPS), 130);
            s_protocols[131] = new RuleProtocol(nameof(PIPE), 131);
            s_protocols[132] = new RuleProtocol(nameof(SCTP), 132);
            s_protocols[133] = new RuleProtocol(nameof(FC), 133);
            s_protocols[134] = new RuleProtocol(nameof(RSVP_E2E_IGNORE), 134);
            s_protocols[135] = new RuleProtocol(nameof(MobilityHeader), 135, true);
            s_protocols[136] = new RuleProtocol(nameof(UDPLite), 136);
            s_protocols[137] = new RuleProtocol(nameof(MPLS_in_IP), 137);
            s_protocols[138] = new RuleProtocol(nameof(manet), 138);
            s_protocols[139] = new RuleProtocol(nameof(HIP), 139, true);

            s_protocols[140] = new RuleProtocol(nameof(Shim6), 140, true);
            s_protocols[141] = new RuleProtocol(nameof(WESP), 141);
            s_protocols[142] = new RuleProtocol(nameof(ROHC), 142);

            for (byte offset = 143; offset <= 252; offset++)
            {
                s_protocols[offset] = new RuleProtocol("Unassigned", offset);
            }
            s_protocols[253] = new RuleProtocol("ExperimentationOrTesting", 253);
            s_protocols[254] = new RuleProtocol("ExperimentationOrTesting", 254);

            s_protocols[255] = new RuleProtocol(nameof(Reserved), 255);
            s_protocols[256] = new RuleProtocol(nameof(Any), 256);
        }

        private RuleProtocol(string name, short value) : this(name, value, false, false)
        {
        }

        private RuleProtocol(string name, short value, bool hasIPv6ExtensionHeader, bool supportedIcmpConfig = false)
        {
            this.Name = name.Replace('_', '-');
            this.Value = value;
            this.HasIPv6ExtensionHeader = hasIPv6ExtensionHeader;
            this.SupportedIcmpConfig = supportedIcmpConfig;
        }

        public string Name { get; }

        public short Value { get; }

        public static implicit operator short(RuleProtocol protocol)
        {
            return protocol.Value;
        }

        public static implicit operator RuleProtocol(int value)
        {
            if (value > byte.MaxValue + 1 || value < byte.MinValue)
                throw new ArgumentOutOfRangeException(nameof(value));
            return s_protocols[value];
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