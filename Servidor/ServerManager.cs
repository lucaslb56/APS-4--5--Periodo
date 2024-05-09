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
		private RoomManager roomManager;
		private bool monitorUsers = false;
		private bool monitorMessage = false;
		private string token = "TOKEN_APS_4_5_CHAT_TCP_IP";
		public ServerManager(string ip, int port) {
			// instanciando um servidor 
			IPAddress ipAddress = IPAddress.Parse(ip);
			listener = new TcpListener(ipAddress, port);
		}

		public void startServer() {
			// Definindo configurações de monitoramento em servidor
			string resposta;
			Console.Write("Monitorar conexões?(s/n):");
			resposta = Console.ReadLine();
			monitorUsers = (resposta == "s") ? true : false; 
			Console.Write("Monitorar conversas?(s/n):");
			resposta = Console.ReadLine();
			monitorMessage = (resposta == "s") ? true : false;
			// Iniciando o servidor
			listener.Start();
			Console.WriteLine("Servidor iniciado.");
			// Iniciando uma sala de conversa
			roomManager = new RoomManager(monitorUsers, monitorMessage);
			// Função que vai receber e tratar as conexões de cliente
			listenConnections();
		}

		public void listenConnections() {
			try
			{
				while (true)
				{
					// Espera a conexão de um cliente
					TcpClient tcp = listener.AcceptTcpClient();
					// Ao receber uma conexão, faz a sua autentificação
					string username = userAuthentication(tcp);
					if (username == "") { tcp.Close(); continue; }
					// verifica o nome repetido em sala
					username = roomManager.validateUserName(username);
					// Instancia um novo usuário
					User user = new User(tcp, username);
					// Adiciona usuário a sala
					roomManager.addUser(user);
	
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
				writer.WriteLine(username);
				writer.Flush();
				return username;
				
			}catch (Exception ex)
			{
				Console.WriteLine($"Conexão de {tcp.Client.RemoteEndPoint} foi recusada! Falha na autentificação.");
				return "";
			}

		}

		public async Task waitMessage(User user){
			
			
		}

		public void stopServer()
		{
			listener.Stop();
		}
	}
}
