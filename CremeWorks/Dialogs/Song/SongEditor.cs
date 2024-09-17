using CremeWorks.App.Data;
using CremeWorks.Common;

namespace CremeWorks.App.Dialogs
{
    public partial class SongEditor : Form
    {
        private readonly IDataParent _parent;
        private readonly Song _s;
        private readonly int _songId;
        private readonly Metronome _metronome = new Metronome();
        private readonly Dictionary<int, ComboBox> _patchBoxes = [];

        public SongEditor(IDataParent parent, int songId)
        {
            InitializeComponent();
            _parent = parent;
            _songId = songId;
            _s = _parent.Database.Songs[_songId];
            DialogResult = DialogResult.Cancel;
            //_c.MidiMatrix.Unregister();

            //Load data
            txtTitle.Text = _s.Title;
            txtArtist.Text = _s.Artist;
            txtKey.Text = _s.Key;
            txtLyrics.Text = _s.Lyrics;
            txtInstructions.Text = _s.Instructions;
            chkClick.Checked = _s.Click;
            txtBpm.Value = _s.Tempo;
            txtLyrics.Text = _s.Lyrics;

            var duration = TimeSpan.FromSeconds(_s.ExpectedDurationSeconds);
            txtDurationMin.Value = duration.Minutes;
            txtDurationSec.Value = duration.Seconds;

            lstCues.Items.AddRange(_s.Cues.Select(x => new ComboBoxCueItem(x, _parent.Database.LightingCues[x.CueId])).ToArray());

            //Generate comboboxes for device patches
            var patchBaseYPos = 260;
            foreach (var item in _parent.Database.Devices.Where(x => x.Value.IsInstrument))
            {

                var lbl = new Label();
                lbl.Location = new Point(505, patchBaseYPos);
                lbl.Name = "lblPatch" + item.Key;
                lbl.Size = new Size(77, 23);
                lbl.TabIndex = 139;
                lbl.Text = item.Value.Name;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Text = item.Value.Name;
                Controls.Add(lbl);

                var cmbBox = new ComboBox();
                cmbBox.Location = new Point(589, patchBaseYPos);
                cmbBox.Name = "boxPatch" + item.Key;
                cmbBox.Size = new Size(146, 23);
                cmbBox.Items.AddRange(_parent.Database.Patches.Where(x => x.Value.DeviceType == item.Value.Type).Select(x => new ComboBoxPatchItem(x.Key, x.Value.Name)).ToArray());
                cmbBox.SelectedItem = cmbBox.Items.Cast<ComboBoxPatchItem>().FirstOrDefault(x => x.PatchId == _s.Patches.FirstOrDefault(y => y.DeviceId == item.Key).PatchId);
                Controls.Add(cmbBox);
                _patchBoxes.Add(item.Key, cmbBox);

                patchBaseYPos += 29;
            }

            if (_patchBoxes.Count > 0)
            {
                lblDevicePatches.Visible = true;
                lblDevicePatches.Location = new Point(516, patchBaseYPos);
            }

            _metronome.Tick += blinkTimer_Tick;
            _metronome.Start((int)txtBpm.Value);
        }

        private void CloseOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseCancel(object sender, EventArgs e) => Close();

        private void SongEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_c.MidiMatrix.Register();
            if (DialogResult != DialogResult.OK) return; //Don't save changes if aborting

            //Save changes
            _s.Title = txtTitle.Text;
            _s.Artist = txtArtist.Text;
            _s.Key = txtKey.Text;
            _s.Lyrics = txtLyrics.Text;
            _s.Instructions = txtInstructions.Text;
            _s.Click = chkClick.Checked;
            _s.Tempo = (byte)txtBpm.Value;
            _s.ExpectedDurationSeconds = (int)(txtDurationMin.Value * 60 + txtDurationSec.Value);
            _s.Patches.Clear();
            foreach (var item in _patchBoxes)
            {
                if (item.Value.SelectedItem is not ComboBoxPatchItem ca) continue;
                _s.Patches.Add(new PatchInstance { DeviceId = item.Key, PatchId = ca.PatchId });
            }
        }

        private void btnChordMakro_Click(object sender, EventArgs e)
        {
            var edit = new ChordMacroEditor(_parent, _s);
            edit.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => _metronome.Start((int)txtBpm.Value);

        private async void blinkTimer_Tick()
        {
            blinkBox.BackColor = Color.Navy;
            await Task.Delay(50);
            blinkBox.BackColor = Color.White;
        }

        private class ComboBoxPatchItem
        {
            public int PatchId { get; init; }
            public string Name { get; init; }

            public ComboBoxPatchItem(int patchId, string name)
            {
                PatchId = patchId;
                Name = name;
            }

            public override string ToString() => Name;
        }

        private void btnCueAdd_Click(object sender, EventArgs e)
        {
            if (SongCueEditor.AddToCue(_parent, out var cueInstance))
            {
                var cue = _parent.Database.LightingCues[cueInstance.CueId];
                var cbi = new ComboBoxCueItem(cueInstance, cue);
                lstCues.Items.Add(cbi);
            }
        }

        private void btnCueEdit_Click(object sender, EventArgs e)
        {
            if (lstCues.SelectedIndex < 0) return;
            var cbi = (ComboBoxCueItem)lstCues.SelectedItem!;
            var cueInstance = cbi.Instance;

            if (SongCueEditor.EditCue(_parent, ref cueInstance))
            {
                cbi.Instance = cueInstance;

                lstCues.Refresh();
            }

        }

        private void btnCueDuplicate_Click(object sender, EventArgs e)
        {
            if (lstCues.SelectedIndex < 0) return;
            var cbi = (ComboBoxCueItem)lstCues.SelectedItem!;
            var newCbi = new ComboBoxCueItem(cbi.Instance, cbi.LightingCueItem);
            lstCues.Items.Add(newCbi);
        }

        private void btnCueRemove_Click(object sender, EventArgs e)
        {
            if (lstCues.SelectedIndex < 0) return;
            lstCues.Items.RemoveAt(lstCues.SelectedIndex);
        }


        private class ComboBoxCueItem
        {
            public CueInstance Instance { get; set; }
            public LightingCueItem LightingCueItem { get; set; }

            public ComboBoxCueItem(CueInstance instance, LightingCueItem lightingCueItem)
            {
                LightingCueItem = lightingCueItem;
                Instance = instance;
            }

            public override string ToString() => $"{Instance.Description} ({LightingCueItem.Name})";
        }

        private void btnRouting_Click(object sender, EventArgs e) => new SongRoutingEditor(_parent, _s).ShowDialog();
    }
}
