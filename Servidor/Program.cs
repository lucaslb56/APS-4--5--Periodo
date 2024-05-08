using Servidor;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
		// Endereço IP e porta do servidor
		Console.WriteLine("Iniciando servidor de aplicação APS...");
		Console.Write("Digite o endereço de ip do servidor: ");
		string ip = Console.ReadLine().ToString();
        int port = 8888;
		ServerManager server = new ServerManager(ip, port);
        server.startServer();
    }

    
}
