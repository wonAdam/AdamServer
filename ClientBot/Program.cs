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
                ChatMsg_RQ packetToSend = new ChatMsg_RQ();
                packetToSend.msgText = "Hello From Client!!";
                packetToSend.time = DateTime.UtcNow;

                Send(packetToSend);
                Thread.Sleep(1500);
            }
        }

        protected override void OnDisconnect()
        {
            Logger.Log(LogLevel.Temp, $"[Disconnect]");
        }

        protected override void OnRecv(PacketBase packet)
        {
            if (packet as ChatMsg_RS != null)
            {
                ChatMsg_RS ChatMsg = (ChatMsg_RS)packet;
                Logger.Log(LogLevel.Temp, $"[Recv] {ChatMsg.msgText} / {ChatMsg.time}");
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
