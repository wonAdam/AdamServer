using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Packet
{
    internal class PacketFactory
    {
        public static PacketBase? CreatePacketById(int id)
        {
            // 자동 생성 코드
            switch (id)
            { 
                case Ping_RQ.Id:
                    return new Ping_RQ();
                case Ping_RS.Id:
                    return new Ping_RS();
                default:
                {
                    Logger.Log(LogLevel.Error, $"Undefined Packet Id");
                    return null;
                }
            }

        }

    }
}
