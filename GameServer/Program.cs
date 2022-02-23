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
    class LobbySession : Session
    {
        static int msgNo = 0;

        public override void OnConnect(IPEndPoint endPoint)
        {
            Logger.Log(LogLevel.Temp, $"[Connect] {endPoint.ToString()}");
        }

        protected override void OnDisconnect()
        {
            Logger.Log(LogLevel.Temp, $"[Disconnect]");
        }

        protected override void OnRecv(PacketBase packet)
        {
            if(packet is ChatMsg_RQ)
            {
                ChatMsg_RQ ChatMsg = (ChatMsg_RQ)packet;
                Logger.Log(LogLevel.Temp, $"[Recv::ChatMsg_RQ] {ChatMsg.msgText} / {ChatMsg.time}");

                ChatMsg_RS packetToSend = new ChatMsg_RS();
                packetToSend.msgText = "Hello From Server!!";
                packetToSend.time = DateTime.UtcNow;

                Send(packetToSend);
            }
            else if(packet is ListTest_RQ)
            {
                ListTest_RQ ListTest = (ListTest_RQ)packet;
                ListTest_RS packetToSend = new ListTest_RS();
                packetToSend.numOfCharacters = new List<int>();
                foreach (var sentence in ListTest.sentences)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] sentences: {sentence}");
                    packetToSend.numOfCharacters.Add(sentence.Length);
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {ListTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {ListTest.time}");

                packetToSend.nickname = ListTest.nickname;
                packetToSend.time = ListTest.time;

                Send(ListTest);
            }
            else if (packet is DictionaryTest_RQ)
            {
                DictionaryTest_RQ DictTest = (DictionaryTest_RQ)packet;
                DictionaryTest_RS packetToSend = new DictionaryTest_RS();
                packetToSend.numOfCharacters = new Dictionary<string, int>();
                foreach (var pair in DictTest.numOfCharacters)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] key: {pair.Key} / value: {pair.Value}");
                    packetToSend.numOfCharacters.Add(pair.Value, pair.Key);
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] nickname: {DictTest.nickname}");
                Logger.Log(LogLevel.Temp, $"[Recv::ListTest_RQ] time: {DictTest.time}");

                packetToSend.nickname = DictTest.nickname;
                packetToSend.time = DictTest.time;

                Send(packetToSend);
            }
            else if (packet is ClassListTest_RQ)
            {
                ClassListTest_RQ ChatListTest = (ClassListTest_RQ)packet;
                ClassListTest_RS packetToSend = new ClassListTest_RS();
                packetToSend.chatList = new List<ChatMsg_RS>();
                foreach (var chat in ChatListTest.chatList)
                {
                    Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] chat.msgText : {chat.msgText}");
                    ChatMsg_RS ChatToSend = new ChatMsg_RS();
                    ChatToSend.msgText = chat.msgText;
                    ChatToSend.time = chat.time;
                    packetToSend.chatList.Add(ChatToSend);
                }
                Logger.Log(LogLevel.Temp, $"[Recv::ClassListTest_RQ] ChatListTest.time: {ChatListTest.time}");
                packetToSend.nickname = ChatListTest.nickname;
                packetToSend.time = ChatListTest.time;

                Send(packetToSend);
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
        static Listener _listener = new Listener();
        static void Main(string[] args)
        {
            _listener.Init(() => { return new LobbySession(); });

            while (true)
            {
            }
        }
    }
}
