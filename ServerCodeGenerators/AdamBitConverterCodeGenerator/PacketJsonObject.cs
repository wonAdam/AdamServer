using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamBitConverterGenerator
{
    public class JsonMemeber
    {
        public string Type;
        public string Name;
    }

    internal class PacketJsonObject
    {
        public string Name;
        public List<JsonMemeber> Memebers = new List<JsonMemeber>();
    }
}
