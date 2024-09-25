namespace CremeWorks.App.Dialogs.Cloud;

partial class PublishDialog
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
        txtName = new TextBox();
        chkPublic = new CheckBox();
        btnOk = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new Point(12, 12);
        label1.Name = "label1";
        label1.Size = new Size(40, 23);
        label1.TabIndex = 0;
        label1.Text = "Name";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtName
        // 
        txtName.Location = new Point(58, 12);
        txtName.Name = "txtName";
        txtName.Size = new Size(213, 23);
        txtName.TabIndex = 1;
        // 
        // chkPublic
        // 
        chkPublic.AutoSize = true;
        chkPublic.Location = new Point(58, 52);
        chkPublic.Name = "chkPublic";
        chkPublic.Size = new Size(91, 19);
        chkPublic.TabIndex = 2;
        chkPublic.Text = "Make Public";
        chkPublic.UseVisualStyleBackColor = true;
        // 
        // btnOk
        // 
        btnOk.Location = new Point(196, 83);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(75, 39);
        btnOk.TabIndex = 3;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // PublishDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(283, 134);
        Controls.Add(btnOk);
        Controls.Add(chkPublic);
        Controls.Add(txtName);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PublishDialog";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Publish";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtName;
    private CheckBox chkPublic;
    private Button btnOk;
}