namespace Cliente2
{
	public partial class Form1 : Form
	{
		int locMsgY = 10;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string ip = "127.0.0.1";
			int port = 8888;
			CommunicationManager ComManager = new CommunicationManager(ip, port);
			ComManager.connectServer(lbStatus);
		}

		private void btEnviar_Click(object sender, EventArgs e)
		{
			Label NovaMsg = new Label();
			NovaMsg.AutoSize = true;
			NovaMsg.ForeColor = SystemColors.ActiveCaptionText;
			NovaMsg.Location = new Point(3, locMsgY);
			NovaMsg.Size = new Size(182, 20);
			NovaMsg.TabIndex = 0;
			NovaMsg.Text = textBox1.Text;
			NovaMsg.UseWaitCursor = true;
			panel1.Controls.Add(NovaMsg);
			locMsgY += 30;

		}

		
	}
}
