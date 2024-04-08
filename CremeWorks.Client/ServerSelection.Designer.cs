namespace CremeWorks.Client;

partial class ServerSelection
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        listBox1 = new ListBox();
        panel1 = new Panel();
        button1 = new Button();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.Dock = DockStyle.Fill;
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new Point(0, 0);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(281, 331);
        listBox1.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Controls.Add(button1);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 293);
        panel1.Name = "panel1";
        panel1.Size = new Size(281, 38);
        panel1.TabIndex = 1;
        // 
        // button1
        // 
        button1.Dock = DockStyle.Right;
        button1.Location = new Point(169, 0);
        button1.Name = "button1";
        button1.Size = new Size(112, 38);
        button1.TabIndex = 0;
        button1.Text = "OK";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // ServerSelection
        // 
        AcceptButton = button1;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(281, 331);
        Controls.Add(panel1);
        Controls.Add(listBox1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ServerSelection";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Select Server";
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private Panel panel1;
    private Button button1;
}