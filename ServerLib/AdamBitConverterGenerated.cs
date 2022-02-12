

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
	enum EDeserializeResult
	{
		Success,
		PacketFragmentation,
		Error,
	}

	internal class AdamBitConverter
	{

		public static byte[] Serialize(PacketHeader header)
		{
			byte[] buff = new byte[PacketHeader.Size];

			byte[] packetSizeBuff = BitConverter.GetBytes(header.PacketSize);
			Array.Copy(packetSizeBuff, 0, buff, 0, sizeof(ushort));
			byte[] packetIdBuff = BitConverter.GetBytes(header.PacketId);
			Array.Copy(packetIdBuff, 0, buff, sizeof(ushort), sizeof(ushort));

			return buff;
		}

		public static void Deserialize(ArraySegment<byte> buff, out int size, out PacketHeader header)
		{
			header = new PacketHeader();
			size = PacketHeader.Size;
			header.PacketSize = BitConverter.ToUInt16(buff.Array, buff.Offset);
			header.PacketId = BitConverter.ToUInt16(buff.Array, buff.Offset + sizeof(ushort));
		}
		
		
		public static byte[] Serialize(PacketBase packet)
		{
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[packet.PacketSize + PacketHeader.Size]);

			switch(packet.PacketId)
			{
				
				case Ping_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((Ping_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case Ping_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((Ping_RS)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ChatMsg_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ChatMsg_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ChatMsg_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ChatMsg_RS)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	

				default:
				{
					return null;
				}
			}
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out PacketBase packet)
		{
			AdamBitConverter.Deserialize(buff, out int headerSize, out PacketHeader header);
			size = headerSize;
			packet = null;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + headerSize, buff.Count - headerSize);

			switch(header.PacketId)
			{
				
				case Ping_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out Ping_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case Ping_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out Ping_RS packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ChatMsg_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ChatMsg_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ChatMsg_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ChatMsg_RS packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	

				default:
				{
					size = 0;
					return EDeserializeResult.Error;
				}
			}
		}
	
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
			byte[] buff = new byte[sizeof(int) + Encoding.UTF8.GetByteCount(data)];
			byte[] lengthBuff = BitConverter.GetBytes(Encoding.UTF8.GetByteCount(data));
			byte[] stringBuff = Encoding.UTF8.GetBytes(data);

			Array.Copy(lengthBuff, 0, buff, 0, lengthBuff.Length);
			Array.Copy(stringBuff, 0, buff, lengthBuff.Length, stringBuff.Length);
			return buff;
		}
	
		public static byte[] Serialize(DateTime data)
		{
			return BitConverter.GetBytes(data.Ticks);
		}
	
		public static byte[] Serialize(Ping_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			Array.Copy(headerBuff, 0, buff, 0, headerBuff.Length);
	
			int cursor = PacketHeader.Size;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(Ping_RS data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	

			byte[] buff = new byte[size];

			// Copy
			Array.Copy(headerBuff, 0, buff, 0, headerBuff.Length);
	
			int cursor = PacketHeader.Size;
			
			{
				Array.Copy(buffs[0], 0, buff, cursor, buffs[0].Length);
				cursor += buffs[0].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ChatMsg_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
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
			Array.Copy(headerBuff, 0, buff, 0, headerBuff.Length);
	
			int cursor = PacketHeader.Size;
			
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
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
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
			Array.Copy(headerBuff, 0, buff, 0, headerBuff.Length);
	
			int cursor = PacketHeader.Size;
			
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
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out int data)
		{
			if(buff.Count < sizeof(int))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToInt32(buff.Array, buff.Offset);
			size = sizeof(int);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out uint data)
		{
			if(buff.Count < sizeof(uint))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToUInt32(buff.Array, buff.Offset);
			size = sizeof(uint);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out short data)
		{
			if(buff.Count < sizeof(short))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToInt16(buff.Array, buff.Offset);
			size = sizeof(short);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ushort data)
		{
			if(buff.Count < sizeof(ushort))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToUInt16(buff.Array, buff.Offset);
			size = sizeof(ushort);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out char data)
		{
			if(buff.Count < sizeof(char))
			{
				size = 0;
				data = 'a';
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToChar(buff.Array, buff.Offset);
			size = sizeof(char);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out long data)
		{
			if(buff.Count < sizeof(long))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToInt64(buff.Array, buff.Offset);
			size = sizeof(long);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ulong data)
		{
			if(buff.Count < sizeof(ulong))
			{
				size = 0;
				data = 0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToUInt64(buff.Array, buff.Offset);
			size = sizeof(ulong);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out float data)
		{
			if(buff.Count < sizeof(float))
			{
				size = 0;
				data = 0.0f;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToSingle(buff.Array, buff.Offset);
			size = sizeof(float);
			return EDeserializeResult.Success;
		}
	
		public EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out double data)
		{
			if(buff.Count < sizeof(double))
			{
				size = 0;
				data = 0.0;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToDouble(buff.Array, buff.Offset);
			size = sizeof(double);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out bool data)
		{
			if(buff.Count < sizeof(bool))
			{
				size = 0;
				data = false;
				return EDeserializeResult.PacketFragmentation;
			}

			data = BitConverter.ToBoolean(buff.Array, buff.Offset);
			size = sizeof(bool);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out string data)
		{
			size = 0;
			data = String.Empty;

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			size = sizeOfLength;

			if(buff.Count < sizeof(int) + length)
				return EDeserializeResult.PacketFragmentation;

			data = Encoding.UTF8.GetString(buff.Array, buff.Offset + sizeof(int), length);
			size += Encoding.UTF8.GetByteCount(data);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out DateTime data)
		{
			if(buff.Count < sizeof(long))
			{
				size = 0;
				data = new DateTime();
				return EDeserializeResult.PacketFragmentation;
			}

			long ticks = BitConverter.ToInt64(buff.Array, buff.Offset);
			data = new DateTime(ticks);
			size = sizeof(long);
			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Ping_RQ data)
		{
			data = new Ping_RQ();
			size = 0;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.time);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Ping_RS data)
		{
			data = new Ping_RS();
			size = 0;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.time);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ChatMsg_RQ data)
		{
			data = new ChatMsg_RQ();
			size = 0;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.msgText);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.time);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ChatMsg_RS data)
		{
			data = new ChatMsg_RS();
			size = 0;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.msgText);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.time);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	

	}
}