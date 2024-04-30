using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Maein(string[] args)
    {
        // Endereço IP e porta do servidor
        string ip = "127.0.0.1";
        int port = 8888;

        // Iniciar servidor
        await StartServerAsync(ip, port);
    }

    static async Task StartServerAsync(string ip, int port)
    {
        // Criar um ponto de extremidade de IP para o servidor
        IPAddress ipAddress = IPAddress.Parse(ip);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

        // Iniciar TcpListener
        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();

        Console.WriteLine("Servidor iniciado. Aguardando conexões...");

        while (true)
        {
            // Aceitar conexão do cliente de forma assíncrona
            TcpClient client = await listener.AcceptTcpClientAsync();

            // Processar cliente de forma assíncrona
            _ = HandleClientAsync(client);
        }
    }

    static async Task HandleClientAsync(TcpClient client)
    {
        Console.WriteLine($"Novo cliente conectado: {client.Client.RemoteEndPoint}");

        // Stream para ler e escrever dados
        using (NetworkStream stream = client.GetStream())
        using (StreamReader reader = new StreamReader(stream))
        using (StreamWriter writer = new StreamWriter(stream))
        {
            try
            {
                while (true)
                {
                    // Ler mensagem do cliente de forma assíncrona
                    string message = await reader.ReadLineAsync();

                    if (message == null)
                        break; // Cliente desconectado
                
                    // Exibir mensagem recebida do cliente
                    Console.WriteLine($"Cliente ({client.Client.RemoteEndPoint}): {message}");

                    // Responder ao cliente (opcional)
                    //await writer.WriteLineAsync($"Servidor: {message}");
                    //await writer.FlushAsync(); // Forçar escrita do buffer
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
