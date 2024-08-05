
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTitle = new TextBox();
            txtArtist = new TextBox();
            txtKey = new TextBox();
            txtLyrics = new TextBox();
            btnOk = new Button();
            btnChordMakro = new Button();
            label33 = new Label();
            txtBpm = new NumericUpDown();
            label34 = new Label();
            blinkBox = new Panel();
            chkClick = new CheckBox();
            txtInstructions = new TextBox();
            label35 = new Label();
            btnRouting = new Button();
            lblDevicePatches = new Label();
            btnCues = new Button();
            ((System.ComponentModel.ISupportInitialize)txtBpm).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 40);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "Artist";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 70);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 2;
            label3.Text = "Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 262);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Lyrics";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(92, 7);
            txtTitle.Margin = new Padding(4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(500, 23);
            txtTitle.TabIndex = 4;
            txtTitle.Text = "Name";
            // 
            // txtArtist
            // 
            txtArtist.Location = new Point(92, 37);
            txtArtist.Margin = new Padding(4);
            txtArtist.Name = "txtArtist";
            txtArtist.Size = new Size(500, 23);
            txtArtist.TabIndex = 5;
            txtArtist.Text = "Unknown";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(92, 67);
            txtKey.Margin = new Padding(4);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(80, 23);
            txtKey.TabIndex = 6;
            // 
            // txtLyrics
            // 
            txtLyrics.Location = new Point(92, 259);
            txtLyrics.Margin = new Padding(4);
            txtLyrics.Multiline = true;
            txtLyrics.Name = "txtLyrics";
            txtLyrics.ScrollBars = ScrollBars.Vertical;
            txtLyrics.Size = new Size(417, 276);
            txtLyrics.TabIndex = 7;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(599, 7);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(146, 53);
            btnOk.TabIndex = 8;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += CloseOK;
            // 
            // btnChordMakro
            // 
            btnChordMakro.Location = new Point(599, 171);
            btnChordMakro.Margin = new Padding(4);
            btnChordMakro.Name = "btnChordMakro";
            btnChordMakro.Size = new Size(146, 36);
            btnChordMakro.TabIndex = 78;
            btnChordMakro.Text = "Chord Macro";
            btnChordMakro.UseVisualStyleBackColor = true;
            btnChordMakro.Click += btnChordMakro_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(14, 97);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(43, 15);
            label33.TabIndex = 131;
            label33.Text = "Tempo";
            // 
            // txtBpm
            // 
            txtBpm.Location = new Point(92, 95);
            txtBpm.Margin = new Padding(4);
            txtBpm.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            txtBpm.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            txtBpm.Name = "txtBpm";
            txtBpm.Size = new Size(80, 23);
            txtBpm.TabIndex = 132;
            txtBpm.Value = new decimal(new int[] { 120, 0, 0, 0 });
            txtBpm.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(178, 97);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(32, 15);
            label34.TabIndex = 133;
            label34.Text = "BPM";
            // 
            // blinkBox
            // 
            blinkBox.BackColor = Color.White;
            blinkBox.BorderStyle = BorderStyle.FixedSingle;
            blinkBox.Location = new Point(220, 93);
            blinkBox.Margin = new Padding(4);
            blinkBox.Name = "blinkBox";
            blinkBox.Size = new Size(23, 23);
            blinkBox.TabIndex = 134;
            // 
            // chkClick
            // 
            chkClick.AutoSize = true;
            chkClick.Location = new Point(599, 96);
            chkClick.Margin = new Padding(4);
            chkClick.Name = "chkClick";
            chkClick.Size = new Size(90, 19);
            chkClick.TabIndex = 135;
            chkClick.Text = "Enable Click";
            chkClick.UseVisualStyleBackColor = true;
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(92, 127);
            txtInstructions.Margin = new Padding(4);
            txtInstructions.Multiline = true;
            txtInstructions.Name = "txtInstructions";
            txtInstructions.ScrollBars = ScrollBars.Vertical;
            txtInstructions.Size = new Size(499, 124);
            txtInstructions.TabIndex = 137;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(13, 130);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(69, 15);
            label35.TabIndex = 136;
            label35.Text = "Instructions";
            // 
            // btnRouting
            // 
            btnRouting.Location = new Point(599, 127);
            btnRouting.Margin = new Padding(4);
            btnRouting.Name = "btnRouting";
            btnRouting.Size = new Size(146, 36);
            btnRouting.TabIndex = 138;
            btnRouting.Text = "MIDI Routing";
            btnRouting.UseVisualStyleBackColor = true;
            // 
            // lblDevicePatches
            // 
            lblDevicePatches.Location = new Point(516, 489);
            lblDevicePatches.Name = "lblDevicePatches";
            lblDevicePatches.Size = new Size(77, 23);
            lblDevicePatches.TabIndex = 143;
            lblDevicePatches.Text = "Device Patches";
            lblDevicePatches.TextAlign = ContentAlignment.TopRight;
            lblDevicePatches.Visible = false;
            // 
            // btnCues
            // 
            btnCues.Location = new Point(599, 215);
            btnCues.Margin = new Padding(4);
            btnCues.Name = "btnCues";
            btnCues.Size = new Size(146, 36);
            btnCues.TabIndex = 144;
            btnCues.Text = "Cues";
            btnCues.UseVisualStyleBackColor = true;
            // 
            // SongEditor
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 548);
            Controls.Add(btnCues);
            Controls.Add(lblDevicePatches);
            Controls.Add(btnRouting);
            Controls.Add(txtInstructions);
            Controls.Add(label35);
            Controls.Add(chkClick);
            Controls.Add(blinkBox);
            Controls.Add(label34);
            Controls.Add(txtBpm);
            Controls.Add(label33);
            Controls.Add(btnChordMakro);
            Controls.Add(btnOk);
            Controls.Add(txtLyrics);
            Controls.Add(txtKey);
            Controls.Add(txtArtist);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SongEditor";
            ShowIcon = false;
            Text = "Edit Song";
            FormClosing += SongEditor_FormClosing;
            ((System.ComponentModel.ISupportInitialize)txtBpm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnChordMakro;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown txtBpm;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel blinkBox;
        private System.Windows.Forms.CheckBox chkClick;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.Label label35;
        private Button btnRouting;
        private Label lblDevicePatches;
        private Button btnCues;
    }
}