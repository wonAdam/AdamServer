
using System;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;

namespace ServerLib.Adam
{
    public static class AdamBitConverterGenerated
    {
        public enum EDeserializeResult
        {
            Success,
            PacketFragmentation,
            PacketCorrupted,
        }

        public static byte[] Serialize(PacketHeader Header)
        {
			byte[] buff = new byte[PacketHeader.Size];

			byte[] packetSizeBuff = BitConverter.GetBytes(Header.PacketSize);
			Array.Copy(packetSizeBuff, 0, buff, 0, sizeof(ushort));
			byte[] packetIdBuff = BitConverter.GetBytes(Header.PacketId);
			Array.Copy(packetIdBuff, 0, buff, sizeof(ushort), sizeof(ushort));

			return buff;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, out PacketHeader Header)
        {
            if(Buff.Count < PacketHeader.Size)
			{
				Header = new PacketHeader();
				return EDeserializeResult.PacketFragmentation;
			}

			Header = new PacketHeader();
			Header.PacketSize = BitConverter.ToUInt16(Buff.Array, Buff.Offset);
			Header.PacketId = BitConverter.ToUInt16(Buff.Array, Buff.Offset + sizeof(ushort));

			return EDeserializeResult.Success;
        }

        public static int SizeOf(PacketHeader Header)
        {
            return PacketHeader.Size;
        }

        public static byte[] Serialize(IMessage Data)
        {
            switch(PacketToIdConverterGenerated.GetId(Data))
            {
                
                case Ping_RQ.Id:
                {
                    return Serialize((Ping_RQ)Data);
                }

                case Ping_RS.Id:
                {
                    return Serialize((Ping_RS)Data);
                }

                case CreateAccount_RQ.Id:
                {
                    return Serialize((CreateAccount_RQ)Data);
                }

                case CreateAccount_RS.Id:
                {
                    return Serialize((CreateAccount_RS)Data);
                }

                case Dummy2_RQ.Id:
                {
                    return Serialize((Dummy2_RQ)Data);
                }

                case Dummy2_RS.Id:
                {
                    return Serialize((Dummy2_RS)Data);
                }

                case Dummy1_RQ.Id:
                {
                    return Serialize((Dummy1_RQ)Data);
                }

                case Dummy1_RS.Id:
                {
                    return Serialize((Dummy1_RS)Data);
                }

                case Login_RQ.Id:
                {
                    return Serialize((Login_RQ)Data);
                }

                case Login_RS.Id:
                {
                    return Serialize((Login_RS)Data);
                }

                case DummyDbUpdate_RQ.Id:
                {
                    return Serialize((DummyDbUpdate_RQ)Data);
                }

                case DummyDbUpdate_RS.Id:
                {
                    return Serialize((DummyDbUpdate_RS)Data);
                }

                case GetPlayerDbIdByPlayerNickname_RQ.Id:
                {
                    return Serialize((GetPlayerDbIdByPlayerNickname_RQ)Data);
                }

                case GetPlayerDbIdByPlayerNickname_RS.Id:
                {
                    return Serialize((GetPlayerDbIdByPlayerNickname_RS)Data);
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {Data.ToString()}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return null;
                }
            }
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out IMessage Data)
        {
            switch(Header.PacketId)
            {
                
                case Ping_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Ping_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Ping_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Ping_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case CreateAccount_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out CreateAccount_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case CreateAccount_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out CreateAccount_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Dummy2_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Dummy2_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Dummy2_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Dummy2_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Dummy1_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Dummy1_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Dummy1_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Dummy1_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Login_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Login_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Login_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Login_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case DummyDbUpdate_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out DummyDbUpdate_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case DummyDbUpdate_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out DummyDbUpdate_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GetPlayerDbIdByPlayerNickname_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GetPlayerDbIdByPlayerNickname_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GetPlayerDbIdByPlayerNickname_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GetPlayerDbIdByPlayerNickname_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Header.PacketId: {Header.PacketId}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return EDeserializeResult.PacketCorrupted;
                }
            }
        }


        public static int SizeOf(IMessage Data)
        {
            switch(PacketToIdConverterGenerated.GetId(Data))
            {
                
                case Ping_RQ.Id:
                {
                    return SizeOf((Ping_RQ)Data);
                }

                case Ping_RS.Id:
                {
                    return SizeOf((Ping_RS)Data);
                }

                case CreateAccount_RQ.Id:
                {
                    return SizeOf((CreateAccount_RQ)Data);
                }

                case CreateAccount_RS.Id:
                {
                    return SizeOf((CreateAccount_RS)Data);
                }

                case Dummy2_RQ.Id:
                {
                    return SizeOf((Dummy2_RQ)Data);
                }

                case Dummy2_RS.Id:
                {
                    return SizeOf((Dummy2_RS)Data);
                }

                case Dummy1_RQ.Id:
                {
                    return SizeOf((Dummy1_RQ)Data);
                }

                case Dummy1_RS.Id:
                {
                    return SizeOf((Dummy1_RS)Data);
                }

                case Login_RQ.Id:
                {
                    return SizeOf((Login_RQ)Data);
                }

                case Login_RS.Id:
                {
                    return SizeOf((Login_RS)Data);
                }

                case DummyDbUpdate_RQ.Id:
                {
                    return SizeOf((DummyDbUpdate_RQ)Data);
                }

                case DummyDbUpdate_RS.Id:
                {
                    return SizeOf((DummyDbUpdate_RS)Data);
                }

                case GetPlayerDbIdByPlayerNickname_RQ.Id:
                {
                    return SizeOf((GetPlayerDbIdByPlayerNickname_RQ)Data);
                }

                case GetPlayerDbIdByPlayerNickname_RS.Id:
                {
                    return SizeOf((GetPlayerDbIdByPlayerNickname_RS)Data);
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {Data.ToString()}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return 0;
                }
            }
        }


        
        public static byte[] Serialize(Ping_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Ping_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(CreateAccount_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(CreateAccount_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Dummy2_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Dummy2_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Dummy1_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Dummy1_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Login_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(Login_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(DummyDbUpdate_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(DummyDbUpdate_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(GetPlayerDbIdByPlayerNickname_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(GetPlayerDbIdByPlayerNickname_RS Data)
        {
            return Data.ToByteArray();
        }


        
        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Ping_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Ping_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Ping_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Ping_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out CreateAccount_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = CreateAccount_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out CreateAccount_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = CreateAccount_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Dummy2_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Dummy2_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Dummy2_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Dummy2_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Dummy1_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Dummy1_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Dummy1_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Dummy1_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Login_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Login_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Login_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Login_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out DummyDbUpdate_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = DummyDbUpdate_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out DummyDbUpdate_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = DummyDbUpdate_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GetPlayerDbIdByPlayerNickname_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = GetPlayerDbIdByPlayerNickname_RQ.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GetPlayerDbIdByPlayerNickname_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = GetPlayerDbIdByPlayerNickname_RS.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }


        
        public static int SizeOf(Ping_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Ping_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(CreateAccount_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(CreateAccount_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Dummy2_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Dummy2_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Dummy1_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Dummy1_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Login_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(Login_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(DummyDbUpdate_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(DummyDbUpdate_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(GetPlayerDbIdByPlayerNickname_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(GetPlayerDbIdByPlayerNickname_RS Data)
        {
            return Data.CalculateSize();
        }

    }
}
