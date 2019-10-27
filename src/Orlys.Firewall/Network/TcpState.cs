// Author: Orlys
// Github: https://github.com/Orlys
namespace Orlys.Network
{
    public enum TcpState : uint
    {
        /// <summary>
        /// The TCP connection is in the CLOSED state that represents no connection state at all.
        /// </summary>
        Closed = 1,
        /// <summary>
        /// The TCP connection is in the LISTEN state waiting for a connection request from any remote TCP and port.
        /// </summary>
        Listen,
        /// <summary>
        /// The TCP connection is in the SYN-SENT state waiting for a matching connection request after having sent a connection request (SYN packet).
        /// </summary>
        SynSent,
        /// <summary>
        /// The TCP connection is in the SYN-RECEIVED state waiting for a confirming connection request acknowledgment after having both received and sent a connection request (SYN packet).
        /// </summary>
        SynRcvd,
        /// <summary>
        /// The TCP connection is in the ESTABLISHED state that represents an open connection, data received can be delivered to the user. This is the normal state for the data transfer phase of the TCP connection.
        /// </summary>
        Established,
        /// <summary>
        /// The TCP connection is FIN-WAIT-1 state waiting for a connection termination request from the remote TCP, or an acknowledgment of the connection termination request previously sent.
        /// </summary>
        FinWait1,
        /// <summary>
        /// The TCP connection is FIN-WAIT-2 state waiting for a connection termination request from the remote TCP.
        /// </summary>
        FinWait2,
        /// <summary>
        /// The TCP connection is in the CLOSE-WAIT state waiting for a connection termination request from the local user.
        /// </summary>
        CloseWait,
        /// <summary>
        /// The TCP connection is in the CLOSING state waiting for a connection termination request acknowledgment from the remote TCP.
        /// </summary>
        Closing,
        /// <summary>
        /// The TCP connection is in the LAST-ACK state waiting for an acknowledgment of the connection termination request previously sent to the remote TCP (which includes an acknowledgment of its connection termination request).
        /// </summary>
        LastAsk,
        /// <summary>
        /// The TCP connection is in the TIME-WAIT state waiting for enough time to pass to be sure the remote TCP received the acknowledgment of its connection termination request.
        /// </summary>
        TimeWait,
        /// <summary>
        /// The TCP connection is in the delete TCB state that represents the deletion of the Transmission Control Block (TCB), a data structure used to maintain information on each TCP entry.
        /// </summary>
        DeleteTCB
    }
}