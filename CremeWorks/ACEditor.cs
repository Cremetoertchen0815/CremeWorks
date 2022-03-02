﻿using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CremeWorks.SysExMan;

namespace CremeWorks
{
    public partial class ACEditor : Form
    {

        public Concert _c;
        public MIDIDevice _d;
        private bool _wasListening;

        private IRefaceDevice _refaceDat;

        public ACEditor(Concert c, MIDIDevice d)
        {
            InitializeComponent();
            _c = c;
            _d = d;
            CheckForIllegalCrossThreadCalls = false;
            _refaceDat = _d.RefaceDevice;
            typeSelector.SelectedIndex = (int?)_refaceDat?.Type ?? 0;
            UpdateControls();

            //Set up MIDI shit
            _c.Connect();
            _wasListening = _d.Input.IsListeningForEvents;
            if (!_d.Input.IsListeningForEvents) _d.Input.StartEventsListening();
            _d.Input.EventReceived += ListenForSysEx;

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
                    var cs = ((CS)_refaceDat).VoiceSettings;
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
                    numericUpDown32.Value = ((DX)_refaceDat).ProgramChangeNr + 1;
                    voiceBoxDX.Visible = true;
                    fetchVoiceData.Enabled = false;
                    break;
                case DeviceType.RefaceCP:
                    var cp = ((CP)_refaceDat).VoiceSettings;
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
            if (e.Event.EventType == MidiEventType.ProgramChange && _refaceDat is DX dx)
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
            } else if (ev.Data.Length == 28 && _refaceDat is CP cp)
            {
                //CP voice data bulk received
                cp.VoiceSettings = StructMarshal<CP.RefaceCPVoiceData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
                UpdateControls();
            }
            else if (ev.Data.Length == 34 && _refaceDat is CS cs)
            {
                //CS voice data bulk received
                cs.VoiceSettings = StructMarshal<CS.RefaceCSVoiceData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
                UpdateControls();
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
                        _refaceDat = new CS();
                        break;
                    case DeviceType.RefaceDX:
                        _refaceDat = new DX();
                        break;
                    case DeviceType.RefaceCP:
                        _refaceDat = new CP();
                        break;
                    default:
                        _refaceDat = null;
                        break;
                }

                _d.RefaceDevice = _refaceDat;
            }
            UpdateControls();
        }

        private void fetchVoiceData_Click(object sender, EventArgs e) => SendVoiceBulkdumpRequest(_d.Output, _refaceDat?.Type ?? DeviceType.Undefined);
    }
}
