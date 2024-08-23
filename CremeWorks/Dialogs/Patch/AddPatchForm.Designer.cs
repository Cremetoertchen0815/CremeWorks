namespace CremeWorks.App.Dialogs.Patch;

partial class AddPatchForm
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
        txtName = new TextBox();
        cmbType = new ComboBox();
        button1 = new Button();
        label1 = new Label();
        label2 = new Label();
        SuspendLayout();
        // 
        // txtName
        // 
        txtName.Location = new Point(74, 12);
        txtName.Name = "txtName";
        txtName.Size = new Size(164, 23);
        txtName.TabIndex = 0;
        // 
        // cmbType
        // 
        cmbType.FormattingEnabled = true;
        cmbType.Items.AddRange(new object[] { "Yamaha Reface CS", "Yamaha Reface CP", "Yamaha Reface YC", "Program Change" });
        cmbType.Location = new Point(74, 41);
        cmbType.Name = "cmbType";
        cmbType.Size = new Size(164, 23);
        cmbType.TabIndex = 1;
        cmbType.Text = "Yamaha Reface CS";
        // 
        // button1
        // 
        button1.Location = new Point(162, 80);
        button1.Name = "button1";
        button1.Size = new Size(76, 34);
        button1.TabIndex = 2;
        button1.Text = "Add";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new Point(12, 12);
        label1.Name = "label1";
        label1.Size = new Size(56, 23);
        label1.TabIndex = 3;
        label1.Text = "Name:";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // label2
        // 
        label2.Location = new Point(12, 41);
        label2.Name = "label2";
        label2.Size = new Size(56, 23);
        label2.TabIndex = 4;
        label2.Text = "Type:";
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // AddPatchForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(250, 126);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(cmbType);
        Controls.Add(txtName);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddPatchForm";
        ShowIcon = false;
        Text = "Add Patch";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtName;
    private ComboBox cmbType;
    private Button button1;
    private Label label1;
    private Label label2;
}