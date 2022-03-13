using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    public class SendBufferHelper
    {
        public static ThreadLocal<AdamSendBuffer> CurrentBuffer = new ThreadLocal<AdamSendBuffer>(() => { return null; });
        public static ArraySegment<byte> Open(int reservedSize)
        {
            if (CurrentBuffer.Value == null)
                CurrentBuffer.Value = new AdamSendBuffer(ServerConstData.SendBufferSize);

            if (CurrentBuffer.Value.FreeSize < reservedSize)
                CurrentBuffer.Value = new AdamSendBuffer(ServerConstData.SendBufferSize);

            return CurrentBuffer.Value.Open(reservedSize);
        }

        public static ArraySegment<byte> Close(int usedSize)
        {
            return CurrentBuffer.Value.Close(usedSize);
        }
    }

    public class AdamSendBuffer
    {
        byte[] _buffer;
        int _usedSize = 0;

        public int FreeSize { get { return _buffer.Length - _usedSize; } }

        public AdamSendBuffer(int chunkSize)
        {
            _buffer = new byte[chunkSize];
        }

        public ArraySegment<byte> Open(int reservedSize)
        {
            if (reservedSize > FreeSize)
                return null;

            return new ArraySegment<byte>(_buffer, _usedSize, reservedSize);
        }

        public ArraySegment<byte> Close(int usedSize)
        {
            ArraySegment<byte> segment = new ArraySegment<byte>(_buffer, _usedSize, usedSize);
            _usedSize += usedSize;
            return segment;
        }


    }
}
