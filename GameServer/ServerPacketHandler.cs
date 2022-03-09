using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib;
using ServerLib.Adam;
using ServerLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Time = Packet.Time,
            };

            Session.Send(PacketToSend);
        }

        protected override void OnRecvPing_RS(Ping_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::Ping_RS] {Packet.ToJson()}");
        }

        protected override void OnRecvChatMsg_RQ(ChatMsg_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RQ] {Packet.ToJson()}");

            ChatMsg_RS PacketToSend = new ChatMsg_RS()
            {
                Time = Packet.Time,
                MsgText = Packet.MsgText,
            };

            Session.Send(PacketToSend);
        }

        protected override void OnRecvChatMsg_RS(ChatMsg_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RS] {Packet.ToJson()}");
        }

        protected override void OnRecvListTest_RQ(ListTest_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] {Packet.ToJson()}");

            List<int> NumOfSentences = new List<int>();
            foreach (var Sentence in Packet.Sentences)
                NumOfSentences.Add(Sentence.Length);

            ListTest_RS PacketToSend = new ListTest_RS()
            {
                Time = Packet.Time,
                Nickname = Packet.Nickname,
            };
            PacketToSend.NumOfSentences.Add(NumOfSentences);

            Session.Send(PacketToSend);
        }

        protected override void OnRecvListTest_RS(ListTest_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RS] {Packet.ToJson()}");
        }

        protected override void OnRecvDictionaryTest_RQ(DictionaryTest_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::DictionaryTest_RQ] {Packet.ToJson()}");

            Dictionary<string, int> NumOfSentences = new Dictionary<string, int>();
            foreach (var Pair in Packet.NumOfSentences)
                NumOfSentences.Add(Pair.Value, Pair.Key);

            DictionaryTest_RS PacketToSend = new DictionaryTest_RS()
            {
                Time = Packet.Time,
                Nickname = Packet.Nickname,
            };
            PacketToSend.NumOfSentences.Add(NumOfSentences);

            Session.Send(PacketToSend);
        }

        protected override void OnRecvDictionaryTest_RS(DictionaryTest_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::DictionaryTest_RS] {Packet.ToJson()}");
        }

        protected override void OnRecvClassListTest_RQ(ClassListTest_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] {Packet.ToJson()}");

            List<ChatMsg_RS> ChatLIst = new List<ChatMsg_RS>();
            foreach (var Chat in Packet.ChatLIst)
                ChatLIst.Add(new ChatMsg_RS() { MsgText = Chat.MsgText, Time = Chat.Time });

            ClassListTest_RS PacketToSend = new ClassListTest_RS()
            {
                Time = Packet.Time,
                Nickname = Packet.Nickname,
            };
            PacketToSend.ChatLIst.Add(ChatLIst);

            Session.Send(PacketToSend);
        }

        protected override void OnRecvClassListTest_RS(ClassListTest_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RS] {Packet.ToJson()}");
        }

        protected override void OnRecvClassDictionaryTest_RQ(ClassDictionaryTest_RQ Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] {Packet.ToJson()}");

            Dictionary<int, ChatMsg_RS> ChatLIst = new Dictionary<int, ChatMsg_RS>();
            foreach (var Pair in Packet.ChatLIst)
                ChatLIst.Add(Pair.Key, new ChatMsg_RS() { MsgText = Pair.Value.MsgText, Time = Pair.Value.Time });

            ClassDictionaryTest_RS PacketToSend = new ClassDictionaryTest_RS()
            {
                Time = Packet.Time,
                Nickname = Packet.Nickname,
            };
            PacketToSend.ChatLIst.Add(ChatLIst);

            Session.Send(PacketToSend);
        }

        protected override void OnRecvClassDictionaryTest_RS(ClassDictionaryTest_RS Packet)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassDictionaryTest_RS] {Packet.ToJson()}");
        }
    }
}
