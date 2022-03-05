using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CremeWorks
{
    public class Concert
    {
        public string FilePath;
        public MIDIDevice[] Devices;
        public (MidiEventType, short, byte)[] FootSwitchConfig;
        public QuickAccessConfig QAConfig;
        public LightController LightConfig;
        public List<Song> Playlist;

        public MIDIMatrix MidiMatrix;
        public Action<bool> ConnectionChangeHandler = (x) => { return; };

        public Concert() => MidiMatrix = new MIDIMatrix(this);

        public void Connect()
        {
            for (var i = 0; i < Devices.Length; i++)
            {
                MIDIDevice element = Devices[i];
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
            foreach (MIDIDevice element in Devices)
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
                FootSwitchConfig = new (MidiEventType, short, byte)[] { (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1) },
                Playlist = new List<Song>(),
                QAConfig = new QuickAccessConfig()
            };
            lol.LightConfig = new LightController(lol);
            return lol;
        }

        private const string cHeader = "CW";
        public static Concert LoadFromFile(string filename)
        {
            //Init stuff
            var nu = new Concert();
            var br = new BinaryReader(File.OpenRead(filename));
            //Read data
            if (br.ReadString() != cHeader) throw new Exception("Incorrect file!");
            nu.FilePath = filename;
            nu.Devices = new MIDIDevice[br.ReadInt32()];
            for (var i = 0; i < nu.Devices.Length; i++) nu.Devices[i] = new MIDIDevice() { Name = br.ReadString() };
            //Foot switch config
            var cnt = br.ReadInt32();
            nu.FootSwitchConfig = new (MidiEventType, short, byte)[12];
            for (var i = 0; i < cnt; i++) nu.FootSwitchConfig[i] = ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());
            //QA config
            nu.LightConfig = new LightController(nu);
            for (int i = 0; i < 128; i++)
                {
                    var str = br.ReadString();
                    nu.LightConfig.Names[i] = str == string.Empty ? null : str;
                    nu.LightConfig.ToggleGroups[i] = br.ReadInt32();
                    nu.LightConfig.ResetWhenSongChange[i] = br.ReadBoolean();
                    nu.LightConfig.IsToggleable[i] = br.ReadBoolean();
                }

            //Playlist
            var count = br.ReadInt32();
            nu.Playlist = new List<Song>();
            for (var i = 0; i < count; i++)
            {
                var s = new Song
                {
                    Title = br.ReadString(),
                    Artist = br.ReadString(),
                    Key = br.ReadString(),
                    Lyrics = br.ReadString(),
                    QA = new sbyte[br.ReadInt32()],
                    NoteMap = new bool[4][],
                    CCMap = new bool[4][]
                };
                var byte_Dat = br.ReadBytes(s.QA.Length);
                Buffer.BlockCopy(byte_Dat, 0, s.QA, 0, byte_Dat.Length);
                for (var j = 0; j < 4; j++)
                {
                    s.NoteMap[j] = new bool[] { br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean() };
                    s.CCMap[j] = new bool[] { br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean(), br.ReadBoolean() };
                }
                s.AutoPatchSlots = new (bool, IRefacePatch)[br.ReadInt32()];
                for (var j = 0; j < s.AutoPatchSlots.Length; j++)
                {
                    var enabled = br.ReadBoolean();
                    var type = br.ReadInt32();

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
                nu.Playlist.Add(s);
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
            bw.Write(cHeader);
            bw.Write(Devices.Length);
            for (var i = 0; i < Devices.Length; i++) bw.Write(Devices[i]?.Name ?? string.Empty);
            //Foot switch config
            bw.Write(FootSwitchConfig.Length);
            for (var i = 0; i < FootSwitchConfig.Length; i++)
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
            for (var i = 0; i < Playlist.Count; i++)
            {
                Song song = Playlist[i];
                bw.Write(song.Title);
                bw.Write(song.Artist);
                bw.Write(song.Key);
                bw.Write(song.Lyrics);
                bw.Write(song.QA.Length);
                var byte_dat = new byte[song.QA.Length];
                Buffer.BlockCopy(song.QA, 0, byte_dat, 0, byte_dat.Length);
                bw.Write(byte_dat);
                for (var j = 0; j < 4; j++)
                {
                    for (var k = 0; k < 4; k++) bw.Write(song.NoteMap[j][k]);
                    for (var k = 0; k < 4; k++) bw.Write(song.CCMap[j][k]);
                }
                
                bw.Write(song.AutoPatchSlots.Length);
                for (var j = 0; j < song.AutoPatchSlots.Length; j++)
                {
                    (bool Enabled, IRefacePatch Patch) obj = song.AutoPatchSlots[j];
                    bw.Write(obj.Enabled);
                    bw.Write((int?)obj.Patch?.Type ?? -1);
                    switch (obj.Patch)
                    {
                        case CSPatch cs:
                            var datA = StructMarshal<RefaceSystemData>.getBytes(cs.SystemSettings);
                            var datB = StructMarshal<CSPatch.RefaceCSVoiceData>.getBytes(cs.VoiceSettings);
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
