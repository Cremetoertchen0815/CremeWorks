
namespace CremeWorks
{
    partial class MidiSetUp
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
            lblDevice = new Label();
            lblMidiDevice = new Label();
            lvlType = new Label();
            boxSelector = new ComboBox();
            boxType = new ComboBox();
            btnPlus = new Button();
            btnRefresh = new Button();
            btnTest = new Button();
            boxDevice = new ComboBox();
            btnMinus = new Button();
            txtName = new TextBox();
            lblName = new Label();
            groupBox1 = new GroupBox();
            btnOk = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDevice
            // 
            lblDevice.AutoSize = true;
            lblDevice.Location = new Point(13, 17);
            lblDevice.Margin = new Padding(4, 0, 4, 0);
            lblDevice.Name = "lblDevice";
            lblDevice.Size = new Size(42, 15);
            lblDevice.TabIndex = 0;
            lblDevice.Text = "Device";
            lblDevice.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMidiDevice
            // 
            lblMidiDevice.Location = new Point(10, 52);
            lblMidiDevice.Margin = new Padding(4, 0, 4, 0);
            lblMidiDevice.Name = "lblMidiDevice";
            lblMidiDevice.Size = new Size(73, 23);
            lblMidiDevice.TabIndex = 2;
            lblMidiDevice.Text = "MIDI Device";
            lblMidiDevice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lvlType
            // 
            lvlType.Location = new Point(13, 83);
            lvlType.Margin = new Padding(4, 0, 4, 0);
            lvlType.Name = "lvlType";
            lvlType.Size = new Size(70, 23);
            lvlType.TabIndex = 3;
            lvlType.Text = "Type";
            lvlType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // boxSelector
            // 
            boxSelector.FormattingEnabled = true;
            boxSelector.Location = new Point(63, 14);
            boxSelector.Margin = new Padding(4);
            boxSelector.Name = "boxSelector";
            boxSelector.Size = new Size(286, 23);
            boxSelector.TabIndex = 5;
            boxSelector.SelectedIndexChanged += comboBoxValueChange;
            // 
            // boxType
            // 
            boxType.FormattingEnabled = true;
            boxType.Items.AddRange(new object[] { "Generic Keyboard", "Generic Controller", "Lighting Device", "RefaceCS", "RefaceDX", "RefaceCP", "RefaceYC" });
            boxType.Location = new Point(97, 83);
            boxType.Margin = new Padding(4);
            boxType.Name = "boxType";
            boxType.Size = new Size(187, 23);
            boxType.TabIndex = 7;
            boxType.SelectedIndexChanged += boxType_SelectedIndexChanged;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlus.Location = new Point(357, 14);
            btnPlus.Margin = new Padding(4);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(32, 23);
            btnPlus.TabIndex = 12;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnPlus_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(292, 52);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(61, 23);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += RefreshButton_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(292, 83);
            btnTest.Margin = new Padding(4);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(61, 23);
            btnTest.TabIndex = 23;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // boxDevice
            // 
            boxDevice.FormattingEnabled = true;
            boxDevice.Location = new Point(97, 52);
            boxDevice.Margin = new Padding(4);
            boxDevice.Name = "boxDevice";
            boxDevice.Size = new Size(187, 23);
            boxDevice.TabIndex = 6;
            boxDevice.SelectedIndexChanged += boxDevice_SelectedIndexChanged;
            // 
            // btnMinus
            // 
            btnMinus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.Location = new Point(391, 14);
            btnMinus.Margin = new Padding(4);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(32, 23);
            btnMinus.TabIndex = 24;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnMinus_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(97, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(187, 23);
            txtName.TabIndex = 25;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // lblName
            // 
            lblName.Location = new Point(13, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 23);
            lblName.TabIndex = 27;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(lblMidiDevice);
            groupBox1.Controls.Add(lvlType);
            groupBox1.Controls.Add(boxDevice);
            groupBox1.Controls.Add(boxType);
            groupBox1.Controls.Add(btnTest);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(65, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 113);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Properties";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(357, 183);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(66, 40);
            btnOk.TabIndex = 30;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(283, 183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 40);
            btnCancel.TabIndex = 31;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MidiSetUp
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 235);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(groupBox1);
            Controls.Add(btnMinus);
            Controls.Add(btnPlus);
            Controls.Add(boxSelector);
            Controls.Add(lblDevice);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MidiSetUp";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "MIDI Devices";
            FormClosing += MIDISetUp_FormClosing;
            Load += MIDISetUp_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblMidiDevice;
        private System.Windows.Forms.Label lvlType;
        private System.Windows.Forms.ComboBox boxSelector;
        private System.Windows.Forms.ComboBox boxType;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ComboBox boxDevice;
        private Button btnMinus;
        private TextBox txtName;
        private Label lblName;
        private GroupBox groupBox1;
        private Button btnOk;
        private Button btnCancel;
    }
}