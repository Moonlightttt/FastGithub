using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WinDivertDataNetwork
    {
        public uint IfIdx;                 
        public uint SubIfIdx;                  
    }
}
