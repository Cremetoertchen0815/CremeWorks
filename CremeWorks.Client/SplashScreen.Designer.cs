namespace CremeWorks.Client;

partial class SplashScreen
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
        label1 = new Label();
        pictureBox1 = new PictureBox();
        lblStatus = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.Font = new Font("Comic Sans MS", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.Red;
        label1.Location = new Point(389, 118);
        label1.Name = "label1";
        label1.Size = new Size(316, 134);
        label1.TabIndex = 0;
        label1.Text = "CremeWorks\r\nClient v1.0";
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = Color.Transparent;
        pictureBox1.Image = Properties.Resources.CremeWorks;
        pictureBox1.Location = new Point(498, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(100, 103);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
        // 
        // lblStatus
        // 
        lblStatus.BackColor = Color.Transparent;
        lblStatus.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStatus.ForeColor = Color.Red;
        lblStatus.Location = new Point(281, 357);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(412, 31);
        lblStatus.TabIndex = 2;
        lblStatus.TextAlign = ContentAlignment.TopRight;
        // 
        // SplashScreen
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.Momentaufnahme___17;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(705, 397);
        Controls.Add(lblStatus);
        Controls.Add(pictureBox1);
        Controls.Add(label1);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        Name = "SplashScreen";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SplashScreen";
        Shown += SplashScreen_Shown;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private PictureBox pictureBox1;
    private Label lblStatus;
}