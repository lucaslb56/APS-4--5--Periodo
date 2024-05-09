using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
	internal class User
	{
		public TcpClient Tcp;
		public string? userName;
		public string endPoint;
		public List<string> messages;
		public NetworkStream stream;
		public StreamReader reader;
		public StreamWriter writer;
		public User(TcpClient tcp, string username) { 
			Tcp = tcp;
			this.userName = username;
			endPoint = Tcp.Client.RemoteEndPoint.ToString();
			stream = Tcp.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);
		}


	}
}
