namespace CremeWorks
{
    partial class SongList
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SongList));
            lstSongs = new ListView();
            ArtistColumn = new ColumnHeader();
            TitleColumn = new ColumnHeader();
            IdColumn = new ColumnHeader();
            panel2 = new Panel();
            btnDuplicate = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnCreate = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lstSongs
            // 
            lstSongs.AllowColumnReorder = true;
            lstSongs.Columns.AddRange(new ColumnHeader[] { ArtistColumn, TitleColumn, IdColumn });
            lstSongs.Dock = DockStyle.Fill;
            lstSongs.FullRowSelect = true;
            lstSongs.Location = new Point(93, 0);
            lstSongs.Margin = new Padding(4, 3, 4, 3);
            lstSongs.MultiSelect = false;
            lstSongs.Name = "lstSongs";
            lstSongs.Size = new Size(303, 373);
            lstSongs.Sorting = SortOrder.Ascending;
            lstSongs.TabIndex = 0;
            lstSongs.UseCompatibleStateImageBehavior = false;
            lstSongs.View = View.Details;
            // 
            // ArtistColumn
            // 
            ArtistColumn.DisplayIndex = 1;
            ArtistColumn.Text = "Artist";
            ArtistColumn.Width = 100;
            // 
            // TitleColumn
            // 
            TitleColumn.DisplayIndex = 0;
            TitleColumn.Text = "Title";
            TitleColumn.Width = 100;
            // 
            // IdColumn
            // 
            IdColumn.Text = "Id";
            IdColumn.Width = 99;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDuplicate);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnCreate);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(93, 373);
            panel2.TabIndex = 2;
            // 
            // btnDuplicate
            // 
            btnDuplicate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDuplicate.Location = new Point(4, 118);
            btnDuplicate.Margin = new Padding(4, 3, 4, 3);
            btnDuplicate.Name = "btnDuplicate";
            btnDuplicate.Size = new Size(86, 51);
            btnDuplicate.TabIndex = 4;
            btnDuplicate.Text = "Duplicate";
            btnDuplicate.UseVisualStyleBackColor = true;
            btnDuplicate.Click += btnDuplicate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.Location = new Point(4, 175);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 51);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEdit.Location = new Point(4, 61);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 51);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCreate.Location = new Point(4, 3);
            btnCreate.Margin = new Padding(4, 3, 4, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(86, 51);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // SongList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 373);
            Controls.Add(lstSongs);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(412, 4000);
            MinimumSize = new Size(412, 269);
            Name = "SongList";
            Text = "Songs";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lstSongs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader ArtistColumn;
        private Button btnDuplicate;
    }
}