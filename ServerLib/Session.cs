using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public class Session
    {
        Socket _sock;
        RecvBuffer _recvBuffer = new RecvBuffer(ServerConstData.RecvBufferSize);
        SendBuffer _sendBuffer = new SendBuffer(ServerConstData.SendBufferSize);

        public Session(Socket clientSock)
        {
            _sock = clientSock;
        }
        
        public void Start()
        {
            BeginRecv();
        }

        public void Disconnect()
        {
            _sock.Shutdown(SocketShutdown.Both);
            _sock.Close();
        }

        public void Send()
        {

        }

        void BeginRecv()
        {
            try 
            {
                SocketError sockError;
                _sock.BeginReceive(_recvBuffer.WriteSegment.Array, _recvBuffer.WriteSegment.Offset, _recvBuffer.WriteSegment.Count, SocketFlags.None, out sockError, new AsyncCallback(RecvCallback), null);
            }
            catch (SocketException se)
            {
                Logger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
            }
        }

        void RecvCallback(IAsyncResult ar)
        {
            try
            {
                int receivedSize = _sock.EndReceive(ar);

                if(receivedSize < 0)
                {
                    Disconnect();
                    return;
                }

                while(true)
                {
                    PacketBitConvertor.Ser
                }

            }
            catch (SocketException se)
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
