namespace CremeWorks.App.Dialogs;

partial class ConcertImportDialog
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
        chkActions = new CheckBox();
        chkPlaylist = new CheckBox();
        txtPlaylist = new TextBox();
        label1 = new Label();
        lstSongs = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        label2 = new Label();
        boxDoubles = new ComboBox();
        label3 = new Label();
        boxRouting = new ComboBox();
        label4 = new Label();
        boxPatches = new ComboBox();
        label6 = new Label();
        btnOk = new Button();
        SuspendLayout();
        // 
        // chkActions
        // 
        chkActions.AutoSize = true;
        chkActions.Checked = true;
        chkActions.CheckState = CheckState.Checked;
        chkActions.Location = new Point(12, 12);
        chkActions.Name = "chkActions";
        chkActions.Size = new Size(105, 19);
        chkActions.TabIndex = 1;
        chkActions.Text = "Import Actions";
        chkActions.UseVisualStyleBackColor = true;
        // 
        // chkPlaylist
        // 
        chkPlaylist.AutoSize = true;
        chkPlaylist.Checked = true;
        chkPlaylist.CheckState = CheckState.Checked;
        chkPlaylist.Location = new Point(12, 37);
        chkPlaylist.Name = "chkPlaylist";
        chkPlaylist.Size = new Size(100, 19);
        chkPlaylist.TabIndex = 2;
        chkPlaylist.Text = "Create Playlist";
        chkPlaylist.UseVisualStyleBackColor = true;
        // 
        // txtPlaylist
        // 
        txtPlaylist.Location = new Point(118, 35);
        txtPlaylist.Name = "txtPlaylist";
        txtPlaylist.Size = new Size(228, 23);
        txtPlaylist.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 73);
        label1.Name = "label1";
        label1.Size = new Size(42, 15);
        label1.TabIndex = 4;
        label1.Text = "Songs:";
        // 
        // lstSongs
        // 
        lstSongs.CheckBoxes = true;
        lstSongs.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
        lstSongs.FullRowSelect = true;
        lstSongs.Location = new Point(12, 91);
        lstSongs.Name = "lstSongs";
        lstSongs.Size = new Size(334, 237);
        lstSongs.TabIndex = 5;
        lstSongs.UseCompatibleStateImageBehavior = false;
        lstSongs.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "Title";
        columnHeader1.Width = 120;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Artist";
        columnHeader2.Width = 100;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "Existing Double";
        columnHeader3.Width = 100;
        // 
        // label2
        // 
        label2.Location = new Point(12, 345);
        label2.Name = "label2";
        label2.Size = new Size(112, 23);
        label2.TabIndex = 6;
        label2.Text = "Action for doubles:";
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // boxDoubles
        // 
        boxDoubles.FormattingEnabled = true;
        boxDoubles.Items.AddRange(new object[] { "Keep both songs", "Keep existing", "Keep new song" });
        boxDoubles.Location = new Point(130, 345);
        boxDoubles.Name = "boxDoubles";
        boxDoubles.Size = new Size(216, 23);
        boxDoubles.TabIndex = 7;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(190, 73);
        label3.Name = "label3";
        label3.Size = new Size(156, 15);
        label3.TabIndex = 8;
        label3.Text = "(double click to edit double)";
        // 
        // boxRouting
        // 
        boxRouting.FormattingEnabled = true;
        boxRouting.Items.AddRange(new object[] { "Don't change", "Create loopback for new devices", "Recalculate(by majority)" });
        boxRouting.Location = new Point(130, 374);
        boxRouting.Name = "boxRouting";
        boxRouting.Size = new Size(216, 23);
        boxRouting.TabIndex = 10;
        // 
        // label4
        // 
        label4.Location = new Point(12, 374);
        label4.Name = "label4";
        label4.Size = new Size(112, 23);
        label4.TabIndex = 9;
        label4.Text = "Default routing:";
        label4.TextAlign = ContentAlignment.MiddleRight;
        // 
        // boxPatches
        // 
        boxPatches.FormattingEnabled = true;
        boxPatches.Items.AddRange(new object[] { "Always create new", "Reuse equal patches" });
        boxPatches.Location = new Point(130, 403);
        boxPatches.Name = "boxPatches";
        boxPatches.Size = new Size(216, 23);
        boxPatches.TabIndex = 13;
        // 
        // label6
        // 
        label6.Location = new Point(12, 403);
        label6.Name = "label6";
        label6.Size = new Size(112, 23);
        label6.TabIndex = 12;
        label6.Text = "Reuse patches:";
        label6.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnOk
        // 
        btnOk.Location = new Point(271, 445);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(75, 34);
        btnOk.TabIndex = 14;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // ImportDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(358, 491);
        Controls.Add(btnOk);
        Controls.Add(boxPatches);
        Controls.Add(label6);
        Controls.Add(boxRouting);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(boxDoubles);
        Controls.Add(label2);
        Controls.Add(lstSongs);
        Controls.Add(label1);
        Controls.Add(txtPlaylist);
        Controls.Add(chkPlaylist);
        Controls.Add(chkActions);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ImportDialog";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Import";
        FormClosing += ImportDialog_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private CheckBox chkActions;
    private CheckBox chkPlaylist;
    private TextBox txtPlaylist;
    private Label label1;
    private ListView lstSongs;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private Label label2;
    private ComboBox boxDoubles;
    private Label label3;
    private ComboBox boxRouting;
    private Label label4;
    private ComboBox boxPatches;
    private Label label6;
    private Button btnOk;
}