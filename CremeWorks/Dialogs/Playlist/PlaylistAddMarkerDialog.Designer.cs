namespace CremeWorks.App.Dialogs.Playlist;

partial class PlaylistAddMarkerDialog
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
        btnCancel = new Button();
        btnOk = new Button();
        btnCueDuplicate = new Button();
        btnCueRemove = new Button();
        btnCueEdit = new Button();
        btnCueAdd = new Button();
        label5 = new Label();
        lstCues = new ListBox();
        txtInstructions = new TextBox();
        label35 = new Label();
        txtTitle = new TextBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(258, 454);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(77, 39);
        btnCancel.TabIndex = 36;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.Location = new Point(341, 454);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(77, 39);
        btnOk.TabIndex = 35;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCueDuplicate
        // 
        btnCueDuplicate.Location = new Point(258, 376);
        btnCueDuplicate.Name = "btnCueDuplicate";
        btnCueDuplicate.Size = new Size(77, 39);
        btnCueDuplicate.TabIndex = 169;
        btnCueDuplicate.Text = "Duplicate";
        btnCueDuplicate.UseVisualStyleBackColor = true;
        btnCueDuplicate.Click += btnCueDuplicate_Click;
        // 
        // btnCueRemove
        // 
        btnCueRemove.Location = new Point(341, 376);
        btnCueRemove.Name = "btnCueRemove";
        btnCueRemove.Size = new Size(77, 39);
        btnCueRemove.TabIndex = 168;
        btnCueRemove.Text = "Remove";
        btnCueRemove.UseVisualStyleBackColor = true;
        btnCueRemove.Click += btnCueRemove_Click;
        // 
        // btnCueEdit
        // 
        btnCueEdit.Location = new Point(175, 376);
        btnCueEdit.Name = "btnCueEdit";
        btnCueEdit.Size = new Size(77, 39);
        btnCueEdit.TabIndex = 167;
        btnCueEdit.Text = "Edit";
        btnCueEdit.UseVisualStyleBackColor = true;
        btnCueEdit.Click += btnCueEdit_Click;
        // 
        // btnCueAdd
        // 
        btnCueAdd.Location = new Point(91, 376);
        btnCueAdd.Name = "btnCueAdd";
        btnCueAdd.Size = new Size(78, 39);
        btnCueAdd.TabIndex = 166;
        btnCueAdd.Text = "Add";
        btnCueAdd.UseVisualStyleBackColor = true;
        btnCueAdd.Click += btnCueAdd_Click;
        // 
        // label5
        // 
        label5.Location = new Point(14, 173);
        label5.Margin = new Padding(4, 0, 4, 0);
        label5.Name = "label5";
        label5.Size = new Size(70, 23);
        label5.TabIndex = 165;
        label5.Text = "Cues";
        label5.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lstCues
        // 
        lstCues.FormattingEnabled = true;
        lstCues.ItemHeight = 15;
        lstCues.Location = new Point(91, 171);
        lstCues.Name = "lstCues";
        lstCues.Size = new Size(328, 199);
        lstCues.TabIndex = 164;
        lstCues.MouseDoubleClick += lstCues_MouseDoubleClick;
        // 
        // txtInstructions
        // 
        txtInstructions.Location = new Point(91, 40);
        txtInstructions.Margin = new Padding(4);
        txtInstructions.Multiline = true;
        txtInstructions.Name = "txtInstructions";
        txtInstructions.ScrollBars = ScrollBars.Vertical;
        txtInstructions.Size = new Size(328, 124);
        txtInstructions.TabIndex = 163;
        // 
        // label35
        // 
        label35.Location = new Point(13, 40);
        label35.Margin = new Padding(4, 0, 4, 0);
        label35.Name = "label35";
        label35.Size = new Size(70, 23);
        label35.TabIndex = 162;
        label35.Text = "Instructions";
        label35.TextAlign = ContentAlignment.MiddleRight;
        // 
        // txtTitle
        // 
        txtTitle.Location = new Point(91, 9);
        txtTitle.Margin = new Padding(4);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(328, 23);
        txtTitle.TabIndex = 154;
        txtTitle.Text = "Name";
        // 
        // label1
        // 
        label1.Location = new Point(13, 9);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(70, 23);
        label1.TabIndex = 151;
        label1.Text = "Title";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // PlaylistAddMarkerDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(431, 505);
        Controls.Add(btnCueDuplicate);
        Controls.Add(btnCueRemove);
        Controls.Add(btnCueEdit);
        Controls.Add(btnCueAdd);
        Controls.Add(label5);
        Controls.Add(lstCues);
        Controls.Add(txtInstructions);
        Controls.Add(label35);
        Controls.Add(txtTitle);
        Controls.Add(label1);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PlaylistAddMarkerDialog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Add Marker";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnCancel;
    private Button btnOk;
    private Button btnCueDuplicate;
    private Button btnCueRemove;
    private Button btnCueEdit;
    private Button btnCueAdd;
    private Label label5;
    private ListBox lstCues;
    private TextBox txtInstructions;
    private Label label35;
    private TextBox txtTitle;
    private Label label1;
}