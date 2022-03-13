using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtobufSourceGenerator
{
    public class PacketXmlReader
    {
        public static XmlDocument ReadPacketRaw()
        {
            DirectoryInfo SolutionDirInfo = PathManager.TryGetSolutionDirectoryInfo();
            XmlDocument Doc = new XmlDocument();
            Doc.Load(Path.Combine(SolutionDirInfo.FullName, "ServerCodeGenerators", "ProtobufSourceGenerator", "PacketRaw.xml"));

            return Doc;
        }
        public static string MakePacketClassName(string XmlClassName, string PacketType)
        {
            switch (PacketType)
            {
                case "Request":
                {
                    return String.Join("_", XmlClassName, "RQ");
                }
                case "Response":
                {
                    return String.Join("_", XmlClassName, "RS");
                }
                case "Notify":
                {
                    return String.Join("_", XmlClassName, "NT");
                }
                case "Report":
                {
                    return String.Join("_", XmlClassName, "RP");
                }
                default:
                {
                    Console.WriteLine($"정의되지않은 패킷타입입니다. PacketType: {PacketType}");
                    Environment.Exit(999);
                    return String.Empty;
                }

            }
        }

    }
}
