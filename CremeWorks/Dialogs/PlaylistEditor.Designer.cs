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
        btnCancel = new Button();
        btnOk = new Button();
        groupBox1 = new GroupBox();
        lstSongs = new ListView();
        ArtistColumn = new ColumnHeader();
        TitleColumn = new ColumnHeader();
        IdColumn = new ColumnHeader();
        panel2 = new Panel();
        button5 = new Button();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        btnDuplicate = new Button();
        btnDelete = new Button();
        btnEdit = new Button();
        btnCreate = new Button();
        panel1 = new Panel();
        txtName = new TextBox();
        dateTimePicker1 = new DateTimePicker();
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
        btnMinus.Location = new Point(477, 6);
        btnMinus.Margin = new Padding(4);
        btnMinus.Name = "btnMinus";
        btnMinus.Size = new Size(32, 23);
        btnMinus.TabIndex = 28;
        btnMinus.Text = "-";
        btnMinus.UseVisualStyleBackColor = true;
        // 
        // btnPlus
        // 
        btnPlus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPlus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnPlus.Location = new Point(443, 6);
        btnPlus.Margin = new Padding(4);
        btnPlus.Name = "btnPlus";
        btnPlus.Size = new Size(32, 23);
        btnPlus.TabIndex = 27;
        btnPlus.Text = "+";
        btnPlus.UseVisualStyleBackColor = true;
        // 
        // boxSelector
        // 
        boxSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        boxSelector.FormattingEnabled = true;
        boxSelector.Location = new Point(65, 6);
        boxSelector.Margin = new Padding(4);
        boxSelector.Name = "boxSelector";
        boxSelector.Size = new Size(370, 23);
        boxSelector.TabIndex = 26;
        // 
        // lblDevice
        // 
        lblDevice.AutoSize = true;
        lblDevice.Location = new Point(13, 9);
        lblDevice.Margin = new Padding(4, 0, 4, 0);
        lblDevice.Name = "lblDevice";
        lblDevice.Size = new Size(44, 15);
        lblDevice.TabIndex = 25;
        lblDevice.Text = "Playlist";
        lblDevice.TextAlign = ContentAlignment.TopRight;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(366, 416);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(66, 40);
        btnCancel.TabIndex = 34;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.Location = new Point(440, 416);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(66, 40);
        btnOk.TabIndex = 33;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox1.Controls.Add(lstSongs);
        groupBox1.Controls.Add(panel2);
        groupBox1.Controls.Add(panel1);
        groupBox1.Enabled = false;
        groupBox1.Location = new Point(65, 36);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(444, 374);
        groupBox1.TabIndex = 32;
        groupBox1.TabStop = false;
        groupBox1.Text = "Properties";
        // 
        // lstSongs
        // 
        lstSongs.AllowColumnReorder = true;
        lstSongs.Columns.AddRange(new ColumnHeader[] { ArtistColumn, TitleColumn, IdColumn });
        lstSongs.Dock = DockStyle.Fill;
        lstSongs.FullRowSelect = true;
        lstSongs.Location = new Point(98, 79);
        lstSongs.Margin = new Padding(4, 3, 4, 3);
        lstSongs.MultiSelect = false;
        lstSongs.Name = "lstSongs";
        lstSongs.Size = new Size(343, 292);
        lstSongs.Sorting = SortOrder.Ascending;
        lstSongs.TabIndex = 36;
        lstSongs.UseCompatibleStateImageBehavior = false;
        lstSongs.View = View.Details;
        // 
        // ArtistColumn
        // 
        ArtistColumn.DisplayIndex = 1;
        ArtistColumn.Text = "Artist";
        ArtistColumn.Width = 100;
        // 
        // TitleColumn
        // 
        TitleColumn.DisplayIndex = 0;
        TitleColumn.Text = "Title";
        TitleColumn.Width = 100;
        // 
        // IdColumn
        // 
        IdColumn.Text = "Id";
        IdColumn.Width = 100;
        // 
        // panel2
        // 
        panel2.Controls.Add(button5);
        panel2.Controls.Add(button1);
        panel2.Controls.Add(button2);
        panel2.Controls.Add(button3);
        panel2.Controls.Add(button4);
        panel2.Controls.Add(btnDuplicate);
        panel2.Controls.Add(btnDelete);
        panel2.Controls.Add(btnEdit);
        panel2.Controls.Add(btnCreate);
        panel2.Dock = DockStyle.Left;
        panel2.Location = new Point(3, 79);
        panel2.Margin = new Padding(4, 3, 4, 3);
        panel2.Name = "panel2";
        panel2.Size = new Size(95, 292);
        panel2.TabIndex = 37;
        // 
        // button5
        // 
        button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button5.Location = new Point(4, 63);
        button5.Margin = new Padding(4, 3, 4, 3);
        button5.Name = "button5";
        button5.Size = new Size(86, 51);
        button5.TabIndex = 9;
        button5.Text = "Add Marker";
        button5.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button1.Location = new Point(5, 177);
        button1.Margin = new Padding(4, 3, 4, 3);
        button1.Name = "button1";
        button1.Size = new Size(86, 51);
        button1.TabIndex = 8;
        button1.Text = "Duplicate";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button2.Location = new Point(5, 234);
        button2.Margin = new Padding(4, 3, 4, 3);
        button2.Name = "button2";
        button2.Size = new Size(86, 51);
        button2.TabIndex = 7;
        button2.Text = "Delete";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button3.Location = new Point(5, 120);
        button3.Margin = new Padding(4, 3, 4, 3);
        button3.Name = "button3";
        button3.Size = new Size(86, 51);
        button3.TabIndex = 6;
        button3.Text = "Edit";
        button3.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        button4.Location = new Point(4, 6);
        button4.Margin = new Padding(4, 3, 4, 3);
        button4.Name = "button4";
        button4.Size = new Size(86, 51);
        button4.TabIndex = 5;
        button4.Text = "Add Song";
        button4.UseVisualStyleBackColor = true;
        // 
        // btnDuplicate
        // 
        btnDuplicate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDuplicate.Location = new Point(4, 118);
        btnDuplicate.Margin = new Padding(4, 3, 4, 3);
        btnDuplicate.Name = "btnDuplicate";
        btnDuplicate.Size = new Size(2, 51);
        btnDuplicate.TabIndex = 4;
        btnDuplicate.Text = "Duplicate";
        btnDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnDelete.Location = new Point(4, 175);
        btnDelete.Margin = new Padding(4, 3, 4, 3);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(2, 51);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // btnEdit
        // 
        btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnEdit.Location = new Point(4, 61);
        btnEdit.Margin = new Padding(4, 3, 4, 3);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(2, 51);
        btnEdit.TabIndex = 1;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = true;
        // 
        // btnCreate
        // 
        btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnCreate.Location = new Point(4, 3);
        btnCreate.Margin = new Padding(4, 3, 4, 3);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(2, 51);
        btnCreate.TabIndex = 0;
        btnCreate.Text = "Create";
        btnCreate.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        panel1.Controls.Add(txtName);
        panel1.Controls.Add(dateTimePicker1);
        panel1.Controls.Add(lblMidiDevice);
        panel1.Controls.Add(lblName);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(3, 19);
        panel1.Name = "panel1";
        panel1.Size = new Size(438, 60);
        panel1.TabIndex = 35;
        // 
        // txtName
        // 
        txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtName.Location = new Point(94, 0);
        txtName.Name = "txtName";
        txtName.Size = new Size(341, 23);
        txtName.TabIndex = 25;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dateTimePicker1.Location = new Point(94, 30);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(341, 23);
        dateTimePicker1.TabIndex = 28;
        // 
        // lblMidiDevice
        // 
        lblMidiDevice.Location = new Point(7, 30);
        lblMidiDevice.Margin = new Padding(4, 0, 4, 0);
        lblMidiDevice.Name = "lblMidiDevice";
        lblMidiDevice.Size = new Size(73, 23);
        lblMidiDevice.TabIndex = 2;
        lblMidiDevice.Text = "Date";
        lblMidiDevice.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblName
        // 
        lblName.Location = new Point(10, 0);
        lblName.Name = "lblName";
        lblName.Size = new Size(70, 23);
        lblName.TabIndex = 27;
        lblName.Text = "Name";
        lblName.TextAlign = ContentAlignment.MiddleRight;
        // 
        // PlaylistEditor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(519, 468);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(groupBox1);
        Controls.Add(btnMinus);
        Controls.Add(btnPlus);
        Controls.Add(boxSelector);
        Controls.Add(lblDevice);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximumSize = new Size(535, 4000);
        MinimumSize = new Size(535, 507);
        Name = "PlaylistEditor";
        Text = "Playlists";
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
    private Button btnCancel;
    private Button btnOk;
    private GroupBox groupBox1;
    private DateTimePicker dateTimePicker1;
    private TextBox txtName;
    private Label lblName;
    private Label lblMidiDevice;
    private Panel panel2;
    private Button btnDuplicate;
    private Button btnDelete;
    private Button btnEdit;
    private Button btnCreate;
    private ListView lstSongs;
    private ColumnHeader ArtistColumn;
    private ColumnHeader TitleColumn;
    private ColumnHeader IdColumn;
    private Panel panel1;
    private Button button5;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
}