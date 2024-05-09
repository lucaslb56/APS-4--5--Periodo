namespace Cliente
{
	partial class I_Cliente
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			gpMensagens = new GroupBox();
			pnMensagens = new Panel();
			btEnviar = new Button();
			ipMessage = new TextBox();
			label2 = new Label();
			lbStatus = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			inpIP = new TextBox();
			inpPorta = new TextBox();
			btConectar = new Button();
			inpUsuario = new TextBox();
			label1 = new Label();
			btclearMessages = new Button();
			gpMensagens.SuspendLayout();
			SuspendLayout();
			// 
			// gpMensagens
			// 
			gpMensagens.BackColor = SystemColors.Control;
			gpMensagens.Controls.Add(pnMensagens);
			gpMensagens.Location = new Point(391, 12);
			gpMensagens.Margin = new Padding(4, 3, 4, 3);
			gpMensagens.Name = "gpMensagens";
			gpMensagens.Padding = new Padding(4, 3, 4, 3);
			gpMensagens.Size = new Size(609, 542);
			gpMensagens.TabIndex = 0;
			gpMensagens.TabStop = false;
			gpMensagens.Text = "Mensagens";
			// 
			// pnMensagens
			// 
			pnMensagens.AutoScroll = true;
			pnMensagens.BackColor = SystemColors.ButtonFace;
			pnMensagens.Location = new Point(7, 22);
			pnMensagens.Name = "pnMensagens";
			pnMensagens.Size = new Size(595, 514);
			pnMensagens.TabIndex = 15;
			// 
			// btEnviar
			// 
			btEnviar.BackColor = SystemColors.ActiveCaption;
			btEnviar.FlatStyle = FlatStyle.System;
			btEnviar.Location = new Point(253, 487);
			btEnviar.Margin = new Padding(4, 3, 4, 3);
			btEnviar.Name = "btEnviar";
			btEnviar.Size = new Size(130, 30);
			btEnviar.TabIndex = 1;
			btEnviar.Text = "Enviar";
			btEnviar.UseVisualStyleBackColor = false;
			btEnviar.Click += btEnviar_Click;
			// 
			// ipMessage
			// 
			ipMessage.Location = new Point(4, 487);
			ipMessage.Multiline = true;
			ipMessage.Name = "ipMessage";
			ipMessage.ScrollBars = ScrollBars.Horizontal;
			ipMessage.Size = new Size(242, 64);
			ipMessage.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = SystemColors.ActiveCaptionText;
			label2.Location = new Point(4, 99);
			label2.Name = "label2";
			label2.Size = new Size(52, 17);
			label2.TabIndex = 3;
			label2.Text = "Status:";
			label2.TextAlign = ContentAlignment.TopRight;
			// 
			// lbStatus
			// 
			lbStatus.AutoEllipsis = true;
			lbStatus.ForeColor = Color.FromArgb(192, 0, 0);
			lbStatus.Location = new Point(51, 99);
			lbStatus.Name = "lbStatus";
			lbStatus.Size = new Size(270, 75);
			lbStatus.TabIndex = 4;
			lbStatus.Text = "Desconectado";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = SystemColors.ActiveCaptionText;
			label3.Location = new Point(4, 12);
			label3.Name = "label3";
			label3.Size = new Size(0, 17);
			label3.TabIndex = 5;
			label3.TextAlign = ContentAlignment.TopRight;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = SystemColors.ActiveCaptionText;
			label4.Location = new Point(4, 41);
			label4.Name = "label4";
			label4.Size = new Size(21, 17);
			label4.TabIndex = 6;
			label4.Text = "Ip";
			label4.TextAlign = ContentAlignment.TopRight;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.ForeColor = SystemColors.ActiveCaptionText;
			label5.Location = new Point(4, 70);
			label5.Name = "label5";
			label5.Size = new Size(41, 17);
			label5.TabIndex = 7;
			label5.Text = "Porta";
			label5.TextAlign = ContentAlignment.TopRight;
			// 
			// inpIP
			// 
			inpIP.Location = new Point(31, 38);
			inpIP.Name = "inpIP";
			inpIP.Size = new Size(215, 23);
			inpIP.TabIndex = 8;
			inpIP.Text = "127.0.0.1";
			// 
			// inpPorta
			// 
			inpPorta.Location = new Point(51, 67);
			inpPorta.Name = "inpPorta";
			inpPorta.Size = new Size(68, 23);
			inpPorta.TabIndex = 9;
			inpPorta.Text = "8888";
			// 
			// btConectar
			// 
			btConectar.BackColor = SystemColors.ActiveCaption;
			btConectar.FlatStyle = FlatStyle.System;
			btConectar.Location = new Point(126, 67);
			btConectar.Margin = new Padding(4, 3, 4, 3);
			btConectar.Name = "btConectar";
			btConectar.Size = new Size(120, 23);
			btConectar.TabIndex = 10;
			btConectar.Text = "Conectar";
			btConectar.UseVisualStyleBackColor = false;
			btConectar.Click += btConectar_Click;
			// 
			// inpUsuario
			// 
			inpUsuario.Location = new Point(65, 9);
			inpUsuario.Name = "inpUsuario";
			inpUsuario.Size = new Size(181, 23);
			inpUsuario.TabIndex = 11;
			inpUsuario.Text = "Lucas";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = SystemColors.ActiveCaptionText;
			label1.Location = new Point(4, 12);
			label1.Name = "label1";
			label1.Size = new Size(55, 17);
			label1.TabIndex = 12;
			label1.Text = "Usuário";
			label1.TextAlign = ContentAlignment.TopRight;
			// 
			// btclearMessages
			// 
			btclearMessages.BackColor = SystemColors.ActiveCaption;
			btclearMessages.FlatStyle = FlatStyle.System;
			btclearMessages.Location = new Point(253, 523);
			btclearMessages.Margin = new Padding(4, 3, 4, 3);
			btclearMessages.Name = "btclearMessages";
			btclearMessages.Size = new Size(130, 28);
			btclearMessages.TabIndex = 14;
			btclearMessages.Text = "Limpar Conversa";
			btclearMessages.UseVisualStyleBackColor = false;
			btclearMessages.Click += clearMessage;
			// 
			// I_Cliente
			// 
			AutoScaleDimensions = new SizeF(8F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1013, 566);
			Controls.Add(btclearMessages);
			Controls.Add(label1);
			Controls.Add(inpUsuario);
			Controls.Add(btConectar);
			Controls.Add(inpPorta);
			Controls.Add(inpIP);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(lbStatus);
			Controls.Add(label2);
			Controls.Add(ipMessage);
			Controls.Add(btEnviar);
			Controls.Add(gpMensagens);
			Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ForeColor = SystemColors.ControlLight;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(4, 3, 4, 3);
			Name = "I_Cliente";
			Text = "APS";
			Load += Form1_Load;
			gpMensagens.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox gpMensagens;
		private Button btEnviar;
		private TextBox ipMessage;
		private Label label1;
		private Label label2;
		private Label lbStatus;
		private Label label3;
		private Label label4;
		private Label label5;
		private TextBox inpIP;
		private TextBox inpPorta;
		private Button btConectar;
		private TextBox inpUsuario;
		private Panel pnMensagens;
		private Button btclearMessages;
	}
}
