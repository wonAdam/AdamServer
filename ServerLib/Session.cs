using ServerLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public abstract class Session
    {
        Socket _sock;
        RecvBuffer _recvBuffer = new RecvBuffer(ServerConstData.RecvBufferSize);
        SendBuffer _sendBuffer = new SendBuffer(ServerConstData.SendBufferSize);

        object _sendLock = new object();
        Queue<PacketBase> _sendQueue = new Queue<PacketBase>();
        bool _isSending = false;

        protected abstract void OnRecv(PacketBase packet);
        protected abstract void OnSend(int sendSize);
        public abstract void OnConnect(IPEndPoint endPoint);
        protected abstract void OnDisconnect();

        public void Start(Socket sock)
        {
            _sock = sock;
            BeginRecv();
        }

        public void Disconnect()
        {
            _sock.Shutdown(SocketShutdown.Both);
            _sock.Close();
        }

        public void Send(PacketBase packet)
        {
            lock (_sendLock)
            {
                _sendQueue.Enqueue(packet);

                if (!_isSending)
                    BeginSend();
            }
        }

        void BeginSend()
        {
            try
            {
                _isSending = true;
                int packetSizeSum = 0;
                List<ArraySegment<byte>> buffs = new List<ArraySegment<byte>>();
                while (_sendQueue.Count > 0)
                {
                    PacketBase packet = _sendQueue.Dequeue();
                    EError error = PacketBitConvertor.Serialize(packet, out int serializeSize, out ArraySegment<byte> serializeResult);
                    if (error == EError.None)
                    {
                        buffs.Add(serializeResult);
                        packetSizeSum += serializeSize;
                    }
                }

                ArraySegment<byte> sendBuffer = SendBufferHelper.Open(packetSizeSum);
                int cursor = 0;
                foreach (ArraySegment<byte> buff in buffs)
                {
                    Array.Copy(buff.Array, 0, sendBuffer.Array, sendBuffer.Offset + cursor, buff.Count);
                    cursor += buff.Count;
                }
                SendBufferHelper.Close(packetSizeSum);

                SocketError sockError;
                _sock.BeginSend(sendBuffer.Array, sendBuffer.Offset, sendBuffer.Count, SocketFlags.None, out sockError, new AsyncCallback(SendCallback), null);

                if (sockError != SocketError.Success)
                    throw new Exception($"BeginSend Error: {sockError.ToString()}");
            }
            catch(Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }

        }

        void SendCallback(IAsyncResult ar)
        {
            try
            {
                int sendSize = _sock.EndSend(ar);

                if (sendSize == 0)
                    throw new Exception($"Send Size is Zero");

                lock (_sendLock)
                {
                    OnSend(sendSize);

                    if (_sendQueue.Count > 0)
                        BeginSend();
                    else
                        _isSending = false;
                }
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        void BeginRecv()
        {
            try 
            {
                SocketError sockError;
                ArraySegment<byte> writeSegment = _recvBuffer.WriteSegment;
                if (writeSegment.Array == null)
                    throw new Exception("WriteSegment of Recv Buffer is Null");

                _sock.BeginReceive(writeSegment.Array, writeSegment.Offset, writeSegment.Count, SocketFlags.None, out sockError, new AsyncCallback(RecvCallback), null);
            }
            catch (SocketException se)
            {
                Logger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        void RecvCallback(IAsyncResult ar)
        {
            try
            {
                int receivedSize = _sock.EndReceive(ar);

                if(receivedSize < 0)
                    throw new Exception("Recved Size is Zero");

                if(!_recvBuffer.OnWrite(receivedSize))
                    throw new Exception("Recv Buffer OnWrite Failed");

                while (true)
                {
                    ArraySegment<byte> readSegment = _recvBuffer.ReadSegment;
                    EError error = PacketBitConvertor.Deserialize(readSegment, out int deserializeSize, out PacketBase? packet);
                    if (error == EError.None && packet != null)
                    {
                        if(!_recvBuffer.OnRead(deserializeSize))
                            throw new Exception("Recv Buffer OnRead Failed");

                        OnRecv(packet);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            catch (SocketException se)
            {
                Logger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }
    }
}
