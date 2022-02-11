





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
		
		
		public static byte[] Serialize(int data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(uint data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(short data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(ushort data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(char data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(long data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(ulong data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(float data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(double data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(bool data)
		{
			return BitConverter.GetBytes(data);
		}
	
		public static byte[] Serialize(string data)
		{
			return Encoding.UTF8.GetBytes(data);
		}
	
		public static byte[] Serialize(DateTime data)
		{
			return BitConverter.GetBytes(data.Ticks);
		}
	
		public static byte[] Serialize(Ping_RQ data)
		{
			int size = 0;
			List<byte[]> buffs = new List<byte[]>();

			// Serializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			int cursor = 0;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(Ping_RS data)
		{
			int size = 0;
			List<byte[]> buffs = new List<byte[]>();

			// Serializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			int cursor = 0;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ChatMsg_RQ data)
		{
			int size = 0;
			List<byte[]> buffs = new List<byte[]>();

			// Serializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.msgText);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			int cursor = 0;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	
			{
				Array.Copy(buffs[1], 0, buff, cursor, buffs[1].Length);
				cursor += buffs[1].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ChatMsg_RS data)
		{
			int size = 0;
			List<byte[]> buffs = new List<byte[]>();

			// Serializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.msgText);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			int cursor = 0;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	
			{
				Array.Copy(buffs[1], 0, buff, cursor, buffs[1].Length);
				cursor += buffs[1].Length;
			}
	

			return buff;
		}
	
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out int data)
		{
			data = BitConverter.ToInt32(buff.Array, buff.Offset);
			size = sizeof(int);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out uint data)
		{
			data = BitConverter.ToUInt32(buff.Array, buff.Offset);
			size = sizeof(uint);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out short data)
		{
			data = BitConverter.ToInt16(buff.Array, buff.Offset);
			size = sizeof(short);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out ushort data)
		{
			data = BitConverter.ToUInt16(buff.Array, buff.Offset);
			size = sizeof(ushort);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out char data)
		{
			data = BitConverter.ToChar(buff.Array, buff.Offset);
			size = sizeof(char);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out long data)
		{
			data = BitConverter.ToInt64(buff.Array, buff.Offset);
			size = sizeof(long);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out ulong data)
		{
			data = BitConverter.ToUInt64(buff.Array, buff.Offset);
			size = sizeof(ulong);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out float data)
		{
			data = BitConverter.ToSingle(buff.Array, buff.Offset);
			size = sizeof(float);
		}
	
		public void Deserialize(ArraySegment<byte> buff, out int size, out double data)
		{
			data = BitConverter.ToDouble(buff.Array, buff.Offset);
			size = sizeof(double);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out bool data)
		{
			data = BitConverter.ToBoolean(buff.Array, buff.Offset);
			size = sizeof(bool);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out string data)
		{
			AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			size = sizeOfLength;
			data = Encoding.UTF8.GetString(buff.Array, buff.Offset + sizeof(int), length);
			size += Encoding.UTF8.GetByteCount(data);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out DateTime data)
		{
			long ticks = BitConverter.ToInt64(buff.Array, buff.Offset);
			data = new DateTime(ticks);
			size = sizeof(long);
		}
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out Ping_RQ data)
		{
			data = new Ping_RQ();
			size = 0;

			// Deserializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
			}
	
		}
	
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out Ping_RS data)
		{
			data = new Ping_RS();
			size = 0;

			// Deserializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
			}
	
		}
	
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out ChatMsg_RQ data)
		{
			data = new ChatMsg_RQ();
			size = 0;

			// Deserializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.msgText);
				size += memberBuff.Length;
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
			}
	
		}
	
	
		public static void Deserialize(ArraySegment<byte> buff, out int size, out ChatMsg_RS data)
		{
			data = new ChatMsg_RS();
			size = 0;

			// Deserializations
			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.msgText);
				size += memberBuff.Length;
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
			}
	
		}
	
	

	}
}