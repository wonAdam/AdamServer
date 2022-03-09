using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public abstract class AdamConnector
    {
        private Func<AdamSession> SessionFactory;
        Socket Sock;
        protected abstract void OnConnect(IPEndPoint EndPoint);

        public void Connect(Func<AdamSession> InSessionFactory, int Count = 1)
        {
            try
            {
                SessionFactory = InSessionFactory;
                Sock = new Socket(AdamListener.GetServerIPEndPoint().AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Sock.BeginConnect(AdamListener.GetServerIPEndPoint(), new AsyncCallback(ConnectCallback), null);
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
            }

        }

        void ConnectCallback(IAsyncResult Ar)
        {
            Sock.EndConnect(Ar);
            AdamSession session = SessionFactory();
            OnConnect(AdamListener.GetServerIPEndPoint());
            session.Start(Sock);
            session.OnConnect(AdamListener.GetServerIPEndPoint());
        }

    }
}
