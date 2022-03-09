using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    internal class ServerSessionManager
    {
		static ServerSessionManager _Instance = new ServerSessionManager();
		public static ServerSessionManager Instance { get { return _Instance; } }

		int SessionIdMax = 0;
		HashSet<int> AvailableSessionIds = new HashSet<int>();
		Dictionary<int, ServerSession> Sessions = new Dictionary<int, ServerSession>();
		Dictionary<int, ServerPacketHandler> PacketHandlers = new Dictionary<int, ServerPacketHandler>();
		object ManagerLock = new object();

		public ServerSession Generate(Func<ServerSession> SessionFactory)
		{
			lock (ManagerLock)
			{
				int SessionIdToUse ;
				if (AvailableSessionIds.Count > 0)
				{
					SessionIdToUse = AvailableSessionIds.ToArray()[0];
				}
                else 
				{
					SessionIdToUse = SessionIdMax;
				}

				ServerSession Session = SessionFactory.Invoke();
				ServerPacketHandler PacketHandler = new ServerPacketHandler(Session);
				Session.SessionId = SessionIdToUse;
				Sessions.Add(SessionIdToUse, Session);
				PacketHandlers.Add(SessionIdToUse, PacketHandler);

				Console.WriteLine($"[Connected] SessionId = {SessionIdToUse}");

				return Session;
			}
		}

		public ServerSession Find(int SessionId)
		{
			lock (ManagerLock)
			{
				ServerSession Session = null;
				Sessions.TryGetValue(SessionId, out Session);
				return Session;
			}
		}

		public void Remove(ServerSession Session)
		{
			lock (ManagerLock)
			{
				Sessions.Remove(Session.SessionId);
				PacketHandlers.Remove(Session.SessionId);
				AvailableSessionIds.Add(Session.SessionId);
			}
		}
	}
}
