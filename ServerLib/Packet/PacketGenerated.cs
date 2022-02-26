
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
	
    public class Ping_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(time));
        public const ushort Id = 0;

		
		public DateTime time;
	
    }
	
    public class Ping_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(time));
        public const ushort Id = 1;

		
		public DateTime time;
	
    }
	
    public class ChatMsg_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(msgText) + AdamBitConverter.SizeOf(time));
        public const ushort Id = 2;

		
		public string msgText;
	
		public DateTime time;
	
    }
	
    public class ChatMsg_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(msgText) + AdamBitConverter.SizeOf(time));
        public const ushort Id = 3;

		
		public string msgText;
	
		public DateTime time;
	
    }
	
    public class ListTest_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(sentences) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 4;

		
		public List<string> sentences;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class ListTest_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(numOfCharacters) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 5;

		
		public List<int> numOfCharacters;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class DictionaryTest_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(numOfCharacters) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 6;

		
		public Dictionary<int, string> numOfCharacters;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class DictionaryTest_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(numOfCharacters) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 7;

		
		public Dictionary<string, int> numOfCharacters;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class ClassListTest_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(chatList) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 8;

		
		public List<ChatMsg_RQ> chatList;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class ClassListTest_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(chatList) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 9;

		
		public List<ChatMsg_RS> chatList;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class ClassDictionaryTest_RQ : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(chatList) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 10;

		
		public Dictionary<int, ChatMsg_RQ> chatList;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
    public class ClassDictionaryTest_RS : PacketBase
    {
		/**************************************

			이 파일은 자동 생성되는 파일입니다.
				절대 직접 수정하지마세요.

		**************************************/

		// 패킷의 고유 아이디
        public override ushort PacketId => Id;

		// 헤더를 제외한 사이즈
        public override ushort PacketSize => (ushort)(AdamBitConverter.SizeOf(chatList) + AdamBitConverter.SizeOf(time) + AdamBitConverter.SizeOf(nickname));
        public const ushort Id = 11;

		
		public Dictionary<int, ChatMsg_RS> chatList;
	
		public DateTime time;
	
		public string nickname;
	
    }
	
}