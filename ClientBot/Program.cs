using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using Google.Protobuf;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib;
using ServerLib.Packet;

namespace ClientBot
{
    class ServerConnector : AdamConnector
    {
        protected override void OnConnect(IPEndPoint endPoint)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Connected] {endPoint.ToString()}");
        }
    }

    class ServerSession : AdamSession
    {
        static int MsgNo = 0;
        public override void OnConnect(IPEndPoint endPoint)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Connect] {endPoint.ToString()}");
            Random Rand = new Random((int)DateTime.UtcNow.Ticks);

            while (true)
            {
                ushort packetId = (ushort)Rand.Next(Ping_RQ.Id, ClassDictionaryTest_RQ.Id);

                IMessage PacketToSend = null;

                switch (packetId)
                {
                    case ChatMsg_RQ.Id:
                    {
                        PacketToSend = new ChatMsg_RQ();
                        ChatMsg_RQ Packet = (ChatMsg_RQ)PacketToSend;
                        Packet.MsgText = "Hello From Client!!";
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                    case ListTest_RQ.Id:
                    {
                        PacketToSend = new ListTest_RQ();
                        ListTest_RQ Packet = (ListTest_RQ)PacketToSend;
                        List<string> Sentences = new List<string>() { "Whassup!!", "Server!!" };
                        Packet.Sentences.Add(Sentences);
                        Packet.Nickname = "wondong";
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                    case DictionaryTest_RQ.Id:
                    {
                        PacketToSend = new DictionaryTest_RQ();
                        DictionaryTest_RQ Packet = (DictionaryTest_RQ)PacketToSend;
                        Dictionary<int, string> NumOfSentences = new Dictionary<int, string>()
                        {
                            { 0, "Whassup!!" },
                            { 1, "Server!!" }
                        };
                        Packet.NumOfSentences.Add(NumOfSentences);
                        Packet.Nickname = "wondong";
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                    case ClassListTest_RQ.Id:
                    {
                        PacketToSend = new ClassListTest_RQ();
                        ClassListTest_RQ Packet = (ClassListTest_RQ)PacketToSend;
                        List<ChatMsg_RQ> ChatLIst = new List<ChatMsg_RQ>()
                        {
                            new ChatMsg_RQ(){ MsgText = "Whassup!! ClassListTest!!"},
                            new ChatMsg_RQ(){ MsgText = "Server!! ClassListTest!!"},
                        };

                        Packet.ChatLIst.Add(ChatLIst);
                        Packet.Nickname = "wondong";
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                    case ClassDictionaryTest_RQ.Id:
                    {
                        PacketToSend = new ClassDictionaryTest_RQ();
                        ClassDictionaryTest_RQ Packet = (ClassDictionaryTest_RQ)PacketToSend;
                        Dictionary<int, ChatMsg_RQ> ChatLIst = new Dictionary<int, ChatMsg_RQ>()
                        {
                            { 0 ,new ChatMsg_RQ(){ MsgText = "Whassup!! ClassListTest!!" } },
                            { 1, new ChatMsg_RQ(){ MsgText = "Server!! ClassListTest!!" } },
                        };
                        Packet.Nickname = "wondong";
                        Packet.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                        break;
                    }
                }

                if (PacketToSend != null)
                {
                    Send(PacketToSend);
                    Thread.Sleep(Rand.Next(100, 1000));
                }

            }
        }

        protected override void OnDisconnect()
        {
            AdamLogger.Log(LogLevel.Temp, $"[Disconnect]");
        }

        protected override void OnRecv(PacketHeader Header, IMessage Packet)
        {
            if (Packet is ChatMsg_RS)
            {
                ChatMsg_RS ChatMsg = (ChatMsg_RS)Packet;
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RS] {ChatMsg.MsgText} / {ChatMsg.Time}");
            }
            else if (Packet is ChatMsg_RQ)
            {
                ChatMsg_RQ ChatMsg = (ChatMsg_RQ)Packet;
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RQ] {ChatMsg.MsgText} / {ChatMsg.Time}");
            }
            else if (Packet is ListTest_RQ)
            {
                ListTest_RQ ListTest = (ListTest_RQ)Packet;
                foreach (var Sentence in ListTest.Sentences)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] sentences: {Sentence}");
                }
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {ListTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {ListTest.Time}");
            }
            else if (Packet is DictionaryTest_RS)
            {
                DictionaryTest_RS DictTest = (DictionaryTest_RS)Packet;
                foreach (var Pair in DictTest.NumOfSentences)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RS] key: {Pair.Key} / value: {Pair.Value}");
                }
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RS] nickname: {DictTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RS] time: {DictTest.Time}");
            }
            else if (Packet is ClassListTest_RS)
            {
                ClassListTest_RS ChatListTest = (ClassListTest_RS)Packet;
                foreach (var Chat in ChatListTest.ChatLIst)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] chat.msgText : {Chat.MsgText}");
                }
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.nickname: {ChatListTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.time: {ChatListTest.Time}");
            }
            else if (Packet is ClassDictionaryTest_RS)
            {
                ClassDictionaryTest_RS ChatListTest = (ClassDictionaryTest_RS)Packet;
                foreach (var Chat in ChatListTest.ChatLIst)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassDictionaryTest_RS] chat.msgText : {Chat.Key} / {Chat.Value.MsgText}");
                }
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RS] ChatListTest.nickname: {ChatListTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RS] ChatListTest.time: {ChatListTest.Time}");
            }
            else
            {
                AdamLogger.Log(LogLevel.Temp, $"[Recv] {Packet.GetType().Name}");
            }
        }

        protected override void OnSend(int SendSize)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Send] Send Size : {SendSize}");
        }
    }


    class Program
    {
        static ServerConnector Conn = new ServerConnector();
        static void Main(string[] args)
        {
            Conn.Connect(() => { return new ServerSession(); });

            while (true)
            {
            }
        }
    }
}
