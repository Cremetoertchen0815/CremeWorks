using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks
{
    public static class CompatibilityFileParser
    {

        public const int PATCH_DEVICE_COUNT_PRE3 = 4;

        public static void LoadFilePreVer5(Concert nu, BinaryReader br, int version)
        {

            var devCount = br.ReadInt32();
            nu.Devices = new MIDIDevice[Math.Max(devCount, Concert.MIN_DEVICE_COUNT)];
            for (int i = 0; i < Concert.MIN_DEVICE_COUNT; i++) nu.Devices[i] = new MIDIDevice() { Name = (i < devCount ? br.ReadString() : null) };
            //Foot switch config
            int cnt = br.ReadInt32();
            nu.FootSwitchConfig = new (MidiEventType, short, byte)[13];
            for (int i = 0; i < cnt; i++) nu.FootSwitchConfig[i] = ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());
            //Light config map(obsolete)
            for (int i = 0; i < 128; i++)
            {
                _ = br.ReadString();
                _ = br.ReadInt32();
                _ = br.ReadBoolean();
                _ = br.ReadBoolean();
            }

            //Quick Access - from Version >= 4
            if (version > 3)
            {
                var qaCount = br.ReadInt32();
                _ = br.ReadBytes(qaCount);
            }

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
                    NotePatchMap = new bool[Concert.PATCH_DEVICE_COUNT][],
                    CCPatchMap = new bool[Concert.PATCH_DEVICE_COUNT][]
                };

                //Quick Access - from Version < 4
                if (version < 4)
                {
                    int len = br.ReadInt32();
                    _ = br.ReadBytes(len);
                }

                var patchCount = (version < 3 ? PATCH_DEVICE_COUNT_PRE3 : Concert.PATCH_DEVICE_COUNT);
                for (int j = 0; j < patchCount; j++)
                {
                    s.NotePatchMap[j] = Concert.LoadBoolArray(br, patchCount);
                    s.CCPatchMap[j] = Concert.LoadBoolArray(br, patchCount);
                }
                s.NotePatchMap = Concert.Convert2DArrayToSize(s.NotePatchMap, Concert.PATCH_DEVICE_COUNT);
                s.CCPatchMap = Concert.Convert2DArrayToSize(s.CCPatchMap, Concert.PATCH_DEVICE_COUNT);

                var autoPatchCount = br.ReadInt32();
                s.AutoPatchSlots = Enumerable.Range(0, Math.Max(autoPatchCount, Concert.PATCH_DEVICE_COUNT)).Select(x => ((bool, IRefacePatch))(false, null)).ToArray();
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

                //Read lighting cue
                int lightcueLen = br.ReadInt32();
                for (int j = 0; j < lightcueLen; j++)
                {
                    _ = br.ReadString();
                    for (int k = 0; k < 128; k++) _ = br.ReadInt32();
                }
                nu.Playlist.Add(s);

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
        }
    }
}
