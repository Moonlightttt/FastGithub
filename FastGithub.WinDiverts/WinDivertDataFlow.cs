using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe public struct WinDivertDataFlow
    {
        public ulong Endpoint;
        public ulong ParentEndpoint;
        public uint ProcessId;
        public fixed uint LocalAddr[4];
        public fixed uint RemoteAddr[4];
        public ushort LocalPort;
        public ushort RemotePort;
        public Protocols Protocol;
    }
}
