using System;
using System.Runtime.InteropServices;

namespace FastGithub.WinDiverts
{
    public class WinDivertBuffer : IDisposable
    {
        /// <summary>
        /// The internal buffer object.
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// The GCHandle that provides our <see cref="Handle"/> member.
        /// </summary>
        private GCHandle bufferHandle;

        /// <summary>
        /// The pinned pointer to the buffer.
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets the length of the buffer.
        /// </summary>
        public int Length => this.buffer.Length;

        /// <summary>
        /// Constructs a new buffer with the default max-packet size.
        /// </summary>
        public WinDivertBuffer()
            : this(new byte[ushort.MaxValue])
        {
        }

        /// <summary>
        /// Constructs a new buffer from the given raw buffer data.
        /// </summary>
        /// <param name="buffer">
        /// The raw buffer data to wrap.
        /// </param>
        public WinDivertBuffer(byte[] buffer)
        {
            this.buffer = buffer;
            this.bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            this.Handle = bufferHandle.AddrOfPinnedObject();
        }

        /// <summary>
        /// Disposes the buffer.
        /// </summary>
        public void Dispose()
        {
            this.bufferHandle.Free();
            this.Handle = IntPtr.Zero;
        }
    }
}
