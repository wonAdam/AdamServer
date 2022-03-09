using Google.Protobuf.Protocol.PacketGenerated;
using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdamBitConverterCodeGenerator
{
    internal class CodeGenerator
    {
        internal static void Generate()
        {
            XmlDocument Doc = PacketXmlReader.ReadPacketRaw();
            AdamBitConverterGenerator.Generate(Doc);
            AdamNetworkHandlerGenerator.Generate(Doc);
            AdamPacketIdPartialClassesGenerator.Generate(Doc);
            CopyGeneratedFilesToServerLib();
        }

        private static void CopyGeneratedFilesToServerLib()
        {
            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string PacketGenFilePath = Path.Combine(SolutionDir.FullName, "ServerCodeGenerators", "ProtobufTargetGenerater", "PacketGenerated.cs");
            string PacketGenDestFilePath = Path.Combine(SolutionDir.FullName, "ServerLib", "Packet", "PacketGenerated.cs");
            File.Copy(PacketGenFilePath, PacketGenDestFilePath, true);
        }


    }
}
