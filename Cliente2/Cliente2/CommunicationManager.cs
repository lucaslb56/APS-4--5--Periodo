using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente2
{
	internal class CommunicationManager
	{
		private string ipServer;
		private int portServer;
		public CommunicationManager(string ip, int porta)
		{
			this.ipServer = ip;
			this.portServer = porta;
		}

		public async Task connectServer(Label lbStatus)
		{
			try
			{
				using (TcpClient client = new TcpClient())
				{
					await client.ConnectAsync(this.ipServer, this.portServer);
					lbStatus.Text = "Conectado";
					lbStatus.ForeColor = Color.FromArgb(50, 205, 50);
				}
			}
			catch (Exception ex)
			{
				lbStatus.Text = "Erro ao conectar: "+ex.Message;
			}
			
		}
	}
}
