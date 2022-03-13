using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Protocol.PacketGenerated;
using Google.Protobuf.Reflection;

namespace ServerLib.Packet
{
    /// <summary>
    /// 패킷의 앞에 PacketHeader를 붙입니다.
    /// [   Packet Header (4byte)   ][     Packet Body (n byte)    ]
    /// [   packetsize ][  packetid ][     Packet Body (n byte)    ]
    /// PacketHeader에는 PacketHeader를 제외한 PacketBody의 사이즈인 PacketSize,
    /// 그리고 해당 패킷의 아이디인 PacketId 로 구성됩니다.
    /// </summary>
    public class PacketHeader
    {
        public static ushort Size
        {
            get { return sizeof(ushort) * 2; }
        }

        public ushort PacketSize { get; set; }
        public ushort PacketId { get; set; }

        public MessageDescriptor Descriptor => throw new NotImplementedException();

        public PacketHeader()
        {
        }

        public PacketHeader(IMessage Packet)
        {
            PacketSize = (ushort)Packet.CalculateSize();
            PacketId = PacketToIdConverterGenerated.GetId(Packet);
        }

    }

}
