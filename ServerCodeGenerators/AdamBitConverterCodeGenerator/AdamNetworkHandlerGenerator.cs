using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdamBitConverterCodeGenerator
{
    internal class AdamNetworkHandlerGenerator
    {
        internal static void Generate(XmlDocument Doc)
        {
            GenerateAdamNetworkHandler(Doc);
        }

        private static void GenerateAdamNetworkHandler(XmlDocument Doc)
        {
            StringBuilder SbActionMembers = new StringBuilder();
            StringBuilder SbSwitchCaseStatements = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            foreach (XmlNode ClassNode in PacketsNode.ChildNodes)
            {
                if (ClassNode.FirstChild.Name != "Name" || ClassNode.SelectSingleNode("Name") == null)
                {
                    Console.WriteLine("Class의 첫번째 자식노드는 Name노드여야 합니다.");
                    Environment.Exit(999);
                }

                string ClassName = ClassNode.SelectSingleNode("Name").InnerText;

                string SerializeFunc = String.Format(OnRecvActionFormat, ClassName);
                SbActionMembers.Append(SerializeFunc);

                string DeserializeFunc = String.Format(GetTypeSwitchCaseFormat, ClassName);
                SbSwitchCaseStatements.Append(DeserializeFunc);
            }

            string AdamNetworkHandlerContent = String.Format(AdamNetworkHandlerFormat, SbActionMembers.ToString(), SbSwitchCaseStatements.ToString());
            DirectoryInfo SolutionDir = PathManager.TryGetSolutionDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "ServerLib", "Packet", "AdamNetworkHandlerGenerated.cs");
            File.WriteAllText(FilePath, AdamNetworkHandlerContent);
        }


        // 0: Action들
        // 1: OnRecv
        private static string AdamNetworkHandlerFormat =
@"
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;
using System.Net;

namespace ServerLib.Adam
{{
    public class AdamNetworkHandlerGenerated : AdamSession
    {{
        public Action<IPEndPoint> OnConnectedEvent;

        public Action OnDisconnectedEvent;

        public Action<int> OnSendEvent;

        {0}
    
        public override void OnConnect(IPEndPoint endPoint)
        {{
            OnConnectedEvent.Invoke(endPoint);
        }}

        protected override void OnDisconnect()
        {{
            OnDisconnectedEvent.Invoke();
        }}

        protected override void OnSend(int sendSize)
        {{
            OnSendEvent.Invoke(sendSize);
        }}

        protected override void OnRecv(PacketHeader Header, IMessage Packet)
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
        public Action<{0}> OnRecv{0};
";

        // 0: Protobuf 자동생성클래스 타입
        private static string GetTypeSwitchCaseFormat =
@"
                case {0}.Id:
                {{
                    OnRecv{0}.Invoke(({0})Packet);
                    break;
                }}
";

    }
}
