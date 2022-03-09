
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;

namespace Google.Protobuf.Protocol.PacketGenerated
{
    
    public partial class Ping_RQ
    {
        public const ushort Id = 1;
    }

    public partial class Ping_RS
    {
        public const ushort Id = 2;
    }

    public partial class ChatMsg_RQ
    {
        public const ushort Id = 3;
    }

    public partial class ChatMsg_RS
    {
        public const ushort Id = 4;
    }

    public partial class ListTest_RQ
    {
        public const ushort Id = 5;
    }

    public partial class ListTest_RS
    {
        public const ushort Id = 6;
    }

    public partial class DictionaryTest_RQ
    {
        public const ushort Id = 7;
    }

    public partial class DictionaryTest_RS
    {
        public const ushort Id = 8;
    }

    public partial class ClassListTest_RQ
    {
        public const ushort Id = 9;
    }

    public partial class ClassListTest_RS
    {
        public const ushort Id = 10;
    }

    public partial class ClassDictionaryTest_RQ
    {
        public const ushort Id = 11;
    }

    public partial class ClassDictionaryTest_RS
    {
        public const ushort Id = 12;
    }

}

namespace ServerLib.Packet
{
    public class PacketToIdConverterGenerated
    {
        public static ushort GetId(IMessage Packet)
        {
            
            if(Packet is Ping_RQ)
                return Ping_RQ.Id;

            else if(Packet is Ping_RS)
                return Ping_RS.Id;

            else if(Packet is ChatMsg_RQ)
                return ChatMsg_RQ.Id;

            else if(Packet is ChatMsg_RS)
                return ChatMsg_RS.Id;

            else if(Packet is ListTest_RQ)
                return ListTest_RQ.Id;

            else if(Packet is ListTest_RS)
                return ListTest_RS.Id;

            else if(Packet is DictionaryTest_RQ)
                return DictionaryTest_RQ.Id;

            else if(Packet is DictionaryTest_RS)
                return DictionaryTest_RS.Id;

            else if(Packet is ClassListTest_RQ)
                return ClassListTest_RQ.Id;

            else if(Packet is ClassListTest_RS)
                return ClassListTest_RS.Id;

            else if(Packet is ClassDictionaryTest_RQ)
                return ClassDictionaryTest_RQ.Id;

            else if(Packet is ClassDictionaryTest_RS)
                return ClassDictionaryTest_RS.Id;

            else
            {
                string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Packet.ToString(): {Packet.ToString()}";
                AdamLogger.Log(LogLevel.Error, ExceptionStr);
                throw new Exception(ExceptionStr);
                return 0;
            }
        }
    }
}
