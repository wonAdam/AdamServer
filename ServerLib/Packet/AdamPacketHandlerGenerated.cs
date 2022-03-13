
using System;
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

        public Action<CreateAccount_RQ> OnRecvEventCreateAccount_RQ;

        public Action<CreateAccount_RS> OnRecvEventCreateAccount_RS;

        public Action<Dummy2_RQ> OnRecvEventDummy2_RQ;

        public Action<Dummy2_RS> OnRecvEventDummy2_RS;

        public Action<Dummy1_RQ> OnRecvEventDummy1_RQ;

        public Action<Dummy1_RS> OnRecvEventDummy1_RS;

        public Action<Login_RQ> OnRecvEventLogin_RQ;

        public Action<Login_RS> OnRecvEventLogin_RS;

        public Action<DummyDbUpdate_RQ> OnRecvEventDummyDbUpdate_RQ;

        public Action<DummyDbUpdate_RS> OnRecvEventDummyDbUpdate_RS;

        public Action<GetPlayerDbIdByPlayerNickname_RQ> OnRecvEventGetPlayerDbIdByPlayerNickname_RQ;

        public Action<GetPlayerDbIdByPlayerNickname_RS> OnRecvEventGetPlayerDbIdByPlayerNickname_RS;


        
        protected virtual void OnRecvPing_RQ(Ping_RQ Packet)
        {
        }

        protected virtual void OnRecvPing_RS(Ping_RS Packet)
        {
        }

        protected virtual void OnRecvCreateAccount_RQ(CreateAccount_RQ Packet)
        {
        }

        protected virtual void OnRecvCreateAccount_RS(CreateAccount_RS Packet)
        {
        }

        protected virtual void OnRecvDummy2_RQ(Dummy2_RQ Packet)
        {
        }

        protected virtual void OnRecvDummy2_RS(Dummy2_RS Packet)
        {
        }

        protected virtual void OnRecvDummy1_RQ(Dummy1_RQ Packet)
        {
        }

        protected virtual void OnRecvDummy1_RS(Dummy1_RS Packet)
        {
        }

        protected virtual void OnRecvLogin_RQ(Login_RQ Packet)
        {
        }

        protected virtual void OnRecvLogin_RS(Login_RS Packet)
        {
        }

        protected virtual void OnRecvDummyDbUpdate_RQ(DummyDbUpdate_RQ Packet)
        {
        }

        protected virtual void OnRecvDummyDbUpdate_RS(DummyDbUpdate_RS Packet)
        {
        }

        protected virtual void OnRecvGetPlayerDbIdByPlayerNickname_RQ(GetPlayerDbIdByPlayerNickname_RQ Packet)
        {
        }

        protected virtual void OnRecvGetPlayerDbIdByPlayerNickname_RS(GetPlayerDbIdByPlayerNickname_RS Packet)
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

                case CreateAccount_RQ.Id:
                {
                    OnRecvEventCreateAccount_RQ?.Invoke((CreateAccount_RQ)Packet);
                    OnRecvCreateAccount_RQ((CreateAccount_RQ)Packet);
                    break;
                }

                case CreateAccount_RS.Id:
                {
                    OnRecvEventCreateAccount_RS?.Invoke((CreateAccount_RS)Packet);
                    OnRecvCreateAccount_RS((CreateAccount_RS)Packet);
                    break;
                }

                case Dummy2_RQ.Id:
                {
                    OnRecvEventDummy2_RQ?.Invoke((Dummy2_RQ)Packet);
                    OnRecvDummy2_RQ((Dummy2_RQ)Packet);
                    break;
                }

                case Dummy2_RS.Id:
                {
                    OnRecvEventDummy2_RS?.Invoke((Dummy2_RS)Packet);
                    OnRecvDummy2_RS((Dummy2_RS)Packet);
                    break;
                }

                case Dummy1_RQ.Id:
                {
                    OnRecvEventDummy1_RQ?.Invoke((Dummy1_RQ)Packet);
                    OnRecvDummy1_RQ((Dummy1_RQ)Packet);
                    break;
                }

                case Dummy1_RS.Id:
                {
                    OnRecvEventDummy1_RS?.Invoke((Dummy1_RS)Packet);
                    OnRecvDummy1_RS((Dummy1_RS)Packet);
                    break;
                }

                case Login_RQ.Id:
                {
                    OnRecvEventLogin_RQ?.Invoke((Login_RQ)Packet);
                    OnRecvLogin_RQ((Login_RQ)Packet);
                    break;
                }

                case Login_RS.Id:
                {
                    OnRecvEventLogin_RS?.Invoke((Login_RS)Packet);
                    OnRecvLogin_RS((Login_RS)Packet);
                    break;
                }

                case DummyDbUpdate_RQ.Id:
                {
                    OnRecvEventDummyDbUpdate_RQ?.Invoke((DummyDbUpdate_RQ)Packet);
                    OnRecvDummyDbUpdate_RQ((DummyDbUpdate_RQ)Packet);
                    break;
                }

                case DummyDbUpdate_RS.Id:
                {
                    OnRecvEventDummyDbUpdate_RS?.Invoke((DummyDbUpdate_RS)Packet);
                    OnRecvDummyDbUpdate_RS((DummyDbUpdate_RS)Packet);
                    break;
                }

                case GetPlayerDbIdByPlayerNickname_RQ.Id:
                {
                    OnRecvEventGetPlayerDbIdByPlayerNickname_RQ?.Invoke((GetPlayerDbIdByPlayerNickname_RQ)Packet);
                    OnRecvGetPlayerDbIdByPlayerNickname_RQ((GetPlayerDbIdByPlayerNickname_RQ)Packet);
                    break;
                }

                case GetPlayerDbIdByPlayerNickname_RS.Id:
                {
                    OnRecvEventGetPlayerDbIdByPlayerNickname_RS?.Invoke((GetPlayerDbIdByPlayerNickname_RS)Packet);
                    OnRecvGetPlayerDbIdByPlayerNickname_RS((GetPlayerDbIdByPlayerNickname_RS)Packet);
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
