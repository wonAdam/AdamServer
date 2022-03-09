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
    class Program
    {
        static AdamListener Listener = new AdamListener();
        static void Main(string[] args)
        {
            Listener.Init(() => ServerSessionManager.Instance.Generate(() => new ServerLobbySession()));

            while (true)
            {
            }
        }
    }   
}
