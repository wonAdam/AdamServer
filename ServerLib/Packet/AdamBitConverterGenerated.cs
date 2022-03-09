
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

                case ChatMsg_RQ.Id:
                {
                    return Serialize((ChatMsg_RQ)Data);
                }

                case ChatMsg_RS.Id:
                {
                    return Serialize((ChatMsg_RS)Data);
                }

                case ListTest_RQ.Id:
                {
                    return Serialize((ListTest_RQ)Data);
                }

                case ListTest_RS.Id:
                {
                    return Serialize((ListTest_RS)Data);
                }

                case DictionaryTest_RQ.Id:
                {
                    return Serialize((DictionaryTest_RQ)Data);
                }

                case DictionaryTest_RS.Id:
                {
                    return Serialize((DictionaryTest_RS)Data);
                }

                case ClassListTest_RQ.Id:
                {
                    return Serialize((ClassListTest_RQ)Data);
                }

                case ClassListTest_RS.Id:
                {
                    return Serialize((ClassListTest_RS)Data);
                }

                case ClassDictionaryTest_RQ.Id:
                {
                    return Serialize((ClassDictionaryTest_RQ)Data);
                }

                case ClassDictionaryTest_RS.Id:
                {
                    return Serialize((ClassDictionaryTest_RS)Data);
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

                case ChatMsg_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ChatMsg_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ChatMsg_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ChatMsg_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ListTest_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ListTest_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ListTest_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ListTest_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case DictionaryTest_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out DictionaryTest_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case DictionaryTest_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out DictionaryTest_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ClassListTest_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ClassListTest_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ClassListTest_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ClassListTest_RS? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ClassDictionaryTest_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ClassDictionaryTest_RQ? PacketData);
                    Data = PacketData;
                    return Result;
                }

                case ClassDictionaryTest_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out ClassDictionaryTest_RS? PacketData);
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

                case ChatMsg_RQ.Id:
                {
                    return SizeOf((ChatMsg_RQ)Data);
                }

                case ChatMsg_RS.Id:
                {
                    return SizeOf((ChatMsg_RS)Data);
                }

                case ListTest_RQ.Id:
                {
                    return SizeOf((ListTest_RQ)Data);
                }

                case ListTest_RS.Id:
                {
                    return SizeOf((ListTest_RS)Data);
                }

                case DictionaryTest_RQ.Id:
                {
                    return SizeOf((DictionaryTest_RQ)Data);
                }

                case DictionaryTest_RS.Id:
                {
                    return SizeOf((DictionaryTest_RS)Data);
                }

                case ClassListTest_RQ.Id:
                {
                    return SizeOf((ClassListTest_RQ)Data);
                }

                case ClassListTest_RS.Id:
                {
                    return SizeOf((ClassListTest_RS)Data);
                }

                case ClassDictionaryTest_RQ.Id:
                {
                    return SizeOf((ClassDictionaryTest_RQ)Data);
                }

                case ClassDictionaryTest_RS.Id:
                {
                    return SizeOf((ClassDictionaryTest_RS)Data);
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

        public static byte[] Serialize(ChatMsg_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ChatMsg_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ListTest_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ListTest_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(DictionaryTest_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(DictionaryTest_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ClassListTest_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ClassListTest_RS Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ClassDictionaryTest_RQ Data)
        {
            return Data.ToByteArray();
        }

        public static byte[] Serialize(ClassDictionaryTest_RS Data)
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

            Data = Ping_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Ping_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = Ping_RS.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ChatMsg_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ChatMsg_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ChatMsg_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ChatMsg_RS.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ListTest_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ListTest_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ListTest_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ListTest_RS.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out DictionaryTest_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = DictionaryTest_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out DictionaryTest_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = DictionaryTest_RS.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ClassListTest_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ClassListTest_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ClassListTest_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ClassListTest_RS.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ClassDictionaryTest_RQ? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ClassDictionaryTest_RQ.Parser.ParseFrom(Buff);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out ClassDictionaryTest_RS? Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = ClassDictionaryTest_RS.Parser.ParseFrom(Buff);
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

        public static int SizeOf(ChatMsg_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ChatMsg_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ListTest_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ListTest_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(DictionaryTest_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(DictionaryTest_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ClassListTest_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ClassListTest_RS Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ClassDictionaryTest_RQ Data)
        {
            return Data.CalculateSize();
        }

        public static int SizeOf(ClassDictionaryTest_RS Data)
        {
            return Data.CalculateSize();
        }

    }
}
