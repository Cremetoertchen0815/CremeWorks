namespace CremeWorks.App.Dialogs;

partial class SoloModeSetup
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
        chkEnable = new CheckBox();
        groupBox1 = new GroupBox();
        btnRemove = new Button();
        label5 = new Label();
        btnAdd = new Button();
        boxDevices = new ListBox();
        nbrFadeDuration = new NumericUpDown();
        label4 = new Label();
        chkFade = new CheckBox();
        nbrSolo = new NumericUpDown();
        label3 = new Label();
        nbrDefault = new NumericUpDown();
        label2 = new Label();
        nbrCC = new NumericUpDown();
        label1 = new Label();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nbrFadeDuration).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nbrSolo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nbrDefault).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nbrCC).BeginInit();
        SuspendLayout();
        // 
        // chkEnable
        // 
        chkEnable.AutoSize = true;
        chkEnable.Location = new Point(12, 12);
        chkEnable.Name = "chkEnable";
        chkEnable.Size = new Size(68, 19);
        chkEnable.TabIndex = 0;
        chkEnable.Text = "Enabled";
        chkEnable.UseVisualStyleBackColor = true;
        chkEnable.CheckedChanged += chkEnable_CheckedChanged;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(btnRemove);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(btnAdd);
        groupBox1.Controls.Add(boxDevices);
        groupBox1.Controls.Add(nbrFadeDuration);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(chkFade);
        groupBox1.Controls.Add(nbrSolo);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(nbrDefault);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(nbrCC);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new Point(12, 37);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(272, 401);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        // 
        // btnRemove
        // 
        btnRemove.Location = new Point(110, 365);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(75, 30);
        btnRemove.TabIndex = 11;
        btnRemove.Text = "Remove";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(6, 187);
        label5.Name = "label5";
        label5.Size = new Size(76, 15);
        label5.TabIndex = 10;
        label5.Text = "Solo Devices:";
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(191, 365);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 30);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // boxDevices
        // 
        boxDevices.FormattingEnabled = true;
        boxDevices.ItemHeight = 15;
        boxDevices.Location = new Point(6, 205);
        boxDevices.Name = "boxDevices";
        boxDevices.Size = new Size(260, 154);
        boxDevices.TabIndex = 9;
        // 
        // nbrFadeDuration
        // 
        nbrFadeDuration.DecimalPlaces = 2;
        nbrFadeDuration.Location = new Point(112, 146);
        nbrFadeDuration.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nbrFadeDuration.Name = "nbrFadeDuration";
        nbrFadeDuration.Size = new Size(154, 23);
        nbrFadeDuration.TabIndex = 8;
        // 
        // label4
        // 
        label4.Location = new Point(6, 146);
        label4.Name = "label4";
        label4.Size = new Size(100, 23);
        label4.TabIndex = 7;
        label4.Text = "Fade duration";
        label4.TextAlign = ContentAlignment.MiddleRight;
        // 
        // chkFade
        // 
        chkFade.AutoSize = true;
        chkFade.Location = new Point(21, 124);
        chkFade.Name = "chkFade";
        chkFade.Size = new Size(87, 19);
        chkFade.TabIndex = 6;
        chkFade.Text = "Fade in/out";
        chkFade.UseVisualStyleBackColor = true;
        chkFade.CheckedChanged += chkFade_CheckedChanged;
        // 
        // nbrSolo
        // 
        nbrSolo.Location = new Point(112, 77);
        nbrSolo.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
        nbrSolo.Name = "nbrSolo";
        nbrSolo.Size = new Size(154, 23);
        nbrSolo.TabIndex = 5;
        // 
        // label3
        // 
        label3.Location = new Point(6, 77);
        label3.Name = "label3";
        label3.Size = new Size(100, 23);
        label3.TabIndex = 4;
        label3.Text = "Solo CC Value";
        label3.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nbrDefault
        // 
        nbrDefault.Location = new Point(112, 48);
        nbrDefault.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
        nbrDefault.Name = "nbrDefault";
        nbrDefault.Size = new Size(154, 23);
        nbrDefault.TabIndex = 3;
        // 
        // label2
        // 
        label2.Location = new Point(6, 48);
        label2.Name = "label2";
        label2.Size = new Size(100, 23);
        label2.TabIndex = 2;
        label2.Text = "Default CC Value";
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nbrCC
        // 
        nbrCC.Location = new Point(112, 19);
        nbrCC.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
        nbrCC.Name = "nbrCC";
        nbrCC.Size = new Size(154, 23);
        nbrCC.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new Point(6, 19);
        label1.Name = "label1";
        label1.Size = new Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "CC Number";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // SoloModeSetup
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(296, 450);
        Controls.Add(groupBox1);
        Controls.Add(chkEnable);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SoloModeSetup";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Solo Mode Configuration";
        FormClosed += SoloModeSetup_FormClosed;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nbrFadeDuration).EndInit();
        ((System.ComponentModel.ISupportInitialize)nbrSolo).EndInit();
        ((System.ComponentModel.ISupportInitialize)nbrDefault).EndInit();
        ((System.ComponentModel.ISupportInitialize)nbrCC).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private CheckBox chkEnable;
    private GroupBox groupBox1;
    private NumericUpDown nbrCC;
    private Label label1;
    private NumericUpDown nbrSolo;
    private Label label3;
    private NumericUpDown nbrDefault;
    private Label label2;
    private ListBox boxDevices;
    private NumericUpDown nbrFadeDuration;
    private Label label4;
    private CheckBox chkFade;
    private Button btnRemove;
    private Label label5;
    private Button btnAdd;
}