using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public abstract class Connector
    {
        private Func<Session> _sessionFactory;
        Socket _sock;
        protected abstract void OnConnect(IPEndPoint endPoint);

        public void Connect(Func<Session> sessionFactory, int count = 1)
        {
            try
            {
                _sessionFactory = sessionFactory;
                _sock = new Socket(Listener.GetServerIPEndPoint().AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _sock.BeginConnect(Listener.GetServerIPEndPoint(), new AsyncCallback(ConnectCallback), null);
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
            }

        }

        void ConnectCallback(IAsyncResult ar)
        {
            _sock.EndConnect(ar);
            Session session = _sessionFactory();
            OnConnect(Listener.GetServerIPEndPoint());
            session.Start(_sock);
            session.OnConnect(Listener.GetServerIPEndPoint());
        }

    }
}
