﻿
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
            this.devicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applySongSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeClientNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectedClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.footSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightingOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.playList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.songTitle = new System.Windows.Forms.Label();
            this.songLyrics = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lightCue = new System.Windows.Forms.ListBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.songKey = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.lblBpm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.devicesToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.configureToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1367, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.configToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.New);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
            // 
            // devicesToolStripMenuItem
            // 
            this.devicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolStripMenuItem1,
            this.connectToolStripMenuItem,
            this.applySongSettingsToolStripMenuItem});
            this.devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            this.devicesToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.devicesToolStripMenuItem.Text = "MIDI";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.configureToolStripMenuItem.Text = "Set Up";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // applySongSettingsToolStripMenuItem
            // 
            this.applySongSettingsToolStripMenuItem.Name = "applySongSettingsToolStripMenuItem";
            this.applySongSettingsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.applySongSettingsToolStripMenuItem.Text = "Apply Device Settings";
            this.applySongSettingsToolStripMenuItem.Click += new System.EventHandler(this.applySongSettingsToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.changeClientNameToolStripMenuItem,
            this.connectedClientsToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // changeClientNameToolStripMenuItem
            // 
            this.changeClientNameToolStripMenuItem.Name = "changeClientNameToolStripMenuItem";
            this.changeClientNameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.changeClientNameToolStripMenuItem.Text = "Change Name";
            // 
            // connectedClientsToolStripMenuItem
            // 
            this.connectedClientsToolStripMenuItem.Name = "connectedClientsToolStripMenuItem";
            this.connectedClientsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.connectedClientsToolStripMenuItem.Text = "Connected Clients";
            // 
            // configureToolStripMenuItem1
            // 
            this.configureToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footSwitchToolStripMenuItem,
            this.lightControllerToolStripMenuItem,
            this.toolStripMenuItem3,
            this.clickOutputToolStripMenuItem,
            this.lightingOutputToolStripMenuItem});
            this.configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            this.configureToolStripMenuItem1.Size = new System.Drawing.Size(67, 24);
            this.configureToolStripMenuItem1.Text = "Config";
            // 
            // footSwitchToolStripMenuItem
            // 
            this.footSwitchToolStripMenuItem.Name = "footSwitchToolStripMenuItem";
            this.footSwitchToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.footSwitchToolStripMenuItem.Text = "Foot Switch";
            this.footSwitchToolStripMenuItem.Click += new System.EventHandler(this.footSwitchToolStripMenuItem_Click);
            // 
            // lightControllerToolStripMenuItem
            // 
            this.lightControllerToolStripMenuItem.Name = "lightControllerToolStripMenuItem";
            this.lightControllerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lightControllerToolStripMenuItem.Text = "Cues";
            this.lightControllerToolStripMenuItem.Click += new System.EventHandler(this.lightControllerToolStripMenuItem_Click);
            // 
            // clickOutputToolStripMenuItem
            // 
            this.clickOutputToolStripMenuItem.Name = "clickOutputToolStripMenuItem";
            this.clickOutputToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clickOutputToolStripMenuItem.Text = "Click Output";
            // 
            // lightingOutputToolStripMenuItem
            // 
            this.lightingOutputToolStripMenuItem.Name = "lightingOutputToolStripMenuItem";
            this.lightingOutputToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lightingOutputToolStripMenuItem.Text = "Lighting Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Playlist:";
            // 
            // playList
            // 
            this.playList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.playList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playList.FormattingEnabled = true;
            this.playList.IntegralHeight = false;
            this.playList.ItemHeight = 25;
            this.playList.Location = new System.Drawing.Point(16, 71);
            this.playList.Margin = new System.Windows.Forms.Padding(4);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(316, 629);
            this.playList.TabIndex = 2;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            this.playList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playList_MouseDown);
            this.playList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playList_MouseMove);
            this.playList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playList_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(14, 708);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewSong);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(89, 708);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.EditSong);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(163, 708);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RemSong);
            // 
            // songTitle
            // 
            this.songTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songTitle.Location = new System.Drawing.Point(341, 30);
            this.songTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(703, 38);
            this.songTitle.TabIndex = 6;
            this.songTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // songLyrics
            // 
            this.songLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songLyrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLyrics.Location = new System.Drawing.Point(341, 71);
            this.songLyrics.Margin = new System.Windows.Forms.Padding(4);
            this.songLyrics.Multiline = true;
            this.songLyrics.Name = "songLyrics";
            this.songLyrics.ReadOnly = true;
            this.songLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.songLyrics.Size = new System.Drawing.Size(699, 629);
            this.songLyrics.TabIndex = 7;
            this.songLyrics.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button12.Location = new System.Drawing.Point(245, 708);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(87, 28);
            this.button12.TabIndex = 17;
            this.button12.Text = "Duplicate";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.DuplicateSong);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1046, 403);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cue Queue:";
            // 
            // lightCue
            // 
            this.lightCue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lightCue.FormattingEnabled = true;
            this.lightCue.IntegralHeight = false;
            this.lightCue.ItemHeight = 16;
            this.lightCue.Location = new System.Drawing.Point(1049, 423);
            this.lightCue.Margin = new System.Windows.Forms.Padding(4);
            this.lightCue.Name = "lightCue";
            this.lightCue.Size = new System.Drawing.Size(300, 276);
            this.lightCue.TabIndex = 22;
            this.lightCue.SelectedIndexChanged += new System.EventHandler(this.lightCue_SelectedIndexChanged);
            this.lightCue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lightCue_MouseDown);
            this.lightCue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lightCue_MouseMove);
            this.lightCue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lightCue_MouseUp);
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.Location = new System.Drawing.Point(1177, 707);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(73, 28);
            this.button13.TabIndex = 25;
            this.button13.Text = "Remove";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Location = new System.Drawing.Point(1113, 707);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(56, 28);
            this.button14.TabIndex = 24;
            this.button14.Text = "Edit";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.Location = new System.Drawing.Point(1050, 707);
            this.button15.Margin = new System.Windows.Forms.Padding(4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(55, 28);
            this.button15.TabIndex = 23;
            this.button15.Text = "Add";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Location = new System.Drawing.Point(1258, 707);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(91, 28);
            this.button10.TabIndex = 26;
            this.button10.Text = "Duplicate";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // songKey
            // 
            this.songKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.songKey.AutoSize = true;
            this.songKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songKey.Location = new System.Drawing.Point(339, 708);
            this.songKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.songKey.Name = "songKey";
            this.songKey.Size = new System.Drawing.Size(0, 25);
            this.songKey.TabIndex = 27;
            // 
            // chatBox
            // 
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.FormattingEnabled = true;
            this.chatBox.IntegralHeight = false;
            this.chatBox.ItemHeight = 16;
            this.chatBox.Location = new System.Drawing.Point(1049, 71);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(305, 276);
            this.chatBox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Chat:";
            // 
            // chatInput
            // 
            this.chatInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chatInput.Location = new System.Drawing.Point(1049, 358);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(207, 22);
            this.chatInput.TabIndex = 30;
            // 
            // btnChatSend
            // 
            this.btnChatSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChatSend.Location = new System.Drawing.Point(1263, 355);
            this.btnChatSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(91, 28);
            this.btnChatSend.TabIndex = 31;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnChatSend_Click);
            // 
            // lblBpm
            // 
            this.lblBpm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBpm.AutoSize = true;
            this.lblBpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpm.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.lblBpm.Location = new System.Drawing.Point(987, 708);
            this.lblBpm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBpm.Name = "lblBpm";
            this.lblBpm.Size = new System.Drawing.Size(0, 25);
            this.lblBpm.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(956, 709);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 24);
            this.panel1.TabIndex = 33;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 6);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnChatSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 743);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBpm);
            this.Controls.Add(this.btnChatSend);
            this.Controls.Add(this.chatInput);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.songKey);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.lightCue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.playList);
            this.Controls.Add(this.songTitle);
            this.Controls.Add(this.songLyrics);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "CremeWorks Stage Controller";
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
        private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox playList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label songTitle;
        private System.Windows.Forms.TextBox songLyrics;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applySongSettingsToolStripMenuItem;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem lightControllerToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lightCue;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label songKey;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.Button btnChatSend;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeClientNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectedClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightingOutputToolStripMenuItem;
        private System.Windows.Forms.Label lblBpm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem footSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

