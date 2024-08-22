namespace CremeWorks.App.Dialogs.Playlist;

partial class PlaylistAddSongDialog
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
        boxSelector = new ComboBox();
        lblDevice = new Label();
        btnCancel = new Button();
        btnOk = new Button();
        SuspendLayout();
        // 
        // boxSelector
        // 
        boxSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        boxSelector.FormattingEnabled = true;
        boxSelector.Location = new Point(64, 13);
        boxSelector.Margin = new Padding(4);
        boxSelector.Name = "boxSelector";
        boxSelector.Size = new Size(322, 23);
        boxSelector.TabIndex = 28;
        // 
        // lblDevice
        // 
        lblDevice.Location = new Point(13, 13);
        lblDevice.Margin = new Padding(4, 0, 4, 0);
        lblDevice.Name = "lblDevice";
        lblDevice.Size = new Size(43, 23);
        lblDevice.TabIndex = 27;
        lblDevice.Text = "Song:";
        lblDevice.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(246, 51);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(66, 26);
        btnCancel.TabIndex = 36;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.Location = new Point(320, 51);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(66, 26);
        btnOk.TabIndex = 35;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // PlaylistAddSongDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(399, 89);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(boxSelector);
        Controls.Add(lblDevice);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PlaylistAddSongDialog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Select Song";
        ResumeLayout(false);
    }

    #endregion

    private ComboBox boxSelector;
    private Label lblDevice;
    private Button btnCancel;
    private Button btnOk;
}