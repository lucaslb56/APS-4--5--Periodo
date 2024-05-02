namespace Cliente2
{
	partial class Form1
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
			groupBox1 = new GroupBox();
			panel1 = new Panel();
			btEnviar = new Button();
			textBox1 = new TextBox();
			label2 = new Label();
			lbStatus = new Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.Control;
			groupBox1.Controls.Add(panel1);
			groupBox1.Location = new Point(391, 12);
			groupBox1.Margin = new Padding(4, 3, 4, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 3, 4, 3);
			groupBox1.Size = new Size(609, 542);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Mensagens";
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.Enabled = false;
			panel1.Location = new Point(7, 26);
			panel1.Name = "panel1";
			panel1.Size = new Size(595, 510);
			panel1.TabIndex = 0;
			panel1.UseWaitCursor = true;
			// 
			// btEnviar
			// 
			btEnviar.BackColor = SystemColors.ActiveCaption;
			btEnviar.FlatStyle = FlatStyle.System;
			btEnviar.Location = new Point(253, 495);
			btEnviar.Margin = new Padding(4, 3, 4, 3);
			btEnviar.Name = "btEnviar";
			btEnviar.Size = new Size(130, 30);
			btEnviar.TabIndex = 1;
			btEnviar.Text = "Enviar";
			btEnviar.UseVisualStyleBackColor = false;
			btEnviar.Click += btEnviar_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(4, 495);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = ScrollBars.Horizontal;
			textBox1.Size = new Size(242, 56);
			textBox1.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = SystemColors.ActiveCaptionText;
			label2.Location = new Point(4, 38);
			label2.Name = "label2";
			label2.Size = new Size(60, 19);
			label2.TabIndex = 3;
			label2.Text = "Status:";
			// 
			// lbStatus
			// 
			lbStatus.ForeColor = Color.FromArgb(192, 0, 0);
			lbStatus.Location = new Point(58, 38);
			lbStatus.Name = "lbStatus";
			lbStatus.Size = new Size(320, 200);
			lbStatus.TabIndex = 4;
			lbStatus.Text = "Desconectado";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(1013, 566);
			Controls.Add(lbStatus);
			Controls.Add(label2);
			Controls.Add(textBox1);
			Controls.Add(btEnviar);
			Controls.Add(groupBox1);
			Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ForeColor = SystemColors.ControlLight;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(4, 3, 4, 3);
			Name = "Form1";
			Text = "APSzap";
			Load += Form1_Load;
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
		private Button btEnviar;
		private TextBox textBox1;
		private Panel panel1;
		private Label label1;
		private Label label2;
		private Label lbStatus;
	}
}
