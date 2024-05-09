namespace CremeWorks.Client;

partial class Disconnected
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
        SuspendLayout();
        // 
        // label1
        // 
        label1.Dock = DockStyle.Fill;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(258, 95);
        label1.TabIndex = 0;
        label1.Text = "Server disconnected!\r\nTrying to reconnect...";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Disconnected
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(258, 95);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Disconnected";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Disconnected";
        Load += Disconnected_Load;
        ResumeLayout(false);
    }

    #endregion

    private Label label1;
}