namespace CremeWorks.App.Dialogs.SoloMode;

partial class SoloDeviceAdd
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
        button1 = new Button();
        boxDevices = new ComboBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new Point(12, 12);
        label1.Name = "label1";
        label1.Size = new Size(51, 23);
        label1.TabIndex = 0;
        label1.Text = "Device:";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // button1
        // 
        button1.Location = new Point(168, 60);
        button1.Name = "button1";
        button1.Size = new Size(75, 28);
        button1.TabIndex = 2;
        button1.Text = "OK";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // boxDevices
        // 
        boxDevices.FormattingEnabled = true;
        boxDevices.Location = new Point(69, 12);
        boxDevices.Name = "boxDevices";
        boxDevices.Size = new Size(174, 23);
        boxDevices.TabIndex = 3;
        // 
        // SoloDeviceAdd
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(255, 100);
        Controls.Add(boxDevices);
        Controls.Add(button1);
        Controls.Add(label1);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SoloDeviceAdd";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Device";
        ResumeLayout(false);
    }

    #endregion

    private Label label1;
    private Button button1;
    private ComboBox boxDevices;
}