






/**************************************

	이 파일은 자동 생성되는 파일입니다.
		절대 직접 수정하지마세요.

**************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Packet
{
	internal class AdamBitConverter
	{
		
		
		public static byte[] Serialize(Ping_RQ data)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[data.PacketSize]);

			
			{
				byte[] memberBuff = Serialize(data.time);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	

			return buff.Array;
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out Ping_RQ data)
		{
			data = new Ping_RQ();

			
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.time);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
		}
	
		public static byte[] Serialize(Ping_RS data)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[data.PacketSize]);

			
			{
				byte[] memberBuff = Serialize(data.time);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	

			return buff.Array;
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out Ping_RS data)
		{
			data = new Ping_RS();

			
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.time);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
		}
	
		public static byte[] Serialize(ChatMsg_RQ data)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[data.PacketSize]);

			
			{
				byte[] memberBuff = Serialize(data.msgText);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	
			{
				byte[] memberBuff = Serialize(data.time);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	

			return buff.Array;
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out ChatMsg_RQ data)
		{
			data = new ChatMsg_RQ();

			
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.msgText);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.time);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
		}
	
		public static byte[] Serialize(ChatMsg_RS data)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[data.PacketSize]);

			
			{
				byte[] memberBuff = Serialize(data.msgText);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	
			{
				byte[] memberBuff = Serialize(data.time);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberBuff.Length);
				cursor += memberBuff.Length;
			}
	

			return buff.Array;
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out ChatMsg_RS data)
		{
			data = new ChatMsg_RS();

			
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.msgText);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
			{
				Deserialize(buff, out int length);
				Deserialize(buff, length, out data.time);
				buff = new ArraySegment(buff.Array, buff.Offset + (length + sizeof(int)), buff.Count - (length + sizeof(int)));
			}
	
		}
	

	}
}