using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdamBitConverterCodeGenerator
{
    internal class AdamBitConverterGenerator
    {
        internal static void Generate(XmlDocument Doc)
        {
            GenerateAdamBitConverter(Doc);
        }

        private static void GenerateAdamBitConverter(XmlDocument Doc)
        {
            StringBuilder SbSerializeFuncs = new StringBuilder();
            StringBuilder SbDeserializeFuncs = new StringBuilder();
            StringBuilder SbSizeOfFuncs = new StringBuilder();
            StringBuilder SbSerializeCaseFuncs = new StringBuilder();
            StringBuilder SbDeserializeCaseFuncs = new StringBuilder();
            StringBuilder SbSizeOfCaseFuncs = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            foreach (XmlNode ClassNode in PacketsNode.ChildNodes)
            {
                if (ClassNode.FirstChild.Name != "Name" || ClassNode.SelectSingleNode("Name") == null)
                {
                    Console.WriteLine("Class의 첫번째 자식노드는 Name노드여야 합니다.");
                    Environment.Exit(999);
                }

                string ClassName = ClassNode.SelectSingleNode("Name").InnerText;
                string PacketType = ClassNode.Attributes["type"].Value;
                string PacketClassName = PacketXmlReader.MakePacketClassName(ClassName, PacketType);

                string SerializeFunc = String.Format(SerializeFormat, PacketClassName);
                SbSerializeFuncs.Append(SerializeFunc);

                string DeserializeFunc = String.Format(DeserializeFormat, PacketClassName);
                SbDeserializeFuncs.Append(DeserializeFunc);

                string SizeOfFunc = String.Format(SizeOfFormat, PacketClassName);
                SbSizeOfFuncs.Append(SizeOfFunc);

                string SerializeCase = String.Format(SerializeCaseFormat, PacketClassName);
                SbSerializeCaseFuncs.Append(SerializeCase);

                string DeserializeCase = String.Format(DeserializeCaseFormat, PacketClassName);
                SbDeserializeCaseFuncs.Append(DeserializeCase);

                string SizeOfCase = String.Format(SizeOfCaseFormat, PacketClassName);
                SbSizeOfCaseFuncs.Append(SizeOfCase);
            }

            string AdamBitConverterContent = String.Format(
                AdamBitConverterFormat, 
                SbSerializeFuncs.ToString(), 
                SbDeserializeFuncs.ToString(), 
                SbSizeOfFuncs.ToString(), 
                SbSerializeCaseFuncs.ToString(),
                SbDeserializeCaseFuncs.ToString(),
                SbSizeOfCaseFuncs.ToString());

            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "ServerLib", "Packet", "AdamBitConverterGenerated.cs");
            File.WriteAllText(FilePath, AdamBitConverterContent);
        }


        // 0: Serialize
        // 1: Deserialize
        // 2: SizeOf
        // 3: Serialize Case
        // 4: Deserialize Case
        private static string AdamBitConverterFormat =
@"
using System;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;

namespace ServerLib.Adam
{{
    public static class AdamBitConverterGenerated
    {{
        public enum EDeserializeResult
        {{
            Success,
            PacketFragmentation,
            PacketCorrupted,
        }}

        public static byte[] Serialize(PacketHeader Header)
        {{
			byte[] buff = new byte[PacketHeader.Size];

			byte[] packetSizeBuff = BitConverter.GetBytes(Header.PacketSize);
			Array.Copy(packetSizeBuff, 0, buff, 0, sizeof(ushort));
			byte[] packetIdBuff = BitConverter.GetBytes(Header.PacketId);
			Array.Copy(packetIdBuff, 0, buff, sizeof(ushort), sizeof(ushort));

			return buff;
        }}

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, out PacketHeader Header)
        {{
            if(Buff.Count < PacketHeader.Size)
			{{
				Header = new PacketHeader();
				return EDeserializeResult.PacketFragmentation;
			}}

			Header = new PacketHeader();
			Header.PacketSize = BitConverter.ToUInt16(Buff.Array, Buff.Offset);
			Header.PacketId = BitConverter.ToUInt16(Buff.Array, Buff.Offset + sizeof(ushort));

			return EDeserializeResult.Success;
        }}

        public static int SizeOf(PacketHeader Header)
        {{
            return PacketHeader.Size;
        }}

        public static byte[] Serialize(IMessage Data)
        {{
            switch(PacketToIdConverterGenerated.GetId(Data))
            {{
                {3}
                default: 
                {{
                    string ExceptionStr = $""정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {{Data.ToString()}}"";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return null;
                }}
            }}
        }}

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out IMessage Data)
        {{
            switch(Header.PacketId)
            {{
                {4}
                default: 
                {{
                    string ExceptionStr = $""정의되지 않은 패킷이 들어왔습니다. Header.PacketId: {{Header.PacketId}}"";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return EDeserializeResult.PacketCorrupted;
                }}
            }}
        }}


        public static int SizeOf(IMessage Data)
        {{
            switch(PacketToIdConverterGenerated.GetId(Data))
            {{
                {5}
                default: 
                {{
                    string ExceptionStr = $""정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {{Data.ToString()}}"";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                    return 0;
                }}
            }}
        }}


        {0}

        {1}

        {2}
    }}
}}
";
        // 0: Protobuf 자동생성클래스 타입
        private static string SizeOfCaseFormat =
@"
                case {0}.Id:
                {{
                    return SizeOf(({0})Data);
                }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string SerializeCaseFormat =
@"
                case {0}.Id:
                {{
                    return Serialize(({0})Data);
                }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string DeserializeCaseFormat =
@"
                case {0}.Id:
                {{
                    EDeserializeResult Result = Deserialize(Buff, Header, out {0}? PacketData);
                    Data = PacketData;
                    return Result;
                }}
";


        // 0: Protobuf 자동생성클래스 타입
        private static string SerializeFormat =
@"
        public static byte[] Serialize({0} Data)
        {{
            return Data.ToByteArray();
        }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string DeserializeFormat =
@"
        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out {0}? Data)
        {{
            if(Buff.Count < Header.PacketSize)
            {{
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }}

            Data = {0}.Parser.ParseFrom(new ArraySegment<byte>(Buff.Array, Buff.Offset, Header.PacketSize));
            return EDeserializeResult.Success;
        }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string SizeOfFormat =
@"
        public static int SizeOf({0} Data)
        {{
            return Data.CalculateSize();
        }}
";
    }
}
