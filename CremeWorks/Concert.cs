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
        public const int MIN_DEVICE_COUNT = 8;
        public const int PATCH_DEVICE_COUNT = 6;
        public string FilePath;
        public MIDIDevice[] Devices;
        public (MidiEventType, short, byte)[] FootSwitchConfig;
        public List<(string name, byte noteOnNr)> LightingCues;
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

        public static Concert Empty() => new Concert
        {
            Devices = new MIDIDevice[] { new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice() },
            FootSwitchConfig = new (MidiEventType, short, byte)[] { (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1)},
            Playlist = new List<Song>(),
            LightingCues = new List<(string name, byte noteOnNr)>()
        };

        private const int cVersion = 4;
        private const string cHeader = "CW";
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

            if (version <= 4)
            {
                CompatibilityFileParser.LoadFilePreVer5(nu, br, version);
                return nu;
            }

            var devCount = br.ReadInt32();
            nu.Devices = new MIDIDevice[Math.Max(devCount, MIN_DEVICE_COUNT)];
            for (int i = 0; i < MIN_DEVICE_COUNT; i++) nu.Devices[i] = new MIDIDevice() { Name = (i < devCount ? br.ReadString() : null) };
            
            //Foot switch config
            int cnt = br.ReadInt32();
            nu.FootSwitchConfig = new (MidiEventType, short, byte)[6];
            for (int i = 0; i < cnt; i++) nu.FootSwitchConfig[i] = ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());

            //Lighting cues config
            var cueCount = br.ReadInt32();
            for (int i = 0; i < cueCount; i++) nu.LightingCues.Add((br.ReadString(), br.ReadByte()));

            //Playlist
            int count = br.ReadInt32();
            nu.Playlist = new List<Song>();
            for (int i = 0; i < count; i++)
            {
                var nuTitle = br.ReadString();
                var nuArtist = br.ReadString();
                var nuKey = br.ReadString();
                var nuLyrics = br.ReadString();
                var s = new Song
                {
                    Title = nuTitle,
                    Artist = nuArtist,
                    Key = nuKey,
                    Lyrics = nuLyrics,
                    NotePatchMap = new bool[PATCH_DEVICE_COUNT][],
                    CCPatchMap = new bool[PATCH_DEVICE_COUNT][]
                };

                for (int j = 0; j < PATCH_DEVICE_COUNT; j++)
                {
                    s.NotePatchMap[j] = LoadBoolArray(br, PATCH_DEVICE_COUNT);
                    s.CCPatchMap[j] = LoadBoolArray(br, PATCH_DEVICE_COUNT);
                }
                s.NotePatchMap = Convert2DArrayToSize(s.NotePatchMap, PATCH_DEVICE_COUNT);
                s.CCPatchMap = Convert2DArrayToSize(s.CCPatchMap, PATCH_DEVICE_COUNT);

                var autoPatchCount = br.ReadInt32();
                s.AutoPatchSlots = Enumerable.Range(0, Math.Max(autoPatchCount, PATCH_DEVICE_COUNT)).Select(x => ((bool, IRefacePatch))(false, null)).ToArray();
                for (int j = 0; j < autoPatchCount; j++)
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
                        case DeviceType.RefaceYC:
                            var yc = new YCPatch
                            {
                                SystemSettings = StructMarshal<RefaceSystemData>.fromBytes(br.ReadBytes(br.ReadInt32())),
                                VoiceSettings = StructMarshal<YCPatch.RefaceYCVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                            };
                            patch = yc;
                            break;
                        default:
                            patch = null;
                            break;
                    }

                    s.AutoPatchSlots[j] = (enabled, patch);
                }

                //Read lighting cues
                int lightcueLen = br.ReadInt32();
                for (int j = 0; j < lightcueLen; j++) s.CueList.Add((br.ReadString(), br.ReadByte()));

                //Read chord macros
                if (version > 0)
                {
                    s.ChordMacroSrc = br.ReadInt32();
                    s.ChordMacroDst = br.ReadInt32();
                    int macroCount = br.ReadInt32();
                    for (int j = 0; j < macroCount; j++)
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

        public static bool[] LoadBoolArray(BinaryReader br, int count)
        {
            var arr = new bool[PATCH_DEVICE_COUNT];
            for (int i = 0; i < count; i++)
            {
                arr[i] = br.ReadBoolean();
            }
            return arr;
        }

        public static T[][] Convert2DArrayToSize<T>(T[][] orig, int size)
        {
            var res = new T[size][];
            for (int i = 0; i < size; i++)
            {
                var inner = new T[size];
                if (i < orig.Length && orig[i] != null)
                {
                    var origInner = orig[i];
                    for (int j = 0; j < Math.Min(origInner.Length, size); j++) inner[j] = origInner[j];
                }
                res[i] = inner;
            }
            return res;
        }

        public void SaveToFile(string filename)
        {
            var bw = new BinaryWriter(File.OpenWrite(filename));
            FilePath = filename;
            //Misc
            bw.Write(cHeader + cVersion);
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

            //Lighting cues
            bw.Write(LightingCues.Count);
            for (int i = 0; i < LightingCues.Count; i++)
            {
                bw.Write(LightingCues[i].name);
                bw.Write(LightingCues[i].noteOnNr);
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
                for (int j = 0; j < PATCH_DEVICE_COUNT; j++)
                {
                    for (int k = 0; k < PATCH_DEVICE_COUNT; k++) bw.Write(song.NotePatchMap?[j]?[k] ?? false);
                    for (int k = 0; k < PATCH_DEVICE_COUNT; k++) bw.Write(song.CCPatchMap?[j]?[k] ?? false);
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
                        case YCPatch yc:
                            datA = StructMarshal<RefaceSystemData>.getBytes(yc.SystemSettings);
                            datB = StructMarshal<YCPatch.RefaceYCVoiceData>.getBytes(yc.VoiceSettings);
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
                    bw.Write(song.CueList[j].cueNr);
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
