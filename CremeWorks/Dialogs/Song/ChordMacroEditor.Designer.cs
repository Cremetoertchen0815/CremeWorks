namespace CremeWorks.App.Dialogs
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
            label1 = new Label();
            label2 = new Label();
            valSrcDev = new ComboBox();
            valDstDev = new ComboBox();
            lstMacros = new ListBox();
            label3 = new Label();
            btnMacrosAdd = new Button();
            btnMacrosRem = new Button();
            boxItem = new GroupBox();
            btnItemTriggerCapture = new Button();
            btnItemNoteCapture = new Button();
            btnItemRemNote = new Button();
            btnItemAddNote = new Button();
            lstItemNotes = new ListBox();
            label7 = new Label();
            valItemVelocity = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            valItemName = new TextBox();
            valItemTrigger = new NumericUpDown();
            label4 = new Label();
            boxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)valItemVelocity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valItemTrigger).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Source Device:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 65);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 1;
            label2.Text = "Destination Device:";
            // 
            // valSrcDev
            // 
            valSrcDev.FormattingEnabled = true;
            valSrcDev.Location = new Point(157, 19);
            valSrcDev.Margin = new Padding(4, 5, 4, 5);
            valSrcDev.Name = "valSrcDev";
            valSrcDev.Size = new Size(156, 28);
            valSrcDev.TabIndex = 2;
            valSrcDev.SelectedIndexChanged += Dev_SelectedIndexChanged;
            // 
            // valDstDev
            // 
            valDstDev.FormattingEnabled = true;
            valDstDev.Location = new Point(157, 60);
            valDstDev.Margin = new Padding(4, 5, 4, 5);
            valDstDev.Name = "valDstDev";
            valDstDev.Size = new Size(156, 28);
            valDstDev.TabIndex = 3;
            valDstDev.SelectedIndexChanged += Dev_SelectedIndexChanged;
            // 
            // lstMacros
            // 
            lstMacros.FormattingEnabled = true;
            lstMacros.Location = new Point(20, 140);
            lstMacros.Margin = new Padding(4, 5, 4, 5);
            lstMacros.Name = "lstMacros";
            lstMacros.Size = new Size(293, 384);
            lstMacros.TabIndex = 4;
            lstMacros.SelectedIndexChanged += lstMacros_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 115);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 5;
            label3.Text = "Macros:";
            // 
            // btnMacrosAdd
            // 
            btnMacrosAdd.Location = new Point(120, 535);
            btnMacrosAdd.Margin = new Padding(4, 5, 4, 5);
            btnMacrosAdd.Name = "btnMacrosAdd";
            btnMacrosAdd.Size = new Size(92, 39);
            btnMacrosAdd.TabIndex = 10;
            btnMacrosAdd.Text = "Add";
            btnMacrosAdd.UseVisualStyleBackColor = true;
            btnMacrosAdd.Click += btnMacrosAdd_Click;
            // 
            // btnMacrosRem
            // 
            btnMacrosRem.Location = new Point(220, 535);
            btnMacrosRem.Margin = new Padding(4, 5, 4, 5);
            btnMacrosRem.Name = "btnMacrosRem";
            btnMacrosRem.Size = new Size(95, 39);
            btnMacrosRem.TabIndex = 11;
            btnMacrosRem.Text = "Remove";
            btnMacrosRem.UseVisualStyleBackColor = true;
            btnMacrosRem.Click += btnMacrosRem_Click;
            // 
            // boxItem
            // 
            boxItem.Controls.Add(btnItemTriggerCapture);
            boxItem.Controls.Add(btnItemNoteCapture);
            boxItem.Controls.Add(btnItemRemNote);
            boxItem.Controls.Add(btnItemAddNote);
            boxItem.Controls.Add(lstItemNotes);
            boxItem.Controls.Add(label7);
            boxItem.Controls.Add(valItemVelocity);
            boxItem.Controls.Add(label6);
            boxItem.Controls.Add(label5);
            boxItem.Controls.Add(valItemName);
            boxItem.Controls.Add(valItemTrigger);
            boxItem.Controls.Add(label4);
            boxItem.Enabled = false;
            boxItem.Location = new Point(401, 19);
            boxItem.Margin = new Padding(4, 5, 4, 5);
            boxItem.Name = "boxItem";
            boxItem.Padding = new Padding(4, 5, 4, 5);
            boxItem.Size = new Size(357, 471);
            boxItem.TabIndex = 14;
            boxItem.TabStop = false;
            boxItem.Text = "Current Item";
            // 
            // btnItemTriggerCapture
            // 
            btnItemTriggerCapture.Location = new Point(273, 171);
            btnItemTriggerCapture.Margin = new Padding(4, 5, 4, 5);
            btnItemTriggerCapture.Name = "btnItemTriggerCapture";
            btnItemTriggerCapture.Size = new Size(76, 32);
            btnItemTriggerCapture.TabIndex = 31;
            btnItemTriggerCapture.Text = "Detect";
            btnItemTriggerCapture.UseVisualStyleBackColor = true;
            btnItemTriggerCapture.Click += btnItemTriggerCapture_Click;
            // 
            // btnItemNoteCapture
            // 
            btnItemNoteCapture.Location = new Point(224, 389);
            btnItemNoteCapture.Margin = new Padding(4, 5, 4, 5);
            btnItemNoteCapture.Name = "btnItemNoteCapture";
            btnItemNoteCapture.Size = new Size(125, 62);
            btnItemNoteCapture.TabIndex = 28;
            btnItemNoteCapture.Text = "Detect Notes (on dst. device)";
            btnItemNoteCapture.UseVisualStyleBackColor = true;
            btnItemNoteCapture.Click += btnItemNoteCapture_Click;
            // 
            // btnItemRemNote
            // 
            btnItemRemNote.Location = new Point(224, 319);
            btnItemRemNote.Margin = new Padding(4, 5, 4, 5);
            btnItemRemNote.Name = "btnItemRemNote";
            btnItemRemNote.Size = new Size(125, 62);
            btnItemRemNote.TabIndex = 27;
            btnItemRemNote.Text = "Remove Selected";
            btnItemRemNote.UseVisualStyleBackColor = true;
            btnItemRemNote.Click += btnItemRemNote_Click;
            // 
            // btnItemAddNote
            // 
            btnItemAddNote.Location = new Point(224, 246);
            btnItemAddNote.Margin = new Padding(4, 5, 4, 5);
            btnItemAddNote.Name = "btnItemAddNote";
            btnItemAddNote.Size = new Size(125, 62);
            btnItemAddNote.TabIndex = 26;
            btnItemAddNote.Text = "Add by Note Nr.";
            btnItemAddNote.UseVisualStyleBackColor = true;
            // 
            // lstItemNotes
            // 
            lstItemNotes.FormattingEnabled = true;
            lstItemNotes.Location = new Point(12, 246);
            lstItemNotes.Margin = new Padding(4, 5, 4, 5);
            lstItemNotes.Name = "lstItemNotes";
            lstItemNotes.Size = new Size(203, 204);
            lstItemNotes.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 134);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 24;
            label7.Text = "Velocity:";
            // 
            // valItemVelocity
            // 
            valItemVelocity.Location = new Point(108, 131);
            valItemVelocity.Margin = new Padding(4, 5, 4, 5);
            valItemVelocity.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            valItemVelocity.Name = "valItemVelocity";
            valItemVelocity.Size = new Size(241, 27);
            valItemVelocity.TabIndex = 23;
            valItemVelocity.ValueChanged += valItemVelocity_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 221);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 22;
            label6.Text = "Notes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 46);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 21;
            label5.Text = "Name:";
            // 
            // valItemName
            // 
            valItemName.Location = new Point(108, 41);
            valItemName.Margin = new Padding(4, 5, 4, 5);
            valItemName.Name = "valItemName";
            valItemName.Size = new Size(240, 27);
            valItemName.TabIndex = 20;
            valItemName.TextChanged += valItemName_TextChanged;
            // 
            // valItemTrigger
            // 
            valItemTrigger.Location = new Point(108, 91);
            valItemTrigger.Margin = new Padding(4, 5, 4, 5);
            valItemTrigger.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            valItemTrigger.Name = "valItemTrigger";
            valItemTrigger.Size = new Size(241, 27);
            valItemTrigger.TabIndex = 19;
            valItemTrigger.ValueChanged += valItemTrigger_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 94);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 18;
            label4.Text = "Trigger Note:";
            // 
            // ChordMacroEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 582);
            Controls.Add(boxItem);
            Controls.Add(btnMacrosRem);
            Controls.Add(btnMacrosAdd);
            Controls.Add(label3);
            Controls.Add(lstMacros);
            Controls.Add(valDstDev);
            Controls.Add(valSrcDev);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChordMacroEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Chord Macros";
            Load += ChordMacroEditor_Load;
            boxItem.ResumeLayout(false);
            boxItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)valItemVelocity).EndInit();
            ((System.ComponentModel.ISupportInitialize)valItemTrigger).EndInit();
            ResumeLayout(false);
            PerformLayout();
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