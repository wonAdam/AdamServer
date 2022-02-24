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
    public class PacketHeader
    {
        public static ushort Size
        {
            get { return sizeof(ushort) * 2; }
        }

        public ushort PacketSize { get; set; }
        public ushort PacketId { get; set; }

        public PacketHeader()
        {
        }

        public PacketHeader(PacketBase packet)
        {
            PacketSize = packet.PacketSize;
            PacketId = packet.PacketId;
        }
    }

    public abstract class PacketBase
    {
        public abstract ushort PacketId { get; }
        public abstract ushort PacketSize { get; }
    }
}
