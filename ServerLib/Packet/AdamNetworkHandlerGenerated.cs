
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;
using System.Net;

namespace ServerLib.Adam
{
    public class AdamNetworkHandlerGenerated : AdamSession
    {
        public Action<IPEndPoint> OnConnectedEvent;

        public Action OnDisconnectedEvent;

        public Action<int> OnSendEvent;

        
        public Action<Ping_RQ> OnRecvPing_RQ;

        public Action<Ping_RS> OnRecvPing_RS;

        public Action<ChatMsg_RQ> OnRecvChatMsg_RQ;

        public Action<ChatMsg_RS> OnRecvChatMsg_RS;

        public Action<ListTest_RQ> OnRecvListTest_RQ;

        public Action<ListTest_RS> OnRecvListTest_RS;

        public Action<DictionaryTest_RQ> OnRecvDictionaryTest_RQ;

        public Action<DictionaryTest_RS> OnRecvDictionaryTest_RS;

        public Action<ClassListTest_RQ> OnRecvClassListTest_RQ;

        public Action<ClassListTest_RS> OnRecvClassListTest_RS;

        public Action<ClassDictionaryTest_RQ> OnRecvClassDictionaryTest_RQ;

        public Action<ClassDictionaryTest_RS> OnRecvClassDictionaryTest_RS;

    
        public override void OnConnect(IPEndPoint endPoint)
        {
            OnConnectedEvent.Invoke(endPoint);
        }

        protected override void OnDisconnect()
        {
            OnDisconnectedEvent.Invoke();
        }

        protected override void OnSend(int sendSize)
        {
            OnSendEvent.Invoke(sendSize);
        }

        protected override void OnRecv(PacketHeader Header, IMessage Packet)
        {
            switch(Header.PacketId)
            {
               
                case Ping_RQ.Id:
                {
                    OnRecvPing_RQ.Invoke((Ping_RQ)Packet);
                    break;
                }

                case Ping_RS.Id:
                {
                    OnRecvPing_RS.Invoke((Ping_RS)Packet);
                    break;
                }

                case ChatMsg_RQ.Id:
                {
                    OnRecvChatMsg_RQ.Invoke((ChatMsg_RQ)Packet);
                    break;
                }

                case ChatMsg_RS.Id:
                {
                    OnRecvChatMsg_RS.Invoke((ChatMsg_RS)Packet);
                    break;
                }

                case ListTest_RQ.Id:
                {
                    OnRecvListTest_RQ.Invoke((ListTest_RQ)Packet);
                    break;
                }

                case ListTest_RS.Id:
                {
                    OnRecvListTest_RS.Invoke((ListTest_RS)Packet);
                    break;
                }

                case DictionaryTest_RQ.Id:
                {
                    OnRecvDictionaryTest_RQ.Invoke((DictionaryTest_RQ)Packet);
                    break;
                }

                case DictionaryTest_RS.Id:
                {
                    OnRecvDictionaryTest_RS.Invoke((DictionaryTest_RS)Packet);
                    break;
                }

                case ClassListTest_RQ.Id:
                {
                    OnRecvClassListTest_RQ.Invoke((ClassListTest_RQ)Packet);
                    break;
                }

                case ClassListTest_RS.Id:
                {
                    OnRecvClassListTest_RS.Invoke((ClassListTest_RS)Packet);
                    break;
                }

                case ClassDictionaryTest_RQ.Id:
                {
                    OnRecvClassDictionaryTest_RQ.Invoke((ClassDictionaryTest_RQ)Packet);
                    break;
                }

                case ClassDictionaryTest_RS.Id:
                {
                    OnRecvClassDictionaryTest_RS.Invoke((ClassDictionaryTest_RS)Packet);
                    break;
                }


                default:
                {
                    AdamLogger.Log(LogLevel.Error, $"정의되지 않은 패킷이 들어왔습니다. {Packet.GetType()}");
                    break;
                }
            }
        }
    }
}
