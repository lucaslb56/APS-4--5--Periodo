using System;
using System.IO;
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

        // Conectar ao servidor
        await ConnectToServerAsync(ip, port);
    }

    static async Task ConnectToServerAsync(string ip, int port)
    {
        // Criar TcpClient e conectar ao servidor
        using (TcpClient client = new TcpClient())
        {
            await client.ConnectAsync(ip, port);
            Console.WriteLine("Conectado ao servidor.");

            // Stream para ler e escrever dados
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                receiveMensege(reader);
                try
                {
                    while (true)
                    {
                        // Ler mensagem do console
                        Console.Write("Digite sua mensagem: ");
                        string message = Console.ReadLine();

                        // Enviar mensagem ao servidor de forma assíncrona
                        await writer.WriteLineAsync(message);
                        await writer.FlushAsync(); // Forçar escrita do buffer
                        Task.Delay(10000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro de comunicação com o servidor: {ex.Message}");
                }
            }
        }
    }

    static async Task receiveMensege(StreamReader reader){
        try
        {
            while (true)
            {
                // Ler resposta do servidor de forma assíncrona
                string response = await reader.ReadLineAsync();
                // Exibir resposta do servidor
                Console.WriteLine(response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro de comunicação com o servidor: {ex.Message}");
        }
    }
}
