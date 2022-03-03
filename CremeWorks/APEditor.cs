using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Windows.Forms;
using static CremeWorks.SysExMan;

namespace CremeWorks
{
    public partial class APEditor : Form
    {

        public Concert _c;
        public Song _s;
        public MIDIDevice _d;
        public int _id;
        private bool _wasListening;

        private IRefacePatch _refaceDat;

        public APEditor(Concert c, Song s, int id)
        {
            InitializeComponent();

            //Load data from old patch
            _c = c;
            _s = s;
            _id = id;
            _d = _c.Devices[2+id];
            CheckForIllegalCrossThreadCalls = false;
            _refaceDat = _s.AutoPatchSlots[id].Patch;

            //Adapt controls
            typeSelector.SelectedIndex = (int?)_refaceDat?.Type ?? 0;
            UpdateControls();

            //Set up MIDI shit
            _c.Connect();
            if (_d.Input == null || _d.Output == null)
            {
                MessageBox.Show("Device not connected yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _wasListening = _d.Input.IsListeningForEvents;
                if (!_d.Input.IsListeningForEvents) _d.Input.StartEventsListening();
                _d.Input.EventReceived += ListenForSysEx;
            }

        }

        private void UpdateControls()
        {
            if ((_refaceDat?.Type ?? 0) != DeviceType.Undefined)
            {
                deviceBox.Visible = true;
                numericUpDown1.Value = _refaceDat.SystemSettings.MIDIChannelTransmit == 0x7F ? 0 : _refaceDat.SystemSettings.MIDIChannelTransmit + 1;
                numericUpDown2.Value = _refaceDat.SystemSettings.MIDIChannelTransmit == 0x10 ? 0 : _refaceDat.SystemSettings.MIDIChannelTransmit + 1;
                numericUpDown3.Value = _refaceDat.SystemSettings.MasterTune;
                comboBox1.SelectedIndex = _refaceDat.SystemSettings.LocalControl;
                numericUpDown4.Value = Math.Max(_refaceDat.SystemSettings.MasterTranspose - 0x40, -12);
                numericUpDown5.Value = _refaceDat.SystemSettings.Tempo;
                numericUpDown7.Value = _refaceDat.SystemSettings.LCDContrast;
                comboBox2.SelectedIndex = _refaceDat.SystemSettings.SustainPedalSelect;
                comboBox3.SelectedIndex = _refaceDat.SystemSettings.AutoPwrOff;
                comboBox4.SelectedIndex = _refaceDat.SystemSettings.SpkOut;

                comboBox5.SelectedIndex = _refaceDat.SystemSettings.MIDICtrl;
                numericUpDown6.Value = Math.Max(_refaceDat.SystemSettings.GlobalPBRange - 0x40, -24);
                comboBox6.SelectedIndex = _refaceDat.SystemSettings.FootSwitchMode;
            } else
                deviceBox.Visible = false;

            //Prepare controls
            voiceBoxCS.Visible = false;
            voiceBoxDX.Visible = false;
            voiceBoxCP.Visible = false;
            fetchVoiceData.Enabled = true;

            if (_refaceDat == null) return;

            switch (_refaceDat.Type)
            {
                case DeviceType.RefaceCS:
                    var cs = ((CSPatch)_refaceDat).VoiceSettings;
                    numericUpDown17.Value = cs.Volume;
                    comboBox11.SelectedIndex = (int)cs.LFOAssign;
                    numericUpDown18.Value = cs.LFODepth;
                    numericUpDown19.Value = cs.LFOSpeed;
                    numericUpDown20.Value = cs.Portamento;
                    comboBox12.SelectedIndex = (int)cs.OSCType;
                    numericUpDown21.Value = cs.OSCTexture;
                    numericUpDown22.Value = cs.OSCMod;
                    numericUpDown23.Value = cs.FilterCutoff;
                    numericUpDown24.Value = cs.FilterResonance;
                    numericUpDown25.Value = cs.EGBalance;
                    numericUpDown26.Value = cs.EGAttack;
                    numericUpDown27.Value = cs.EGDecay;
                    numericUpDown28.Value = cs.EGSustain;
                    numericUpDown29.Value = cs.EGRelease;
                    comboBox13.SelectedIndex = (int)cs.FXType;
                    numericUpDown30.Value = cs.FXDepth;
                    numericUpDown31.Value = cs.FXRate;
                    voiceBoxCS.Visible = true;
                    break;
                case DeviceType.RefaceDX:
                    numericUpDown32.Value = ((DXPatch)_refaceDat).ProgramChangeNr + 1;
                    voiceBoxDX.Visible = true;
                    fetchVoiceData.Enabled = false;
                    break;
                case DeviceType.RefaceCP:
                    var cp = ((CPPatch)_refaceDat).VoiceSettings;
                    numericUpDown8.Value = cp.Volume;
                    comboBox7.SelectedIndex = (int)cp.WaveType;
                    numericUpDown9.Value = cp.Drive;
                    comboBox8.SelectedIndex = (int)cp.EffectAType;
                    numericUpDown10.Value = cp.EffectADepth;
                    numericUpDown11.Value = cp.EffectARate;
                    comboBox9.SelectedIndex = (int)cp.EffectBType;
                    numericUpDown12.Value = cp.EffectBDepth;
                    numericUpDown13.Value = cp.EffectBSpeed;
                    comboBox10.SelectedIndex = (int)cp.EffectCType;
                    numericUpDown14.Value = cp.EffectCDepth;
                    numericUpDown15.Value = cp.EffectCTime;
                    numericUpDown16.Value = cp.ReverbDepth;
                    voiceBoxCP.Visible = true;
                    break;
            }
        }

        private void ListenForSysEx(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType == MidiEventType.ProgramChange && _refaceDat is DXPatch dx)
            {
                //DX program change received
                var pc = (ProgramChangeEvent)e.Event;
                dx.ProgramChangeNr = pc.ProgramNumber;
                UpdateControls();
                return;
            }

            if (e.Event.EventType != MidiEventType.NormalSysEx) return;

            var ev = (NormalSysExEvent)e.Event;
            if (ev.Data.Length == 44)
            {
                //System settings bulk received
                _refaceDat.SystemSettings = StructMarshal<RefaceSystemData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
                UpdateControls();
            } else if (ev.Data.Length == 28 && _refaceDat is CPPatch cp)
            {
                //CP voice data bulk received
                cp.VoiceSettings = StructMarshal<CPPatch.RefaceCPVoiceData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
                UpdateControls();
            }
            else if (ev.Data.Length == 34 && _refaceDat is CSPatch cs)
            {
                //CS voice data bulk received
                cs.VoiceSettings = StructMarshal<CSPatch.RefaceCSVoiceData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
                UpdateControls();
            }
        }

