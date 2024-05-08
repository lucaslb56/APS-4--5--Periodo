using System.Net;
using System.Security.Authentication;

namespace Cliente
{
	public partial class I_Cliente : Form
	{
		int locMsgY = 25;
		CommunicationManager ComManager;
		bool conected = false;
		public I_Cliente()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ComManager = new CommunicationManager(this);
		}

		private void btEnviar_Click(object sender, EventArgs e)
		{
			if (!conected) { return; }
			string mensagem = ipMessage.Text;
			ComManager.sendMessage(mensagem);
			ipMessage.Text = "";

		}

		public void updateStatus(bool sucess, string error = "")
		{
			if (sucess)
			{
				conected = true;
				lbStatus.Text = "Conectado";
				btConectar.Text = "Desconectar";
				lbStatus.ForeColor = Color.FromArgb(50, 205, 50);
			}
			else
			{
				conected = false;
				btConectar.Text = "Conectar";
				lbStatus.Text = (error != "") ? "Erro ao conectar: " + error : "Desconectado";
				lbStatus.ForeColor = Color.FromArgb(192, 0, 0);
			}
			Cursor = Cursors.Default;

		}

		private void btConectar_Click(object sender, EventArgs e)
		{
			if (conected)
			{
				ComManager.disconnectServer();
				updateStatus(false);
			}
			else
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					if (!IPAddress.TryParse(inpIP.Text, out IPAddress ip))
					{
						updateStatus(false, "IP inválido!");
						return;
						
					}
					if (!int.TryParse(inpPorta.Text, out int port))
					{
						updateStatus(false, "Porta inválida!");
						return;
					}
					string username = inpUsuario.Text;
					
					ComManager.connectServer(ip, port, username);
					updateStatus(true);
				}
				catch (AuthenticationException)
				{
					updateStatus(false, "Falha ao autentificar! verifique a aplicação.");
				}
				catch (Exception ex)
				{
					updateStatus(false, ex.Message);
				}
			}
			
		}

		public void addMessage(string message)
		{
			Label lbMessage = new Label();
			lbMessage.AutoSize = true;
			lbMessage.MaximumSize = new Size(550, 0);
			lbMessage.Text = message;
			lbMessage.ForeColor = SystemColors.ActiveCaptionText;
			lbMessage.Name = "lbMessage";
			lbMessage.TabIndex = 3;
			lbMessage.Location = new Point(3, locMsgY);
			pnMensagens.Controls.Add(lbMessage);
			locMsgY += 30;
		}
	}
}
