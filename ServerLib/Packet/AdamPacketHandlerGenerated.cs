
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib.Packet;
using System.Net;

namespace ServerLib.Adam
{
    public class AdamPacketHandlerGenerated
    {
        protected AdamSession Session;
        public AdamPacketHandlerGenerated(AdamSession InSession)
        {
            Session = InSession;
            Session.OnRecvEvent += (PacketHeader InHeader, IMessage InPacket) => { OnRecv(InHeader, InPacket); };
            Session.OnConnectEvent += () => { OnConnect(); };
            Session.OnDisconnectEvent += () => { OnDisconnect(); };
            Session.OnSendEvent += (int SendSize) => { OnSend(SendSize); };
            Session.OnPreSendEvent += (PacketHeader Header, IMessage Packet) => { OnPreSend(Header, Packet); };
        }
    
        
        public Action<Ping_RQ> OnRecvEventPing_RQ;

        public Action<Ping_RS> OnRecvEventPing_RS;

        public Action<ChatMsg_RQ> OnRecvEventChatMsg_RQ;

        public Action<ChatMsg_RS> OnRecvEventChatMsg_RS;

        public Action<ListTest_RQ> OnRecvEventListTest_RQ;

        public Action<ListTest_RS> OnRecvEventListTest_RS;

        public Action<DictionaryTest_RQ> OnRecvEventDictionaryTest_RQ;

        public Action<DictionaryTest_RS> OnRecvEventDictionaryTest_RS;

        public Action<ClassListTest_RQ> OnRecvEventClassListTest_RQ;

        public Action<ClassListTest_RS> OnRecvEventClassListTest_RS;

        public Action<ClassDictionaryTest_RQ> OnRecvEventClassDictionaryTest_RQ;

        public Action<ClassDictionaryTest_RS> OnRecvEventClassDictionaryTest_RS;


        
        protected virtual void OnRecvPing_RQ(Ping_RQ Packet)
        {
        }

        protected virtual void OnRecvPing_RS(Ping_RS Packet)
        {
        }

        protected virtual void OnRecvChatMsg_RQ(ChatMsg_RQ Packet)
        {
        }

        protected virtual void OnRecvChatMsg_RS(ChatMsg_RS Packet)
        {
        }

        protected virtual void OnRecvListTest_RQ(ListTest_RQ Packet)
        {
        }

        protected virtual void OnRecvListTest_RS(ListTest_RS Packet)
        {
        }

        protected virtual void OnRecvDictionaryTest_RQ(DictionaryTest_RQ Packet)
        {
        }

        protected virtual void OnRecvDictionaryTest_RS(DictionaryTest_RS Packet)
        {
        }

        protected virtual void OnRecvClassListTest_RQ(ClassListTest_RQ Packet)
        {
        }

        protected virtual void OnRecvClassListTest_RS(ClassListTest_RS Packet)
        {
        }

        protected virtual void OnRecvClassDictionaryTest_RQ(ClassDictionaryTest_RQ Packet)
        {
        }

        protected virtual void OnRecvClassDictionaryTest_RS(ClassDictionaryTest_RS Packet)
        {
        }


        protected virtual void OnSend() 
        {
        }

        protected virtual void OnConnect() 
        {
        }
        protected virtual void OnSend(int SendSize) 
        {
        }
        protected virtual void OnPreSend(PacketHeader Header, IMessage Packet) 
        {
        }

        protected virtual void OnDisconnect() 
        {
        }

        protected virtual void OnRecv(PacketHeader Header, IMessage Packet)
        {
            switch(Header.PacketId)
            {
               
                case Ping_RQ.Id:
                {
                    OnRecvEventPing_RQ?.Invoke((Ping_RQ)Packet);
                    OnRecvPing_RQ((Ping_RQ)Packet);
                    break;
                }

                case Ping_RS.Id:
                {
                    OnRecvEventPing_RS?.Invoke((Ping_RS)Packet);
                    OnRecvPing_RS((Ping_RS)Packet);
                    break;
                }

                case ChatMsg_RQ.Id:
                {
                    OnRecvEventChatMsg_RQ?.Invoke((ChatMsg_RQ)Packet);
                    OnRecvChatMsg_RQ((ChatMsg_RQ)Packet);
                    break;
                }

                case ChatMsg_RS.Id:
                {
                    OnRecvEventChatMsg_RS?.Invoke((ChatMsg_RS)Packet);
                    OnRecvChatMsg_RS((ChatMsg_RS)Packet);
                    break;
                }

                case ListTest_RQ.Id:
                {
                    OnRecvEventListTest_RQ?.Invoke((ListTest_RQ)Packet);
                    OnRecvListTest_RQ((ListTest_RQ)Packet);
                    break;
                }

                case ListTest_RS.Id:
                {
                    OnRecvEventListTest_RS?.Invoke((ListTest_RS)Packet);
                    OnRecvListTest_RS((ListTest_RS)Packet);
                    break;
                }

                case DictionaryTest_RQ.Id:
                {
                    OnRecvEventDictionaryTest_RQ?.Invoke((DictionaryTest_RQ)Packet);
                    OnRecvDictionaryTest_RQ((DictionaryTest_RQ)Packet);
                    break;
                }

                case DictionaryTest_RS.Id:
                {
                    OnRecvEventDictionaryTest_RS?.Invoke((DictionaryTest_RS)Packet);
                    OnRecvDictionaryTest_RS((DictionaryTest_RS)Packet);
                    break;
                }

                case ClassListTest_RQ.Id:
                {
                    OnRecvEventClassListTest_RQ?.Invoke((ClassListTest_RQ)Packet);
                    OnRecvClassListTest_RQ((ClassListTest_RQ)Packet);
                    break;
                }

                case ClassListTest_RS.Id:
                {
                    OnRecvEventClassListTest_RS?.Invoke((ClassListTest_RS)Packet);
                    OnRecvClassListTest_RS((ClassListTest_RS)Packet);
                    break;
                }

                case ClassDictionaryTest_RQ.Id:
                {
                    OnRecvEventClassDictionaryTest_RQ?.Invoke((ClassDictionaryTest_RQ)Packet);
                    OnRecvClassDictionaryTest_RQ((ClassDictionaryTest_RQ)Packet);
                    break;
                }

                case ClassDictionaryTest_RS.Id:
                {
                    OnRecvEventClassDictionaryTest_RS?.Invoke((ClassDictionaryTest_RS)Packet);
                    OnRecvClassDictionaryTest_RS((ClassDictionaryTest_RS)Packet);
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
