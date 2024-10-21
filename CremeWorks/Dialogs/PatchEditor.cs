using CremeWorks.App;
using CremeWorks.App.Data;
using CremeWorks.App.Data.Patches;
using CremeWorks.App.Dialogs.Patch;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using static CremeWorks.App.Reface.CommonHelpers;

namespace CremeWorks
{
    public partial class PatchEditor : Form
    {

        public readonly IDataParent _parent;
        private PatchComboBoxItem? _oldItem = null;

        public PatchEditor(IDataParent parent)
        {
            InitializeComponent();

            _parent = parent;
            boxSelector.Items.AddRange(_parent.Database.Patches.OrderBy(x => x.Value.DeviceType).Select(p => new PatchComboBoxItem(p.Key, p.Value)).ToArray());
            if (boxSelector.Items.Count > 0)
            {
                boxSelector.SelectedIndex = 0;
                UpdateControls();
            }

            if (!parent.MidiManager.IsConnected)
            {
                MessageBox.Show("MIDI devices are not connected. You need to connect to them first if you want to fetch or push voice data.", "No MIDI devices connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void UpdateControls()
        {
            //Disable all controls first
            voiceBoxCS.Visible = false;
            voiceBoxPC.Visible = false;
            voiceBoxCP.Visible = false;
            voiceBoxYC.Visible = false;
            fetchVoiceData.Enabled = false;
            pushVoiceData.Enabled = false;
            boxPlayback.Enabled = false;

            if (boxSelector.SelectedItem is not PatchComboBoxItem item) return;

            //If actual patch was selected, enable controls
            boxPlayback.Enabled = true;

            //Find viable playback devices
            boxPlayback.Items.Clear();
            var devices = _parent.Database.Devices.Where(d => d.Value.Type == item.patch.DeviceType && _parent.MidiManager.TryGetMidiDevicePort(d.Key, out _, out _))
                            .Select(d => new DeviceComboBoxItem(d.Key, d.Value)).ToArray();
            boxPlayback.Items.AddRange(devices);
            if (boxPlayback.Items.Count > 0)
            {
                boxPlayback.SelectedIndex = 0;
                fetchVoiceData.Enabled = true;
                pushVoiceData.Enabled = true;
            }

            switch (item.patch)
            {
                case CSPatch cs:
                    numericUpDown17.Value = cs.VoiceSettings.Volume;
                    comboBox11.SelectedIndex = (int)cs.VoiceSettings.LFOAssign;
                    numericUpDown18.Value = cs.VoiceSettings.LFODepth;
                    numericUpDown19.Value = cs.VoiceSettings.LFOSpeed;
                    numericUpDown20.Value = cs.VoiceSettings.Portamento;
                    comboBox12.SelectedIndex = (int)cs.VoiceSettings.OSCType;
                    numericUpDown21.Value = cs.VoiceSettings.OSCTexture;
                    numericUpDown22.Value = cs.VoiceSettings.OSCMod;
                    numericUpDown23.Value = cs.VoiceSettings.FilterCutoff;
                    numericUpDown24.Value = cs.VoiceSettings.FilterResonance;
                    numericUpDown25.Value = cs.VoiceSettings.EGBalance;
                    numericUpDown26.Value = cs.VoiceSettings.EGAttack;
                    numericUpDown27.Value = cs.VoiceSettings.EGDecay;
                    numericUpDown28.Value = cs.VoiceSettings.EGSustain;
                    numericUpDown29.Value = cs.VoiceSettings.EGRelease;
                    comboBox13.SelectedIndex = (int)cs.VoiceSettings.FXType;
                    numericUpDown30.Value = cs.VoiceSettings.FXDepth;
                    numericUpDown31.Value = cs.VoiceSettings.FXRate;
                    voiceBoxCS.Visible = true;
                    break;
                case ProgramChangePatch pc:
                    numericUpDown32.Value = pc.ProgramChangeNr + 1;
                    voiceBoxPC.Visible = true;
                    fetchVoiceData.Enabled = false;
                    break;
                case CPPatch cp:
                    numericUpDown8.Value = cp.VoiceSettings.Volume;
                    comboBox7.SelectedIndex = (int)cp.VoiceSettings.WaveType;
                    numericUpDown9.Value = cp.VoiceSettings.Drive;
                    comboBox8.SelectedIndex = (int)cp.VoiceSettings.EffectAType;
                    numericUpDown10.Value = cp.VoiceSettings.EffectADepth;
                    numericUpDown11.Value = cp.VoiceSettings.EffectARate;
                    comboBox9.SelectedIndex = (int)cp.VoiceSettings.EffectBType;
                    numericUpDown12.Value = cp.VoiceSettings.EffectBDepth;
                    numericUpDown13.Value = cp.VoiceSettings.EffectBSpeed;
                    comboBox10.SelectedIndex = (int)cp.VoiceSettings.EffectCType;
                    numericUpDown14.Value = cp.VoiceSettings.EffectCDepth;
                    numericUpDown15.Value = cp.VoiceSettings.EffectCTime;
                    numericUpDown16.Value = cp.VoiceSettings.ReverbDepth;
                    voiceBoxCP.Visible = true;
                    break;
                case YCPatch yc:
                    numericUpDown47.Value = yc.VoiceSettings.Volume;
                    comboBox16.SelectedIndex = (int)yc.VoiceSettings.VoiceType;
                    comboBox15.SelectedIndex = (int)yc.VoiceSettings.VibratoChorusSwitch;
                    numericUpDown43.Value = yc.VoiceSettings.VibratoChorusDepth;
                    comboBox14.SelectedIndex = yc.VoiceSettings.PercussionOnOff != 0 ? (int)yc.VoiceSettings.PercussionType + 1 : 0;
                    numericUpDown34.Value = yc.VoiceSettings.PercussionLength;
                    comboBox17.SelectedIndex = (int)yc.VoiceSettings.RotarySpeakerSpeed;
                    numericUpDown39.Value = yc.VoiceSettings.DistortionDrive;
                    numericUpDown38.Value = yc.VoiceSettings.ReverbDepth;

                    trackBarA.Value = 6 - yc.VoiceSettings.Footage16;
                    trackBarB.Value = 6 - yc.VoiceSettings.Footage5_13;
                    trackBarC.Value = 6 - yc.VoiceSettings.Footage8;
                    trackBarD.Value = 6 - yc.VoiceSettings.Footage4;
                    trackBarE.Value = 6 - yc.VoiceSettings.Footage2_23;
                    trackBarF.Value = 6 - yc.VoiceSettings.Footage2;
                    trackBarG.Value = 6 - yc.VoiceSettings.Footage1_35;
                    trackBarH.Value = 6 - yc.VoiceSettings.Footage1_13;
                    trackBarI.Value = 6 - yc.VoiceSettings.Footage1;
                    voiceBoxYC.Visible = true;
                    break;
            }
        }

        private void ListenForSysEx(object? sender, MidiEventReceivedEventArgs e)
        {
            var inputDev = sender as InputDevice;
            var patch = _oldItem?.patch;
            if (patch is null || inputDev is null) return;

            if (e.Event.EventType == MidiEventType.ProgramChange && patch is ProgramChangePatch pc)
            {
                //DX program change received
                var evPc = (ProgramChangeEvent)e.Event;
                pc.ProgramChangeNr = evPc.ProgramNumber;
                UpdateControls();
                return;
            }

            if (e.Event.EventType != MidiEventType.NormalSysEx) return;

            var ev = (NormalSysExEvent)e.Event;
            if (ev.Data.Length == 28 && patch is CPPatch cp)
            {
                //CP voice data bulk received
                cp.VoiceSettings = StructMarshal<CPPatch.RefaceCPVoiceData>.fromBytes(ev.Data[10..^2]);
                UpdateControls();
                inputDev.EventReceived -= ListenForSysEx;
            }
            else if (ev.Data.Length == 34 && patch is CSPatch cs)
            {
                //CS voice data bulk received
                cs.VoiceSettings = StructMarshal<CSPatch.RefaceCSVoiceData>.fromBytes(ev.Data[10..^2]);
                UpdateControls();
                inputDev.EventReceived -= ListenForSysEx;

            }
            else if (ev.Data.Length == 34 && patch is YCPatch yc)
            {
                //CS voice data bulk received
                yc.VoiceSettings = StructMarshal<YCPatch.RefaceYCVoiceData>.fromBytes(ev.Data[10..^2]);
                UpdateControls();
                inputDev.EventReceived -= ListenForSysEx;
            }
        }

        private IDevicePatch? SaveVoiceData()
        {
            if (_oldItem is null) return null;

            switch (_oldItem.patch)
            {
                case CSPatch cs:
                    var csDat = new CSPatch.RefaceCSVoiceData
                    {
                        Volume = (byte)numericUpDown17.Value,
                        LFOAssign = (CSPatch.RefaceCSLFOAssign)comboBox11.SelectedIndex,
                        LFODepth = (byte)numericUpDown18.Value,
                        LFOSpeed = (byte)numericUpDown19.Value,
                        Portamento = (byte)numericUpDown20.Value,
                        OSCType = (CSPatch.RefaceCSOSCType)comboBox12.SelectedIndex,
                        OSCTexture = (byte)numericUpDown21.Value,
                        OSCMod = (byte)numericUpDown22.Value,
                        FilterCutoff = (byte)numericUpDown23.Value,
                        FilterResonance = (byte)numericUpDown24.Value,
                        EGBalance = (byte)numericUpDown25.Value,
                        EGAttack = (byte)numericUpDown26.Value,
                        EGDecay = (byte)numericUpDown27.Value,
                        EGSustain = (byte)numericUpDown28.Value,
                        EGRelease = (byte)numericUpDown29.Value,
                        FXType = (CSPatch.RefaceCSFXType)comboBox13.SelectedIndex,
                        FXDepth = (byte)numericUpDown30.Value,
                        FXRate = (byte)numericUpDown31.Value
                    };
                    cs.VoiceSettings = csDat;
                    break;
                case ProgramChangePatch dx:
                    dx.ProgramChangeNr = (byte)(numericUpDown32.Value - 1);
                    break;
                case CPPatch cp:
                    var cpDat = new CPPatch.RefaceCPVoiceData
                    {
                        Volume = (byte)numericUpDown8.Value,
                        WaveType = (CPPatch.RefaceCPWaveType)comboBox7.SelectedIndex,
                        Drive = (byte)numericUpDown9.Value,
                        EffectAType = (CPPatch.RefaceCPEffectA)comboBox8.SelectedIndex,
                        EffectADepth = (byte)numericUpDown10.Value,
                        EffectARate = (byte)numericUpDown11.Value,
                        EffectBType = (CPPatch.RefaceCPEffectB)comboBox9.SelectedIndex,
                        EffectBDepth = (byte)numericUpDown12.Value,
                        EffectBSpeed = (byte)numericUpDown13.Value,
                        EffectCType = (CPPatch.RefaceCPEffectC)comboBox10.SelectedIndex,
                        EffectCDepth = (byte)numericUpDown14.Value,
                        EffectCTime = (byte)numericUpDown15.Value,
                        ReverbDepth = (byte)numericUpDown16.Value
                    };
                    cp.VoiceSettings = cpDat;
                    break;
                case YCPatch yc:
                    var ycDat = new YCPatch.RefaceYCVoiceData
                    {
                        Volume = (byte)numericUpDown47.Value,
                        VoiceType = (YCPatch.RefaceYCVoiceType)comboBox16.SelectedIndex,
                        VibratoChorusSwitch = (YCPatch.RefaceYCVibratoSwitch)comboBox15.SelectedIndex,
                        VibratoChorusDepth = (byte)numericUpDown43.Value,
                        PercussionOnOff = (byte)(comboBox14.SelectedIndex > 0 ? 1 : 0),
                        PercussionType = (YCPatch.RefaceYCPercussionType)(comboBox14.SelectedIndex > 0 ? comboBox14.SelectedIndex - 1 : 0),
                        PercussionLength = (byte)numericUpDown43.Value,
                        RotarySpeakerSpeed = (YCPatch.RefaceYCRotarySpeakerSetting)comboBox17.SelectedIndex,
                        DistortionDrive = (byte)numericUpDown39.Value,
                        ReverbDepth = (byte)numericUpDown38.Value,
                        Footage16 = (byte)(6 - trackBarA.Value),
                        Footage5_13 = (byte)(6 - trackBarB.Value),
                        Footage8 = (byte)(6 - trackBarC.Value),
                        Footage4 = (byte)(6 - trackBarD.Value),
                        Footage2_23 = (byte)(6 - trackBarE.Value),
                        Footage2 = (byte)(6 - trackBarF.Value),
                        Footage1_35 = (byte)(6 - trackBarG.Value),
                        Footage1_13 = (byte)(6 - trackBarH.Value),
                        Footage1 = (byte)(6 - trackBarI.Value),
                    };
                    yc.VoiceSettings = ycDat;
                    break;
            }

            return _oldItem.patch;
        }

        private void fetchVoiceData_Click(object sender, EventArgs e)
        {
            if (boxPlayback.SelectedItem is not DeviceComboBoxItem dev || !_parent.MidiManager.TryGetMidiDevicePort(dev.deviceId, out var inputDev, out var outputDev)) return;

            var patch = _oldItem?.patch;
            if (patch is null || inputDev is null || outputDev is null) return;

            var refaceType = GetRefaceType(patch.DeviceType);

            inputDev.EventReceived += ListenForSysEx;

            SendVoiceBulkdumpRequest(outputDev, refaceType);
            fetchVoiceData.Enabled = false;
        }

        private void SaveStuffWhenClosing(object sender, FormClosingEventArgs e) => SaveVoiceData();

        private void PushVoiceSettings(object sender, EventArgs e)
        {
            var dev = (DeviceComboBoxItem)boxPlayback.SelectedItem!;
            var voice = SaveVoiceData();
            voice?.ApplyPatch(_parent, dev.deviceId);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var patch = AddPatchForm.ShowNewDialog();
            if (patch != null)
            {
                var nuId = Random.Shared.Next();
                _parent.Database.Patches.Add(nuId, patch);
                var index = boxSelector.Items.Add(new PatchComboBoxItem(nuId, patch));
                boxSelector.SelectedIndex = index;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (boxSelector.SelectedItem is not PatchComboBoxItem item) return;
            _parent.Database.Patches.Remove(item.patchId);
            boxSelector.Items.Remove(item);
            _oldItem = null;
            if (boxSelector.Items.Count > 0)
            {
                boxSelector.SelectedIndex = 0;
                UpdateControls();
            }

            //Remove references to this patch
            foreach (var song in _parent.Database.Songs)
            {
                var remove = song.Value.Patches.Where(p => p.PatchId == item.patchId).ToArray();
                foreach (var p in remove) song.Value.Patches.Remove(p);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (boxSelector.SelectedItem is not PatchComboBoxItem item) return;
            AddPatchForm.ShowRenameDialog(item.patch);
            boxSelector.Items[boxSelector.SelectedIndex] = item;
        }

        private void boxSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveVoiceData();
            UpdateControls();
            _oldItem = boxSelector.SelectedItem as PatchComboBoxItem;
        }

        private void boxPlayback_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dev = boxPlayback.SelectedItem as DeviceComboBoxItem;
            if (dev is null)
            {
                _parent.MidiManager.UpdateMatrix([]);
            }
            else
            {
                _parent.MidiManager.UpdateMatrix([new MidiMatrixNode(dev.deviceId, dev.deviceId, MidiMatrixNodeType.Both)]);
            }
        }

        private record PatchComboBoxItem(int patchId, IDevicePatch patch)
        {
            public override string ToString() => $"{patch.Name} ({patch.DeviceType})";
        }

        private record DeviceComboBoxItem(int deviceId, App.Data.MidiDevice device)
        {
            public override string ToString() => device.Name;
        }
    }
}
