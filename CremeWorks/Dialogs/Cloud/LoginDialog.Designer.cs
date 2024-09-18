﻿namespace CremeWorks.App.Dialogs.Cloud;

partial class LoginDialog
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
        pictureBox1 = new PictureBox();
        label1 = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        label2 = new Label();
        button2 = new Button();
        button1 = new Button();
        lblIncorrect = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Image = Properties.Resources.cw_cloud;
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(387, 150);
        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.Location = new Point(12, 205);
        label1.Name = "label1";
        label1.Size = new Size(78, 27);
        label1.TabIndex = 1;
        label1.Text = "Username";
        label1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(96, 205);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(303, 27);
        txtUsername.TabIndex = 2;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(96, 238);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(303, 27);
        txtPassword.TabIndex = 4;
        // 
        // label2
        // 
        label2.Location = new Point(12, 238);
        label2.Name = "label2";
        label2.Size = new Size(78, 27);
        label2.TabIndex = 3;
        label2.Text = "Password";
        label2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // button2
        // 
        button2.Location = new Point(12, 331);
        button2.Name = "button2";
        button2.Size = new Size(107, 49);
        button2.TabIndex = 6;
        button2.Text = "Register";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.Location = new Point(292, 331);
        button1.Name = "button1";
        button1.Size = new Size(107, 49);
        button1.TabIndex = 7;
        button1.Text = "Login";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // lblIncorrect
        // 
        lblIncorrect.AutoSize = true;
        lblIncorrect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblIncorrect.ForeColor = Color.Red;
        lblIncorrect.Location = new Point(215, 268);
        lblIncorrect.Name = "lblIncorrect";
        lblIncorrect.Size = new Size(184, 20);
        lblIncorrect.TabIndex = 8;
        lblIncorrect.Text = "Credentials are incorrect!";
        // 
        // LoginDialog
        // 
        AcceptButton = button1;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(411, 392);
        Controls.Add(lblIncorrect);
        Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(txtPassword);
        Controls.Add(label2);
        Controls.Add(txtUsername);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginDialog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Label label1;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Label label2;
    private Button button2;
    private Button button1;
    private Label lblIncorrect;
}