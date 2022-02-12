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
            if(packet as ChatMsg_RQ != null)
            {
                ChatMsg_RQ ChatMsg = (ChatMsg_RQ)packet;
                Logger.Log(LogLevel.Temp, $"[Recv] {ChatMsg.msgText} / {ChatMsg.time}");
            }
            else
            {
                Logger.Log(LogLevel.Temp, $"[Recv] {packet.GetType().Name}");
            }

            ChatMsg_RS packetToSend = new ChatMsg_RS();
            packetToSend.msgText = "Hello From Server!!";
            packetToSend.time = DateTime.UtcNow;

            Send(packetToSend);
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
