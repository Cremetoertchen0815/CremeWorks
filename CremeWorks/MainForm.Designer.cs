
namespace CremeWorks
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWCDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mIDIDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.playList = new System.Windows.Forms.ListBox();
            this.songTitle = new System.Windows.Forms.Label();
            this.songLyrics = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lightCue = new System.Windows.Forms.ListBox();
            this.songKey = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.songTempo = new System.Windows.Forms.Label();
            this.boxTempo = new System.Windows.Forms.Panel();
            this.csvExportSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.editToolStripMenuItem,
            this.configureToolStripMenuItem1,
            this.serverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem3,
            this.beendenToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.configToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.New);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cWCDateiToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // cWCDateiToolStripMenuItem
            // 
            this.cWCDateiToolStripMenuItem.Name = "cWCDateiToolStripMenuItem";
            this.cWCDateiToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cWCDateiToolStripMenuItem.Text = "CremeWorks Concert (*.csv)";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.setToolStripMenuItem.Text = "Set (*.csv)";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.exportSetToCSVToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Exit";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songsToolStripMenuItem,
            this.playlistsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // songsToolStripMenuItem
            // 
            this.songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            this.songsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.songsToolStripMenuItem.Text = "Songs";
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            // 
            // configureToolStripMenuItem1
            // 
            this.configureToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mIDIDevicesToolStripMenuItem,
            this.footSwitchToolStripMenuItem,
            this.lightControllerToolStripMenuItem});
            this.configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            this.configureToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.configureToolStripMenuItem1.Text = "Settings";
            // 
            // mIDIDevicesToolStripMenuItem
            // 
            this.mIDIDevicesToolStripMenuItem.Name = "mIDIDevicesToolStripMenuItem";
            this.mIDIDevicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mIDIDevicesToolStripMenuItem.Text = "MIDI Devices";
            this.mIDIDevicesToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // footSwitchToolStripMenuItem
            // 
            this.footSwitchToolStripMenuItem.Name = "footSwitchToolStripMenuItem";
            this.footSwitchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.footSwitchToolStripMenuItem.Text = "Foot Switch";
            this.footSwitchToolStripMenuItem.Click += new System.EventHandler(this.footSwitchToolStripMenuItem_Click);
            // 
            // lightControllerToolStripMenuItem
            // 
            this.lightControllerToolStripMenuItem.Name = "lightControllerToolStripMenuItem";
            this.lightControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lightControllerToolStripMenuItem.Text = "Light Cues";
            this.lightControllerToolStripMenuItem.Click += new System.EventHandler(this.lightControllerToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMIDIToolStripMenuItem,
            this.startToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.serverToolStripMenuItem.Text = "Connection";
            // 
            // startMIDIToolStripMenuItem
            // 
            this.startMIDIToolStripMenuItem.Name = "startMIDIToolStripMenuItem";
            this.startMIDIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startMIDIToolStripMenuItem.Text = "MIDI Host";
            this.startMIDIToolStripMenuItem.Click += new System.EventHandler(this.startMIDIToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Remote Server";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Playlist:";
            // 
            // playList
            // 
            this.playList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.playList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playList.FormattingEnabled = true;
            this.playList.IntegralHeight = false;
            this.playList.ItemHeight = 18;
            this.playList.Location = new System.Drawing.Point(12, 58);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(264, 564);
            this.playList.TabIndex = 2;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            // 
            // songTitle
            // 
            this.songTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songTitle.Location = new System.Drawing.Point(280, 24);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(585, 31);
            this.songTitle.TabIndex = 6;
            this.songTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // songLyrics
            // 
            this.songLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songLyrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLyrics.Location = new System.Drawing.Point(281, 58);
            this.songLyrics.Multiline = true;
            this.songLyrics.Name = "songLyrics";
            this.songLyrics.ReadOnly = true;
            this.songLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.songLyrics.Size = new System.Drawing.Size(636, 464);
            this.songLyrics.TabIndex = 7;
            this.songLyrics.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CremeWorks Concert(.cwc)|*.cwc";
            this.openFileDialog1.Title = "Open Concert";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CremeWorks Concert(.cwc)|*.cwc";
            this.saveFileDialog1.Title = "Save Concert";
            // 
            // lightCue
            // 
            this.lightCue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightCue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lightCue.FormattingEnabled = true;
            this.lightCue.IntegralHeight = false;
            this.lightCue.ItemHeight = 18;
            this.lightCue.Location = new System.Drawing.Point(922, 58);
            this.lightCue.Name = "lightCue";
            this.lightCue.Size = new System.Drawing.Size(214, 464);
            this.lightCue.TabIndex = 22;
            this.lightCue.SelectedIndexChanged += new System.EventHandler(this.lightCue_SelectedIndexChanged);
            // 
            // songKey
            // 
            this.songKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.songKey.AutoSize = true;
            this.songKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songKey.Location = new System.Drawing.Point(1006, 536);
            this.songKey.Name = "songKey";
            this.songKey.Size = new System.Drawing.Size(31, 20);
            this.songKey.TabIndex = 27;
            this.songKey.Text = "mn";
            // 
            // chatBox
            // 
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chatBox.FormattingEnabled = true;
            this.chatBox.IntegralHeight = false;
            this.chatBox.ItemHeight = 18;
            this.chatBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.chatBox.Location = new System.Drawing.Point(281, 527);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(636, 93);
            this.chatBox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(925, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cue Queue:";
            // 
            // chatInput
            // 
            this.chatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chatInput.Location = new System.Drawing.Point(281, 626);
            this.chatInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(563, 24);
            this.chatInput.TabIndex = 30;
            // 
            // btnChatSend
            // 
            this.btnChatSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChatSend.Location = new System.Drawing.Point(848, 626);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(68, 23);
            this.btnChatSend.TabIndex = 31;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnChatSend_Click);
            // 
            // songTempo
            // 
            this.songTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.songTempo.AutoSize = true;
            this.songTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songTempo.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.songTempo.Location = new System.Drawing.Point(1030, 562);
            this.songTempo.Name = "songTempo";
            this.songTempo.Size = new System.Drawing.Size(43, 20);
            this.songTempo.TabIndex = 32;
            this.songTempo.Text = "BPM";
            // 
            // boxTempo
            // 
            this.boxTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxTempo.BackColor = System.Drawing.Color.White;
            this.boxTempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxTempo.Location = new System.Drawing.Point(1010, 562);
            this.boxTempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxTempo.Name = "boxTempo";
            this.boxTempo.Size = new System.Drawing.Size(18, 20);
            this.boxTempo.TabIndex = 33;
            // 
            // csvExportSaveFile
            // 
            this.csvExportSaveFile.Filter = "CSV file|*.csv";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "[BACKLOG]"});
            this.comboBox1.Location = new System.Drawing.Point(13, 626);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 26);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.Text = "[BACKLOG]";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(922, 590);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Solo Mode:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(1006, 590);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Off";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(922, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tempo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(922, 536);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Key:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnChatSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 656);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.boxTempo);
            this.Controls.Add(this.songTempo);
            this.Controls.Add(this.btnChatSend);
            this.Controls.Add(this.chatInput);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.songKey);
            this.Controls.Add(this.lightCue);
            this.Controls.Add(this.playList);
            this.Controls.Add(this.songTitle);
            this.Controls.Add(this.songLyrics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CremeWorks Stage Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox playList;
        private System.Windows.Forms.Label songTitle;
        private System.Windows.Forms.TextBox songLyrics;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem lightControllerToolStripMenuItem;
        private System.Windows.Forms.ListBox lightCue;
        private System.Windows.Forms.Label songKey;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.Button btnChatSend;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.Label songTempo;
        private System.Windows.Forms.Panel boxTempo;
        private System.Windows.Forms.ToolStripMenuItem footSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.SaveFileDialog csvExportSaveFile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cWCDateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mIDIDevicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}

