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
		public User(TcpClient tcp) { 
			Tcp = tcp;
			endPoint = Tcp.Client.RemoteEndPoint.ToString();
			stream = Tcp.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);
		}
		
		public void setUserName(string username, List<User> users){
			this.userName = username;
			int d = 1;
			while (true){
				User foundUser = users.FirstOrDefault(user => (user.userName == userName) && user.Tcp.Connected);
				if (foundUser != null){
					this.userName = username + d.ToString();
				}else break; 
			}			
			
		}

		public void disconnectUser(){
			reader.Close();
			writer.Close();
			stream.Close();
			Tcp.Close();
		}
		


	}
}
