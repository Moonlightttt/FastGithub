namespace FastGithub.WinDiverts
{
    unsafe public class WinDivertPacket
    {

        public IPv4Header* IPv4Header { get; }
        public IPv6Header* IPv6Header { get; }
        public IcmpV4Header* IcmpV4Header { get; }
        public IcmpV6Header* IcmpV6Header { get; }
        public TcpHeader* TcpHeader { get; }
        public UdpHeader* UdpHeader { get; }

        public Protocols Protocol { get; }

        public byte* Data { get; }
        public int DataLength { get; }

        public byte* Next { get; }
        public int NextLength { get; }


        public WinDivertPacket(IPv4Header* iPv4Header, IPv6Header* iPv6Header, IcmpV4Header* icmpV4Header, IcmpV6Header* icmpV6Header, TcpHeader* tcpHeader, UdpHeader* udpHeader, Protocols protocol, byte* data, int dataLength, byte* next, int nextLength)
        {
            IPv4Header = iPv4Header;
            IPv6Header = iPv6Header;
            IcmpV4Header = icmpV4Header;
            IcmpV6Header = icmpV6Header;
            TcpHeader = tcpHeader;
            UdpHeader = udpHeader;
            Protocol = protocol;
            Data = data;
            DataLength = dataLength;
            Next = next;
            NextLength = nextLength;
        }
    }
}
