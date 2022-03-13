using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib;
using ServerLib.Adam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBot
{
    internal class ClientPacketHandler : AdamPacketHandlerGenerated
    {
        public ClientPacketHandler(AdamSession InSession) : base(InSession)
        {
        }

        private Random Rand = new Random((int)DateTime.UtcNow.Ticks);
        private long PlayerDbId { get; set; } = -1;

        protected override void OnConnect()
        {
            AdamLogger.Log(LogLevel.Temp, $"[Connect]");

            //CreateAccount_RQ AccountCreate = new CreateAccount_RQ()
            //{
            //    Nickname = "wondong",
            //    Password = "password",
            //};
            //Session.Send(AccountCreate);

            List<ushort> CandidatePacketIds = new List<ushort>()
            {
                Login_RQ.Id, Ping_RQ.Id, DummyDbUpdate_RQ.Id, Dummy1_RQ.Id, Dummy2_RQ.Id,
            };

            GetPlayerDbIdByPlayerNickname_RQ GetPlayerDbIdRequest = new GetPlayerDbIdByPlayerNickname_RQ()
            {
                Nickname = "wondong"
            };

            Session.Send(GetPlayerDbIdRequest);

            while (true)
            {
                int RandomIndex = Rand.Next(0, CandidatePacketIds.Count);
                ushort packetId = CandidatePacketIds[RandomIndex];

                IMessage PacketToSend = null;

                switch (packetId)
                {
                    case Ping_RQ.Id:
                    {
                        PacketToSend = new Ping_RQ();
                        Ping_RQ Packet = (Ping_RQ)PacketToSend;
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                    case Login_RQ.Id:
                    {
                        PacketToSend = new Login_RQ();
                        Login_RQ Packet = (Login_RQ)PacketToSend;
                        Packet.Nickname = "wondong";
                        Packet.Password = "wondongpassword";
                        break;
                    }
                    case Dummy1_RQ.Id:
                    {
                        PacketToSend = new Dummy1_RQ();
                        Dummy1_RQ Packet = (Dummy1_RQ)PacketToSend;
                        Packet.DummyString = "dqrdasfisdjroiawejorijw";
                        break;
                    }
                    case Dummy2_RQ.Id:
                    {
                        PacketToSend = new Dummy2_RQ();
                        Dummy2_RQ Packet = (Dummy2_RQ)PacketToSend;
                        Packet.DummyStrings.Add("ewaioroifasdjncszvmknzcmk");
                        Packet.DummyStrings.Add("araewfdsvdsvc");
                        Packet.DummyStrings.Add("bvszdfg");
                        Packet.DummyStrings.Add("ewaioroifadfqwedssdjncszvmknzcmk");
                        Packet.DummyStrings.Add("asfdwaqtpppppppppppppppppppppppppppppppppppppppppppppppppppppppp");
                        break;
                    }
                    case DummyDbUpdate_RQ.Id:
                    {
                        PacketToSend = new DummyDbUpdate_RQ();
                        DummyDbUpdate_RQ Packet = (DummyDbUpdate_RQ)PacketToSend;
                        Packet.Value = Rand.Next(0, 100000);
                        break;
                    }
                }

                if (PacketToSend != null)
                {
                    Session.Send(PacketToSend);
                    Thread.Sleep((1000 / 30));
                }

            }
        }

        protected override void OnRecvCreateAccount_RS(CreateAccount_RS Packet)
        {
            base.OnRecvCreateAccount_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());
        }

        protected override void OnRecvPing_RS(Ping_RS Packet)
        {
            base.OnRecvPing_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());
        }

        protected override void OnRecvLogin_RS(Login_RS Packet)
        {
            base.OnRecvLogin_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());
        }

        protected override void OnRecvGetPlayerDbIdByPlayerNickname_RS(GetPlayerDbIdByPlayerNickname_RS Packet)
        {
            base.OnRecvGetPlayerDbIdByPlayerNickname_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());

            PlayerDbId = Packet.PlayerDbId;

            DummyDbUpdate_RQ Request = new DummyDbUpdate_RQ()
            { 
                PlayerDbId = PlayerDbId,
                Value = Rand.Next(0, 10000),
            };

            Session.Send(Request);
        }

        protected override void OnRecvDummy1_RS(Dummy1_RS Packet)
        {
            base.OnRecvDummy1_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());
        }

        protected override void OnRecvDummy2_RS(Dummy2_RS Packet)
        {
            base.OnRecvDummy2_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());
        }

        protected override void OnRecvDummyDbUpdate_RS(DummyDbUpdate_RS Packet)
        {
            base.OnRecvDummyDbUpdate_RS(Packet);

            AdamLogger.Log(LogLevel.Temp, Packet.ToJson());

            DummyDbUpdate_RQ Request = new DummyDbUpdate_RQ()
            {
                PlayerDbId = PlayerDbId,
                Value = Rand.Next(0, 10000),
            };
            Session.Send(Request);
        }
    }
}
