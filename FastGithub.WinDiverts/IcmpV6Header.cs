using System;
using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IcmpV6Header
    {
        public byte Type;
        public byte Code;
        public ushort checksum;
        public int Checksum
        {
            get => BinaryPrimitives.ReverseEndianness(this.checksum);
            set => this.checksum = BinaryPrimitives.ReverseEndianness((ushort)value);
        }
        public uint Body;
    }
}
