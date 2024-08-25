using CremeWorks.App.Data.Patches;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Data.Compatibility;

public static class CompatibilityFileParser
{
    public const int ALL_DEVICES_COUNT_PRE5 = 8;
    public const int PATCH_DEVICE_COUNT_PRE3 = 4;

    public static void LoadFilePreVer5(ref Concert? nu, BinaryReader br, int version)
    {
        if (version == 0)
        {
            MessageBox.Show("Version 0 files cannot be loaded anymore!", "Error Loading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            nu = null;
            return;
        }

        if (nu is null) return;

        var lightDevice = true;
        var devCount = br.ReadInt32();
        nu.MIDIDevices = new string[Math.Max(devCount, ALL_DEVICES_COUNT_PRE5) - 1];
        for (int i = 0; i < nu.MIDIDevices.Length; i++)
        {
            //Don't read lighting device as it was removed in version 5
            if (i == 1 && lightDevice)
            {
                _ = br.ReadString();
                lightDevice = false;
                i--;
                continue;
            }
            nu.MIDIDevices[i] = i < devCount ? br.ReadString() : null;
        }

        //Foot switch config
        int cnt = br.ReadInt32();
        nu.FootSwitchConfig = new (MidiEventType, short, byte)[6];
        for (int i = 0; i < cnt; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                    nu.FootSwitchConfig[i] = ReadFootSwitchItem(br);
                    break;
                case 3:
                case 4:
                    nu.FootSwitchConfig[i - 1] = ReadFootSwitchItem(br);
                    break;
                case 11:
                case 12:
                    nu.FootSwitchConfig[i - 7] = ReadFootSwitchItem(br);
                    break;
                default:
                    _ = ReadFootSwitchItem(br);
                    break;
            }
        }
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
            s.AutoPatchSlots = Enumerable.Range(0, Math.Max(autoPatchCount, Concert.PATCH_DEVICE_COUNT)).Select(x => ((bool, IDevicePatch?))(false, null)).ToArray();

            var csPatchCount = 1;
            var dxPatchCount = 1;
            var cpPatchCount = 1;
            var ycPatchCount = 1;
            for (int j = 0; j < autoPatchCount; j++)
            {
                bool enabled = br.ReadBoolean();
                int type = br.ReadInt32();

                IDevicePatch? patch = null;
                switch ((OldDeviceType)type)
                {
                    case OldDeviceType.RefaceCS:
                        _ = br.ReadBytes(br.ReadInt32()); //System settings(obsolete)
                        var cs = new CSPatch($"Reface CS Patch #{csPatchCount++}")
                        {
                            VoiceSettings = StructMarshal<CSPatch.RefaceCSVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                        };
                        patch = cs;
                        break;
                    case OldDeviceType.RefaceDX:
                        _ = br.ReadBytes(br.ReadInt32());
                        var dx = new ProgramChangePatch($"Reface DX Patch #{dxPatchCount++}")
                        {
                            ProgramChangeNr = br.ReadByte()
                        };
                        patch = dx;
                        break;
                    case OldDeviceType.RefaceCP:
                        _ = br.ReadBytes(br.ReadInt32());
                        var cp = new CPPatch($"Reface CP Patch #{cpPatchCount++}")
                        {
                            VoiceSettings = StructMarshal<CPPatch.RefaceCPVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                        };
                        patch = cp;
                        break;
                    case OldDeviceType.RefaceYC:
                        _ = br.ReadBytes(br.ReadInt32());
                        var yc = new YCPatch($"Reface YC Patch #{ycPatchCount++}")
                        {
                            VoiceSettings = StructMarshal<YCPatch.RefaceYCVoiceData>.fromBytes(br.ReadBytes(br.ReadInt32()))
                        };
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
        br.Close();
        br.Dispose();
    }

    private static (MidiEventType, short, byte) ReadFootSwitchItem(BinaryReader br) => ((MidiEventType)br.ReadInt32(), br.ReadInt16(), br.ReadByte());
}