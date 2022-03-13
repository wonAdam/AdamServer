using GameServer.Model;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using Microsoft.EntityFrameworkCore;
using ServerLib;
using ServerLib.Adam;
using ServerLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GameServer
{
    internal class ServerPacketHandler : AdamPacketHandlerGenerated
    {
        public ServerPacketHandler(AdamSession InSession) : base(InSession)
        {
        }

        protected override void OnRecvPing_RQ(Ping_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::Ping_RQ] {Packet.ToJson()}");

            Ping_RS PacketToSend = new Ping_RS()
            { 
                Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
            };

            Session.Send(PacketToSend);
        }

        protected override async void OnRecvCreateAccount_RQ(CreateAccount_RQ Packet)
        {
            base.OnRecvCreateAccount_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::CreateAccount_RQ] {Packet.ToJson()}");

            using (var Context = new SDDbContext())
            {
                Account? DuplicateAccount = Context.Accounts
                    .Where((Account Target) => Target.Nickname == Packet.Nickname)
                    .FirstOrDefault();

                if (DuplicateAccount != null)
                    return;

                HashSalt ResultHashSalt = HashHelper.Hash(Packet.Password);

                var Entry = Context.Accounts.Add(new Account { 
                    Nickname = Packet.Nickname, 
                    PasswordHash = ResultHashSalt.Hash, 
                    PasswordSalt = ResultHashSalt.Salt 
                });

                await Context
                .SaveChangesAsync()
                .ContinueWith(SaveTask =>
                    {
                        CreateAccount_RS Response = new CreateAccount_RS();
                        Session.Send(Response);
                    });
            }
        }

        protected override void OnRecvLogin_RQ(Login_RQ Packet)
        {
            base.OnRecvLogin_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::Login_RQ] {Packet.ToJson()}");

            using (var Context = new SDDbContext())
            {
                Account? NicknameMatchAccount = Context.Accounts
                    .Where((Account) => Account.Nickname == Packet.Nickname)
                    .FirstOrDefault();

                if (NicknameMatchAccount == null)
                    return; // todo.wondong Error 패킷 보내기

                bool PasswordMatch = HashHelper.Verify(
                    Packet.Password, 
                    new HashSalt() { 
                        Hash = NicknameMatchAccount.PasswordHash,
                        Salt = NicknameMatchAccount.PasswordSalt
                    });

                Login_RS Response = new Login_RS() { LoginSuccess = PasswordMatch };
                Session.Send(Response);
            }
        }

        protected override void OnRecvGetPlayerDbIdByPlayerNickname_RQ(GetPlayerDbIdByPlayerNickname_RQ Packet)
        {
            base.OnRecvGetPlayerDbIdByPlayerNickname_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::OnRecvGetPlayerDbIdByPlayerNickname_RQ] {Packet.ToJson()}");

            using (var Context = new SDDbContext())
            {
                Account? NicknameMatchAccount = Context.Accounts
                    .Where((Account) => Account.Nickname == Packet.Nickname)
                    .FirstOrDefault();

                if (NicknameMatchAccount == null)
                    return; // todo.wondong Error 패킷 보내기

                GetPlayerDbIdByPlayerNickname_RS Response = new GetPlayerDbIdByPlayerNickname_RS() { PlayerDbId = NicknameMatchAccount.DbId };
                Session.Send(Response);
            }
        }

        protected override void OnRecvDummy1_RQ(Dummy1_RQ Packet)
        {
            base.OnRecvDummy1_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::OnRecvDummyDbUpdate_RQ] {Packet.ToJson()}");

            Dummy1_RS Response = new Dummy1_RS()
            { 
                DummyStrings =
                {
                    "dqwdieurqoqiuofnasdlfnoisdajhfois",
                    "dqiwjodijaslknkljsznvoizsjfoisd",
                    Packet.DummyString,
                }
            
            };

            Session.Send(Response);
        }

        protected override void OnRecvDummy2_RQ(Dummy2_RQ Packet)
        {
            base.OnRecvDummy2_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::OnRecvDummyDbUpdate_RQ] {Packet.ToJson()}");

            Dummy2_RS Response = new Dummy2_RS()
            {
                DummyString = Packet.DummyStrings[0]

            };

            Session.Send(Response);
        }

        protected override async void OnRecvDummyDbUpdate_RQ(DummyDbUpdate_RQ Packet)
        {
            base.OnRecvDummyDbUpdate_RQ(Packet);

            AdamLogger.Log(LogLevel.Temp, $"[Recv::OnRecvDummyDbUpdate_RQ] {Packet.ToJson()}");

            using (var Context = new SDDbContext())
            {
                DummyDBUpdate? DbUpdate = Context.DummyDBUpdates
                    .Where((Update) => Update.PlayerDbId == Packet.PlayerDbId)
                    .FirstOrDefault();

                if (DbUpdate == null)
                    Context.DummyDBUpdates.Add(new DummyDBUpdate() { PlayerDbId = Packet.PlayerDbId, Value = Packet.Value });
                else
                    DbUpdate.Value = Packet.Value;

                await Context
                .SaveChangesAsync()
                .ContinueWith((SaveTask) =>
                {
                    DummyDbUpdate_RS Response = new DummyDbUpdate_RS() { Value = Packet.Value };
                    Session.Send(Response);
                });
            }
        }
    }

}
