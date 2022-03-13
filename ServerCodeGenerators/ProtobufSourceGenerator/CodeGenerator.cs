using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtobufSourceGenerator
{
    public class CodeGenerator
    {
        static HashSet<string> PacketNames = new HashSet<string>();
        internal static void Generate()
        {
            // 1. Xml 파일 읽기
            XmlDocument Doc = PacketXmlReader.ReadPacketRaw();

            // 2. Xml 파일로 .proto 파일 만들기
            MakeProtobufSource(Doc);
        }

        internal static void MakeProtobufSource(XmlDocument Doc)
        {
            StringBuilder SbClasses = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            foreach (XmlNode ClassNode in PacketsNode.ChildNodes)
            {
                if (ClassNode.SelectSingleNode("Name") == null)
                {
                    Console.WriteLine("Class의 첫번째 자식노드는 Name노드여야 합니다.");
                    Environment.Exit(999);
                }

                string ClassName = ClassNode.SelectSingleNode("Name").InnerText;
                string PacketType = ClassNode.Attributes["type"].Value;
                string PacketClassName = PacketXmlReader.MakePacketClassName(ClassName, PacketType);

                if (PacketNames.Contains(PacketClassName))
                {
                    Console.WriteLine($"패킷 이름은 중복되면 안됩니다. ClassName: {ClassName}");
                    Environment.Exit(999);
                }

                PacketNames.Add(ClassName);
            }

            foreach (XmlNode ClassNode in PacketsNode.ChildNodes)
            {
                if (ClassNode.SelectSingleNode("Name") == null)
                {
                    Console.WriteLine("Class의 첫번째 자식노드는 Name노드여야 합니다.");
                    Environment.Exit(999);
                }

                string ClassName = ClassNode.SelectSingleNode("Name").InnerText;
                string PacketType = ClassNode.Attributes["type"].Value;
                string PacketClassName = PacketXmlReader.MakePacketClassName(ClassName, PacketType);

                StringBuilder SbMembers = new StringBuilder();
                int FieldNumber = 1;
                foreach (XmlNode VariableNode in ClassNode.LastChild.ChildNodes)
                {
                    string MemberType = VariableNode.Name;
                    string MemberName = VariableNode.InnerText;

                    string ProtobufType = XmlNodeToProtobufType(MemberType, VariableNode);

                    string MemeberLine = String.Format(ProtobufClassMemberFormat, ProtobufType, MemberName, FieldNumber++);
                    SbMembers.Append(MemeberLine);
                    SbMembers.AppendLine();
                }

                string ClassLine = String.Format(ProtobufClassFormat, PacketClassName, SbMembers.ToString());

                SbClasses.Append(ClassLine);
                SbClasses.AppendLine();
            }

            string ProtoContent = String.Format(ProtobufFormat, SbClasses.ToString());

            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "ServerCodeGenerators", "ProtobufSourceGenerator", "PacketGenerated.proto");
            File.WriteAllText(FilePath, ProtoContent);
        }

        public static string XmlNodeToProtobufType(string TypeStr, XmlNode? Node)
        {
            if (TypeStr == "int")
            {
                return "int32";
            }
            else if (TypeStr == "uint")
            {
                return "uint32";
            }
            else if (TypeStr == "short")
            {
                Console.WriteLine("short는 지원하지않습니다.");
                Environment.Exit(999);
                return "";
            }
            else if (TypeStr == "ushort")
            {
                Console.WriteLine("ushort는 지원하지않습니다.");
                Environment.Exit(999);
                return "";
            }
            else if (TypeStr == "char")
            {
                Console.WriteLine("ushort는 지원하지않습니다.");
                Environment.Exit(999);
                return "";
            }
            else if (TypeStr == "long")
            {
                return "int64";
            }
            else if (TypeStr == "ulong")
            {
                return "uint64";
            }
            else if (TypeStr == "float")
            {
                return "float";
            }
            else if (TypeStr == "double")
            {
                return "double";
            }
            else if (TypeStr == "bool")
            {
                return "bool";
            }
            else if (TypeStr == "string")
            {
                return "string";
            }
            else if (TypeStr == "DateTime")
            {
                return "google.protobuf.Timestamp";
            }
            else if (TypeStr == "List")
            {
                if(Node.Attributes["element"] == null)
                {
                    Console.WriteLine("List에는 element라는 Attrivbute가 있어야합니다.");
                    Environment.Exit(999);
                }

                return $"repeated {XmlNodeToProtobufType(Node.Attributes["element"].Value, null)}";
            }
            else if (TypeStr == "Dictionary")
            {
                if (Node.Attributes["key"] == null)
                {
                    Console.WriteLine("Dictionary에는 key라는 Attrivbute가 있어야합니다.");
                    Environment.Exit(999);
                }
                if (Node.Attributes["value"] == null)
                {
                    Console.WriteLine("Dictionary에는 value라는 Attrivbute가 있어야합니다.");
                    Environment.Exit(999);
                }
                return $"map<{XmlNodeToProtobufType(Node.Attributes["key"].Value, null)}, {XmlNodeToProtobufType(Node.Attributes["value"].Value, null)}>";
            }
            else 
            {
                if(PacketNames.Contains(TypeStr) == false) // 클래스인지 확인해야함
                {
                    Console.WriteLine($"기본 타입도 아니고 패킷타입도 아닙니다. 혹시 오타? Node.Name: {TypeStr}");
                    Environment.Exit(999);
                }

                return TypeStr;
            }
        }
        

        // 0: classes
        static string ProtobufFormat =
@"
    syntax = ""proto3"";
    package tutorial;

    import ""google/protobuf/timestamp.proto"";

    option csharp_namespace = ""Google.Protobuf.Protocol.PacketGenerated"";

    {0}
";

        // 0: class name
        // 1: members
        static string ProtobufClassFormat =
@"
    message {0} 
    {{
        {1}
    }}
";

        // 0: type
        // 1: name
        // 2: field number
        static string ProtobufClassMemberFormat =
@"
        {0} {1} = {2};
";
    }
}
