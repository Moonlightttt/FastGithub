namespace FastGithub.WinDiverts
{
    public enum  WinDivertChecksumFlags : ulong
    {
        /// <summary>
        /// Performs a full checksum calculation on the packet.
        /// </summary>
        All = 0,

        /// <summary>
        /// Skips IPv4 checksum calculations.
        /// </summary>
        NoIpChecksum = 1,

        /// <summary>
        /// Skips Icmp V4 checksum calculations.
        /// </summary>
        NoIcmpChecksum = 2,

        /// <summary>
        /// Skips Icmp V6 checksum calculations.
        /// </summary>
        NoIcmpV6Checksum = 4,

        /// <summary>
        /// Skips Tcp checksum calculations.
        /// </summary>
        NoTcpChecksum = 8,

        /// <summary>
        /// Skips Udp checksum calculations.
        /// </summary>
        NoUdpChecksum = 16
    }
}
