using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Packet
{
    internal class PacketBitConvertor
    {
        public static EError Serialize(PacketBase packet, out int serializeSize, out ArraySegment<byte> serializeResult)
        {
            serializeSize = 0;
            serializeResult = new ArraySegment<byte>();

            try
            {
                PacketHeader packetHeader = new PacketHeader(packet);

                EError headerError = packetHeader.Serialize(out ArraySegment<byte> headerBuff);
                if (headerError != EError.None)
                    return headerError;

                EError contentError = packet.Serialize(out ArraySegment<byte> contentBuff);
                if (contentError != EError.None)
                    return contentError;

                serializeResult = new ArraySegment<byte>(new byte[packet.PacketSize + PacketHeader.Size]);
                Array.Copy(headerBuff.Array, 0, serializeResult.Array, 0, headerBuff.Count); // header copy
                if(contentBuff.Array != null) // size가 0이면 null일 수 있다.
                    Array.Copy(contentBuff.Array, 0, serializeResult.Array, headerBuff.Count, contentBuff.Count); // content copy

                serializeSize = packet.PacketSize + PacketHeader.Size;
                return EError.None;
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                return EError.Exception;
            }
        }

        public static EError Deserialize(ArraySegment<byte> buff, out int deserializeSize, out PacketBase? packet)
        {
            deserializeSize = 0;
            packet = null;

            try
            {
                //////////////////////////////////////
                // PacketHeader
                if (buff.Count < PacketHeader.Size)
                    return EError.PacketFragmentation;

                PacketHeader packetHeader = new PacketHeader();
                EError headerError = packetHeader.Deserialize(buff);
                if (headerError != EError.None)
                    return headerError;

                deserializeSize += PacketHeader.Size;
                buff = new ArraySegment<byte>(buff.Array, buff.Offset + PacketHeader.Size, buff.Count - PacketHeader.Size);

                //////////////////////////////////////
                // PacketContent
                if (buff.Count < packetHeader.PacketSize)
                    return EError.PacketFragmentation;

                packet = PacketFactory.CreatePacketById(packetHeader.PacketId);
                if(packet == null)
                    throw new Exception("Packet CreatePacketById Failed");

                EError contentError = packet.Deserialize(buff);
                if (contentError != EError.None)
                    return contentError;

                deserializeSize += packet.PacketSize;
                return EError.None;
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, $"{e.Message}");
                return EError.Exception;
            }
        }
    }
}
