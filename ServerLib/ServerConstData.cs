using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public class ServerConstData
    {
        static public int RecvBufferSize = (int)Math.Pow(2, 16);
        static public int SendBufferSize = (int)Math.Pow(2, 16);
    }

}
