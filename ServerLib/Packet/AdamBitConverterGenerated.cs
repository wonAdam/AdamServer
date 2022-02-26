

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

		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out PacketHeader header)
		{
			if(buff.Count < PacketHeader.Size)
			{
				size = 0;
				header = new PacketHeader();
				return EDeserializeResult.PacketFragmentation;
			}

			header = new PacketHeader();
			size = PacketHeader.Size;
			header.PacketSize = BitConverter.ToUInt16(buff.Array, buff.Offset);
			header.PacketId = BitConverter.ToUInt16(buff.Array, buff.Offset + sizeof(ushort));

			return EDeserializeResult.Success;
		}

		public static int SizeOf(PacketHeader header) => PacketHeader.Size;
		
		
		public static int SizeOf(int data) => sizeof(int);
	
		public static int SizeOf(uint data) => sizeof(uint);
	
		public static int SizeOf(short data) => sizeof(short);
	
		public static int SizeOf(ushort data) => sizeof(ushort);
	
		public static int SizeOf(char data) => sizeof(char);
	
		public static int SizeOf(long data) => sizeof(long);
	
		public static int SizeOf(ulong data) => sizeof(ulong);
	
		public static int SizeOf(float data) => sizeof(float);
	
		public static int SizeOf(double data) => sizeof(double);
	
		public static int SizeOf(bool data) => sizeof(bool);
	
		public static int SizeOf(string data) => sizeof(int) + Encoding.UTF8.GetByteCount(data);
	
		public static int SizeOf(DateTime data) => sizeof(long);
	
		public static int SizeOf(List<int> data)
		{
			int size = sizeof(int);
			foreach(int e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<uint> data)
		{
			int size = sizeof(int);
			foreach(uint e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<short> data)
		{
			int size = sizeof(int);
			foreach(short e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<ushort> data)
		{
			int size = sizeof(int);
			foreach(ushort e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<char> data)
		{
			int size = sizeof(int);
			foreach(char e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<long> data)
		{
			int size = sizeof(int);
			foreach(long e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<ulong> data)
		{
			int size = sizeof(int);
			foreach(ulong e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<float> data)
		{
			int size = sizeof(int);
			foreach(float e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<double> data)
		{
			int size = sizeof(int);
			foreach(double e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<bool> data)
		{
			int size = sizeof(int);
			foreach(bool e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<string> data)
		{
			int size = sizeof(int);
			foreach(string e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(List<DateTime> data)
		{
			int size = sizeof(int);
			foreach(DateTime e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<uint, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				uint key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<short, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				short key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ushort, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ushort key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<char, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				char key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<ulong, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				ulong key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<float, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				float key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<double, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				double key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<bool, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				bool key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<string, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				string key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, int> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				int value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, uint> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				uint value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, short> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				short value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, ushort> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				ushort value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, char> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				char value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, long> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				long value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, ulong> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				ulong value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, float> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				float value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, double> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				double value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, bool> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				bool value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, string> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				string value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<DateTime, DateTime> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				DateTime key = pair.Key;
				DateTime value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<Ping_RQ> data)
		{
			int size = sizeof(int);
			foreach(Ping_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, Ping_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				Ping_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, Ping_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				Ping_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<Ping_RS> data)
		{
			int size = sizeof(int);
			foreach(Ping_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, Ping_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				Ping_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, Ping_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				Ping_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ChatMsg_RQ> data)
		{
			int size = sizeof(int);
			foreach(ChatMsg_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ChatMsg_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ChatMsg_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ChatMsg_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ChatMsg_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ChatMsg_RS> data)
		{
			int size = sizeof(int);
			foreach(ChatMsg_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ChatMsg_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ChatMsg_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ChatMsg_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ChatMsg_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ListTest_RQ> data)
		{
			int size = sizeof(int);
			foreach(ListTest_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ListTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ListTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ListTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ListTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ListTest_RS> data)
		{
			int size = sizeof(int);
			foreach(ListTest_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ListTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ListTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ListTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ListTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<DictionaryTest_RQ> data)
		{
			int size = sizeof(int);
			foreach(DictionaryTest_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, DictionaryTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				DictionaryTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, DictionaryTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				DictionaryTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<DictionaryTest_RS> data)
		{
			int size = sizeof(int);
			foreach(DictionaryTest_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, DictionaryTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				DictionaryTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, DictionaryTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				DictionaryTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ClassListTest_RQ> data)
		{
			int size = sizeof(int);
			foreach(ClassListTest_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ClassListTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ClassListTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ClassListTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ClassListTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ClassListTest_RS> data)
		{
			int size = sizeof(int);
			foreach(ClassListTest_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ClassListTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ClassListTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ClassListTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ClassListTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ClassDictionaryTest_RQ> data)
		{
			int size = sizeof(int);
			foreach(ClassDictionaryTest_RQ e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ClassDictionaryTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ClassDictionaryTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ClassDictionaryTest_RQ> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ClassDictionaryTest_RQ value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(List<ClassDictionaryTest_RS> data)
		{
			int size = sizeof(int);
			foreach(ClassDictionaryTest_RS e in data)
			{
				size += SizeOf(e);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<int, ClassDictionaryTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				int key = pair.Key;
				ClassDictionaryTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Dictionary<long, ClassDictionaryTest_RS> data) 
		{
			int size = sizeof(int);
			foreach(var pair in data)
			{
				long key = pair.Key;
				ClassDictionaryTest_RS value = pair.Value;
				size += SizeOf(key);
				size += SizeOf(value);
			}
			return size;
		}
	
		public static int SizeOf(Ping_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.time);
	

			return size;
		}
	
		public static int SizeOf(Ping_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.time);
	

			return size;
		}
	
		public static int SizeOf(ChatMsg_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.msgText);
	
			size += AdamBitConverter.SizeOf(packet.time);
	

			return size;
		}
	
		public static int SizeOf(ChatMsg_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.msgText);
	
			size += AdamBitConverter.SizeOf(packet.time);
	

			return size;
		}
	
		public static int SizeOf(ListTest_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.sentences);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(ListTest_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.numOfCharacters);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(DictionaryTest_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.numOfCharacters);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(DictionaryTest_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.numOfCharacters);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(ClassListTest_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.chatList);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(ClassListTest_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.chatList);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(ClassDictionaryTest_RQ packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.chatList);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
		}
	
		public static int SizeOf(ClassDictionaryTest_RS packet)
		{
			int size = 0;

			size += PacketHeader.Size;

			
			size += AdamBitConverter.SizeOf(packet.chatList);
	
			size += AdamBitConverter.SizeOf(packet.time);
	
			size += AdamBitConverter.SizeOf(packet.nickname);
	

			return size;
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
	
				case ListTest_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ListTest_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ListTest_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ListTest_RS)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case DictionaryTest_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((DictionaryTest_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case DictionaryTest_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((DictionaryTest_RS)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ClassListTest_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ClassListTest_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ClassListTest_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ClassListTest_RS)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ClassDictionaryTest_RQ.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ClassDictionaryTest_RQ)packet);
					Array.Copy(packetBuff, 0, buff.Array, 0, packetBuff.Length);
					return buff.Array;
				}
	
				case ClassDictionaryTest_RS.Id:
				{
					byte[] packetBuff = AdamBitConverter.Serialize((ClassDictionaryTest_RS)packet);
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
			size = 0;
			packet = null;
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out PacketHeader header);
			if(headerError != EDeserializeResult.Success)
				return headerError;

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
	
				case ListTest_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ListTest_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ListTest_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ListTest_RS packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case DictionaryTest_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out DictionaryTest_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case DictionaryTest_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out DictionaryTest_RS packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ClassListTest_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ClassListTest_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ClassListTest_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ClassListTest_RS packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ClassDictionaryTest_RQ.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ClassDictionaryTest_RQ packetObject);
					if(result != EDeserializeResult.Success)
						return result;
					packet = packetObject;
					size += packetSize;
					return EDeserializeResult.Success;
				}
	
				case ClassDictionaryTest_RS.Id:
				{
					EDeserializeResult result = AdamBitConverter.Deserialize(buff, out int packetSize, out ClassDictionaryTest_RS packetObject);
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
	
		public static byte[] Serialize(List<int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<uint, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<short, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ushort, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<char, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<ulong, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<float, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<double, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<bool, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<string, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, int> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, uint> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, short> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, ushort> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, char> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, long> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, ulong> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, float> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, double> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, bool> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, string> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<DateTime, DateTime> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<Ping_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, Ping_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, Ping_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<Ping_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, Ping_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, Ping_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ChatMsg_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ChatMsg_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ChatMsg_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ChatMsg_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ChatMsg_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ChatMsg_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<DictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, DictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, DictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<DictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, DictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, DictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ClassListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ClassListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ClassListTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ClassListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ClassListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ClassListTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ClassDictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ClassDictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ClassDictionaryTest_RQ> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(List<ClassDictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var e in data)
			{
				byte[] buff = AdamBitConverter.Serialize(e);
				buffs.Add(buff);
				size += buff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<int, ClassDictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
		}
	
		public static byte[] Serialize(Dictionary<long, ClassDictionaryTest_RS> data)
		{
			int size = 0;
			int count = 0;
			List<byte[]> buffs = new List<byte[]>();
			foreach(var pair in data)
			{
				byte[] keyBuff = AdamBitConverter.Serialize(pair.Key);
				byte[] valBuff = AdamBitConverter.Serialize(pair.Value);
				buffs.Add(keyBuff);
				buffs.Add(valBuff);
				size += keyBuff.Length;
				size += valBuff.Length;
				count++;
			}

			byte[] resultBuff = new byte[size + sizeof(int)];

			int cursor = 0;
			byte[] lengthBuff = AdamBitConverter.Serialize(count);
			Array.Copy(lengthBuff, 0, resultBuff, cursor, buffs.Count);
			cursor += lengthBuff.Length;

			foreach(byte[] buff in buffs)
			{
				Array.Copy(buff, 0, resultBuff, cursor, buff.Length);
				cursor += buff.Length;
			}

			return resultBuff;
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
	
	
		public static byte[] Serialize(ListTest_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.sentences);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ListTest_RS data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.numOfCharacters);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(DictionaryTest_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.numOfCharacters);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(DictionaryTest_RS data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.numOfCharacters);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ClassListTest_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.chatList);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ClassListTest_RS data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.chatList);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ClassDictionaryTest_RQ data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.chatList);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
			}
	

			return buff;
		}
	
	
		public static byte[] Serialize(ClassDictionaryTest_RS data)
		{
			int size = PacketHeader.Size;
			List<byte[]> buffs = new List<byte[]>();
			
			// Serializations
			PacketHeader header = new PacketHeader(data);
			byte[] headerBuff = AdamBitConverter.Serialize(header);

			
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.chatList);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.time);
				size += memberBuff.Length;
				buffs.Add(memberBuff);
			}
	
			{
				byte[] memberBuff = AdamBitConverter.Serialize(data.nickname);
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
	
			{
				Array.Copy(buffs[2], 0, buff, cursor, buffs[2].Length);
				cursor += buffs[2].Length;
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
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out double data)
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

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

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
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<int> data)
		{
			size = 0;
			data = new List<int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out int element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<uint> data)
		{
			size = 0;
			data = new List<uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out uint element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<short> data)
		{
			size = 0;
			data = new List<short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out short element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ushort> data)
		{
			size = 0;
			data = new List<ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ushort element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<char> data)
		{
			size = 0;
			data = new List<char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out char element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<long> data)
		{
			size = 0;
			data = new List<long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out long element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ulong> data)
		{
			size = 0;
			data = new List<ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ulong element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<float> data)
		{
			size = 0;
			data = new List<float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out float element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<double> data)
		{
			size = 0;
			data = new List<double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out double element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<bool> data)
		{
			size = 0;
			data = new List<bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out bool element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<string> data)
		{
			size = 0;
			data = new List<string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out string element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<DateTime> data)
		{
			size = 0;
			data = new List<DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out DateTime element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, int> data)
		{
			size = 0;
			data = new Dictionary<int, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, uint> data)
		{
			size = 0;
			data = new Dictionary<int, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, short> data)
		{
			size = 0;
			data = new Dictionary<int, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ushort> data)
		{
			size = 0;
			data = new Dictionary<int, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, char> data)
		{
			size = 0;
			data = new Dictionary<int, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, long> data)
		{
			size = 0;
			data = new Dictionary<int, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ulong> data)
		{
			size = 0;
			data = new Dictionary<int, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, float> data)
		{
			size = 0;
			data = new Dictionary<int, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, double> data)
		{
			size = 0;
			data = new Dictionary<int, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, bool> data)
		{
			size = 0;
			data = new Dictionary<int, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, string> data)
		{
			size = 0;
			data = new Dictionary<int, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, DateTime> data)
		{
			size = 0;
			data = new Dictionary<int, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, int> data)
		{
			size = 0;
			data = new Dictionary<uint, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, uint> data)
		{
			size = 0;
			data = new Dictionary<uint, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, short> data)
		{
			size = 0;
			data = new Dictionary<uint, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, ushort> data)
		{
			size = 0;
			data = new Dictionary<uint, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, char> data)
		{
			size = 0;
			data = new Dictionary<uint, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, long> data)
		{
			size = 0;
			data = new Dictionary<uint, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, ulong> data)
		{
			size = 0;
			data = new Dictionary<uint, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, float> data)
		{
			size = 0;
			data = new Dictionary<uint, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, double> data)
		{
			size = 0;
			data = new Dictionary<uint, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, bool> data)
		{
			size = 0;
			data = new Dictionary<uint, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, string> data)
		{
			size = 0;
			data = new Dictionary<uint, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<uint, DateTime> data)
		{
			size = 0;
			data = new Dictionary<uint, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out uint key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, int> data)
		{
			size = 0;
			data = new Dictionary<short, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, uint> data)
		{
			size = 0;
			data = new Dictionary<short, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, short> data)
		{
			size = 0;
			data = new Dictionary<short, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, ushort> data)
		{
			size = 0;
			data = new Dictionary<short, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, char> data)
		{
			size = 0;
			data = new Dictionary<short, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, long> data)
		{
			size = 0;
			data = new Dictionary<short, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, ulong> data)
		{
			size = 0;
			data = new Dictionary<short, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, float> data)
		{
			size = 0;
			data = new Dictionary<short, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, double> data)
		{
			size = 0;
			data = new Dictionary<short, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, bool> data)
		{
			size = 0;
			data = new Dictionary<short, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, string> data)
		{
			size = 0;
			data = new Dictionary<short, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<short, DateTime> data)
		{
			size = 0;
			data = new Dictionary<short, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out short key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, int> data)
		{
			size = 0;
			data = new Dictionary<ushort, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, uint> data)
		{
			size = 0;
			data = new Dictionary<ushort, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, short> data)
		{
			size = 0;
			data = new Dictionary<ushort, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, ushort> data)
		{
			size = 0;
			data = new Dictionary<ushort, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, char> data)
		{
			size = 0;
			data = new Dictionary<ushort, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, long> data)
		{
			size = 0;
			data = new Dictionary<ushort, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, ulong> data)
		{
			size = 0;
			data = new Dictionary<ushort, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, float> data)
		{
			size = 0;
			data = new Dictionary<ushort, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, double> data)
		{
			size = 0;
			data = new Dictionary<ushort, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, bool> data)
		{
			size = 0;
			data = new Dictionary<ushort, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, string> data)
		{
			size = 0;
			data = new Dictionary<ushort, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ushort, DateTime> data)
		{
			size = 0;
			data = new Dictionary<ushort, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ushort key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, int> data)
		{
			size = 0;
			data = new Dictionary<char, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, uint> data)
		{
			size = 0;
			data = new Dictionary<char, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, short> data)
		{
			size = 0;
			data = new Dictionary<char, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, ushort> data)
		{
			size = 0;
			data = new Dictionary<char, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, char> data)
		{
			size = 0;
			data = new Dictionary<char, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, long> data)
		{
			size = 0;
			data = new Dictionary<char, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, ulong> data)
		{
			size = 0;
			data = new Dictionary<char, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, float> data)
		{
			size = 0;
			data = new Dictionary<char, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, double> data)
		{
			size = 0;
			data = new Dictionary<char, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, bool> data)
		{
			size = 0;
			data = new Dictionary<char, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, string> data)
		{
			size = 0;
			data = new Dictionary<char, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<char, DateTime> data)
		{
			size = 0;
			data = new Dictionary<char, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out char key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, int> data)
		{
			size = 0;
			data = new Dictionary<long, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, uint> data)
		{
			size = 0;
			data = new Dictionary<long, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, short> data)
		{
			size = 0;
			data = new Dictionary<long, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ushort> data)
		{
			size = 0;
			data = new Dictionary<long, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, char> data)
		{
			size = 0;
			data = new Dictionary<long, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, long> data)
		{
			size = 0;
			data = new Dictionary<long, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ulong> data)
		{
			size = 0;
			data = new Dictionary<long, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, float> data)
		{
			size = 0;
			data = new Dictionary<long, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, double> data)
		{
			size = 0;
			data = new Dictionary<long, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, bool> data)
		{
			size = 0;
			data = new Dictionary<long, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, string> data)
		{
			size = 0;
			data = new Dictionary<long, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, DateTime> data)
		{
			size = 0;
			data = new Dictionary<long, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, int> data)
		{
			size = 0;
			data = new Dictionary<ulong, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, uint> data)
		{
			size = 0;
			data = new Dictionary<ulong, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, short> data)
		{
			size = 0;
			data = new Dictionary<ulong, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, ushort> data)
		{
			size = 0;
			data = new Dictionary<ulong, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, char> data)
		{
			size = 0;
			data = new Dictionary<ulong, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, long> data)
		{
			size = 0;
			data = new Dictionary<ulong, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, ulong> data)
		{
			size = 0;
			data = new Dictionary<ulong, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, float> data)
		{
			size = 0;
			data = new Dictionary<ulong, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, double> data)
		{
			size = 0;
			data = new Dictionary<ulong, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, bool> data)
		{
			size = 0;
			data = new Dictionary<ulong, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, string> data)
		{
			size = 0;
			data = new Dictionary<ulong, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<ulong, DateTime> data)
		{
			size = 0;
			data = new Dictionary<ulong, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out ulong key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, int> data)
		{
			size = 0;
			data = new Dictionary<float, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, uint> data)
		{
			size = 0;
			data = new Dictionary<float, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, short> data)
		{
			size = 0;
			data = new Dictionary<float, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, ushort> data)
		{
			size = 0;
			data = new Dictionary<float, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, char> data)
		{
			size = 0;
			data = new Dictionary<float, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, long> data)
		{
			size = 0;
			data = new Dictionary<float, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, ulong> data)
		{
			size = 0;
			data = new Dictionary<float, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, float> data)
		{
			size = 0;
			data = new Dictionary<float, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, double> data)
		{
			size = 0;
			data = new Dictionary<float, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, bool> data)
		{
			size = 0;
			data = new Dictionary<float, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, string> data)
		{
			size = 0;
			data = new Dictionary<float, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<float, DateTime> data)
		{
			size = 0;
			data = new Dictionary<float, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out float key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, int> data)
		{
			size = 0;
			data = new Dictionary<double, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, uint> data)
		{
			size = 0;
			data = new Dictionary<double, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, short> data)
		{
			size = 0;
			data = new Dictionary<double, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, ushort> data)
		{
			size = 0;
			data = new Dictionary<double, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, char> data)
		{
			size = 0;
			data = new Dictionary<double, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, long> data)
		{
			size = 0;
			data = new Dictionary<double, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, ulong> data)
		{
			size = 0;
			data = new Dictionary<double, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, float> data)
		{
			size = 0;
			data = new Dictionary<double, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, double> data)
		{
			size = 0;
			data = new Dictionary<double, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, bool> data)
		{
			size = 0;
			data = new Dictionary<double, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, string> data)
		{
			size = 0;
			data = new Dictionary<double, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<double, DateTime> data)
		{
			size = 0;
			data = new Dictionary<double, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out double key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, int> data)
		{
			size = 0;
			data = new Dictionary<bool, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, uint> data)
		{
			size = 0;
			data = new Dictionary<bool, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, short> data)
		{
			size = 0;
			data = new Dictionary<bool, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, ushort> data)
		{
			size = 0;
			data = new Dictionary<bool, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, char> data)
		{
			size = 0;
			data = new Dictionary<bool, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, long> data)
		{
			size = 0;
			data = new Dictionary<bool, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, ulong> data)
		{
			size = 0;
			data = new Dictionary<bool, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, float> data)
		{
			size = 0;
			data = new Dictionary<bool, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, double> data)
		{
			size = 0;
			data = new Dictionary<bool, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, bool> data)
		{
			size = 0;
			data = new Dictionary<bool, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, string> data)
		{
			size = 0;
			data = new Dictionary<bool, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<bool, DateTime> data)
		{
			size = 0;
			data = new Dictionary<bool, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out bool key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, int> data)
		{
			size = 0;
			data = new Dictionary<string, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, uint> data)
		{
			size = 0;
			data = new Dictionary<string, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, short> data)
		{
			size = 0;
			data = new Dictionary<string, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, ushort> data)
		{
			size = 0;
			data = new Dictionary<string, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, char> data)
		{
			size = 0;
			data = new Dictionary<string, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, long> data)
		{
			size = 0;
			data = new Dictionary<string, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, ulong> data)
		{
			size = 0;
			data = new Dictionary<string, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, float> data)
		{
			size = 0;
			data = new Dictionary<string, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, double> data)
		{
			size = 0;
			data = new Dictionary<string, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, bool> data)
		{
			size = 0;
			data = new Dictionary<string, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, string> data)
		{
			size = 0;
			data = new Dictionary<string, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<string, DateTime> data)
		{
			size = 0;
			data = new Dictionary<string, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out string key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, int> data)
		{
			size = 0;
			data = new Dictionary<DateTime, int>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out int value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, uint> data)
		{
			size = 0;
			data = new Dictionary<DateTime, uint>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out uint value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, short> data)
		{
			size = 0;
			data = new Dictionary<DateTime, short>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out short value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, ushort> data)
		{
			size = 0;
			data = new Dictionary<DateTime, ushort>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ushort value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, char> data)
		{
			size = 0;
			data = new Dictionary<DateTime, char>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out char value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, long> data)
		{
			size = 0;
			data = new Dictionary<DateTime, long>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out long value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, ulong> data)
		{
			size = 0;
			data = new Dictionary<DateTime, ulong>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ulong value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, float> data)
		{
			size = 0;
			data = new Dictionary<DateTime, float>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out float value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, double> data)
		{
			size = 0;
			data = new Dictionary<DateTime, double>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out double value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, bool> data)
		{
			size = 0;
			data = new Dictionary<DateTime, bool>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out bool value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, string> data)
		{
			size = 0;
			data = new Dictionary<DateTime, string>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out string value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<DateTime, DateTime> data)
		{
			size = 0;
			data = new Dictionary<DateTime, DateTime>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out DateTime key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DateTime value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<Ping_RQ> data)
		{
			size = 0;
			data = new List<Ping_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out Ping_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, Ping_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, Ping_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out Ping_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, Ping_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, Ping_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out Ping_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<Ping_RS> data)
		{
			size = 0;
			data = new List<Ping_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out Ping_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, Ping_RS> data)
		{
			size = 0;
			data = new Dictionary<int, Ping_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out Ping_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, Ping_RS> data)
		{
			size = 0;
			data = new Dictionary<long, Ping_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out Ping_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ChatMsg_RQ> data)
		{
			size = 0;
			data = new List<ChatMsg_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ChatMsg_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ChatMsg_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, ChatMsg_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ChatMsg_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ChatMsg_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, ChatMsg_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ChatMsg_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ChatMsg_RS> data)
		{
			size = 0;
			data = new List<ChatMsg_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ChatMsg_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ChatMsg_RS> data)
		{
			size = 0;
			data = new Dictionary<int, ChatMsg_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ChatMsg_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ChatMsg_RS> data)
		{
			size = 0;
			data = new Dictionary<long, ChatMsg_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ChatMsg_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ListTest_RQ> data)
		{
			size = 0;
			data = new List<ListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ListTest_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ListTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, ListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ListTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ListTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, ListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ListTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ListTest_RS> data)
		{
			size = 0;
			data = new List<ListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ListTest_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ListTest_RS> data)
		{
			size = 0;
			data = new Dictionary<int, ListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ListTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ListTest_RS> data)
		{
			size = 0;
			data = new Dictionary<long, ListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ListTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<DictionaryTest_RQ> data)
		{
			size = 0;
			data = new List<DictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out DictionaryTest_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, DictionaryTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, DictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DictionaryTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, DictionaryTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, DictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DictionaryTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<DictionaryTest_RS> data)
		{
			size = 0;
			data = new List<DictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out DictionaryTest_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, DictionaryTest_RS> data)
		{
			size = 0;
			data = new Dictionary<int, DictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DictionaryTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, DictionaryTest_RS> data)
		{
			size = 0;
			data = new Dictionary<long, DictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out DictionaryTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ClassListTest_RQ> data)
		{
			size = 0;
			data = new List<ClassListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ClassListTest_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ClassListTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, ClassListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassListTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ClassListTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, ClassListTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassListTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ClassListTest_RS> data)
		{
			size = 0;
			data = new List<ClassListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ClassListTest_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ClassListTest_RS> data)
		{
			size = 0;
			data = new Dictionary<int, ClassListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassListTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ClassListTest_RS> data)
		{
			size = 0;
			data = new Dictionary<long, ClassListTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassListTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ClassDictionaryTest_RQ> data)
		{
			size = 0;
			data = new List<ClassDictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ClassDictionaryTest_RQ element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ClassDictionaryTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<int, ClassDictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassDictionaryTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ClassDictionaryTest_RQ> data)
		{
			size = 0;
			data = new Dictionary<long, ClassDictionaryTest_RQ>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassDictionaryTest_RQ value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out List<ClassDictionaryTest_RS> data)
		{
			size = 0;
			data = new List<ClassDictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult elementError = AdamBitConverter.Deserialize(buff, out int eSize, out ClassDictionaryTest_RS element);

				if(elementError == EDeserializeResult.PacketFragmentation)
					return elementError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + eSize, buff.Count - eSize);
				size += eSize;
				data.Add(element);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<int, ClassDictionaryTest_RS> data)
		{
			size = 0;
			data = new Dictionary<int, ClassDictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out int key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassDictionaryTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Dictionary<long, ClassDictionaryTest_RS> data)
		{
			size = 0;
			data = new Dictionary<long, ClassDictionaryTest_RS>();

			if(buff.Count < sizeof(int))
				return EDeserializeResult.PacketFragmentation;

			EDeserializeResult lengthError = AdamBitConverter.Deserialize(buff, out int sizeOfLength, out int length);
			if(lengthError != EDeserializeResult.Success)
				return lengthError;

			buff = new ArraySegment<byte>(buff.Array, buff.Offset + sizeOfLength, buff.Count - sizeOfLength);
			size = sizeOfLength;

			for(int i = 0; i < length; ++i)
			{
				EDeserializeResult keyError = AdamBitConverter.Deserialize(buff, out int keySize, out long key);
				if(keyError == EDeserializeResult.PacketFragmentation)
					return keyError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + keySize, buff.Count - keySize);

				EDeserializeResult valError = AdamBitConverter.Deserialize(buff, out int valSize, out ClassDictionaryTest_RS value);
				if(valError == EDeserializeResult.PacketFragmentation)
					return valError;

				buff = new ArraySegment<byte>(buff.Array, buff.Offset + valSize, buff.Count - valSize);

				size += (keySize + valSize);
				data.Add(key, value);
			}

			return EDeserializeResult.Success;
		}
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out Ping_RQ data)
		{
			data = new Ping_RQ();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

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

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

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

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

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

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

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
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ListTest_RQ data)
		{
			data = new ListTest_RQ();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.sentences);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ListTest_RS data)
		{
			data = new ListTest_RS();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.numOfCharacters);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out DictionaryTest_RQ data)
		{
			data = new DictionaryTest_RQ();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.numOfCharacters);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out DictionaryTest_RS data)
		{
			data = new DictionaryTest_RS();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.numOfCharacters);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ClassListTest_RQ data)
		{
			data = new ClassListTest_RQ();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.chatList);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ClassListTest_RS data)
		{
			data = new ClassListTest_RS();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.chatList);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ClassDictionaryTest_RQ data)
		{
			data = new ClassDictionaryTest_RQ();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.chatList);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	
		public static EDeserializeResult Deserialize(ArraySegment<byte> buff, out int size, out ClassDictionaryTest_RS data)
		{
			data = new ClassDictionaryTest_RS();
			size = 0;

			PacketHeader header = new PacketHeader();
			EDeserializeResult headerError = AdamBitConverter.Deserialize(buff, out int headerSize, out header);
			if(headerError != EDeserializeResult.Success)
					return headerError;

			size += headerSize;

			// Deserializations
			
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.chatList);
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
	
			{
				ArraySegment<byte> memberBuff = new ArraySegment<byte>(buff.Array, buff.Offset + size, buff.Count - size);
				EDeserializeResult memberError = AdamBitConverter.Deserialize(memberBuff, out int memberSize, out data.nickname);
				if(memberError != EDeserializeResult.Success)
					return memberError;

				size += memberSize;
			}
	

			return EDeserializeResult.Success;
		}
	
	

	}
}