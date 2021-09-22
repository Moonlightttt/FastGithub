using System;
using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Explicit)]
    unsafe public struct WinDivertAddress
    {
        [FieldOffset(0)]
        public long Timestamp;

        [FieldOffset(8)]
        private uint @interface;

        public uint Layer // 8 bits
        {
            set => @interface = (@interface & 0xFFFFFF00) | (Convert.ToUInt32(value) & 0xFF);
            get => Convert.ToUInt32(@interface & 0xFF);
        }

        public uint Event // 8 bits
        {
            set => @interface = (@interface & 0xFFFF00FF) | ((Convert.ToUInt32(value) & 0xFF) << 8);
            get => Convert.ToUInt32((@interface & 0xFF00) >> 8);
        }

        public bool Sniffed // 1 bit
        {
            set => @interface = (@interface & 0xFFFEFFFF) | (Convert.ToUInt32(value) << 16);
            get => Convert.ToBoolean(@interface & 0x10000);
        }
        public bool Outbound // 1 bit
        {
            set => @interface = (@interface & 0xFFFDFFFF) | (Convert.ToUInt32(value) << 17);
            get => Convert.ToBoolean(@interface & 0x20000);
        }
        public bool Loopback // 1 bit
        {
            set => @interface = (@interface & 0xFFFBFFFF) | (Convert.ToUInt32(value) << 18);
            get => Convert.ToBoolean(@interface & 0x40000);
        }
        public bool Impostor // 1 bit
        {
            set => @interface = (@interface & 0xFFF7FFFF) | (Convert.ToUInt32(value) << 19);
            get => Convert.ToBoolean(@interface & 0x80000);
        }
        public bool IPv6 // 1 bit
        {
            set => @interface = (@interface & 0xFFEFFFFF) | (Convert.ToUInt32(value) << 20);
            get => Convert.ToBoolean(@interface & 0x100000);
        }
        public bool IPChecksum // 1 bit
        {
            set => @interface = (@interface & 0xFFDFFFFF) | (Convert.ToUInt32(value) << 21);
            get => Convert.ToBoolean(@interface & 0x200000);
        }
        public bool TCPChecksum // 1 bit
        {
            set => @interface = (@interface & 0xFFBFFFFF) | (Convert.ToUInt32(value) << 22);
            get => Convert.ToBoolean(@interface & 0x400000);
        }
        public bool UDPChecksum // 1 bit
        {
            set => @interface = (@interface & 0xFF7FFFFF) | (Convert.ToUInt32(value) << 23);
            get => Convert.ToBoolean(@interface & 0x800000);
        }
        public uint Reserved1 // 8 bits
        {
            set => @interface = (@interface & 0x00FFFFFF) | ((Convert.ToUInt32(value) & 0xFF) << 24);
            get => Convert.ToUInt32((@interface & 0xFF000000) >> 24);
        }

        [FieldOffset(12)]
        public uint Reserved2;

        [FieldOffset(16)]
        public fixed byte Reserved3[64];

        [FieldOffset(16)]
        public WinDivertDataNetwork Network;

        [FieldOffset(16)]
        public WinDivertDataFlow Flow;

        [FieldOffset(16)]
        public WinDivertDataSocket Socket;

        [FieldOffset(16)]
        public WinDivertDataReflect Reflect;
    }
}
