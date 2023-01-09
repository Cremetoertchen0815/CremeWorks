namespace CremeWorks
{
    partial class ChordMacroEditor
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
            this.valSrcDev = new System.Windows.Forms.ComboBox();
            this.valDstDev = new System.Windows.Forms.ComboBox();
            this.lstMacros = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMacrosAdd = new System.Windows.Forms.Button();
            this.btnMacrosRem = new System.Windows.Forms.Button();
            this.boxItem = new System.Windows.Forms.GroupBox();
            this.btnItemTriggerCapture = new System.Windows.Forms.Button();
            this.btnItemNoteCapture = new System.Windows.Forms.Button();
            this.btnItemRemNote = new System.Windows.Forms.Button();
            this.btnItemAddNote = new System.Windows.Forms.Button();
            this.lstItemNotes = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valItemVelocity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.valItemName = new System.Windows.Forms.TextBox();
            this.valItemTrigger = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.boxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valItemVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valItemTrigger)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Device:";
            // 
            // valSrcDev
            // 
            this.valSrcDev.FormattingEnabled = true;
            this.valSrcDev.Items.AddRange(new object[] {
            "Master Instr.",
            "Aux A",
            "Aux B",
            "Aux C"});
            this.valSrcDev.Location = new System.Drawing.Point(118, 12);
            this.valSrcDev.Name = "valSrcDev";
            this.valSrcDev.Size = new System.Drawing.Size(118, 21);
            this.valSrcDev.TabIndex = 2;
            this.valSrcDev.Text = "Master Instr.";
            this.valSrcDev.SelectedIndexChanged += new System.EventHandler(this.Dev_SelectedIndexChanged);
            // 
            // valDstDev
            // 
            this.valDstDev.FormattingEnabled = true;
            this.valDstDev.Items.AddRange(new object[] {
            "Master Instr.",
            "Aux A",
            "Aux B",
            "Aux C"});
            this.valDstDev.Location = new System.Drawing.Point(118, 39);
            this.valDstDev.Name = "valDstDev";
            this.valDstDev.Size = new System.Drawing.Size(118, 21);
            this.valDstDev.TabIndex = 3;
            this.valDstDev.Text = "Master Instr.";
            this.valDstDev.SelectedIndexChanged += new System.EventHandler(this.Dev_SelectedIndexChanged);
            // 
            // lstMacros
            // 
            this.lstMacros.FormattingEnabled = true;
            this.lstMacros.Location = new System.Drawing.Point(15, 91);
            this.lstMacros.Name = "lstMacros";
            this.lstMacros.Size = new System.Drawing.Size(221, 251);
            this.lstMacros.TabIndex = 4;
            this.lstMacros.SelectedIndexChanged += new System.EventHandler(this.lstMacros_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Macros:";
            // 
            // btnMacrosAdd
            // 
            this.btnMacrosAdd.Location = new System.Drawing.Point(90, 348);
            this.btnMacrosAdd.Name = "btnMacrosAdd";
            this.btnMacrosAdd.Size = new System.Drawing.Size(69, 25);
            this.btnMacrosAdd.TabIndex = 10;
            this.btnMacrosAdd.Text = "Add";
            this.btnMacrosAdd.UseVisualStyleBackColor = true;
            this.btnMacrosAdd.Click += new System.EventHandler(this.btnMacrosAdd_Click);
            // 
            // btnMacrosRem
            // 
            this.btnMacrosRem.Location = new System.Drawing.Point(165, 348);
            this.btnMacrosRem.Name = "btnMacrosRem";
            this.btnMacrosRem.Size = new System.Drawing.Size(71, 25);
            this.btnMacrosRem.TabIndex = 11;
            this.btnMacrosRem.Text = "Remove";
            this.btnMacrosRem.UseVisualStyleBackColor = true;
            this.btnMacrosRem.Click += new System.EventHandler(this.btnMacrosRem_Click);
            // 
            // boxItem
            // 
            this.boxItem.Controls.Add(this.btnItemTriggerCapture);
            this.boxItem.Controls.Add(this.btnItemNoteCapture);
            this.boxItem.Controls.Add(this.btnItemRemNote);
            this.boxItem.Controls.Add(this.btnItemAddNote);
            this.boxItem.Controls.Add(this.lstItemNotes);
            this.boxItem.Controls.Add(this.label7);
            this.boxItem.Controls.Add(this.valItemVelocity);
            this.boxItem.Controls.Add(this.label6);
            this.boxItem.Controls.Add(this.label5);
            this.boxItem.Controls.Add(this.valItemName);
            this.boxItem.Controls.Add(this.valItemTrigger);
            this.boxItem.Controls.Add(this.label4);
            this.boxItem.Enabled = false;
            this.boxItem.Location = new System.Drawing.Point(301, 12);
            this.boxItem.Name = "boxItem";
            this.boxItem.Size = new System.Drawing.Size(268, 306);
            this.boxItem.TabIndex = 14;
            this.boxItem.TabStop = false;
            this.boxItem.Text = "Current Item";
            // 
            // btnItemTriggerCapture
            // 
            this.btnItemTriggerCapture.Location = new System.Drawing.Point(205, 111);
            this.btnItemTriggerCapture.Name = "btnItemTriggerCapture";
            this.btnItemTriggerCapture.Size = new System.Drawing.Size(57, 21);
            this.btnItemTriggerCapture.TabIndex = 31;
            this.btnItemTriggerCapture.Text = "Detect";
            this.btnItemTriggerCapture.UseVisualStyleBackColor = true;
            this.btnItemTriggerCapture.Click += new System.EventHandler(this.btnItemTriggerCapture_Click);
            // 
            // btnItemNoteCapture
            // 
            this.btnItemNoteCapture.Location = new System.Drawing.Point(168, 253);
            this.btnItemNoteCapture.Name = "btnItemNoteCapture";
            this.btnItemNoteCapture.Size = new System.Drawing.Size(94, 41);
            this.btnItemNoteCapture.TabIndex = 28;
            this.btnItemNoteCapture.Text = "Detect Notes (on dst. device)";
            this.btnItemNoteCapture.UseVisualStyleBackColor = true;
            this.btnItemNoteCapture.Click += new System.EventHandler(this.btnItemNoteCapture_Click);
            // 
            // btnItemRemNote
            // 
            this.btnItemRemNote.Location = new System.Drawing.Point(168, 207);
            this.btnItemRemNote.Name = "btnItemRemNote";
            this.btnItemRemNote.Size = new System.Drawing.Size(94, 41);
            this.btnItemRemNote.TabIndex = 27;
            this.btnItemRemNote.Text = "Remove Selected";
            this.btnItemRemNote.UseVisualStyleBackColor = true;
            this.btnItemRemNote.Click += new System.EventHandler(this.btnItemRemNote_Click);
            // 
            // btnItemAddNote
            // 
            this.btnItemAddNote.Location = new System.Drawing.Point(168, 160);
            this.btnItemAddNote.Name = "btnItemAddNote";
            this.btnItemAddNote.Size = new System.Drawing.Size(94, 41);
            this.btnItemAddNote.TabIndex = 26;
            this.btnItemAddNote.Text = "Add by Note Nr.";
            this.btnItemAddNote.UseVisualStyleBackColor = true;
            // 
            // lstItemNotes
            // 
            this.lstItemNotes.FormattingEnabled = true;
            this.lstItemNotes.Location = new System.Drawing.Point(9, 160);
            this.lstItemNotes.Name = "lstItemNotes";
            this.lstItemNotes.Size = new System.Drawing.Size(153, 134);
            this.lstItemNotes.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Velocity:";
            // 
            // valItemVelocity
            // 
            this.valItemVelocity.Location = new System.Drawing.Point(81, 85);
            this.valItemVelocity.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.valItemVelocity.Name = "valItemVelocity";
            this.valItemVelocity.Size = new System.Drawing.Size(181, 20);
            this.valItemVelocity.TabIndex = 23;
            this.valItemVelocity.ValueChanged += new System.EventHandler(this.valItemVelocity_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Notes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Name:";
            // 
            // valItemName
            // 
            this.valItemName.Location = new System.Drawing.Point(81, 27);
            this.valItemName.Name = "valItemName";
            this.valItemName.Size = new System.Drawing.Size(181, 20);
            this.valItemName.TabIndex = 20;
            this.valItemName.TextChanged += new System.EventHandler(this.valItemName_TextChanged);
            // 
            // valItemTrigger
            // 
            this.valItemTrigger.Location = new System.Drawing.Point(81, 59);
            this.valItemTrigger.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.valItemTrigger.Name = "valItemTrigger";
            this.valItemTrigger.Size = new System.Drawing.Size(181, 20);
            this.valItemTrigger.TabIndex = 19;
            this.valItemTrigger.ValueChanged += new System.EventHandler(this.valItemTrigger_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Trigger Note:";
            // 
            // ChordMacroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 379);
            this.Controls.Add(this.boxItem);
            this.Controls.Add(this.btnMacrosRem);
            this.Controls.Add(this.btnMacrosAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstMacros);
            this.Controls.Add(this.valDstDev);
            this.Controls.Add(this.valSrcDev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChordMacroEditor";
            this.Text = "Edit Chord Macros";
            this.Load += new System.EventHandler(this.ChordMacroEditor_Load);
            this.boxItem.ResumeLayout(false);
            this.boxItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valItemVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valItemTrigger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valSrcDev;
        private System.Windows.Forms.ComboBox valDstDev;
        private System.Windows.Forms.ListBox lstMacros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMacrosAdd;
        private System.Windows.Forms.Button btnMacrosRem;
        private System.Windows.Forms.GroupBox boxItem;
        private System.Windows.Forms.Button btnItemNoteCapture;
        private System.Windows.Forms.Button btnItemRemNote;
        private System.Windows.Forms.Button btnItemAddNote;
        private System.Windows.Forms.ListBox lstItemNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown valItemVelocity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox valItemName;
        private System.Windows.Forms.NumericUpDown valItemTrigger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnItemTriggerCapture;
    }
}