        private void SaveSystemData()
        {
            if (_refaceDat == null) return;
            var sysDat = new RefaceSystemData();
            sysDat.MIDIChannelTransmit = (byte)(numericUpDown1.Value == 0 ? 0x7F : numericUpDown1.Value - 1);
            sysDat.MIDIChannelReceive = (byte)(numericUpDown2.Value == 0 ? 0x10 : numericUpDown2.Value - 1);
            sysDat.MasterTune = (uint)numericUpDown3.Value;
            sysDat.LocalControl = (byte)comboBox1.SelectedIndex;
            sysDat.MasterTranspose = (byte)(numericUpDown4.Value + 0x40);
            sysDat.Tempo = (ushort)numericUpDown5.Value;
            sysDat.LCDContrast = (byte)numericUpDown7.Value;
            sysDat.SustainPedalSelect = (byte)comboBox2.SelectedIndex;
            sysDat.AutoPwrOff = (byte)comboBox3.SelectedIndex;
            sysDat.SpkOut = (byte)comboBox4.SelectedIndex;
            sysDat.MIDICtrl = (byte)comboBox5.SelectedIndex;
            sysDat.GlobalPBRange = (byte)(numericUpDown4.Value + 0x40);
            sysDat.FootSwitchMode = (byte)comboBox6.SelectedIndex;
            _refaceDat.SystemSettings = sysDat;
        }

