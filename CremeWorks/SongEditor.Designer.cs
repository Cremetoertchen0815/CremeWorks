
namespace CremeWorks
{
    partial class SongEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkMM = new System.Windows.Forms.CheckBox();
            this.chk21 = new System.Windows.Forms.CheckBox();
            this.chk1M = new System.Windows.Forms.CheckBox();
            this.chkM1 = new System.Windows.Forms.CheckBox();
            this.chkM3 = new System.Windows.Forms.CheckBox();
            this.chk32 = new System.Windows.Forms.CheckBox();
            this.chk11 = new System.Windows.Forms.CheckBox();
            this.chk22 = new System.Windows.Forms.CheckBox();
            this.chk12 = new System.Windows.Forms.CheckBox();
            this.chk33 = new System.Windows.Forms.CheckBox();
            this.chkM2 = new System.Windows.Forms.CheckBox();
            this.chk23 = new System.Windows.Forms.CheckBox();
            this.chk31 = new System.Windows.Forms.CheckBox();
            this.chk13 = new System.Windows.Forms.CheckBox();
            this.chk2M = new System.Windows.Forms.CheckBox();
            this.chk3M = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lyrics";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(66, 6);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(361, 20);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "Name";
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(66, 32);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(361, 20);
            this.txtArtist.TabIndex = 5;
            this.txtArtist.Text = "Unknown";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(66, 58);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(361, 20);
            this.txtNotes.TabIndex = 6;
            // 
            // txtLyrics
            // 
            this.txtLyrics.Location = new System.Drawing.Point(66, 84);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyrics.Size = new System.Drawing.Size(361, 372);
            this.txtLyrics.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(214, 526);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 38);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.CloseOK);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CloseCancel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Routing";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "I/O";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Master";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 506);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Aux 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 526);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Aux 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 546);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Aux 3";
            // 
            // chkMM
            // 
            this.chkMM.AutoSize = true;
            this.chkMM.Location = new System.Drawing.Point(103, 486);
            this.chkMM.Name = "chkMM";
            this.chkMM.Size = new System.Drawing.Size(15, 14);
            this.chkMM.TabIndex = 16;
            this.chkMM.UseVisualStyleBackColor = true;
            // 
            // chk21
            // 
            this.chk21.AutoSize = true;
            this.chk21.Location = new System.Drawing.Point(124, 526);
            this.chk21.Name = "chk21";
            this.chk21.Size = new System.Drawing.Size(15, 14);
            this.chk21.TabIndex = 17;
            this.chk21.UseVisualStyleBackColor = true;
            // 
            // chk1M
            // 
            this.chk1M.AutoSize = true;
            this.chk1M.Location = new System.Drawing.Point(103, 506);
            this.chk1M.Name = "chk1M";
            this.chk1M.Size = new System.Drawing.Size(15, 14);
            this.chk1M.TabIndex = 18;
            this.chk1M.UseVisualStyleBackColor = true;
            // 
            // chkM1
            // 
            this.chkM1.AutoSize = true;
            this.chkM1.Location = new System.Drawing.Point(124, 486);
            this.chkM1.Name = "chkM1";
            this.chkM1.Size = new System.Drawing.Size(15, 14);
            this.chkM1.TabIndex = 19;
            this.chkM1.UseVisualStyleBackColor = true;
            // 
            // chkM3
            // 
            this.chkM3.AutoSize = true;
            this.chkM3.Location = new System.Drawing.Point(166, 486);
            this.chkM3.Name = "chkM3";
            this.chkM3.Size = new System.Drawing.Size(15, 14);
            this.chkM3.TabIndex = 20;
            this.chkM3.UseVisualStyleBackColor = true;
            // 
            // chk32
            // 
            this.chk32.AutoSize = true;
            this.chk32.Location = new System.Drawing.Point(145, 546);
            this.chk32.Name = "chk32";
            this.chk32.Size = new System.Drawing.Size(15, 14);
            this.chk32.TabIndex = 21;
            this.chk32.UseVisualStyleBackColor = true;
            // 
            // chk11
            // 
            this.chk11.AutoSize = true;
            this.chk11.Location = new System.Drawing.Point(124, 506);
            this.chk11.Name = "chk11";
            this.chk11.Size = new System.Drawing.Size(15, 14);
            this.chk11.TabIndex = 22;
            this.chk11.UseVisualStyleBackColor = true;
            // 
            // chk22
            // 
            this.chk22.AutoSize = true;
            this.chk22.Location = new System.Drawing.Point(145, 526);
            this.chk22.Name = "chk22";
            this.chk22.Size = new System.Drawing.Size(15, 14);
            this.chk22.TabIndex = 23;
            this.chk22.UseVisualStyleBackColor = true;
            // 
            // chk12
            // 
            this.chk12.AutoSize = true;
            this.chk12.Location = new System.Drawing.Point(145, 506);
            this.chk12.Name = "chk12";
            this.chk12.Size = new System.Drawing.Size(15, 14);
            this.chk12.TabIndex = 24;
            this.chk12.UseVisualStyleBackColor = true;
            // 
            // chk33
            // 
            this.chk33.AutoSize = true;
            this.chk33.Location = new System.Drawing.Point(166, 546);
            this.chk33.Name = "chk33";
            this.chk33.Size = new System.Drawing.Size(15, 14);
            this.chk33.TabIndex = 25;
            this.chk33.UseVisualStyleBackColor = true;
            // 
            // chkM2
            // 
            this.chkM2.AutoSize = true;
            this.chkM2.Location = new System.Drawing.Point(145, 486);
            this.chkM2.Name = "chkM2";
            this.chkM2.Size = new System.Drawing.Size(15, 14);
            this.chkM2.TabIndex = 26;
            this.chkM2.UseVisualStyleBackColor = true;
            // 
            // chk23
            // 
            this.chk23.AutoSize = true;
            this.chk23.Location = new System.Drawing.Point(166, 526);
            this.chk23.Name = "chk23";
            this.chk23.Size = new System.Drawing.Size(15, 14);
            this.chk23.TabIndex = 27;
            this.chk23.UseVisualStyleBackColor = true;
            // 
            // chk31
            // 
            this.chk31.AutoSize = true;
            this.chk31.Location = new System.Drawing.Point(124, 546);
            this.chk31.Name = "chk31";
            this.chk31.Size = new System.Drawing.Size(15, 14);
            this.chk31.TabIndex = 28;
            this.chk31.UseVisualStyleBackColor = true;
            // 
            // chk13
            // 
            this.chk13.AutoSize = true;
            this.chk13.Location = new System.Drawing.Point(166, 506);
            this.chk13.Name = "chk13";
            this.chk13.Size = new System.Drawing.Size(15, 14);
            this.chk13.TabIndex = 29;
            this.chk13.UseVisualStyleBackColor = true;
            // 
            // chk2M
            // 
            this.chk2M.AutoSize = true;
            this.chk2M.Location = new System.Drawing.Point(103, 526);
            this.chk2M.Name = "chk2M";
            this.chk2M.Size = new System.Drawing.Size(15, 14);
            this.chk2M.TabIndex = 30;
            this.chk2M.UseVisualStyleBackColor = true;
            // 
            // chk3M
            // 
            this.chk3M.AutoSize = true;
            this.chk3M.Location = new System.Drawing.Point(103, 546);
            this.chk3M.Name = "chk3M";
            this.chk3M.Size = new System.Drawing.Size(15, 14);
            this.chk3M.TabIndex = 31;
            this.chk3M.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 470);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "M";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 470);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(166, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "3";
            // 
            // SongEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 572);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chk3M);
            this.Controls.Add(this.chk2M);
            this.Controls.Add(this.chk13);
            this.Controls.Add(this.chk31);
            this.Controls.Add(this.chk23);
            this.Controls.Add(this.chkM2);
            this.Controls.Add(this.chk33);
            this.Controls.Add(this.chk12);
            this.Controls.Add(this.chk22);
            this.Controls.Add(this.chk11);
            this.Controls.Add(this.chk32);
            this.Controls.Add(this.chkM3);
            this.Controls.Add(this.chkM1);
            this.Controls.Add(this.chk1M);
            this.Controls.Add(this.chk21);
            this.Controls.Add(this.chkMM);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongEditor";
            this.Text = "Edit Song";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongEditor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkMM;
        private System.Windows.Forms.CheckBox chk21;
        private System.Windows.Forms.CheckBox chk1M;
        private System.Windows.Forms.CheckBox chkM1;
        private System.Windows.Forms.CheckBox chkM3;
        private System.Windows.Forms.CheckBox chk32;
        private System.Windows.Forms.CheckBox chk11;
        private System.Windows.Forms.CheckBox chk22;
        private System.Windows.Forms.CheckBox chk12;
        private System.Windows.Forms.CheckBox chk33;
        private System.Windows.Forms.CheckBox chkM2;
        private System.Windows.Forms.CheckBox chk23;
        private System.Windows.Forms.CheckBox chk31;
        private System.Windows.Forms.CheckBox chk13;
        private System.Windows.Forms.CheckBox chk2M;
        private System.Windows.Forms.CheckBox chk3M;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}