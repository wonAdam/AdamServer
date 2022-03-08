using ProtobufCodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamBitConverterGenerator
{

    internal class ProtobufCopyer
    {
        public static void Copy()
        {
            DirectoryInfo SolutionDirInfo = PathManager.TryGetSolutionDirectoryInfo();

            string DestinationPath = Path.Combine(SolutionDirInfo.FullName, "ServerLib", "Packet", "PacketProtobufGenerated.cs");
            string SourcePath = Path.Combine(SolutionDirInfo.FullName, "ProtobufCodeGenerator", "PacketProtobufGenerated.cs");

            File.Copy(SourcePath, DestinationPath, true);
        }
    }
}
