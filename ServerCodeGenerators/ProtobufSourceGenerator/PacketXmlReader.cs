using System;
using System.Collections.Generic;
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
    }
}
