using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using ServerLib.Packet;

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
        int _disconnected = 0;

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
            // 이미 disconnect됐음
            if (Interlocked.Exchange(ref _disconnected, 1) == 1)
                return;

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
                List<byte[]> buffs = new List<byte[]>();
                while (_sendQueue.Count > 0)
                {
                    PacketBase packet = _sendQueue.Dequeue();
                    byte[] packetBuff = AdamBitConverter.Serialize(packet);
                    buffs.Add(packetBuff);
                    packetSizeSum += packetBuff.Length;
                }

                ArraySegment<byte> sendBuffer = SendBufferHelper.Open(packetSizeSum);
                int cursor = 0;
                foreach (byte[] buff in buffs)
                {
                    Array.Copy(buff, 0, sendBuffer.Array, sendBuffer.Offset + cursor, buff.Length);
                    cursor += buff.Length;
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

                if (receivedSize == 0)
                {
                    Disconnect();
                    return;
                }

                if (receivedSize <= 0)
                    throw new Exception("Recved Size is Zero");

                if(!_recvBuffer.OnWrite(receivedSize))
                    throw new Exception("Recv Buffer OnWrite Failed");

                while (receivedSize > 0)
                {
                    ArraySegment<byte> readSegment = _recvBuffer.ReadSegment;
                    EDeserializeResult result = AdamBitConverter.Deserialize(readSegment, out int deserializeSize, out PacketBase packet);

                    if (result != EDeserializeResult.Success)
                    {
                        BeginRecv();
                        return;
                    }

                    if (!_recvBuffer.OnRead(deserializeSize))
                        throw new Exception("Recv Buffer OnRead Failed");

                    OnRecv(packet);

                    receivedSize -= deserializeSize;

                    if (receivedSize < 0)
                    {
                        Logger.Log(LogLevel.Error, "Deserialize Error : receivedSize < 0");
                    }
                }

                BeginRecv();
            }
            catch (SocketException se)
            {
                Logger.Log(LogLevel.Error, $"{se.Message}");
                Disconnect();
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }
    }
}
