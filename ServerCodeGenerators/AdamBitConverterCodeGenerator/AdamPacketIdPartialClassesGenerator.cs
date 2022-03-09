using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdamBitConverterCodeGenerator
{
    internal class AdamPacketIdPartialClassesGenerator
    {
        internal static void Generate(XmlDocument Doc)
        {
            GenerateAdamPacketIdPartialClasses(Doc);
        }

        private static void GenerateAdamPacketIdPartialClasses(XmlDocument Doc)
        {
            StringBuilder SbPartialClasses = new StringBuilder();
            StringBuilder SbGetIdIfStatements = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            ushort Id = 1;
            foreach (XmlNode ClassNode in PacketsNode.ChildNodes)
            {
                if (ClassNode.FirstChild.Name != "Name" || ClassNode.SelectSingleNode("Name") == null)
                {
                    Console.WriteLine("Class의 첫번째 자식노드는 Name노드여야 합니다.");
                    Environment.Exit(999);
                }

                string ClassName = ClassNode.SelectSingleNode("Name").InnerText;

                string SerializeFunc = String.Format(PartialClassFormat, ClassName, Id);
                SbPartialClasses.Append(SerializeFunc);

                string IfStatement = String.Format(Id == 1 ? GetIdIfFormat : GetIdElseIfFormat, ClassName);
                SbGetIdIfStatements.Append(IfStatement);

                Id++;
            }

            string AdamBitConverterContent = String.Format(AdamPacketIdPartialClassesFormat, SbPartialClasses.ToString(), SbGetIdIfStatements.ToString());
            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "ServerLib", "Packet", "AdamPacketIdPartialClassesGenerated.cs");
            File.WriteAllText(FilePath, AdamBitConverterContent);
        }

        // 0: Pair들
        // 1: if문들
        private static string AdamPacketIdPartialClassesFormat =
@"
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;

namespace Google.Protobuf.Protocol.PacketGenerated
{{
    {0}
}}

namespace ServerLib.Packet
{{
    public class PacketToIdConverterGenerated
    {{
        public static ushort GetId(IMessage Packet)
        {{
            {1}
            else
            {{
                string ExceptionStr = $""정의되지 않은 패킷이 들어왔습니다. Packet.ToString(): {{Packet.ToString()}}"";
                AdamLogger.Log(LogLevel.Error, ExceptionStr);
                throw new Exception(ExceptionStr);
                return 0;
            }}
        }}
    }}
}}
";

        // 0: Protobuf 자동생성클래스 타입
        // 1: Id
        private static string PartialClassFormat =
@"
    public partial class {0}
    {{
        public const ushort Id = {1};
    }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string GetIdIfFormat =
@"
            if(Packet is {0})
                return {0}.Id;
";

        // 0: Protobuf 자동생성클래스 타입
        private static string GetIdElseIfFormat =
@"
            else if(Packet is {0})
                return {0}.Id;
";



    }
}
