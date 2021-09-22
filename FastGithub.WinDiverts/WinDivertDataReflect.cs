using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WinDivertDataReflect
    {
        public long Timestamp;
        public uint ProcessId;
        public WinDivertLayer Layer;
        public ulong Flags;
        public short Priority;
    }
}
