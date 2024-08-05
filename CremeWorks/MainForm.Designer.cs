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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            configToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            importToolStripMenuItem = new ToolStripMenuItem();
            cWCDateiToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            setToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            beendenToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            songsToolStripMenuItem = new ToolStripMenuItem();
            playlistsToolStripMenuItem = new ToolStripMenuItem();
            configureToolStripMenuItem1 = new ToolStripMenuItem();
            mIDIDevicesToolStripMenuItem = new ToolStripMenuItem();
            footSwitchToolStripMenuItem = new ToolStripMenuItem();
            lightControllerToolStripMenuItem = new ToolStripMenuItem();
            serverToolStripMenuItem = new ToolStripMenuItem();
            startMIDIToolStripMenuItem = new ToolStripMenuItem();
            startToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            playList = new ListBox();
            songTitle = new Label();
            songLyrics = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            lightCue = new ListBox();
            songKey = new Label();
            chatBox = new ListBox();
            label3 = new Label();
            chatInput = new TextBox();
            btnChatSend = new Button();
            songTempo = new Label();
            boxTempo = new Panel();
            csvExportSaveFile = new SaveFileDialog();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            label6 = new Label();
            defaultMIDIRoutingToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { configToolStripMenuItem, editToolStripMenuItem, configureToolStripMenuItem1, serverToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1334, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem2, importToolStripMenuItem, exportToolStripMenuItem, toolStripMenuItem3, beendenToolStripMenuItem });
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(37, 20);
            configToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += New;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += Save;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += SaveAs;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(111, 6);
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cWCDateiToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(114, 22);
            importToolStripMenuItem.Text = "Import";
            // 
            // cWCDateiToolStripMenuItem
            // 
            cWCDateiToolStripMenuItem.Name = "cWCDateiToolStripMenuItem";
            cWCDateiToolStripMenuItem.Size = new Size(223, 22);
            cWCDateiToolStripMenuItem.Text = "CremeWorks Concert (*.csv)";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(114, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // setToolStripMenuItem
            // 
            setToolStripMenuItem.Name = "setToolStripMenuItem";
            setToolStripMenuItem.Size = new Size(126, 22);
            setToolStripMenuItem.Text = "Set (*.csv)";
            setToolStripMenuItem.Click += exportSetToCSVToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(111, 6);
            // 
            // beendenToolStripMenuItem
            // 
            beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            beendenToolStripMenuItem.Size = new Size(114, 22);
            beendenToolStripMenuItem.Text = "Exit";
            beendenToolStripMenuItem.Click += beendenToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { songsToolStripMenuItem, playlistsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // songsToolStripMenuItem
            // 
            songsToolStripMenuItem.Name = "songsToolStripMenuItem";
            songsToolStripMenuItem.Size = new Size(180, 22);
            songsToolStripMenuItem.Text = "Songs";
            // 
            // playlistsToolStripMenuItem
            // 
            playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            playlistsToolStripMenuItem.Size = new Size(180, 22);
            playlistsToolStripMenuItem.Text = "Playlists";
            // 
            // configureToolStripMenuItem1
            // 
            configureToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { mIDIDevicesToolStripMenuItem, defaultMIDIRoutingToolStripMenuItem, footSwitchToolStripMenuItem, lightControllerToolStripMenuItem });
            configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            configureToolStripMenuItem1.Size = new Size(61, 20);
            configureToolStripMenuItem1.Text = "Settings";
            // 
            // mIDIDevicesToolStripMenuItem
            // 
            mIDIDevicesToolStripMenuItem.Name = "mIDIDevicesToolStripMenuItem";
            mIDIDevicesToolStripMenuItem.Size = new Size(170, 22);
            mIDIDevicesToolStripMenuItem.Text = "MIDI Devices";
            mIDIDevicesToolStripMenuItem.Click += configureToolStripMenuItem_Click;
            // 
            // footSwitchToolStripMenuItem
            // 
            footSwitchToolStripMenuItem.Name = "footSwitchToolStripMenuItem";
            footSwitchToolStripMenuItem.Size = new Size(170, 22);
            footSwitchToolStripMenuItem.Text = "Controller Actions";
            footSwitchToolStripMenuItem.Click += footSwitchToolStripMenuItem_Click;
            // 
            // lightControllerToolStripMenuItem
            // 
            lightControllerToolStripMenuItem.Name = "lightControllerToolStripMenuItem";
            lightControllerToolStripMenuItem.Size = new Size(170, 22);
            lightControllerToolStripMenuItem.Text = "Light Cues";
            lightControllerToolStripMenuItem.Click += lightControllerToolStripMenuItem_Click;
            // 
            // serverToolStripMenuItem
            // 
            serverToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startMIDIToolStripMenuItem, startToolStripMenuItem });
            serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            serverToolStripMenuItem.Size = new Size(81, 20);
            serverToolStripMenuItem.Text = "Connection";
            // 
            // startMIDIToolStripMenuItem
            // 
            startMIDIToolStripMenuItem.Name = "startMIDIToolStripMenuItem";
            startMIDIToolStripMenuItem.Size = new Size(180, 22);
            startMIDIToolStripMenuItem.Text = "MIDI Host";
            startMIDIToolStripMenuItem.Click += startMIDIToolStripMenuItem_Click;
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(180, 22);
            startToolStripMenuItem.Text = "Remote Server";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 45);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Playlist:";
            // 
            // playList
            // 
            playList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            playList.Font = new Font("Microsoft Sans Serif", 11F);
            playList.FormattingEnabled = true;
            playList.IntegralHeight = false;
            playList.ItemHeight = 18;
            playList.Location = new Point(14, 67);
            playList.Margin = new Padding(4, 3, 4, 3);
            playList.Name = "playList";
            playList.Size = new Size(307, 650);
            playList.TabIndex = 2;
            playList.SelectedIndexChanged += playList_SelectedIndexChanged;
            // 
            // songTitle
            // 
            songTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            songTitle.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            songTitle.Location = new Point(327, 28);
            songTitle.Margin = new Padding(4, 0, 4, 0);
            songTitle.Name = "songTitle";
            songTitle.Size = new Size(682, 36);
            songTitle.TabIndex = 6;
            songTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // songLyrics
            // 
            songLyrics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            songLyrics.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            songLyrics.Location = new Point(328, 67);
            songLyrics.Margin = new Padding(4, 3, 4, 3);
            songLyrics.Multiline = true;
            songLyrics.Name = "songLyrics";
            songLyrics.ReadOnly = true;
            songLyrics.ScrollBars = ScrollBars.Vertical;
            songLyrics.Size = new Size(741, 535);
            songLyrics.TabIndex = 7;
            songLyrics.TextAlign = HorizontalAlignment.Center;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "CremeWorks Concert(.cwc)|*.cwc";
            openFileDialog1.Title = "Open Concert";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "CremeWorks Concert(.cwc)|*.cwc";
            saveFileDialog1.Title = "Save Concert";
            // 
            // lightCue
            // 
            lightCue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lightCue.Font = new Font("Microsoft Sans Serif", 11F);
            lightCue.FormattingEnabled = true;
            lightCue.IntegralHeight = false;
            lightCue.ItemHeight = 18;
            lightCue.Location = new Point(1076, 67);
            lightCue.Margin = new Padding(4, 3, 4, 3);
            lightCue.Name = "lightCue";
            lightCue.Size = new Size(249, 535);
            lightCue.TabIndex = 22;
            lightCue.SelectedIndexChanged += lightCue_SelectedIndexChanged;
            // 
            // songKey
            // 
            songKey.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            songKey.AutoSize = true;
            songKey.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            songKey.Location = new Point(1174, 618);
            songKey.Margin = new Padding(4, 0, 4, 0);
            songKey.Name = "songKey";
            songKey.Size = new Size(31, 20);
            songKey.TabIndex = 27;
            songKey.Text = "mn";
            // 
            // chatBox
            // 
            chatBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatBox.Font = new Font("Microsoft Sans Serif", 11F);
            chatBox.FormattingEnabled = true;
            chatBox.IntegralHeight = false;
            chatBox.ItemHeight = 18;
            chatBox.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F" });
            chatBox.Location = new Point(328, 608);
            chatBox.Margin = new Padding(4, 3, 4, 3);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(741, 107);
            chatBox.TabIndex = 29;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1079, 45);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 28;
            label3.Text = "Cue Queue:";
            // 
            // chatInput
            // 
            chatInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatInput.Font = new Font("Microsoft Sans Serif", 11F);
            chatInput.Location = new Point(328, 722);
            chatInput.Margin = new Padding(2);
            chatInput.Name = "chatInput";
            chatInput.Size = new Size(656, 24);
            chatInput.TabIndex = 30;
            // 
            // btnChatSend
            // 
            btnChatSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChatSend.Location = new Point(989, 722);
            btnChatSend.Margin = new Padding(4, 3, 4, 3);
            btnChatSend.Name = "btnChatSend";
            btnChatSend.Size = new Size(79, 27);
            btnChatSend.TabIndex = 31;
            btnChatSend.Text = "Send";
            btnChatSend.UseVisualStyleBackColor = true;
            btnChatSend.Click += btnChatSend_Click;
            // 
            // songTempo
            // 
            songTempo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            songTempo.AutoSize = true;
            songTempo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            songTempo.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            songTempo.Location = new Point(1202, 648);
            songTempo.Margin = new Padding(4, 0, 4, 0);
            songTempo.Name = "songTempo";
            songTempo.Size = new Size(43, 20);
            songTempo.TabIndex = 32;
            songTempo.Text = "BPM";
            // 
            // boxTempo
            // 
            boxTempo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            boxTempo.BackColor = Color.White;
            boxTempo.BorderStyle = BorderStyle.FixedSingle;
            boxTempo.Location = new Point(1178, 648);
            boxTempo.Margin = new Padding(2);
            boxTempo.Name = "boxTempo";
            boxTempo.Size = new Size(21, 23);
            boxTempo.TabIndex = 33;
            // 
            // csvExportSaveFile
            // 
            csvExportSaveFile.Filter = "CSV file|*.csv";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox1.Font = new Font("Microsoft Sans Serif", 11F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "[BACKLOG]" });
            comboBox1.Location = new Point(15, 722);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(307, 26);
            comboBox1.TabIndex = 34;
            comboBox1.Text = "[BACKLOG]";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.Font = new Font("Microsoft Sans Serif", 11F);
            label4.Location = new Point(1076, 681);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 23);
            label4.TabIndex = 35;
            label4.Text = "Solo Mode:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(1174, 681);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(31, 18);
            label5.TabIndex = 36;
            label5.Text = "Off";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.Font = new Font("Microsoft Sans Serif", 11F);
            label2.Location = new Point(1076, 648);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 23);
            label2.TabIndex = 37;
            label2.Text = "Tempo:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.Font = new Font("Microsoft Sans Serif", 11F);
            label6.Location = new Point(1076, 618);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(96, 23);
            label6.TabIndex = 38;
            label6.Text = "Key:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // defaultMIDIRoutingToolStripMenuItem
            // 
            defaultMIDIRoutingToolStripMenuItem.Name = "defaultMIDIRoutingToolStripMenuItem";
            defaultMIDIRoutingToolStripMenuItem.Size = new Size(170, 22);
            defaultMIDIRoutingToolStripMenuItem.Text = "MIDI Routing";
            // 
            // MainForm
            // 
            AcceptButton = btnChatSend;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 757);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(boxTempo);
            Controls.Add(songTempo);
            Controls.Add(btnChatSend);
            Controls.Add(chatInput);
            Controls.Add(chatBox);
            Controls.Add(label3);
            Controls.Add(songKey);
            Controls.Add(lightCue);
            Controls.Add(playList);
            Controls.Add(songTitle);
            Controls.Add(songLyrics);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "CremeWorks Stage Controller";
            FormClosed += MainForm_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem defaultMIDIRoutingToolStripMenuItem;
    }
}

