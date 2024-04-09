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
        listBox1 = new ListBox();
        listBox2 = new ListBox();
        label2 = new Label();
        textBox1 = new TextBox();
        button1 = new Button();
        groupBox1 = new GroupBox();
        groupBox2 = new GroupBox();
        label7 = new Label();
        label5 = new Label();
        panel1 = new Panel();
        textBox2 = new TextBox();
        label9 = new Label();
        label8 = new Label();
        label6 = new Label();
        label3 = new Label();
        label1 = new Label();
        setBox = new GroupBox();
        label4 = new Label();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        setBox.SuspendLayout();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listBox1.Font = new Font("Microsoft Sans Serif", 12F);
        listBox1.FormattingEnabled = true;
        listBox1.IntegralHeight = false;
        listBox1.ItemHeight = 25;
        listBox1.Location = new Point(7, 63);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(310, 554);
        listBox1.TabIndex = 0;
        // 
        // listBox2
        // 
        listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listBox2.Font = new Font("Microsoft Sans Serif", 12F);
        listBox2.FormattingEnabled = true;
        listBox2.IntegralHeight = false;
        listBox2.ItemHeight = 25;
        listBox2.Items.AddRange(new object[] { "Server: HiHat zu laut!", "Mischa: Ja, ich weiß!" });
        listBox2.Location = new Point(10, 30);
        listBox2.Name = "listBox2";
        listBox2.Size = new Size(598, 163);
        listBox2.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label2.Location = new Point(10, 83);
        label2.Name = "label2";
        label2.Size = new Size(80, 25);
        label2.TabIndex = 3;
        label2.Text = "Tempo:";
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox1.Location = new Point(10, 199);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(498, 34);
        textBox1.TabIndex = 4;
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        button1.Location = new Point(514, 199);
        button1.Name = "button1";
        button1.Size = new Size(94, 34);
        button1.TabIndex = 5;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(listBox2);
        groupBox1.Controls.Add(button1);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Dock = DockStyle.Bottom;
        groupBox1.Location = new Point(324, 384);
        groupBox1.Margin = new Padding(10);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(7);
        groupBox1.Size = new Size(618, 240);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Chat";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(label5);
        groupBox2.Controls.Add(panel1);
        groupBox2.Controls.Add(textBox2);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(label8);
        groupBox2.Controls.Add(label6);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(label1);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.Location = new Point(324, 0);
        groupBox2.Margin = new Padding(10);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(7);
        groupBox2.Size = new Size(618, 384);
        groupBox2.TabIndex = 7;
        groupBox2.TabStop = false;
        groupBox2.Text = "Current Song";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label7.Location = new Point(146, 149);
        label7.Name = "label7";
        label7.Size = new Size(73, 25);
        label7.TabIndex = 12;
        label7.Text = "Refrain";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label5.Location = new Point(10, 182);
        label5.Name = "label5";
        label5.Size = new Size(122, 25);
        label5.TabIndex = 11;
        label5.Text = "Instructions: ";
        // 
        // panel1
        // 
        panel1.BackColor = Color.White;
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Location = new Point(245, 83);
        panel1.Name = "panel1";
        panel1.Size = new Size(24, 24);
        panel1.TabIndex = 10;
        // 
        // textBox2
        // 
        textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox2.Location = new Point(146, 182);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(456, 163);
        textBox2.TabIndex = 9;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label9.Location = new Point(146, 83);
        label9.Name = "label9";
        label9.Size = new Size(93, 25);
        label9.TabIndex = 8;
        label9.Text = "120 BPM";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label8.Location = new Point(146, 116);
        label8.Name = "label8";
        label8.Size = new Size(81, 25);
        label8.TabIndex = 7;
        label8.Text = "Strophe";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label6.Location = new Point(10, 149);
        label6.Name = "label6";
        label6.Size = new Size(105, 25);
        label6.TabIndex = 5;
        label6.Text = "Next Cue: ";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label3.Location = new Point(10, 116);
        label3.Name = "label3";
        label3.Size = new Size(102, 25);
        label3.TabIndex = 4;
        label3.Text = "Cur. Cue: ";
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Font = new Font("Microsoft Sans Serif", 21.75F);
        label1.Location = new Point(7, 27);
        label1.Name = "label1";
        label1.Size = new Size(604, 48);
        label1.TabIndex = 2;
        label1.Text = "Song1";
        label1.TextAlign = ContentAlignment.TopCenter;
        // 
        // setBox
        // 
        setBox.Controls.Add(label4);
        setBox.Controls.Add(listBox1);
        setBox.Dock = DockStyle.Left;
        setBox.Location = new Point(0, 0);
        setBox.Margin = new Padding(10);
        setBox.Name = "setBox";
        setBox.Padding = new Padding(7);
        setBox.Size = new Size(324, 624);
        setBox.TabIndex = 5;
        setBox.TabStop = false;
        setBox.Text = "Set";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label4.Location = new Point(10, 27);
        label4.Name = "label4";
        label4.Size = new Size(75, 25);
        label4.TabIndex = 5;
        label4.Text = "Name: ";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(942, 624);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(setBox);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(680, 600);
        Name = "Form1";
        Text = "CremeWorks Client v1.0";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        setBox.ResumeLayout(false);
        setBox.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private ListBox listBox2;
    private Label label2;
    private TextBox textBox1;
    private Button button1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label3;
    private Label label1;
    private GroupBox setBox;
    private Label label4;
    private TextBox textBox2;
    private Label label9;
    private Label label8;
    private Label label6;
    private Panel panel1;
    private Label label5;
    private Label label7;
}
