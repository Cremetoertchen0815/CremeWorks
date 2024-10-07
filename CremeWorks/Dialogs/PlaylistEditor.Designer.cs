namespace CremeWorks.App.Dialogs;

partial class PlaylistEditor
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistEditor));
        btnMinus = new Button();
        btnPlus = new Button();
        boxSelector = new ComboBox();
        lblDevice = new Label();
        groupBox1 = new GroupBox();
        lstEntries = new ListView();
        columnNr = new ColumnHeader();
        columnTitle = new ColumnHeader();
        columnArtist = new ColumnHeader();
        columnType = new ColumnHeader();
        columnDuration = new ColumnHeader();
        panel2 = new Panel();
        label2 = new Label();
        lblDuration = new Label();
        btnDown = new Button();
        btnUp = new Button();
        btnAddMarker = new Button();
        btnDuplicate = new Button();
        btnDelete = new Button();
        btnEdit = new Button();
        btnAddSong = new Button();
        panel1 = new Panel();
        txtName = new TextBox();
        txtDate = new DateTimePicker();
        lblMidiDevice = new Label();
        lblName = new Label();
        groupBox1.SuspendLayout();
        panel2.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnMinus
        // 
        btnMinus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMinus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnMinus.Location = new Point(545, 8);
        btnMinus.Margin = new Padding(5, 5, 5, 5);
        btnMinus.Name = "btnMinus";
        btnMinus.Size = new Size(37, 31);
        btnMinus.TabIndex = 28;
        btnMinus.Text = "-";
        btnMinus.UseVisualStyleBackColor = true;
        btnMinus.Click += btnMinus_Click;
        // 
        // btnPlus
        // 
        btnPlus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPlus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnPlus.Location = new Point(506, 8);
        btnPlus.Margin = new Padding(5, 5, 5, 5);
        btnPlus.Name = "btnPlus";
        btnPlus.Size = new Size(37, 31);
        btnPlus.TabIndex = 27;
        btnPlus.Text = "+";
        btnPlus.UseVisualStyleBackColor = true;
        btnPlus.Click += btnPlus_Click;
        // 
        // boxSelector
        // 
        boxSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        boxSelector.FormattingEnabled = true;
        boxSelector.Location = new Point(74, 8);
        boxSelector.Margin = new Padding(5, 5, 5, 5);
        boxSelector.Name = "boxSelector";
        boxSelector.Size = new Size(422, 28);
        boxSelector.TabIndex = 26;
        boxSelector.SelectedIndexChanged += boxSelector_SelectedIndexChanged;
        // 
        // lblDevice
        // 
        lblDevice.AutoSize = true;
        lblDevice.Location = new Point(15, 12);
        lblDevice.Margin = new Padding(5, 0, 5, 0);
        lblDevice.Name = "lblDevice";
        lblDevice.Size = new Size(55, 20);
        lblDevice.TabIndex = 25;
        lblDevice.Text = "Playlist";
        lblDevice.TextAlign = ContentAlignment.TopRight;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox1.Controls.Add(lstEntries);
        groupBox1.Controls.Add(panel2);
        groupBox1.Controls.Add(panel1);
        groupBox1.Enabled = false;
        groupBox1.Location = new Point(74, 48);
        groupBox1.Margin = new Padding(3, 4, 3, 4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 4, 3, 4);
        groupBox1.Size = new Size(507, 568);
        groupBox1.TabIndex = 32;
        groupBox1.TabStop = false;
        groupBox1.Text = "Properties";
        // 
        // lstEntries
        // 
        lstEntries.AllowDrop = true;
        lstEntries.Columns.AddRange(new ColumnHeader[] { columnNr, columnTitle, columnArtist, columnType, columnDuration });
        lstEntries.Dock = DockStyle.Fill;
        lstEntries.FullRowSelect = true;
        lstEntries.Location = new Point(112, 104);
        lstEntries.Margin = new Padding(5, 4, 5, 4);
        lstEntries.MultiSelect = false;
        lstEntries.Name = "lstEntries";
        lstEntries.Size = new Size(392, 460);
        lstEntries.TabIndex = 36;
        lstEntries.UseCompatibleStateImageBehavior = false;
        lstEntries.View = View.Details;
        lstEntries.ItemDrag += lstEntries_ItemDrag;
        lstEntries.DragDrop += lstEntries_DragDrop;
        lstEntries.DragEnter += lstEntries_DragEnter;
        lstEntries.DragOver += lstEntries_DragOver;
        lstEntries.MouseDoubleClick += lstEntries_MouseDoubleClick;
        // 
        // columnNr
        // 
        columnNr.Text = "Nr";
        columnNr.Width = 25;
        // 
        // columnTitle
        // 
        columnTitle.Text = "Title";
        columnTitle.Width = 100;
        // 
        // columnArtist
        // 
        columnArtist.Text = "Artist";
        columnArtist.Width = 80;
        // 
        // columnType
        // 
        columnType.Text = "Type";
        // 
        // columnDuration
        // 
        columnDuration.Text = "Duration";
        columnDuration.Width = 74;
        // 
        // panel2
        // 
        panel2.Controls.Add(label2);
        panel2.Controls.Add(lblDuration);
        panel2.Controls.Add(btnDown);
        panel2.Controls.Add(btnUp);
        panel2.Controls.Add(btnAddMarker);
        panel2.Controls.Add(btnDuplicate);
        panel2.Controls.Add(btnDelete);
        panel2.Controls.Add(btnEdit);
        panel2.Controls.Add(btnAddSong);
        panel2.Dock = DockStyle.Left;
        panel2.Location = new Point(3, 104);
        panel2.Margin = new Padding(5, 4, 5, 4);
        panel2.Name = "panel2";
        panel2.Size = new Size(109, 460);
        panel2.TabIndex = 37;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        label2.Location = new Point(5, 400);
        label2.Name = "label2";
        label2.Size = new Size(98, 31);
        label2.TabIndex = 13;
        label2.Text = "Total duration:";
        label2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDuration
        // 
        lblDuration.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblDuration.Location = new Point(5, 428);
        lblDuration.Name = "lblDuration";
        lblDuration.Size = new Size(98, 31);
        lblDuration.TabIndex = 12;
        lblDuration.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnDown
        // 
        btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDown.Font = new Font("Segoe UI", 12F);
        btnDown.Location = new Point(5, 189);
        btnDown.Margin = new Padding(5, 4, 5, 4);
        btnDown.Name = "btnDown";
        btnDown.Size = new Size(98, 37);
        btnDown.TabIndex = 11;
        btnDown.Text = "↓";
        btnDown.UseVisualStyleBackColor = true;
        btnDown.Click += btnDown_Click;
        // 
        // btnUp
        // 
        btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnUp.Font = new Font("Segoe UI", 12F);
        btnUp.Location = new Point(5, 144);
        btnUp.Margin = new Padding(5, 4, 5, 4);
        btnUp.Name = "btnUp";
        btnUp.Size = new Size(98, 37);
        btnUp.TabIndex = 10;
        btnUp.Text = "↑";
        btnUp.UseVisualStyleBackColor = true;
        btnUp.Click += btnUp_Click;
        // 
        // btnAddMarker
        // 
        btnAddMarker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnAddMarker.Location = new Point(5, 53);
        btnAddMarker.Margin = new Padding(5, 4, 5, 4);
        btnAddMarker.Name = "btnAddMarker";
        btnAddMarker.Size = new Size(98, 37);
        btnAddMarker.TabIndex = 9;
        btnAddMarker.Text = "Add Marker";
        btnAddMarker.UseVisualStyleBackColor = true;
        btnAddMarker.Click += btnAddMarker_Click;
        // 
        // btnDuplicate
        // 
        btnDuplicate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDuplicate.Location = new Point(5, 235);
        btnDuplicate.Margin = new Padding(5, 4, 5, 4);
        btnDuplicate.Name = "btnDuplicate";
        btnDuplicate.Size = new Size(98, 37);
        btnDuplicate.TabIndex = 8;
        btnDuplicate.Text = "Duplicate";
        btnDuplicate.UseVisualStyleBackColor = true;
        btnDuplicate.Click += btnDuplicate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDelete.Location = new Point(5, 280);
        btnDelete.Margin = new Padding(5, 4, 5, 4);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(98, 37);
        btnDelete.TabIndex = 7;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnEdit
        // 
        btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnEdit.Location = new Point(5, 99);
        btnEdit.Margin = new Padding(5, 4, 5, 4);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(98, 37);
        btnEdit.TabIndex = 6;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = true;
        btnEdit.Click += btnEdit_Click;
        // 
        // btnAddSong
        // 
        btnAddSong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnAddSong.Location = new Point(5, 8);
        btnAddSong.Margin = new Padding(5, 4, 5, 4);
        btnAddSong.Name = "btnAddSong";
        btnAddSong.Size = new Size(98, 37);
        btnAddSong.TabIndex = 5;
        btnAddSong.Text = "Add Song";
        btnAddSong.UseVisualStyleBackColor = true;
        btnAddSong.Click += btnAddSong_Click;
        // 
        // panel1
        // 
        panel1.Controls.Add(txtName);
        panel1.Controls.Add(txtDate);
        panel1.Controls.Add(lblMidiDevice);
        panel1.Controls.Add(lblName);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(3, 24);
        panel1.Margin = new Padding(3, 4, 3, 4);
        panel1.Name = "panel1";
        panel1.Size = new Size(501, 80);
        panel1.TabIndex = 35;
        // 
        // txtName
        // 
        txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtName.Location = new Point(107, 0);
        txtName.Margin = new Padding(3, 4, 3, 4);
        txtName.Name = "txtName";
        txtName.Size = new Size(393, 27);
        txtName.TabIndex = 25;
        txtName.TextChanged += txtName_TextChanged;
        // 
        // txtDate
        // 
        txtDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtDate.Location = new Point(107, 40);
        txtDate.Margin = new Padding(3, 4, 3, 4);
        txtDate.Name = "txtDate";
        txtDate.Size = new Size(393, 27);
        txtDate.TabIndex = 28;
        txtDate.ValueChanged += txtDate_ValueChanged;
        // 
        // lblMidiDevice
        // 
        lblMidiDevice.Location = new Point(8, 40);
        lblMidiDevice.Margin = new Padding(5, 0, 5, 0);
        lblMidiDevice.Name = "lblMidiDevice";
        lblMidiDevice.Size = new Size(83, 31);
        lblMidiDevice.TabIndex = 2;
        lblMidiDevice.Text = "Date";
        lblMidiDevice.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblName
        // 
        lblName.Location = new Point(11, 0);
        lblName.Name = "lblName";
        lblName.Size = new Size(80, 31);
        lblName.TabIndex = 27;
        lblName.Text = "Name";
        lblName.TextAlign = ContentAlignment.MiddleRight;
        // 
        // PlaylistEditor
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(591, 632);
        Controls.Add(groupBox1);
        Controls.Add(btnMinus);
        Controls.Add(btnPlus);
        Controls.Add(boxSelector);
        Controls.Add(lblDevice);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        MaximumSize = new Size(609, 5318);
        MinimumSize = new Size(609, 544);
        Name = "PlaylistEditor";
        Text = "Playlists";
        FormClosing += PlaylistEditor_FormClosing;
        groupBox1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnMinus;
    private Button btnPlus;
    private ComboBox boxSelector;
    private Label lblDevice;
    private GroupBox groupBox1;
    private DateTimePicker txtDate;
    private TextBox txtName;
    private Label lblName;
    private Label lblMidiDevice;
    private Panel panel2;
    private Button btnDuplicate;
    private Button btnDelete;
    private Button btnEdit;
    private ListView lstEntries;
    private Panel panel1;
    private Button btnAddMarker;
    private Button btnAddSong;
    private Button btnUp;
    private Button btnDown;
    private ColumnHeader columnNr;
    private ColumnHeader columnTitle;
    private ColumnHeader columnArtist;
    private ColumnHeader columnType;
    private ColumnHeader columnDuration;
    private Label label2;
    private Label lblDuration;
}