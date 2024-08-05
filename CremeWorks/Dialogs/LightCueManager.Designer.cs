namespace CremeWorks
{
    partial class LightCueManager
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
            this.lstCues = new System.Windows.Forms.ListBox();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNoteOn = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoteOn)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCues
            // 
            this.lstCues.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstCues.FormattingEnabled = true;
            this.lstCues.IntegralHeight = false;
            this.lstCues.ItemHeight = 16;
            this.lstCues.Location = new System.Drawing.Point(0, 0);
            this.lstCues.Name = "lstCues";
            this.lstCues.Size = new System.Drawing.Size(348, 244);
            this.lstCues.TabIndex = 0;
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(12, 250);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(103, 38);
            this.btnTrigger.TabIndex = 1;
            this.btnTrigger.Text = "Trigger";
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(121, 250);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(103, 38);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtNoteOn);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Note On Nr.:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtNoteOn
            // 
            this.txtNoteOn.Location = new System.Drawing.Point(91, 46);
            this.txtNoteOn.Name = "txtNoteOn";
            this.txtNoteOn.Size = new System.Drawing.Size(133, 22);
            this.txtNoteOn.TabIndex = 3;
            this.txtNoteOn.ValueChanged += new System.EventHandler(this.txtNoteOn_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 50);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // LightCueManager
            // 
            this.AcceptButton = this.btnTrigger;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnTrigger);
            this.Controls.Add(this.lstCues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LightCueManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Cues";
            this.Load += new System.EventHandler(this.LightCueManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoteOn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCues;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown txtNoteOn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}