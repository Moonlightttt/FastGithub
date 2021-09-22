using System;
using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    unsafe public static class WinDivert
    {
        [DllImport("WinDivert.dll", EntryPoint = "WinDivertOpen", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr WinDivertOpen([MarshalAs(UnmanagedType.LPWStr)] string filter, WinDivertLayer layer, short priority, WinDivertOpenFlags flags);


        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern bool WinDivertClose(IntPtr handle);


        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool WinDivertRecv(IntPtr handle, IntPtr packet, uint packetLen, ref uint recvLen, ref WinDivertAddress addr);

        public static bool WinDivertRecv(IntPtr handle, WinDivertBuffer buffer, ref int packetLength, ref WinDivertAddress address)
        {
            var recvLength = 0u;
            var result = WinDivertRecv(handle, buffer.Handle, (uint)buffer.Length, ref recvLength, ref address);
            packetLength = (int)recvLength;
            return result;
        }


        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool WinDivertSend(IntPtr handle, IntPtr packet, uint packetLen, ref uint sendLen, ref WinDivertAddress addr);

        public static bool WinDivertSend(IntPtr handle, WinDivertBuffer buffer, int packetLength, ref WinDivertAddress address)
        {
            var sendLength = 0u;
            return WinDivertSend(handle, buffer.Handle, (uint)buffer.Length, ref sendLength, ref address);
        }

        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool WinDivertHelperParsePacket(
            IntPtr packet,
            uint packetLen,
            IPv4Header** ipHdr,
            IPv6Header** ipv6Hdr,
            ref Protocols protocol,
            IcmpV4Header** icmpHdr,
            IcmpV6Header** icmpv6Hdr,
            TcpHeader** tcpHdr,
            UdpHeader** udpHdr,
            byte** data,
            ref uint dataLen,
            byte** next,
            ref uint nextLen);

        public static WinDivertPacket? WinDivertHelperParsePacket(WinDivertBuffer buffer, int packetLength)
        {
            IPv4Header* ipHdr = null;
            IPv6Header* ipv6Hdr = null;
            Protocols protocol = Protocols.HOPOPTS;
            IcmpV4Header* icmpHdr = null;
            IcmpV6Header* icmpv6Hdr = null;
            TcpHeader* tcpHdr = null;
            UdpHeader* udpHdr = null;
            byte* data = null;
            uint dataLen = 0u;
            byte* next = null;
            uint nextLen = 0u;

            var state = WinDivertHelperParsePacket(buffer.Handle, (uint)buffer.Length, &ipHdr, &ipv6Hdr, ref protocol, &icmpHdr, &icmpv6Hdr, &tcpHdr, &udpHdr, &data, ref dataLen, &next, ref nextLen);
            return state == false ? default
                : new WinDivertPacket(ipHdr, ipv6Hdr, icmpHdr, icmpv6Hdr, tcpHdr, udpHdr, protocol, data, (int)dataLen, next, (int)nextLen);
        }



        [DllImport("WinDivert.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool WinDivertHelperCalcChecksums(
            IntPtr packet,
            uint packetLen,
            ref WinDivertAddress addr,
            WinDivertChecksumFlags flags
        );

        public static bool WinDivertHelperCalcChecksums(WinDivertBuffer buffer, int packetLength, ref WinDivertAddress address, WinDivertChecksumFlags flags)
        {
            return WinDivertHelperCalcChecksums(buffer.Handle, (uint)packetLength, ref address, flags);
        }
    }
}
