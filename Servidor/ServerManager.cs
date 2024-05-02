using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Servidor
{
	internal class ServerManager
	{
		private TcpListener listener;
		private List<User> users;
		private bool monitorConexoes = false;
		private bool monitorConversas = false;
		public ServerManager(string ip, int port) {

			// Cria um endpoint de IP para o servidor
			IPAddress ipAddress = IPAddress.Parse(ip);
			
			// Iniciar TcpListener
			listener = new TcpListener(ipAddress, port);
		}

		public void startServer() {
			string resposta;
			Console.Write("Monitorar conexões?(s/n):");
			resposta = Console.ReadLine();
			monitorConexoes = (resposta == "s") ? true : false; 
			Console.Write("Monitorar conversas?(s/n):");
			resposta = Console.ReadLine();
			monitorConversas = (resposta == "s") ? true : false;
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
				if (monitorConexoes) Console.WriteLine("Novo usuário conectado: "+user.userName);
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
						if (monitorConexoes) Console.WriteLine("Usuário: "+user.userName+" desconectou");
						break;
					}
					if (monitorConversas) Console.WriteLine($"({user.userName}): {message}");
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
