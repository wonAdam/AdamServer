using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Protocol.PacketGenerated;
using ServerLib;
using ServerLib.Packet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;

namespace GameServer
{
    class LobbySession : AdamSession
    {
        static int msgNo = 0;

        public override void OnConnect(IPEndPoint endPoint)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Connect] {endPoint.ToString()}");
        }

        protected override void OnDisconnect()
        {
            AdamLogger.Log(LogLevel.Temp, $"[Disconnect]");
        }

        protected override void OnRecv(PacketHeader Header, IMessage Packet)
        {
            if (Packet is ChatMsg_RQ)
            {
                ChatMsg_RQ ChatMsg = (ChatMsg_RQ)Packet;
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RQ] {ChatMsg.MsgText} / {ChatMsg.Time}");

                ChatMsg_RS PacketToSend = new ChatMsg_RS();
                PacketToSend.MsgText = "Hello From Server!!";
                PacketToSend.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                Send(PacketToSend);
            }
            else if (Packet is ListTest_RQ)
            {
                ListTest_RQ ListTest = (ListTest_RQ)Packet;
                ListTest_RS packetToSend = new ListTest_RS();
                List<int> NumOfSentences = new List<int>();
                foreach (var Sentence in ListTest.Sentences)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] Sentence: {Sentence}");
                    NumOfSentences.Add(Sentence.Length);
                }
                packetToSend.NumOfSentences.Add(NumOfSentences);

                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] Nickname: {ListTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] Time {ListTest.Time}");

                packetToSend.Nickname = ListTest.Nickname;
                packetToSend.Time = ListTest.Time;

                Send(ListTest);
            }
            else if (Packet is DictionaryTest_RQ)
            {
                DictionaryTest_RQ DictTest = (DictionaryTest_RQ)Packet;
                DictionaryTest_RS PacketToSend = new DictionaryTest_RS();
                Dictionary<string, int> NumOfSentences = new Dictionary<string, int>();
                foreach (var pair in DictTest.NumOfSentences)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] key: {pair.Key} / value: {pair.Value}");
                    NumOfSentences.Add(pair.Value, pair.Key);
                }
                PacketToSend.NumOfSentences.Add(NumOfSentences);

                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {DictTest.Nickname}");
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {DictTest.Time}");

                PacketToSend.Nickname = DictTest.Nickname;
                PacketToSend.Time = DictTest.Time;

                Send(PacketToSend);
            }
            else if (Packet is ClassListTest_RQ)
            {
                ClassListTest_RQ ChatListTest = (ClassListTest_RQ)Packet;
                ClassListTest_RS PacketToSend = new ClassListTest_RS();
                List<ChatMsg_RS> ChatList = new List<ChatMsg_RS>();
                foreach (var Chat in ChatListTest.ChatLIst)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] chat.msgText : {Chat.MsgText}");
                    ChatMsg_RS ChatToSend = new ChatMsg_RS();
                    ChatToSend.MsgText = Chat.MsgText;
                    ChatToSend.Time = Chat.Time;
                    ChatList.Add(ChatToSend);
                }
                PacketToSend.ChatLIst.Add(ChatList);
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.time: {ChatListTest.Time}");
                PacketToSend.Nickname = ChatListTest.Nickname;
                PacketToSend.Time = ChatListTest.Time;

                Send(PacketToSend);
            }
            else if (Packet is ClassDictionaryTest_RQ)
            {
                ClassDictionaryTest_RQ ChatListTest = (ClassDictionaryTest_RQ)Packet;
                ClassDictionaryTest_RS PacketToSend = new ClassDictionaryTest_RS();
                Dictionary<int, ChatMsg_RS>  ChatList = new Dictionary<int, ChatMsg_RS>();
                foreach (var chat in ChatListTest.ChatLIst)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassDictionaryTest_RQ] chat.msgText : {chat.Key} / {chat.Value.MsgText}");
                    ChatMsg_RS ChatToSend = new ChatMsg_RS();
                    ChatToSend.MsgText = chat.Value.MsgText;
                    ChatToSend.Time = chat.Value.Time;
                    ChatList.Add(chat.Key, ChatToSend);
                }
                PacketToSend.ChatLIst.Add(ChatList);
                AdamLogger.Log(LogLevel.Temp, $"[Recv::ClassDictionaryTest_RQ] ChatListTest.time: {ChatListTest.Time}");
                PacketToSend.Nickname = ChatListTest.Nickname;
                PacketToSend.Time = ChatListTest.Time;

                Send(PacketToSend);
            }
            else
            {
                AdamLogger.Log(LogLevel.Temp, $"[Recv] {Packet.GetType().Name}");
            }

        }

        protected override void OnSend(int sendSize)
        {
            AdamLogger.Log(LogLevel.Temp, $"[Send] Send Size : {sendSize}");
        }
    }

    class Program
    {
        static AdamListener Listener = new AdamListener();
        static void Main(string[] args)
        {
            Listener.Init(() => { return new LobbySession(); });

            while (true)
            {
            }
        }
    }   
}
