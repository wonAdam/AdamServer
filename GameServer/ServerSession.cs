using ServerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    internal class ServerSession : AdamSession
    {
        public int SessionId { get; set; }
    }
}
