using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
	internal class MessageManager
	{
		RoomManager room;
		bool monitorMessage;
		public MessageManager(RoomManager room, bool monitorMessage) 
		{
			this.room = room;
			this.monitorMessage = monitorMessage;
		}
		public async Task listenMessages(User user)
		{
			string message;
			try
			{
				while (user.Tcp.Connected)
				{
					// Ler mensagem do cliente
					message = await user.reader.ReadLineAsync();
					// Verifica possível desconexão do cliente
					if (message == null) throw new IOException();
					// Envia mensagem para todos os usuários conectados da sala
					sendRoom(user, message);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Houve um erro ao tratar a mensagem do usuário: {user.userName}");
			}
			finally
			{
				// Libera os recursos desse usuário
				room.disconnectUser(user);
			}
		}

		public void sendRoom(User senderUser, string message)
		{
			if (monitorMessage) Console.WriteLine($"({senderUser.userName}): {message}");

			foreach (User user in room.users)
			{
				if (user.Tcp.Connected)
				{
					user.writer.WriteLine($"[{senderUser.userName}]: {message}");
					user.writer.Flush();
				}
			}
		}
	}
}
