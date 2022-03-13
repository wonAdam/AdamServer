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
            AdamPacketHandlerGenerator.Generate(Doc);
            AdamPacketIdPartialClassesGenerator.Generate(Doc);
        }
    }
}
