namespace CremeWorks.App.Dialogs;

partial class SongRoutingEditor
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
        dataGridView1 = new DataGridView();
        panel1 = new Panel();
        selSelection = new ComboBox();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dataGridView1.Size = new Size(443, 450);
        dataGridView1.TabIndex = 0;
        dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
        // 
        // panel1
        // 
        panel1.Controls.Add(selSelection);
        panel1.Controls.Add(label1);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 417);
        panel1.Name = "panel1";
        panel1.Size = new Size(443, 33);
        panel1.TabIndex = 1;
        // 
        // selSelection
        // 
        selSelection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        selSelection.FormattingEnabled = true;
        selSelection.Items.AddRange(new object[] { "Notes", "Control Change" });
        selSelection.Location = new Point(61, 5);
        selSelection.Name = "selSelection";
        selSelection.Size = new Size(370, 23);
        selSelection.TabIndex = 1;
        selSelection.Text = "Notes";
        selSelection.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(43, 15);
        label1.TabIndex = 0;
        label1.Text = "Values:";
        // 
        // SongRoutingEditor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(443, 450);
        Controls.Add(panel1);
        Controls.Add(dataGridView1);
        Name = "SongRoutingEditor";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Routing";
        FormClosed += SongRoutingEditor_FormClosed;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Panel panel1;
    private ComboBox selSelection;
    private Label label1;
}