using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Packet
{
    public class Ping_RQ : PacketBase
    {
        public override ushort PacketId => Id;

        public override ushort PacketSize => 0;
        public const ushort Id = 0;

        public override EError Deserialize(ArraySegment<byte> buff)
        {
            if (buff.Count < PacketSize)
                return EError.PacketFragmentation;

            return EError.None;
        }

        public override EError Serialize(out ArraySegment<byte> buff)
        {
            buff = new ArraySegment<byte>();
            return EError.None;
        }
    }

    public class Ping_RS : PacketBase
    {
        public override ushort PacketId => Id;

        public override ushort PacketSize => 0;
        public const ushort Id = 1;

        public override EError Deserialize(ArraySegment<byte> buff)
        {
            if (buff.Count < PacketSize)
                return EError.PacketFragmentation;

            return EError.None;
        }

        public override EError Serialize(out ArraySegment<byte> buff)
        {
            buff = new ArraySegment<byte>();
            return EError.None;
        }
    }
}
