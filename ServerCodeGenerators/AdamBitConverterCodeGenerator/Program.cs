// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Text;
using System.Text.Json;
using AdamBitConverterGenerator;
using Google.Protobuf;
using ProtobufCodeGenerator;

// Protobuf Copy
ProtobufCopyer.Copy();

// Protobuf -> Type[]
Type[] PacketTypes = Assembly
    .GetAssembly(typeof(ProtobufMaker))
    .GetTypes()
    .Where(t => t.FullName.StartsWith("Google.Protobuf.Protocol.PacketGenerated"))
    .ToArray();

// Type[] -> Json
string JsonStr = ProtobufJsonMaker.MakeJsonStr(PacketTypes);
DirectoryInfo SolutionDirInfo = PathManager.TryGetSolutionDirectoryInfo();
string JsonFilePath = Path.Combine(SolutionDirInfo.FullName, "AdamBitConverterCodeGenerator", "PacketProtobufJsonGenerated.json"); 
File.WriteAllText(JsonFilePath, JsonStr, Encoding.UTF8);

// Json -> AdamBitConverter
