using CremeWorks.Common;

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
        lstSet = new ListBox();
        lstChat = new ListBox();
        label2 = new Label();
        textBox1 = new TextBox();
        button1 = new Button();
        groupBox1 = new BorderedGroupBox();
        groupBox2 = new BorderedGroupBox();
        label7 = new Label();
        label5 = new Label();
        pnlClick = new Panel();
        textBox2 = new TextBox();
        label9 = new Label();
        label8 = new Label();
        label6 = new Label();
        label3 = new Label();
        label1 = new Label();
        setBox = new BorderedGroupBox();
        label4 = new Label();
        tableLayoutPanel1 = new TableLayoutPanel();
        lblSetName = new Label();
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
        lstSet.ItemHeight = 25;
        lstSet.Location = new Point(13, 61);
        lstSet.Name = "lstSet";
        lstSet.Size = new Size(257, 582);
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
        lstChat.ItemHeight = 25;
        lstChat.Items.AddRange(new object[] { "Server: HiHat zu laut!", "Mischa: Ja, ich weiß!" });
        lstChat.Location = new Point(13, 33);
        lstChat.Name = "lstChat";
        lstChat.Size = new Size(684, 204);
        lstChat.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.ForeColor = Color.White;
        label2.Location = new Point(13, 86);
        label2.Name = "label2";
        label2.Size = new Size(80, 25);
        label2.TabIndex = 3;
        label2.Text = "Tempo:";
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.BackColor = Color.Black;
        textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox1.ForeColor = Color.White;
        textBox1.Location = new Point(13, 243);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(584, 34);
        textBox1.TabIndex = 4;
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        button1.BackColor = Color.FromArgb(64, 64, 64);
        button1.ForeColor = Color.White;
        button1.Location = new Point(603, 243);
        button1.Name = "button1";
        button1.Size = new Size(94, 34);
        button1.TabIndex = 5;
        button1.Text = "Send";
        button1.UseVisualStyleBackColor = false;
        // 
        // groupBox1
        // 
        groupBox1.BorderColor = Color.Navy;
        groupBox1.BorderRadius = 8;
        groupBox1.BorderWidth = 2;
        groupBox1.Controls.Add(lstChat);
        groupBox1.Controls.Add(button1);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Dock = DockStyle.Fill;
        groupBox1.ForeColor = Color.FromArgb(128, 128, 255);
        groupBox1.LabelIndent = 10;
        groupBox1.Location = new Point(298, 372);
        groupBox1.Margin = new Padding(5);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(10);
        groupBox1.Size = new Size(710, 287);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Chat";
        // 
        // groupBox2
        // 
        groupBox2.BorderColor = Color.Navy;
        groupBox2.BorderRadius = 8;
        groupBox2.BorderWidth = 2;
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(label5);
        groupBox2.Controls.Add(pnlClick);
        groupBox2.Controls.Add(textBox2);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(label8);
        groupBox2.Controls.Add(label6);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(label1);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.ForeColor = Color.FromArgb(128, 128, 255);
        groupBox2.LabelIndent = 10;
        groupBox2.Location = new Point(298, 5);
        groupBox2.Margin = new Padding(5);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(10);
        groupBox2.Size = new Size(710, 357);
        groupBox2.TabIndex = 7;
        groupBox2.TabStop = false;
        groupBox2.Text = "Current Song";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label7.ForeColor = Color.White;
        label7.Location = new Point(149, 152);
        label7.Name = "label7";
        label7.Size = new Size(73, 25);
        label7.TabIndex = 12;
        label7.Text = "Refrain";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label5.ForeColor = Color.White;
        label5.Location = new Point(13, 185);
        label5.Name = "label5";
        label5.Size = new Size(122, 25);
        label5.TabIndex = 11;
        label5.Text = "Instructions: ";
        // 
        // pnlClick
        // 
        pnlClick.BackColor = Color.White;
        pnlClick.BorderStyle = BorderStyle.FixedSingle;
        pnlClick.Location = new Point(245, 85);
        pnlClick.Name = "pnlClick";
        pnlClick.Size = new Size(24, 24);
        pnlClick.TabIndex = 10;
        // 
        // textBox2
        // 
        textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox2.BackColor = Color.FromArgb(64, 64, 64);
        textBox2.ForeColor = Color.White;
        textBox2.Location = new Point(149, 189);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(548, 130);
        textBox2.TabIndex = 9;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label9.ForeColor = Color.White;
        label9.Location = new Point(149, 86);
        label9.Name = "label9";
        label9.Size = new Size(93, 25);
        label9.TabIndex = 8;
        label9.Text = "120 BPM";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label8.ForeColor = Color.White;
        label8.Location = new Point(149, 119);
        label8.Name = "label8";
        label8.Size = new Size(81, 25);
        label8.TabIndex = 7;
        label8.Text = "Strophe";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label6.ForeColor = Color.White;
        label6.Location = new Point(13, 152);
        label6.Name = "label6";
        label6.Size = new Size(105, 25);
        label6.TabIndex = 5;
        label6.Text = "Next Cue: ";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label3.ForeColor = Color.White;
        label3.Location = new Point(13, 119);
        label3.Name = "label3";
        label3.Size = new Size(102, 25);
        label3.TabIndex = 4;
        label3.Text = "Cur. Cue: ";
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Font = new Font("Microsoft Sans Serif", 21.75F);
        label1.ForeColor = Color.White;
        label1.Location = new Point(10, 30);
        label1.Name = "label1";
        label1.Size = new Size(690, 48);
        label1.TabIndex = 2;
        label1.Text = "Song1";
        label1.TextAlign = ContentAlignment.TopCenter;
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
        setBox.Padding = new Padding(15, 10, 10, 10);
        tableLayoutPanel1.SetRowSpan(setBox, 2);
        setBox.Size = new Size(283, 654);
        setBox.TabIndex = 5;
        setBox.TabStop = false;
        setBox.Text = "Set";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label4.ForeColor = Color.White;
        label4.Location = new Point(13, 25);
        label4.Name = "label4";
        label4.Size = new Size(75, 25);
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
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55.30504F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.69496F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(1013, 664);
        tableLayoutPanel1.TabIndex = 8;
        // 
        // lblSetName
        // 
        lblSetName.AutoSize = true;
        lblSetName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSetName.ForeColor = Color.White;
        lblSetName.Location = new Point(94, 25);
        lblSetName.Name = "lblSetName";
        lblSetName.Size = new Size(0, 25);
        lblSetName.TabIndex = 8;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1013, 664);
        Controls.Add(tableLayoutPanel1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(680, 600);
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

    private ListBox lstSet;
    private ListBox lstChat;
    private Label label2;
    private TextBox textBox1;
    private Button button1;
    private Label label3;
    private Label label1;
    private Label label4;
    private TextBox textBox2;
    private Label label9;
    private Label label8;
    private Label label6;
    private Panel pnlClick;
    private Label label5;
    private Label label7;
    private TableLayoutPanel tableLayoutPanel1;
    private BorderedGroupBox groupBox1;
    private BorderedGroupBox groupBox2;
    private BorderedGroupBox setBox;
    private Label lblSetName;
}
