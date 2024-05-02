using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
	internal class ServerManager
	{
		private TcpListener listener;
		private List<User> users;
		public ServerManager(string ip, int port) {

			// Cria um endpoint de IP para o servidor
			IPAddress ipAddress = IPAddress.Parse(ip);
			IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

			// Iniciar TcpListener
			listener = new TcpListener(ipAddress, port);
		}

		public void startServer() {

			listener.Start();
			waitConnections();
		}

		public async Task waitConnections() {
			users = new List<User>();
			while (true)
			{
				TcpClient tcp = await listener.AcceptTcpClientAsync();
				
				User user = new User(tcp);
				user.setUserName(users);
				users.Add(user);
				Console.WriteLine("Novo usuário conectado: "+user.userName);
				waitMessage(user);
			}
		}

		public async Task waitMessage(User user){
			try
			{
				while (true)
				{
					// Ler mensagem do cliente de forma assíncrona
					string message = await user.reader.ReadLineAsync();
					if (message == null){
						Console.WriteLine("Usuário: "+user.userName+" desconectou");
                        break;
					}
					Console.WriteLine($"({user.userName}): {message}");
					foreach (User otherUser in users)
					{   
						if(otherUser.Tcp.Connected){
							await otherUser.writer.WriteLineAsync($"({user.userName}): {message}");
							await otherUser.writer.FlushAsync();
						}else{
							continue;
						}
						
					}  
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Cliente ({user.endPoint}) desconectado: {ex.Message}");
			}
			finally{
				user.disconnectUser();
			}
			
		}
	}
}
