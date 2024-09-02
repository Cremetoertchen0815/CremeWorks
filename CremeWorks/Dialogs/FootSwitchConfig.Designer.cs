
namespace CremeWorks
{
    partial class FootSwitchConfig
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
            panel1 = new Panel();
            btnRemove = new Button();
            groupBox1 = new GroupBox();
            btnDetect = new Button();
            label4 = new Label();
            boxAction = new ComboBox();
            nbrNumber = new NumericUpDown();
            label3 = new Label();
            nbrChannel = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            boxType = new ComboBox();
            btnAdd = new Button();
            lstActions = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nbrNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbrChannel).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemove);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 233);
            panel1.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(237, 6);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(70, 37);
            btnRemove.TabIndex = 12;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(btnDetect);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(boxAction);
            groupBox1.Controls.Add(nbrNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(nbrChannel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(boxType);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 172);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "New Action";
            // 
            // btnDetect
            // 
            btnDetect.Location = new Point(225, 138);
            btnDetect.Name = "btnDetect";
            btnDetect.Size = new Size(70, 28);
            btnDetect.TabIndex = 12;
            btnDetect.Text = "Detect";
            btnDetect.UseVisualStyleBackColor = true;
            btnDetect.Click += btnDetect_Click;
            // 
            // label4
            // 
            label4.Location = new Point(0, 109);
            label4.Name = "label4";
            label4.Size = new Size(93, 23);
            label4.TabIndex = 10;
            label4.Text = "Action:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // boxAction
            // 
            boxAction.FormattingEnabled = true;
            boxAction.Location = new Point(99, 109);
            boxAction.Name = "boxAction";
            boxAction.Size = new Size(196, 23);
            boxAction.TabIndex = 9;
            // 
            // nbrNumber
            // 
            nbrNumber.Location = new Point(99, 80);
            nbrNumber.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            nbrNumber.Name = "nbrNumber";
            nbrNumber.Size = new Size(196, 23);
            nbrNumber.TabIndex = 8;
            // 
            // label3
            // 
            label3.Location = new Point(0, 80);
            label3.Name = "label3";
            label3.Size = new Size(93, 23);
            label3.TabIndex = 7;
            label3.Text = "Event Number:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nbrChannel
            // 
            nbrChannel.Location = new Point(99, 51);
            nbrChannel.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            nbrChannel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nbrChannel.Name = "nbrChannel";
            nbrChannel.Size = new Size(196, 23);
            nbrChannel.TabIndex = 6;
            nbrChannel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.Location = new Point(0, 51);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 5;
            label2.Text = "Event Channel:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(0, 22);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 3;
            label1.Text = "Event Type:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // boxType
            // 
            boxType.FormattingEnabled = true;
            boxType.Location = new Point(99, 22);
            boxType.Name = "boxType";
            boxType.Size = new Size(196, 23);
            boxType.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(161, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 37);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstActions
            // 
            lstActions.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lstActions.Dock = DockStyle.Fill;
            lstActions.Location = new Point(0, 0);
            lstActions.Name = "lstActions";
            lstActions.Size = new Size(325, 228);
            lstActions.TabIndex = 0;
            lstActions.UseCompatibleStateImageBehavior = false;
            lstActions.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Action";
            columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Event Type";
            columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Channel";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Number";
            // 
            // FootSwitchConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 461);
            Controls.Add(lstActions);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FootSwitchConfig";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Controller Actions";
            FormClosing += FootSwitchConfig_FormClosing;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nbrNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbrChannel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListView lstActions;
        private GroupBox groupBox1;
        private NumericUpDown nbrChannel;
        private Label label2;
        private Label label1;
        private ComboBox boxType;
        private Button btnDetect;
        private Button btnAdd;
        private Label label4;
        private ComboBox boxAction;
        private NumericUpDown nbrNumber;
        private Label label3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button btnRemove;
    }
}