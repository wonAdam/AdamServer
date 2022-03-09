using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using ServerLib.Adam;
using ServerLib.Packet;
using static ServerLib.Adam.AdamBitConverterGenerated;

namespace ServerLib
{
    public abstract class AdamSession
    {
        Socket Sock;
        AdamRecvBuffer RecvBuffer = new AdamRecvBuffer(ServerConstData.RecvBufferSize);
        AdamSendBuffer SendBuffer = new AdamSendBuffer(ServerConstData.SendBufferSize);

        object SendLock = new object();
        Queue<IMessage> SendQueue = new Queue<IMessage>();
        bool bIsSending = false;
        int Disconnected = 0;

        protected abstract void OnRecv(PacketHeader Header, IMessage Packet);
        protected abstract void OnSend(int SendSize);
        public abstract void OnConnect(IPEndPoint EndPoint);
        protected abstract void OnDisconnect();

        public void Start(Socket InSock)
        {
            Sock = InSock;
            BeginRecv();
        }

        public void Disconnect()
        {
            // 이미 disconnect됐음
            if (Interlocked.Exchange(ref Disconnected, 1) == 1)
                return;

            Sock.Shutdown(SocketShutdown.Both);
            Sock.Close();
        }

        public void Send(IMessage Packet)
        {
            lock (SendLock)
            {
                SendQueue.Enqueue(Packet);

                if (!bIsSending)
                    BeginSend();
            }
        }

        void BeginSend()
        {
            try
            {
                bIsSending = true;
                int PacketSizeSum = 0;
                List<byte[]> Buffs = new List<byte[]>();
                while (SendQueue.Count > 0)
                {
                    IMessage Packet = SendQueue.Dequeue();
                    PacketHeader Header = new PacketHeader(Packet);
                    byte[] PacketHeaderBuff = AdamBitConverterGenerated.Serialize(Header);
                    byte[] PacketBodyBuff = AdamBitConverterGenerated.Serialize(Packet);
                    Buffs.Add(PacketHeaderBuff);
                    Buffs.Add(PacketBodyBuff);
                    PacketSizeSum += PacketHeaderBuff.Length;
                    PacketSizeSum += PacketBodyBuff.Length;
                }

                ArraySegment<byte> SendBufferOpen = SendBufferHelper.Open(PacketSizeSum);
                int cursor = 0;
                foreach (byte[] Buff in Buffs)
                {
                    Array.Copy(Buff, 0, SendBufferOpen.Array, SendBufferOpen.Offset + cursor, Buff.Length);
                    cursor += Buff.Length;
                }
                SendBufferHelper.Close(PacketSizeSum);

                SocketError SockError;
                Sock.BeginSend(SendBufferOpen.Array, SendBufferOpen.Offset, SendBufferOpen.Count, SocketFlags.None, out SockError, new AsyncCallback(SendCallback), null);

                if (SockError != SocketError.Success)
                    throw new Exception($"BeginSend Error: {SockError.ToString()}");
            }
            catch(Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }

        }

        void SendCallback(IAsyncResult Ar)
        {
            try
            {
                int SendSize = Sock.EndSend(Ar);

                if (SendSize == 0)
                    throw new Exception($"Send Size is Zero");

                lock (SendLock)
                {
                    OnSend(SendSize);

                    if (SendQueue.Count > 0)
                        BeginSend();
                    else
                        bIsSending = false;
                }
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        void BeginRecv()
        {
            try 
            {
                RecvBuffer.Clean();
                SocketError SockError;
                ArraySegment<byte> WriteSegment = RecvBuffer.WriteSegment;
                if (WriteSegment.Array == null)
                    throw new Exception("WriteSegment of Recv Buffer is Null");

                Sock.BeginReceive(WriteSegment.Array, WriteSegment.Offset, WriteSegment.Count, SocketFlags.None, out SockError, new AsyncCallback(RecvCallback), null);
            }
            catch (SocketException se)
            {
                AdamLogger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        void RecvCallback(IAsyncResult ar)
        {
            try
            {
                int ReceivedSize = Sock.EndReceive(ar);

                if (ReceivedSize == 0)
                {
                    Disconnect();
                    return;
                }

                if (ReceivedSize <= 0)
                    throw new Exception("Recved Size is Zero");

                if(!RecvBuffer.OnWrite(ReceivedSize))
                    throw new Exception("Recv Buffer OnWrite Failed");

                while (ReceivedSize > 0)
                {
                    ArraySegment<byte> ReadSegment = RecvBuffer.ReadSegment;

                    int DesereializeSize = 0; 
                    // Header Deserialize
                    EDeserializeResult HeaderResult = AdamBitConverterGenerated.Deserialize(ReadSegment, out PacketHeader Header);
                    if (HeaderResult != EDeserializeResult.Success)
                    {
                        BeginRecv();
                        return;
                    }

                    DesereializeSize += AdamBitConverterGenerated.SizeOf(Header);
                    ReadSegment = new ArraySegment<byte>(
#pragma warning disable CS8604 // Possible null reference argument.
                        ReadSegment.Array,
#pragma warning restore CS8604 // Possible null reference argument.
                        ReadSegment.Offset + AdamBitConverterGenerated.SizeOf(Header), 
                        ReadSegment.Count - AdamBitConverterGenerated.SizeOf(Header)); 

                    // Packet Body Deserialize
                    EDeserializeResult PacketBodyResult = AdamBitConverterGenerated.Deserialize(ReadSegment, Header, out IMessage PacketBody);
                    if (PacketBodyResult != EDeserializeResult.Success)
                    {
                        BeginRecv();
                        return;
                    }

                    DesereializeSize += AdamBitConverterGenerated.SizeOf(PacketBody);

                    if (!RecvBuffer.OnRead(DesereializeSize))
                        throw new Exception("Recv Buffer OnRead Failed");

                    OnRecv(Header, PacketBody);

                    ReceivedSize -= DesereializeSize;

                    if (ReceivedSize < 0)
                    {
                        AdamLogger.Log(LogLevel.Error, "Deserialize Error : receivedSize < 0");
                    }
                }

                BeginRecv();
            }
            catch (SocketException se)
            {
                AdamLogger.Log(LogLevel.Error, $"{se.Message}");
                Disconnect();
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }
    }
}
