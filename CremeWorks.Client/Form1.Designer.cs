
namespace CremeWorks.Client;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        lstSet = new ReadOnlyListBox();
        lstChat = new ListBox();
        label2 = new Label();
        txtChat = new TextBox();
        btnChat = new Button();
        groupBox1 = new BorderedGroupBox();
        groupBox2 = new BorderedGroupBox();
        lblNextCue = new Label();
        label5 = new Label();
        pnlClick = new Panel();
        lblInstructions = new TextBox();
        lblTempo = new Label();
        lblCurrCue = new Label();
        label6 = new Label();
        label3 = new Label();
        lblTitle = new Label();
        setBox = new BorderedGroupBox();
        lblSetName = new Label();
        label4 = new Label();
        tableLayoutPanel1 = new TableLayoutPanel();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        setBox.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // lstSet
        // 
        lstSet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstSet.BackColor = Color.FromArgb(48, 48, 48);
        lstSet.Font = new Font("Segoe UI", 18F);
        lstSet.ForeColor = Color.White;
        lstSet.FormattingEnabled = true;
        lstSet.IntegralHeight = false;
        lstSet.ItemHeight = 41;
        lstSet.Location = new Point(13, 85);
        lstSet.Name = "lstSet";
        lstSet.ReadOnly = true;
        lstSet.Size = new Size(449, 837);
        lstSet.TabIndex = 0;
        // 
        // lstChat
        // 
        lstChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstChat.BackColor = Color.FromArgb(48, 48, 48);
        lstChat.Font = new Font("Segoe UI", 18F);
        lstChat.ForeColor = Color.White;
        lstChat.FormattingEnabled = true;
        lstChat.IntegralHeight = false;
        lstChat.ItemHeight = 41;
        lstChat.Location = new Point(13, 33);
        lstChat.Name = "lstChat";
        lstChat.Size = new Size(646, 344);
        lstChat.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 18F);
        label2.ForeColor = Color.White;
        label2.Location = new Point(13, 85);
        label2.Name = "label2";
        label2.Size = new Size(116, 41);
        label2.TabIndex = 3;
        label2.Text = "Tempo:";
        // 
        // txtChat
        // 
        txtChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtChat.BackColor = Color.Black;
        txtChat.Font = new Font("Segoe UI", 18F);
        txtChat.ForeColor = Color.White;
        txtChat.Location = new Point(14, 405);
        txtChat.Name = "txtChat";
        txtChat.Size = new Size(514, 47);
        txtChat.TabIndex = 4;
        // 
        // btnChat
        // 
        btnChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnChat.BackColor = Color.FromArgb(64, 64, 64);
        btnChat.Font = new Font("Segoe UI", 18F);
        btnChat.ForeColor = Color.White;
        btnChat.Location = new Point(535, 405);
        btnChat.Name = "btnChat";
        btnChat.Size = new Size(123, 52);
        btnChat.TabIndex = 5;
        btnChat.Text = "Send";
        btnChat.UseVisualStyleBackColor = false;
        btnChat.Click += btnChat_Click;
        // 
        // groupBox1
        // 
        groupBox1.BorderColor = Color.Navy;
        groupBox1.BorderRadius = 8;
        groupBox1.BorderWidth = 2;
        groupBox1.Controls.Add(lstChat);
        groupBox1.Controls.Add(btnChat);
        groupBox1.Controls.Add(txtChat);
        groupBox1.Dock = DockStyle.Fill;
        groupBox1.ForeColor = Color.FromArgb(128, 128, 255);
        groupBox1.LabelIndent = 10;
        groupBox1.Location = new Point(490, 470);
        groupBox1.Margin = new Padding(5);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(10, 11, 10, 11);
        groupBox1.Size = new Size(672, 466);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Chat";
        // 
        // groupBox2
        // 
        groupBox2.BackColor = Color.Black;
        groupBox2.BorderColor = Color.Navy;
        groupBox2.BorderRadius = 8;
        groupBox2.BorderWidth = 2;
        groupBox2.Controls.Add(lblNextCue);
        groupBox2.Controls.Add(label5);
        groupBox2.Controls.Add(pnlClick);
        groupBox2.Controls.Add(lblInstructions);
        groupBox2.Controls.Add(lblTempo);
        groupBox2.Controls.Add(lblCurrCue);
        groupBox2.Controls.Add(label6);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(lblTitle);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.ForeColor = Color.FromArgb(128, 128, 255);
        groupBox2.LabelIndent = 10;
        groupBox2.Location = new Point(490, 5);
        groupBox2.Margin = new Padding(5);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(10, 11, 10, 11);
        groupBox2.Size = new Size(672, 455);
        groupBox2.TabIndex = 7;
        groupBox2.TabStop = false;
        groupBox2.Text = "Current Song";
        // 
        // lblNextCue
        // 
        lblNextCue.AutoSize = true;
        lblNextCue.Font = new Font("Segoe UI", 18F);
        lblNextCue.ForeColor = Color.White;
        lblNextCue.Location = new Point(190, 172);
        lblNextCue.Name = "lblNextCue";
        lblNextCue.Size = new Size(109, 41);
        lblNextCue.TabIndex = 12;
        lblNextCue.Text = "Refrain";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 18F);
        label5.ForeColor = Color.White;
        label5.Location = new Point(13, 216);
        label5.Name = "label5";
        label5.Size = new Size(179, 41);
        label5.TabIndex = 11;
        label5.Text = "Instructions:";
        // 
        // pnlClick
        // 
        pnlClick.BackColor = Color.White;
        pnlClick.BorderStyle = BorderStyle.FixedSingle;
        pnlClick.Location = new Point(321, 96);
        pnlClick.Name = "pnlClick";
        pnlClick.Size = new Size(20, 23);
        pnlClick.TabIndex = 10;
        // 
        // lblInstructions
        // 
        lblInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblInstructions.BackColor = Color.FromArgb(48, 48, 48);
        lblInstructions.Font = new Font("Segoe UI", 18F);
        lblInstructions.ForeColor = Color.White;
        lblInstructions.Location = new Point(198, 231);
        lblInstructions.Multiline = true;
        lblInstructions.Name = "lblInstructions";
        lblInstructions.ReadOnly = true;
        lblInstructions.Size = new Size(461, 209);
        lblInstructions.TabIndex = 9;
        lblInstructions.TextChanged += lblInstructions_TextChanged;
        // 
        // lblTempo
        // 
        lblTempo.AutoSize = true;
        lblTempo.Font = new Font("Segoe UI", 18F);
        lblTempo.ForeColor = Color.White;
        lblTempo.Location = new Point(190, 85);
        lblTempo.Name = "lblTempo";
        lblTempo.Size = new Size(135, 41);
        lblTempo.TabIndex = 8;
        lblTempo.Text = "120 BPM";
        // 
        // lblCurrCue
        // 
        lblCurrCue.AutoSize = true;
        lblCurrCue.Font = new Font("Segoe UI", 18F);
        lblCurrCue.ForeColor = Color.White;
        lblCurrCue.Location = new Point(190, 128);
        lblCurrCue.Name = "lblCurrCue";
        lblCurrCue.Size = new Size(122, 41);
        lblCurrCue.TabIndex = 7;
        lblCurrCue.Text = "Strophe";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI", 18F);
        label6.ForeColor = Color.White;
        label6.Location = new Point(13, 172);
        label6.Name = "label6";
        label6.Size = new Size(155, 41);
        label6.TabIndex = 5;
        label6.Text = "Next Cue: ";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 18F);
        label3.ForeColor = Color.White;
        label3.Location = new Point(13, 128);
        label3.Name = "label3";
        label3.Size = new Size(146, 41);
        label3.TabIndex = 4;
        label3.Text = "Cur. Cue: ";
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Microsoft Sans Serif", 26F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(10, 31);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(652, 48);
        lblTitle.TabIndex = 2;
        lblTitle.Text = "Song1";
        lblTitle.TextAlign = ContentAlignment.TopCenter;
        // 
        // setBox
        // 
        setBox.BorderColor = Color.Navy;
        setBox.BorderRadius = 8;
        setBox.BorderWidth = 2;
        setBox.Controls.Add(lblSetName);
        setBox.Controls.Add(label4);
        setBox.Controls.Add(lstSet);
        setBox.Dock = DockStyle.Fill;
        setBox.ForeColor = Color.FromArgb(128, 128, 255);
        setBox.LabelIndent = 10;
        setBox.Location = new Point(5, 5);
        setBox.Margin = new Padding(5);
        setBox.Name = "setBox";
        setBox.Padding = new Padding(15, 11, 10, 11);
        tableLayoutPanel1.SetRowSpan(setBox, 2);
        setBox.Size = new Size(475, 931);
        setBox.TabIndex = 5;
        setBox.TabStop = false;
        setBox.Text = "Set";
        // 
        // lblSetName
        // 
        lblSetName.AutoSize = true;
        lblSetName.Font = new Font("Segoe UI", 18F);
        lblSetName.ForeColor = Color.White;
        lblSetName.Location = new Point(120, 25);
        lblSetName.Name = "lblSetName";
        lblSetName.Size = new Size(0, 41);
        lblSetName.TabIndex = 8;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 18F);
        label4.ForeColor = Color.White;
        label4.Location = new Point(13, 25);
        label4.Name = "label4";
        label4.Size = new Size(112, 41);
        label4.TabIndex = 5;
        label4.Text = "Name: ";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = Color.Black;
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
        tableLayoutPanel1.Controls.Add(setBox, 0, 0);
        tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.4334259F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.5665741F));
        tableLayoutPanel1.Size = new Size(1167, 941);
        tableLayoutPanel1.TabIndex = 8;
        // 
        // Form1
        // 
        AcceptButton = btnChat;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(1167, 941);
        Controls.Add(tableLayoutPanel1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(680, 595);
        Name = "Form1";
        Text = "CremeWorks Client v1.5.2";
        FormClosed += Form1_FormClosed;
        Load += Form1_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        setBox.ResumeLayout(false);
        setBox.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ReadOnlyListBox lstSet;
    private ListBox lstChat;
    private Label label2;
    private TextBox txtChat;
    private Button btnChat;
    private Label label3;
    private Label lblTitle;
    private Label label4;
    private TextBox lblInstructions;
    private Label lblTempo;
    private Label lblCurrCue;
    private Label label6;
    private Panel pnlClick;
    private Label label5;
    private Label lblNextCue;
    private TableLayoutPanel tableLayoutPanel1;
    private BorderedGroupBox groupBox1;
    private BorderedGroupBox groupBox2;
    private BorderedGroupBox setBox;
    private Label lblSetName;
}
