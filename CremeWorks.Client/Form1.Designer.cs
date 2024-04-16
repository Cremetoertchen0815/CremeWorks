﻿
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
        lstSet.BackColor = Color.FromArgb(64, 64, 64);
        lstSet.Font = new Font("Microsoft Sans Serif", 12F);
        lstSet.ForeColor = Color.White;
        lstSet.FormattingEnabled = true;
        lstSet.IntegralHeight = false;
        lstSet.ItemHeight = 20;
        lstSet.Location = new Point(11, 46);
        lstSet.Margin = new Padding(3, 2, 3, 2);
        lstSet.Name = "lstSet";
        lstSet.ReadOnly = true;
        lstSet.Size = new Size(225, 438);
        lstSet.TabIndex = 0;
        // 
        // lstChat
        // 
        lstChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstChat.BackColor = Color.FromArgb(64, 64, 64);
        lstChat.Font = new Font("Microsoft Sans Serif", 12F);
        lstChat.ForeColor = Color.White;
        lstChat.FormattingEnabled = true;
        lstChat.IntegralHeight = false;
        lstChat.ItemHeight = 20;
        lstChat.Items.AddRange(new object[] { "Server: HiHat zu laut!", "Mischa: Ja, ich weiß!" });
        lstChat.Location = new Point(11, 25);
        lstChat.Margin = new Padding(3, 2, 3, 2);
        lstChat.Name = "lstChat";
        lstChat.Size = new Size(600, 154);
        lstChat.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.ForeColor = Color.White;
        label2.Location = new Point(11, 64);
        label2.Name = "label2";
        label2.Size = new Size(62, 20);
        label2.TabIndex = 3;
        label2.Text = "Tempo:";
        // 
        // txtChat
        // 
        txtChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtChat.BackColor = Color.Black;
        txtChat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtChat.ForeColor = Color.White;
        txtChat.Location = new Point(11, 182);
        txtChat.Margin = new Padding(3, 2, 3, 2);
        txtChat.Name = "txtChat";
        txtChat.Size = new Size(513, 29);
        txtChat.TabIndex = 4;
        // 
        // btnChat
        // 
        btnChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnChat.BackColor = Color.FromArgb(64, 64, 64);
        btnChat.ForeColor = Color.White;
        btnChat.Location = new Point(529, 182);
        btnChat.Margin = new Padding(3, 2, 3, 2);
        btnChat.Name = "btnChat";
        btnChat.Size = new Size(82, 26);
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
        groupBox1.Location = new Point(260, 279);
        groupBox1.Margin = new Padding(4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(9, 8, 9, 8);
        groupBox1.Size = new Size(622, 215);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Chat";
        // 
        // groupBox2
        // 
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
        groupBox2.Location = new Point(260, 4);
        groupBox2.Margin = new Padding(4);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(9, 8, 9, 8);
        groupBox2.Size = new Size(622, 267);
        groupBox2.TabIndex = 7;
        groupBox2.TabStop = false;
        groupBox2.Text = "Current Song";
        // 
        // lblNextCue
        // 
        lblNextCue.AutoSize = true;
        lblNextCue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNextCue.ForeColor = Color.White;
        lblNextCue.Location = new Point(130, 114);
        lblNextCue.Name = "lblNextCue";
        lblNextCue.Size = new Size(61, 20);
        lblNextCue.TabIndex = 12;
        lblNextCue.Text = "Refrain";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label5.ForeColor = Color.White;
        label5.Location = new Point(11, 139);
        label5.Name = "label5";
        label5.Size = new Size(100, 20);
        label5.TabIndex = 11;
        label5.Text = "Instructions: ";
        // 
        // pnlClick
        // 
        pnlClick.BackColor = Color.White;
        pnlClick.BorderStyle = BorderStyle.FixedSingle;
        pnlClick.Location = new Point(214, 64);
        pnlClick.Margin = new Padding(3, 2, 3, 2);
        pnlClick.Name = "pnlClick";
        pnlClick.Size = new Size(21, 18);
        pnlClick.TabIndex = 10;
        // 
        // lblInstructions
        // 
        lblInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblInstructions.BackColor = Color.FromArgb(64, 64, 64);
        lblInstructions.ForeColor = Color.White;
        lblInstructions.Location = new Point(130, 142);
        lblInstructions.Margin = new Padding(3, 2, 3, 2);
        lblInstructions.Multiline = true;
        lblInstructions.Name = "lblInstructions";
        lblInstructions.ReadOnly = true;
        lblInstructions.Size = new Size(481, 97);
        lblInstructions.TabIndex = 9;
        // 
        // lblTempo
        // 
        lblTempo.AutoSize = true;
        lblTempo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTempo.ForeColor = Color.White;
        lblTempo.Location = new Point(130, 64);
        lblTempo.Name = "lblTempo";
        lblTempo.Size = new Size(74, 20);
        lblTempo.TabIndex = 8;
        lblTempo.Text = "120 BPM";
        // 
        // lblCurrCue
        // 
        lblCurrCue.AutoSize = true;
        lblCurrCue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCurrCue.ForeColor = Color.White;
        lblCurrCue.Location = new Point(130, 89);
        lblCurrCue.Name = "lblCurrCue";
        lblCurrCue.Size = new Size(66, 20);
        lblCurrCue.TabIndex = 7;
        lblCurrCue.Text = "Strophe";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label6.ForeColor = Color.White;
        label6.Location = new Point(11, 114);
        label6.Name = "label6";
        label6.Size = new Size(82, 20);
        label6.TabIndex = 5;
        label6.Text = "Next Cue: ";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.White;
        label3.Location = new Point(11, 89);
        label3.Name = "label3";
        label3.Size = new Size(79, 20);
        label3.TabIndex = 4;
        label3.Text = "Cur. Cue: ";
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Microsoft Sans Serif", 21.75F);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(9, 24);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(604, 36);
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
        setBox.Location = new Point(4, 4);
        setBox.Margin = new Padding(4);
        setBox.Name = "setBox";
        setBox.Padding = new Padding(13, 8, 9, 8);
        tableLayoutPanel1.SetRowSpan(setBox, 2);
        setBox.Size = new Size(248, 490);
        setBox.TabIndex = 5;
        setBox.TabStop = false;
        setBox.Text = "Set";
        // 
        // lblSetName
        // 
        lblSetName.AutoSize = true;
        lblSetName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSetName.ForeColor = Color.White;
        lblSetName.Location = new Point(82, 19);
        lblSetName.Name = "lblSetName";
        lblSetName.Size = new Size(0, 20);
        lblSetName.TabIndex = 8;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label4.ForeColor = Color.White;
        label4.Location = new Point(11, 19);
        label4.Name = "label4";
        label4.Size = new Size(59, 20);
        label4.TabIndex = 5;
        label4.Text = "Name: ";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = Color.Black;
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.92498F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.07502F));
        tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
        tableLayoutPanel1.Controls.Add(setBox, 0, 0);
        tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55.30504F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.69496F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
        tableLayoutPanel1.Size = new Size(886, 498);
        tableLayoutPanel1.TabIndex = 8;
        // 
        // Form1
        // 
        AcceptButton = btnChat;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(886, 498);
        Controls.Add(tableLayoutPanel1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(597, 460);
        Name = "Form1";
        Text = "CremeWorks Client v1.0";
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
