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
    internal class AdamPacketHandlerGenerator
    {
        internal static void Generate(XmlDocument Doc)
        {
            GenerateAdamPacketHandler(Doc);
        }

        private static void GenerateAdamPacketHandler(XmlDocument Doc)
        {
            StringBuilder SbActionMembers = new StringBuilder();
            StringBuilder SbSwitchCaseStatements = new StringBuilder();
            StringBuilder SbOnRecvVirtualFuncs = new StringBuilder();

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

                string SerializeFunc = String.Format(OnRecvActionFormat, PacketClassName);
                SbActionMembers.Append(SerializeFunc);

                string DeserializeFunc = String.Format(GetTypeSwitchCaseFormat, PacketClassName);
                SbSwitchCaseStatements.Append(DeserializeFunc);

                string OnRecvFunc = String.Format(OnRecvFuncFormat, PacketClassName);
                SbOnRecvVirtualFuncs.Append(OnRecvFunc);
            }

            string AdamNetworkHandlerContent = String.Format(
                AdamPacketHandlerFormat, 
                SbActionMembers.ToString(), 
                SbSwitchCaseStatements.ToString(),
                SbOnRecvVirtualFuncs.ToString());

            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "ServerLib", "Packet", "AdamPacketHandlerGenerated.cs");
            File.WriteAllText(FilePath, AdamNetworkHandlerContent);
        }


        // 0: Action들
        // 1: OnRecv
        // 1: OnRecv{패킷이름들}
        private static string AdamPacketHandlerFormat =
@"
using System;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;
using System.Net;

namespace ServerLib.Adam
{{
    public class AdamPacketHandlerGenerated
    {{
        protected AdamSession Session;
        public AdamPacketHandlerGenerated(AdamSession InSession)
        {{
            Session = InSession;
            Session.OnRecvEvent += (PacketHeader InHeader, IMessage InPacket) => {{ OnRecv(InHeader, InPacket); }};
            Session.OnConnectEvent += () => {{ OnConnect(); }};
            Session.OnDisconnectEvent += () => {{ OnDisconnect(); }};
            Session.OnSendEvent += (int SendSize) => {{ OnSend(SendSize); }};
            Session.OnPreSendEvent += (PacketHeader Header, IMessage Packet) => {{ OnPreSend(Header, Packet); }};
        }}
    
        {0}

        {2}

        protected virtual void OnSend() 
        {{
        }}

        protected virtual void OnConnect() 
        {{
        }}
        protected virtual void OnSend(int SendSize) 
        {{
        }}
        protected virtual void OnPreSend(PacketHeader Header, IMessage Packet) 
        {{
        }}

        protected virtual void OnDisconnect() 
        {{
        }}

        protected virtual void OnRecv(PacketHeader Header, IMessage Packet)
        {{
            switch(Header.PacketId)
            {{
               {1}

                default:
                {{
                    AdamLogger.Log(LogLevel.Error, $""정의되지 않은 패킷이 들어왔습니다. {{Packet.GetType()}}"");
                    break;
                }}
            }}
        }}
    }}
}}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvActionFormat =
@"
        public Action<{0}> OnRecvEvent{0};
";

        // 0: Protobuf 자동생성클래스 타입
        private static string GetTypeSwitchCaseFormat =
@"
                case {0}.Id:
                {{
                    OnRecvEvent{0}?.Invoke(({0})Packet);
                    OnRecv{0}(({0})Packet);
                    break;
                }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvFuncFormat =
@"
        protected virtual void OnRecv{0}({0} Packet)
        {{
        }}
";

    }
}
