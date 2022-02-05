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
            Logger.Log(LogLevel.Temp, $"[Recv] {packet.GetType().Name}");

            Send(new Ping_RS());
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
