using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using ServerLib;
using ServerLib.Packet;

namespace ClientBot
{
    class ServerConnector : Connector
    {
        protected override void OnConnect(IPEndPoint endPoint)
        {
            Logger.Log(LogLevel.Temp, $"[Connected] {endPoint.ToString()}");
        }
    }

    class ServerSession : Session
    {
        static int msgNo = 0;
        public override void OnConnect(IPEndPoint endPoint)
        {
            Logger.Log(LogLevel.Temp, $"[Connect] {endPoint.ToString()}");

            while(true)
            {
                ushort packetId = ClassDictionaryTest_RQ.Id;

                PacketBase packetToSend = null;

                switch (packetId)
                {
                    case ChatMsg_RQ.Id:
                    {
                        packetToSend = new ChatMsg_RQ();
                        ChatMsg_RQ packet = (ChatMsg_RQ)packetToSend;
                        packet.msgText = "Hello From Client!!";
                        packet.time = DateTime.UtcNow;
                        break;
                    }
                    case ListTest_RQ.Id:
                    {
                        packetToSend = new ListTest_RQ();
                        ListTest_RQ packet = (ListTest_RQ)packetToSend;
                        packet.sentences = new List<string>();
                        packet.sentences.Add("Whassup!!");
                        packet.sentences.Add("Server!!");
                        packet.nickname = "wondong";
                        packet.time = DateTime.Now;
                        break;
                    }
                    case DictionaryTest_RQ.Id:
                    {
                        packetToSend = new DictionaryTest_RQ();
                        DictionaryTest_RQ packet = (DictionaryTest_RQ)packetToSend;
                        packet.numOfCharacters = new Dictionary<int, string>();
                        packet.numOfCharacters.Add(0, "Whassup!!");
                        packet.numOfCharacters.Add(1, "Server!!");
                        packet.nickname = "wondong";
                        packet.time = DateTime.Now;
                        break;
                    }
                    case ClassListTest_RQ.Id:
                    {
                        packetToSend = new ClassListTest_RQ();
                        ClassListTest_RQ packet = (ClassListTest_RQ)packetToSend;
                        packet.chatList = new List<ChatMsg_RQ>();
                        ChatMsg_RQ chat1 = new ChatMsg_RQ();
                        chat1.msgText = "Whassup!! ClassListTest!!";
                        ChatMsg_RQ chat2 = new ChatMsg_RQ();
                        chat2.msgText = "Server!! ClassListTest!!";
                        packet.chatList.Add(chat1);
                        packet.chatList.Add(chat2);
                        packet.nickname = "wondong";
                        packet.time = DateTime.Now;
                        break;
                    }
                    case ClassDictionaryTest_RQ.Id:
                    {
                        packetToSend = new ClassDictionaryTest_RQ();
                        ClassDictionaryTest_RQ packet = (ClassDictionaryTest_RQ)packetToSend;
                        packet.chatList = new Dictionary<int, ChatMsg_RQ>();
                        ChatMsg_RQ chat1 = new ChatMsg_RQ();
                        chat1.msgText = "Whassup!! ClassListTest!!";
                        ChatMsg_RQ chat2 = new ChatMsg_RQ();
                        chat2.msgText = "Server!! ClassListTest!!";
                        packet.chatList.Add(0, chat1);
                        packet.chatList.Add(1, chat2);
                        packet.nickname = "wondong";
                        packet.time = DateTime.Now;
                        break;
                    }
                }

                if(packetToSend != null)
                {
                    Send(packetToSend);
                    Thread.Sleep(1500);
                }
            }
        }

        protected override void OnDisconnect()
        {
            Logger.Log(LogLevel.Temp, $"[Disconnect]");
        }

        protected override void OnRecv(PacketBase packet)
        {
            if (packet is ChatMsg_RS)
            {
                ChatMsg_RS ChatMsg = (ChatMsg_RS)packet;
                Logger.Log(LogLevel.Temp, $"[Recv] {ChatMsg.msgText} / {ChatMsg.time}");
            }
            else if (packet is ListTest_RQ)
            {
                ListTest_RQ ListTest = (ListTest_RQ)packet;
                foreach (var sentence in ListTest.sentences)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] sentences: {sentence}");
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {ListTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {ListTest.time}");
            }
            else if (packet is DictionaryTest_RS)
            {
                DictionaryTest_RS DictTest = (DictionaryTest_RS)packet;
                foreach (var pair in DictTest.numOfCharacters)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] key: {pair.Key} / value: {pair.Value}");
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {DictTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {DictTest.time}");
            }
            else if (packet is ClassListTest_RS)
            {
                ClassListTest_RS ChatListTest = (ClassListTest_RS)packet;
                foreach (var chat in ChatListTest.chatList)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] chat.msgText : {chat.msgText}");
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.nickname: {ChatListTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.time: {ChatListTest.time}");
            }
            else if (packet is ClassDictionaryTest_RS)
            {
                ClassDictionaryTest_RS ChatListTest = (ClassDictionaryTest_RS)packet;
                foreach (var chat in ChatListTest.chatList)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ClassDictionaryTest_RS] chat.msgText : {chat.Key} / {chat.Value.msgText}");
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.nickname: {ChatListTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.time: {ChatListTest.time}");
            }
            else
            {
                Logger.Log(LogLevel.Temp, $"[Recv] {packet.GetType().Name}");
            }
        }

        protected override void OnSend(int sendSize)
        {
            Logger.Log(LogLevel.Temp, $"[Send] Send Size : {sendSize}");
        }
    }


    class Program
    {
        static ServerConnector _conn = new ServerConnector();
        static void Main(string[] args)
        {
            _conn.Connect(() => { return new ServerSession(); });

            while (true)
            {
            }
        }
    }
}
