using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdamBitConverterGenerator
{
    internal class ProtobufJsonMaker
    {
        public static string MakeJsonStr(Type[] Types)
        {
            StringBuilder Sb = new StringBuilder();

            foreach (Type T in Types)
            {
                PacketJsonObject JsonObject = new PacketJsonObject();
                JsonObject.Name = T.Name;
                MemberInfo[] Members = T.GetMembers();
                foreach(MemberInfo Member in Members)
                {
                    JsonObject.Memebers.Add(new JsonMemeber() { Name = Member.Name, Type = Member.GetType().Name }); 
                }

                JsonSerializerOptions Options = new JsonSerializerOptions();
                Sb.Append(JsonSerializer.Serialize<PacketJsonObject>(JsonObject, Options));
            }

            return Sb.ToString();
        }

    }
}