        private void SaveVoiceData()
        {
            switch(_refaceDat)
            {
                case CSPatch cs:
                    var csDat = new CSPatch.RefaceCSVoiceData();
                    csDat.Volume = (byte)numericUpDown17.Value;
                    csDat.LFOAssign = (CSPatch.RefaceCSLFOAssign)comboBox11.SelectedIndex;
                    csDat.LFODepth = (byte)numericUpDown18.Value;
                    csDat.LFOSpeed = (byte)numericUpDown19.Value;
                    csDat.Portamento = (byte)numericUpDown20.Value;
                    csDat.OSCType = (CSPatch.RefaceCSOSCType)comboBox12.SelectedIndex;
                    csDat.OSCTexture = (byte)numericUpDown21.Value;
                    csDat.OSCMod = (byte)numericUpDown22.Value;
                    csDat.FilterCutoff = (byte)numericUpDown23.Value;
                    csDat.FilterResonance = (byte)numericUpDown24.Value;
                    csDat.EGBalance = (byte)numericUpDown25.Value;
                    csDat.EGAttack = (byte)numericUpDown26.Value;
                    csDat.EGDecay = (byte)numericUpDown27.Value;
                    csDat.EGSustain = (byte)numericUpDown28.Value;
                    csDat.EGRelease = (byte)numericUpDown29.Value;
                    csDat.FXType = (CSPatch.RefaceCSFXType)comboBox13.SelectedIndex;
                    csDat.FXDepth = (byte)numericUpDown30.Value;
                    csDat.FXRate = (byte)numericUpDown31.Value;
                    cs.VoiceSettings = csDat;
                    break;
                case DXPatch dx:
                    dx.ProgramChangeNr = (byte)(numericUpDown32.Value - 1);
                    break;
                case CPPatch cp:
                    var cpDat = new CPPatch.RefaceCPVoiceData();
                    cpDat.Volume = (byte)numericUpDown8.Value;
                    cpDat.WaveType = (CPPatch.RefaceCPWaveType)comboBox7.SelectedIndex;
                    cpDat.Drive = (byte)numericUpDown9.Value;
                    cpDat.EffectAType = (CPPatch.RefaceCPEffectA)comboBox8.SelectedIndex;
                    cpDat.EffectADepth = (byte)numericUpDown10.Value;
                    cpDat.EffectARate = (byte)numericUpDown11.Value;
                    cpDat.EffectBType = (CPPatch.RefaceCPEffectB)comboBox9.SelectedIndex;
                    cpDat.EffectBDepth = (byte)numericUpDown12.Value;
                    cpDat.EffectBSpeed = (byte)numericUpDown13.Value;
                    cpDat.EffectCType = (CPPatch.RefaceCPEffectC)comboBox10.SelectedIndex;
                    cpDat.EffectCDepth = (byte)numericUpDown14.Value;
                    cpDat.EffectCTime = (byte)numericUpDown15.Value;
                    cpDat.ReverbDepth = (byte)numericUpDown16.Value;
                    cp.VoiceSettings = cpDat;
                    break;
            }
        }

        private byte[] CutOffBulkDumpHeader(byte[] dat)
        {
            byte[] res = new byte[dat.Length - 12];
            for (int i = 0; i < res.Length; i++) res[i] = dat[i + 10];
            return res;
        }

        private void button4_Click(object sender, EventArgs e) => SendSystemBulkdumpRequest(_d.Output, _refaceDat?.Type ?? DeviceType.Undefined);
        private void typeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nuType = (DeviceType)typeSelector.SelectedIndex;
            if (_refaceDat == null || _refaceDat.Type != nuType)
            {
                switch (nuType)
                {
                    case DeviceType.RefaceCS:
                        _refaceDat = new CSPatch();
                        break;
                    case DeviceType.RefaceDX:
                        _refaceDat = new DXPatch();
                        break;
                    case DeviceType.RefaceCP:
                        _refaceDat = new CPPatch();
                        break;
                    default:
                        _refaceDat = null;
                        break;
                }

            }
            UpdateControls();
        }

        private void fetchVoiceData_Click(object sender, EventArgs e) => SendVoiceBulkdumpRequest(_d.Output, _refaceDat?.Type ?? DeviceType.Undefined);

        private void SaveStuffWhenClosing(object sender, FormClosingEventArgs e)
        {
            //End MIDI listening
            if (_d.Input != null) _d.Input.EventReceived -= ListenForSysEx;
            //Save data
            SaveSystemData();
            SaveVoiceData();
            _s.AutoPatchSlots[_id] = (true, _refaceDat);
        }

        private void PushSysSettings(object sender, EventArgs e)
        {
            SaveSystemData();
            _refaceDat?.ApplySettings(_d); 
        }

        private void PushVoiceSettings(object sender, EventArgs e)
        {
            SaveVoiceData();
            _refaceDat?.ApplyPatch(_d);
        }
    }
}
