namespace CremeWorks.App.Dialogs.Cloud;

partial class CloneDialog
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
        listView1 = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        btnOk = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(146, 15);
        label1.TabIndex = 0;
        label1.Text = "Select a database to clone:";
        // 
        // listView1
        // 
        listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
        listView1.Location = new Point(12, 27);
        listView1.Name = "listView1";
        listView1.Size = new Size(354, 302);
        listView1.TabIndex = 1;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "Name";
        columnHeader1.Width = 100;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Owner";
        columnHeader2.Width = 100;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "Public";
        columnHeader3.Width = 50;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "Last Edited";
        columnHeader4.Width = 100;
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.Location = new Point(281, 335);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(85, 48);
        btnOk.TabIndex = 2;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // CloneDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(378, 395);
        Controls.Add(btnOk);
        Controls.Add(listView1);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CloneDialog";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Clone Database";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private ListView listView1;
    private Button btnOk;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
}