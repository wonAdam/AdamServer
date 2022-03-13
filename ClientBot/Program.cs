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

    class ClientSession : AdamSession
    {
    }


    class Program
    {
        static ServerConnector Conn = new ServerConnector();
        static void Main(string[] args)
        {
            Conn.Connect(() => 
            {
                ClientSession Session = new ClientSession();
                ClientPacketHandler PacketHandler = new ClientPacketHandler(Session);
                return Session; 
            });

            while (true)
            {
            }
        }
    }
}
