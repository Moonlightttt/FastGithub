using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UdpHeader
    {
        /// <summary>
        /// Gets or sets the source port.
        /// </summary>
        public ushort srcPort;
        public int SrcPort
        {
            get => BinaryPrimitives.ReverseEndianness(this.srcPort);
            set => this.srcPort = BinaryPrimitives.ReverseEndianness((ushort)value);
        }

        public ushort dstPort;
        public int DstPort
        {
            get => BinaryPrimitives.ReverseEndianness(this.dstPort);
            set => this.dstPort = BinaryPrimitives.ReverseEndianness((ushort)value);
        }

        public ushort length;
        public int Length
        {
            get => BinaryPrimitives.ReverseEndianness(this.length);
            set => this.length = BinaryPrimitives.ReverseEndianness((ushort)value);
        }

        /// <summary>
        /// Gets or sets the checksum.
        /// </summary>
        public ushort checksum;
        public int Checksum
        {
            get => BinaryPrimitives.ReverseEndianness(this.checksum);
            set => this.checksum = BinaryPrimitives.ReverseEndianness((ushort)value);
        }
    }
}
