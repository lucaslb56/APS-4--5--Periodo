using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Authentication;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Servidor
{
	internal class ServerManager
	{
		private TcpListener listener;
		private List<User> users;
		private bool monitorConexoes = false;
		private bool monitorConversas = false;
		private string token = "TOKEN_APS_4_5_CHAT_TCP_IP";
		public ServerManager(string ip, int port) {
			// instanciando um servidor 
			IPAddress ipAddress = IPAddress.Parse(ip);
			listener = new TcpListener(ipAddress, port);
			// Inicia uma lista de usuários vazios
			users = new List<User>();
		}

		public void startServer() {
			// Definindo configurações de monitoramento em servidor
			string resposta;
			Console.Write("Monitorar conexões?(s/n):");
			resposta = Console.ReadLine();
			monitorConexoes = (resposta == "s") ? true : false; 
			Console.Write("Monitorar conversas?(s/n):");
			resposta = Console.ReadLine();
			monitorConversas = (resposta == "s") ? true : false;
			// Iniciando o servidor
			listener.Start();
			Console.WriteLine("Servidor iniciado.");
			// Função que vai receber e tratar as conexões de cliente
			waitConnections();
		}

		public void waitConnections() {
			try
			{
				while (true)
				{
					// Espera a conexão de um cliente
					TcpClient tcp = listener.AcceptTcpClient();
					// Ao receber um cliente, faz a sua autentificação
					string username = userAuthentication(tcp);
					if (username == "")
					{
						tcp.Close();
						continue;
					}
					// instancia um novo usuário
					User user = new User(tcp);
					user.setUserName(username, users);
					users.Add(user);
					if (monitorConexoes) Console.WriteLine("Novo usuário conectado: " + user.userName);
					// Função assincrona que escuta as mensagens recebidas pelo usuário
					waitMessage(user);
				}
			}catch (Exception ex)
			{
				Console.WriteLine($"Erro inesperado: {ex.Message}");
			}
			finally
			{
				stopServer();
			}
		}

		public string userAuthentication(TcpClient tcp)
		{
			NetworkStream stream = tcp.GetStream();
			StreamReader reader = new StreamReader(stream);
			StreamWriter writer = new StreamWriter(stream);
			try
			{
				stream.ReadTimeout = 5000;
				string authentication = reader.ReadLine();
				if (authentication == null) throw new AuthenticationException();
				string[] authInfors = authentication.Split(":");
				if (authInfors[0] != token) throw new AuthenticationException();
				string username = authInfors[1];
				writer.Write(username);
				writer.Flush();
				return username;
				
			}catch (Exception ex)
			{
				Console.WriteLine($"Conexão de {tcp.Client.RemoteEndPoint} foi recusada! Falha na autentificação.");
				return "";
			}

		}

		public async Task waitMessage(User user){
			try
			{
				while (true)
				{
					// Ler mensagem do cliente
					string message = await user.reader.ReadLineAsync();
					// Verifica possível desconexão do cliente
					if (message == null && !user.Tcp.Connected){
						if (monitorConexoes) Console.WriteLine("Usuário: "+user.userName+" desconectou");
						break;
					}
					// Realiza a tratativa da mensagem recebida deste usuário
					if (monitorConversas) Console.WriteLine($"({user.userName}): {message}");
					// Envia mensagem para todos os usuários conectados
					foreach (User otherUser in users)
					{   
						if(otherUser.Tcp.Connected){
							await otherUser.writer.WriteLineAsync($"({user.userName}): {message}");
							await otherUser.writer.FlushAsync();
						}						
					}  
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Houve um erro ao tratar a mensagem do usuário: {user.userName}");
			}
			finally{
				// Libera os recursos desse usuário
				user.disconnectUser();
			}
			
		}

		public void stopServer()
		{
			listener.Stop();
		}
	}
}
