






/**************************************

	이 파일은 자동 생성되는 파일입니다.
		절대 직접 수정하지마세요.

**************************************/

namespace ServerLib.Packet
{
	internal class AdamBitConverter
	{
		
		
		public static byte[] Serialize(Ping_RQ date, out int serializeSize)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[date.Size]);

			
			{
				byte[] memberBuff = Serialize(data.time, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	

			serializeSize = cursor;
			return buff.Array;
		}
	
		public static Ping_RQ Deserialize(ArraySegment<byte> buff, out int deserializeSize)
		{
			
			{
				time = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
		}
	
		public static byte[] Serialize(Ping_RS date, out int serializeSize)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[date.Size]);

			
			{
				byte[] memberBuff = Serialize(data.time, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	

			serializeSize = cursor;
			return buff.Array;
		}
	
		public static Ping_RS Deserialize(ArraySegment<byte> buff, out int deserializeSize)
		{
			
			{
				time = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
		}
	
		public static byte[] Serialize(ChatMsg_RQ date, out int serializeSize)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[date.Size]);

			
			{
				byte[] memberBuff = Serialize(data.msgText, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	
			{
				byte[] memberBuff = Serialize(data.time, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	

			serializeSize = cursor;
			return buff.Array;
		}
	
		public static ChatMsg_RQ Deserialize(ArraySegment<byte> buff, out int deserializeSize)
		{
			
			{
				msgText = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
			{
				time = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
		}
	
		public static byte[] Serialize(ChatMsg_RS date, out int serializeSize)
		{
			int cursor = 0;
			ArraySegment<byte> buff = new ArraySegment<byte>(new byte[date.Size]);

			
			{
				byte[] memberBuff = Serialize(data.msgText, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	
			{
				byte[] memberBuff = Serialize(data.time, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				cursor += memberSize;
			}
	

			serializeSize = cursor;
			return buff.Array;
		}
	
		public static ChatMsg_RS Deserialize(ArraySegment<byte> buff, out int deserializeSize)
		{
			
			{
				msgText = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
			{
				time = Deserialize(buff, out int memberSize);
				Array.Copy(memberBuff, 0, buff.Array, buff.Count + cursor, memberSize);
				buff = new ArraySegment(buff.Array, buff.Offset + memberSize, buff.Count - memberSize);
			}
	
		}
	

	}
}