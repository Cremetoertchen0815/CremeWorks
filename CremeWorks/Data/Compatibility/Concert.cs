using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using System.Diagnostics;

namespace CremeWorks.App.Data.Compatibility
{
    public class Concert
    {
        public const int ALL_DEVICES_COUNT = 7;
        public const int PATCH_DEVICE_COUNT = 6;
        public string?[] MIDIDevices = new string[ALL_DEVICES_COUNT];
        public (MidiEventType, short, byte)[] FootSwitchConfig = new (MidiEventType, short, byte)[6];
        public List<LightingCueItem> LightingCues = [];
        public List<Song> Playlist = [];

        public static Concert Empty => new Concert()
        {
            FootSwitchConfig = [(0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1), (0, 0, 1)]
        };

        private const string cHeader = "CW";
        public static Concert? LoadFromFile(string filename)
        {
            //Init stuff
            var nu = new Concert();
            var br = new BinaryReader(File.OpenRead(filename));
            try
            {
                //Read header
                var version = 0;
                var headerStr = br.ReadString();
                if (!headerStr.StartsWith(cHeader)) throw new Exception("Incorrect file!");
                if (headerStr.Length > 2 && int.TryParse(headerStr[2..], out int v)) version = v;

                if (version <= 4)
                {
                    CompatibilityFileParser.LoadFilePreVer5(ref nu, br, version);
                    return nu;
                }

                for (int i = 0; i < ALL_DEVICES_COUNT; i++) nu.MIDIDevices[i] = br.ReadString();

                //Foot switch config
                int cnt = br.ReadInt32();
                for (int i = 0; i < cnt; i++) nu.FootSwitchConfig[i] = ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());

                //Lighting cues config
                var cueCount = br.ReadInt32();
                for (int i = 0; i < cueCount; i++) nu.LightingCues.Add(new LightingCueItem(Id: br.ReadUInt64(), Name: br.ReadString(), NoteValue: br.ReadByte()));

                //Playlist
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    var s = new Song
                    {
                        Title = br.ReadString(),
                        Artist = br.ReadString(),
                        Key = br.ReadString(),
                        Lyrics = br.ReadString(),
                        Instructions = br.ReadString(),
                        Tempo = br.ReadByte(),
                        Click = br.ReadBoolean(),
                        SpecialEvent = br.ReadBoolean(),
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
                    s.AutoPatchSlots = Enumerable.Range(0, Math.Max(autoPatchCount, PATCH_DEVICE_COUNT)).Select(x => ((bool, IDevicePatch?))(false, null)).ToArray();
                    for (int j = 0; j < autoPatchCount; j++)
                    {
                        bool enabled = br.ReadBoolean();
                        int type = br.ReadInt32();

                        IDevicePatch? patch;
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
                    for (int j = 0; j < lightcueLen; j++) s.CueQueue.Add((br.ReadUInt64(), br.ReadString()));

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
                            s.ChordMacros.Add(new ChordMacro(name, triggerNote, velocity, [.. keys]));
                        }
                    }

                    nu.Playlist.Add(s);

                }

                return nu;
            }
            catch (Exception)
            {
                if (!Debugger.IsAttached) throw;
                return null;
            } finally
            {
                br.Close();
                br.Dispose();
            }

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
    }

}
