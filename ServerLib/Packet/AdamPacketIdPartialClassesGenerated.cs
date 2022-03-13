
using System;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;

namespace Google.Protobuf.Protocol.PacketGenerated
{
    
    public partial class Ping_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 1;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Ping_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 2;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class CreateAccount_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 3;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class CreateAccount_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 4;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Dummy2_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 5;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Dummy2_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 6;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Dummy1_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 7;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Dummy1_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 8;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Login_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 9;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class Login_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 10;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class DummyDbUpdate_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 11;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class DummyDbUpdate_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 12;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class GetPlayerDbIdByPlayerNickname_RQ
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 13;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
    }

    public partial class GetPlayerDbIdByPlayerNickname_RS
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 14;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }
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

            else if(Packet is CreateAccount_RQ)
                return CreateAccount_RQ.Id;

            else if(Packet is CreateAccount_RS)
                return CreateAccount_RS.Id;

            else if(Packet is Dummy2_RQ)
                return Dummy2_RQ.Id;

            else if(Packet is Dummy2_RS)
                return Dummy2_RS.Id;

            else if(Packet is Dummy1_RQ)
                return Dummy1_RQ.Id;

            else if(Packet is Dummy1_RS)
                return Dummy1_RS.Id;

            else if(Packet is Login_RQ)
                return Login_RQ.Id;

            else if(Packet is Login_RS)
                return Login_RS.Id;

            else if(Packet is DummyDbUpdate_RQ)
                return DummyDbUpdate_RQ.Id;

            else if(Packet is DummyDbUpdate_RS)
                return DummyDbUpdate_RS.Id;

            else if(Packet is GetPlayerDbIdByPlayerNickname_RQ)
                return GetPlayerDbIdByPlayerNickname_RQ.Id;

            else if(Packet is GetPlayerDbIdByPlayerNickname_RS)
                return GetPlayerDbIdByPlayerNickname_RS.Id;

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
