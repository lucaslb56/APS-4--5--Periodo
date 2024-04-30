namespace Cliente2;

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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "APSzap";
		// Adicionando um rótulo
		Label label1 = new Label
		{
			Text = "Nome:",
			Location = new System.Drawing.Point(20, 20)
			
		};
		this.Controls.Add(label1);

		// Adicionando uma caixa de texto
		TextBox textBox1 = new TextBox
		{
			Location = new System.Drawing.Point(100, 20),
			Size = new System.Drawing.Size(200, 20)
		};
		this.Controls.Add(textBox1);

		// Adicionando um botão
		Button button1 = new Button
		{
			Text = "Clique Aqui!",
			Location = new System.Drawing.Point(20, 50)
		};
		button1.Click += Button1_Click; // Adiciona um evento de clique ao botão
		this.Controls.Add(button1);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		MessageBox.Show("Você clicou no botão!");
	}

	#endregion
}
