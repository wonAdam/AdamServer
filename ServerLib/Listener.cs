using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public class Listener
    {
        Socket _sock;
        Func<Session> _sessionFactory;

        public static int serverPortNum = 9999;
        public static IPEndPoint GetServerIPEndPoint()
        {
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            return new IPEndPoint(ipAddr, serverPortNum);
        }
        public void Init(Func<Session> sessionFactory)
        {
            IPEndPoint endPoint = GetServerIPEndPoint();
            _sock = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _sock.Bind(endPoint);
            _sock.Listen(10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Listening on {endPoint.Address.ToString()} : {endPoint.Port}");

            _sessionFactory = sessionFactory;

            BeginAccept();
        }

        public void BeginAccept()
        {
            _sock.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket clientSock = _sock.EndAccept(ar);
                Session session = _sessionFactory();
                session.Start(clientSock);

                _sock.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch(SocketException se)
            {
                Logger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
            }
        }
    }
}
