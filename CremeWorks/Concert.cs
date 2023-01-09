using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public class Concert
    {
        public string FilePath;
        public MIDIDevice[] Devices;
        public (MidiEventType, short, byte)[] FootSwitchConfig;
        public LightController LightConfig;
        public List<Song> Playlist;

        public MIDIMatrix MidiMatrix;
        public Action<bool> ConnectionChangeHandler = (x) => { return; };

        public Concert() => MidiMatrix = new MIDIMatrix(this);

        public void Connect()
        {
            for (int i = 0; i < Devices.Length; i++)
            {
                var element = Devices[i];
                if (element.Name == null || element.Name == string.Empty) continue;
                try
                {
                    if (element.Input == null && i != 1) element.Input = InputDevice.GetByName(element.Name);
                }
                catch { MessageBox.Show("Input Device \"" + element.Name + "\" not found! Check connections and reconnect!", "MIDI Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                try
                {
                    if (element.Output == null && i != 0) element.Output = OutputDevice.GetByName(element.Name);
                }
                catch { MessageBox.Show("Output Device \"" + element.Name + "\" not found! Check connections and reconnect!", "MIDI Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            ConnectionChangeHandler(true);
        }

        public void Disconnect()
        {
            MidiMatrix.Unregister();
            foreach (var element in Devices)
            {
                if (element.Name == null || element.Name == string.Empty) continue;
                if (element.Input != null) { element.Input.Dispose(); element.Input = null; }
                if (element.Output != null) { element.Output.Dispose(); element.Output = null; }
            }

            ConnectionChangeHandler(false);
        }

        public static Concert Empty()
        {
            var lol = new Concert
            {
                Devices = new MIDIDevice[] { new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice() },
                FootSwitchConfig = new (MidiEventType, short, byte)[] { (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1) },
                Playlist = new List<Song>()
            };
            lol.LightConfig = new LightController(lol);
            return lol;
        }

        private const string cHeader = "CW";
        private const string cHeaderVersioned = "CW2";
        public static Concert LoadFromFile(string filename)
        {
            //Init stuff
            var nu = new Concert();
            var br = new BinaryReader(File.OpenRead(filename));
            //Read header
            var version = 0;
            var headerStr = br.ReadString();
            if (!headerStr.StartsWith(cHeader)) throw new Exception("Incorrect file!");
            if (headerStr.Length > 2 && int.TryParse(headerStr.Substring(2), out int v)) version = v;
            nu.FilePath = filename;
            nu.Devices = new MIDIDevice[br.ReadInt32()];
            for (int i = 0; i < nu.Devices.Length; i++) nu.Devices[i] = new MIDIDevice() { Name = br.ReadString() };
            //Foot switch config
            int cnt = br.ReadInt32();
            nu.FootSwitchConfig = new (MidiEventType, short, byte)[13];
            for (int i = 0; i < cnt; i++) nu.FootSwitchConfig[i] = ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());
            //QA config
            nu.LightConfig = new LightController(nu);
            for (int i = 0; i < 128; i++)
            {
                string str = br.ReadString();
                nu.LightConfig.Names[i] = str == string.Empty ? null : str;
                nu.LightConfig.ToggleGroups[i] = br.ReadInt32();
                nu.LightConfig.ResetWhenSongChange[i] = br.ReadBoolean();
                nu.LightConfig.IsToggleable[i] = br.ReadBoolean();
            }

            //Playlist
            int count = br.ReadInt32();
            nu.Playlist = new List<Song>();
            for (int i = 0; i < count; i++)
            {
                var s = new Song
                {
                    Title = br.ReadString(),
                    Artist = br.ReadString(),
                    Key = br.ReadString(),
                    Lyrics = br.ReadString(),
                    QA = new sbyte[br.ReadInt32()],
                    NotePatchMap = new bool[4][],
                    CCPatchMap = new bool[4][]
                };
                byte[] byte_Dat = br.ReadBytes(s.QA.Length);
                Buffer.BlockCopy(byte_Dat, 0, s.QA, 0, byte_Dat.Length);
                for (int j = 0; j < 4; j++)
                {
                    s.NotePatchMap[j] = new bool[] { br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean() };
                    s.CCPatchMap[j] = new bool[] { br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean() };
                }
                s.AutoPatchSlots = new (bool, IRefacePatch)[br.ReadInt32()];
                for (int j = 0; j < s.AutoPatchSlots.Length; j++)
                {
                    bool enabled = br.ReadBoolean();
                    int type = br.ReadInt32();

                    IRefacePatch patch;
                    switch ((DeviceType)type)
                    {
                        case DeviceType.RefaceCS:
                            var cs = new CSPatch
                            {
                                SystemSettings = StructMarshal<RefaceSystemData>.fromBytes(br.ReadBytes(br.ReadInt32())),
                                VoiceSettings = StructMarshal<CSPatch.RefaceCSVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                            };
                            patch = cs;
                            break;
                        case DeviceType.RefaceDX:
                            var dx = new DXPatch
                            {
                                SystemSettings = StructMarshal<RefaceSystemData>.fromBytes(br.ReadBytes(br.ReadInt32())),
                                ProgramChangeNr = br.ReadByte()
                            };
                            patch = dx;
                            break;
                        case DeviceType.RefaceCP:
                            var cp = new CPPatch
                            {
                                SystemSettings = StructMarshal<RefaceSystemData>.fromBytes(br.ReadBytes(br.ReadInt32())),
                                VoiceSettings = StructMarshal<CPPatch.RefaceCPVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                            };
                            patch = cp;
                            break;
                        default:
                            patch = null;
                            break;
                    }

                    s.AutoPatchSlots[j] = (enabled, patch);
                }

                //Read lighting cue
                int lightcueLen = br.ReadInt32();
                for (int j = 0; j < lightcueLen; j++)
                {
                    string comment = br.ReadString();
                    var data = new LightSwitchType[128];
                    for (int k = 0; k < 128; k++) data[k] = (LightSwitchType)br.ReadInt32();
                    s.CueList.Add((comment, data));
                }
                nu.Playlist.Add(s);

                //Read chord macros
                if (version > 0)
                {
                    s.ChordMacroSrc = br.ReadInt32();
                    s.ChordMacroDst = br.ReadInt32();
                    int macroCount = br.ReadInt32();
                    for (int j = 0; j < lightcueLen; j++)
                    {
                        string name = br.ReadString();
                        int triggerNote = br.ReadInt32();
                        int velocity = br.ReadInt32();
                        var keys = new int[br.ReadInt32()];
                        for (int k = 0; k < keys.Length; k++) keys[k] = br.ReadInt32();
                        s.ChordMacros.Add((name, triggerNote, velocity, keys.ToList()));
                    }
                }
            }
            br.Close();
            br.Dispose();

            return nu;
        }

        public void SaveToFile(string filename)
        {
            var bw = new BinaryWriter(File.OpenWrite(filename));
            FilePath = filename;
            //Misc
            bw.Write(cHeaderVersioned);
            bw.Write(Devices.Length);
            for (int i = 0; i < Devices.Length; i++) bw.Write(Devices[i]?.Name ?? string.Empty);
            //Foot switch config
            bw.Write(FootSwitchConfig.Length);
            for (int i = 0; i < FootSwitchConfig.Length; i++)
            {
                bw.Write((int)FootSwitchConfig[i].Item1);
                bw.Write(FootSwitchConfig[i].Item2);
                bw.Write(FootSwitchConfig[i].Item3);
            }

            //Lighting
            for (int i = 0; i < 128; i++)
            {
                bw.Write(LightConfig.Names[i] ?? string.Empty);
                bw.Write(LightConfig.ToggleGroups[i]);
                bw.Write(LightConfig.ResetWhenSongChange[i]);
                bw.Write(LightConfig.IsToggleable[i]);
            }

            //Playlist
            bw.Write(Playlist.Count);
            for (int i = 0; i < Playlist.Count; i++)
            {
                var song = Playlist[i];
                bw.Write(song.Title);
                bw.Write(song.Artist);
                bw.Write(song.Key);
                bw.Write(song.Lyrics);
                bw.Write(song.QA.Length);
                byte[] byte_dat = new byte[song.QA.Length];
                Buffer.BlockCopy(song.QA, 0, byte_dat, 0, byte_dat.Length);
                bw.Write(byte_dat);
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++) bw.Write(song.NotePatchMap[j][k]);
                    for (int k = 0; k < 4; k++) bw.Write(song.CCPatchMap[j][k]);
                }

                bw.Write(song.AutoPatchSlots.Length);
                for (int j = 0; j < song.AutoPatchSlots.Length; j++)
                {
                    var obj = song.AutoPatchSlots[j];
                    bw.Write(obj.Enabled);
                    bw.Write((int?)obj.Patch?.Type ?? -1);
                    switch (obj.Patch)
                    {
                        case CSPatch cs:
                            byte[] datA = StructMarshal<RefaceSystemData>.getBytes(cs.SystemSettings);
                            byte[] datB = StructMarshal<CSPatch.RefaceCSVoiceData>.getBytes(cs.VoiceSettings);
                            bw.Write(datA.Length);
                            bw.Write(datA);
                            bw.Write(datB.Length);
                            bw.Write(datB);
                            break;
                        case DXPatch dx:
                            datA = StructMarshal<RefaceSystemData>.getBytes(dx.SystemSettings);
                            bw.Write(datA.Length);
                            bw.Write(datA);
                            bw.Write(dx.ProgramChangeNr);
                            break;
                        case CPPatch cp:
                            datA = StructMarshal<RefaceSystemData>.getBytes(cp.SystemSettings);
                            datB = StructMarshal<CPPatch.RefaceCPVoiceData>.getBytes(cp.VoiceSettings);
                            bw.Write(datA.Length);
                            bw.Write(datA);
                            bw.Write(datB.Length);
                            bw.Write(datB);
                            break;
                        default:
                            break;
                    }
                }

                //Lighting cue
                bw.Write(song.CueList.Count);
                for (int j = 0; j < song.CueList.Count; j++)
                {
                    bw.Write(song.CueList[j].comment);
                    for (int k = 0; k < 128; k++) bw.Write((int)song.CueList[j].data[k]);
                }

                //Write chord macros
                bw.Write(song.ChordMacroSrc);
                bw.Write(song.ChordMacroDst);
                bw.Write(song.ChordMacros.Count);
                for (int j = 0; j < song.ChordMacros.Count; j++)
                {
                    var item = song.ChordMacros[j];
                    bw.Write(item.Name);
                    bw.Write(item.TriggerNote);
                    bw.Write(item.Velocity);
                    bw.Write(item.PlayNotes.Count);
                    for (int k = 0; k < item.PlayNotes.Count; k++) bw.Write(item.PlayNotes[k]);
                }
            }

            bw.Close();
            bw.Dispose();
        }
    }

    public class MIDIDevice
    {
        public InputDevice Input;
        public OutputDevice Output;
        public string Name;
    }
}
