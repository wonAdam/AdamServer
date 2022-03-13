using System;
using System.Net;
using System.Net.Sockets;

namespace ServerLib
{
    public class AdamListener
    {
        Socket Sock;
        Func<AdamSession> SessionFactory;

        public static int ServerPortNum = 9999;
        public static IPEndPoint GetServerIPEndPoint()
        {
            string Host = Dns.GetHostName();
            IPHostEntry IpHost = Dns.GetHostEntry(Host);
            IPAddress IpAddr = IpHost.AddressList[0];
            return new IPEndPoint(IpAddr, ServerPortNum);
        }
        public void Init(Func<AdamSession> InSessionFactory)
        {
            IPEndPoint EndPoint = GetServerIPEndPoint();
            Sock = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Sock.Bind(EndPoint);
            Sock.Listen(10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Listening on {EndPoint.Address.ToString()} : {EndPoint.Port}");

            SessionFactory = InSessionFactory;

            BeginAccept();
        }

        public void BeginAccept()
        {
            Sock.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void AcceptCallback(IAsyncResult Ar)
        {
            try
            {
                Socket ClientSock = Sock.EndAccept(Ar);
                AdamSession Session = SessionFactory();
                Session.Start(ClientSock);

                Sock.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch(SocketException se)
            {
                AdamLogger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
            }
        }
    }
}
