using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    /// <summary>
    /// 패킷의 앞에 PacketHeader를 붙입니다.
    /// PacketHeader에는 PacketHeader를 제외한 PacketContent의 사이즈인 _size,
    /// 그리고 해당 패킷의 아이디인 _id 로 구성됩니다.
    /// </summary>
    public class PacketHeader
    {
        public ushort Size
        {
            get { return sizeof(ushort) * 2; }
        }

        ushort _packetSize;
        ushort _id;

        public PacketHeader(Packet packet)
        {
            _packetSize = packet.GetSize();
            _id = packet.GetPacketId();
        }

        public ArraySegment<byte> Serialize()
        {
            ArraySegment<byte> buff = new ArraySegment<byte>(new byte[Size]);
            int cursor = 0;
            Array.Copy(BitConverter.GetBytes(_packetSize), 0, buff.Array, buff.Offset + cursor, sizeof(ushort));
            cursor += sizeof(ushort);
            Array.Copy(BitConverter.GetBytes(_id), 0, buff.Array, buff.Offset + cursor, sizeof(ushort));

            return buff;
        }

        public void Deserialize(ArraySegment<byte> buff)
        {
            if(buff.Array == null)
            {
                Logger.Log(LogLevel.Error, "Packet Header Deserialize Failed: Null Buffer");
                return;
            }

            if (buff.Count != Size)
            {
                Logger.Log(LogLevel.Error, "Packet Header Deserialize Failed: Not Enough Buffer Size");
                return;
            }

            _packetSize = BitConverter.ToUInt16(buff.AsSpan(0, 2));
            _id = BitConverter.ToUInt16(buff.AsSpan(2, 4));
        }
    }

    public class Packet
    {
        public Packet()
        {

        }

        public ushort GetPacketId()
        {
            
        }

        public ushort GetSize()
        {
            
        }
    }
}
