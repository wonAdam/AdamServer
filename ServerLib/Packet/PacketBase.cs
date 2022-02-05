using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Packet
{
    /// <summary>
    /// 패킷의 앞에 PacketHeader를 붙입니다.
    /// PacketHeader에는 PacketHeader를 제외한 PacketContent의 사이즈인 _size,
    /// 그리고 해당 패킷의 아이디인 _id 로 구성됩니다.
    /// </summary>
    [Serializable]
    public class PacketHeader
    {
        public static ushort Size
        {
            get { return sizeof(ushort) * 2; }
        }

        public ushort PacketSize { get; private set; }
        public ushort PacketId { get; private set; }

        public PacketHeader()
        {
        }

        public PacketHeader(PacketBase packet)
        {
            PacketSize = packet.PacketSize;
            PacketId = packet.PacketId;
        }

        public EError Serialize(out ArraySegment<byte> buff)
        {
            try
            {
                buff = new ArraySegment<byte>(new byte[Size]);
                int cursor = 0;
                Array.Copy(BitConverter.GetBytes(PacketSize), 0, buff.Array, buff.Offset + cursor, sizeof(ushort));
                cursor += sizeof(ushort);
                Array.Copy(BitConverter.GetBytes(PacketId), 0, buff.Array, buff.Offset + cursor, sizeof(ushort));

                return EError.None; 
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                buff = new ArraySegment<byte>();
                return EError.Exception;
            }
        }

        public EError Deserialize(ArraySegment<byte> buff)
        {
            try
            {
                if (buff.Array == null)
                    throw new Exception("Packet Header Deserialize Failed: Null Buffer");

                if (buff.Count < Size)
                    return EError.PacketFragmentation;

                int cursor = 0;
                PacketSize = BitConverter.ToUInt16(buff.AsSpan(cursor, sizeof(ushort)));
                cursor += sizeof(ushort);
                PacketId = BitConverter.ToUInt16(buff.AsSpan(cursor, sizeof(ushort)));
                return EError.None;
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                return EError.Exception;
            }
        }
    }

    [Serializable]
    public abstract class PacketBase
    {
        public abstract ushort PacketId { get; }
        public abstract ushort PacketSize { get; }
        public abstract EError Serialize(out ArraySegment<byte> buff);
        public abstract EError Deserialize(ArraySegment<byte> buff);
    }
}
