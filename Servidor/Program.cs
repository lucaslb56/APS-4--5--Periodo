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
        string ip = "127.0.0.1";
        int port = 8888;
		ServerManager server = new ServerManager(ip, port);
        server.startServer();
		Console.WriteLine("Servidor iniciado. Aguardando conexões...");
        Console.ReadLine();
    }

    static async Task receiveConnection(TcpListener listener, List<TcpClient> clients){
        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine("Novo Cliente conectado: "+client.Client.RemoteEndPoint);
            clients.Add(client);
            receiveMensege(client, clients);
        }
    }

    static async Task receiveMensege(TcpClient client, List<TcpClient> clients){
        using (NetworkStream stream = client.GetStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            try
            {
                while (true)
                {
                    // Ler mensagem do cliente de forma assíncrona
                    string message = await reader.ReadLineAsync();

                    if (message == null)
                        break; // Cliente desconectado
                    
                    Console.WriteLine($"Cliente ({client.Client.RemoteEndPoint}): {message}");
                   foreach (TcpClient receiver in clients)
                   {   
                        if (receiver == client) { continue; } 
                        using (NetworkStream streamReceiver = receiver.GetStream())
                        using (StreamWriter writerReceiver = new StreamWriter(streamReceiver))
                        {
                            await writerReceiver.WriteLineAsync($"Cliente ({client.Client.RemoteEndPoint}): {message}");
                        }
                   }  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cliente ({client.Client.RemoteEndPoint}) desconectado: {ex.Message}");
            }
        }

        // Fechar TcpClient
        client.Close();
    }

    
}
