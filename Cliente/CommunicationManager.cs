using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente2
{
	internal class CommunicationManager
	{
		private I_Cliente form;
		private TcpClient client;
		private NetworkStream stream;
		private StreamWriter writer;
		private StreamReader reader;
		public CommunicationManager(I_Cliente form)
		{
			this.form = form;
		}

		public void connectServer(IPAddress ip, int port, string userName)
		{
			
			client = new TcpClient();
			client.Connect(ip, port);
			stream = client.GetStream();
			writer = new StreamWriter(stream);
			reader = new StreamReader(stream);
			sendMessage(userName);
			waitMessage();
		}

		public async Task sendMessage(string mensagem)
		{
			try
			{
				await writer.WriteLineAsync(mensagem);
				await writer.FlushAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public async Task waitMessage()
		{
			try {
				while (true)
				{
					string message = await reader.ReadLineAsync();
					if (message == null){ break; }
					form.addMessage(message);
				}
			
			}catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}finally {
				form.updateStatus(false, "Servidor parou de responder!");
				disconnectServer();
			}
			
		}

		public void disconnectServer()
		{
			reader.Close();
			writer.Close();
			stream.Close();	
			client.Close();
		}
	}
}