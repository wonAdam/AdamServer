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

            ThreadPool.SetMaxThreads((int)Math.Pow(2.0, 17.0), (int)Math.Pow(2.0, 12.0));

            while (true)
            {
            }
        }
    }   
}
