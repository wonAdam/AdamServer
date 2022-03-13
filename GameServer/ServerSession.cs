using ServerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    internal class ServerSession : AdamSession
    {
        public int SessionId { get; set; }

        public override void Start(Socket InSock)
        {
            base.Start(InSock);

            // todo.wondong
            // Authenticate을 시작
            // Timeout 시간을 두어 일정시간동안 Authenticate을 못하면 
            // Disconnect시켜버리자.
        }

        public override void Disconnect()
        {
            ServerSessionManager.Instance.Remove(this);
            
            base.Disconnect();
        }
    }
}
