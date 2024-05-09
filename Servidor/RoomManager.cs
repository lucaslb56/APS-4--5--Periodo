using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
	
	internal class RoomManager
	{
		public List<User> users;
		private bool monitorUsers;
		private MessageManager messageManager;

		public RoomManager(bool monitorUsers, bool monitorMessage) 
		{
			messageManager = new MessageManager(this, monitorMessage);
			this.monitorUsers = monitorUsers;
			users = new List<User>();
		}

		public void addUser(User user)
		{
			users.Add(user);
			if (monitorUsers) Console.WriteLine("Novo usuário conectado: " + user.userName);
			messageManager.sendRoom(user, "Entrou!");
			// inicia ouvinte das mensagens do usuário
			messageManager.listenMessages(user);
		}
		
		public string validateUserName(string username) 
		{
			string validUserName = username;
			int d = 1;
			while (true)
			{
				User? foundUser = users.FirstOrDefault(user => (user.userName == username) && user.Tcp.Connected);
				if (foundUser != null)
				{
					validUserName = $"{username}({d.ToString()})";
				}
				else break;
			}
			return validUserName;
		}

		public void disconnectUser(User user)
		{
			if (monitorUsers) Console.WriteLine($"Usuário {user.userName} desconectou.");
			messageManager.sendRoom(user, "Saiu!");
			user.reader.Close();
			user.writer.Close();
			user.stream.Close();
			user.Tcp.Close();
		}
	}
}
