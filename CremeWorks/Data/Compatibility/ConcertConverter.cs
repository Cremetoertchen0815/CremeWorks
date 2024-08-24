using Melanchall.DryWetMidi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Data.Compatibility;
public class ConcertConverter
{
    public static bool Convert(ref Database db, Concert c, ConcertConversionConfig config, out string? errorMsg)
    {
        if (config.SongOverride == ConversionOverrideType.CreateNew)
        {
            db = new Database();
        }

        //Convert devices
        var deviceMap = new Dictionary<int, int>(); //Maps device index from concert to database index
        var devicesForRemappingRouting = new List<int>();
        for (int i = 0; i < c.MIDIDevices.Length; i++)
        {
            if (c.MIDIDevices[i] == null) continue;

            // If we are not importing devices, we need to find the old device that matches the new one
            if (!config.ImportDevices)
            {

                var oldId = db.Devices.FirstOrDefault(x => x.Value.MidiId == c.MIDIDevices[i]!).Key;
                if (oldId == 0)
                {
                    errorMsg = $"No matching device found for {c.MIDIDevices[i]}";
                    return false;
                }
                deviceMap.Add(i, oldId);
            }

            // We are importing devices, so we need to create new ones
            MidiDeviceType type = i == 0 ? MidiDeviceType.GenericController : c.MIDIDevices[i] switch
            {
                "reface CS" => MidiDeviceType.RefaceCS,
                "reface CP" => MidiDeviceType.RefaceCP,
                "reface YC" => MidiDeviceType.RefaceYC,
                _ => MidiDeviceType.GenericKeyboard
            };

            var id = Random.Shared.Next();
            db.Devices.Add(id, new MidiDevice(c.MIDIDevices[i]!, c.MIDIDevices[i]!, false, type));
            deviceMap.Add(i, id);

            // Add loopback to default routing if needed
            if (config.DefaultRoutingConversionMethod == DefaultRoutingConversionType.GenerateLoopbackForNewDevices)
            {
                db.DefaultRouting.Add(new MidiMatrixNode(id, id, MidiMatrixNodeType.Both));
            }
        }

        //Convert actions
        if (config.ImportActions)
        {
            for (int i = 0; i < c.FootSwitchConfig.Length; i++)
            {
                var (eventType, value, channel) = c.FootSwitchConfig[i];
                ControllerActionType actionType = i switch
                {
                    0 => ControllerActionType.NextSong,
                    1 => ControllerActionType.PrevSong,
                    2 => ControllerActionType.ScrollUp,
                    3 => ControllerActionType.ScrollDown,
                    4 => ControllerActionType.CueBack,
                    5 => ControllerActionType.CueAdvance,
                    _ => ControllerActionType.Undefined
                };

                db.Actions.Add(new ControllerAction(eventType, new FourBitNumber(channel), (byte)value, actionType));
            }
        }

        //Convert cues
        var cueMap = new Dictionary<int, int>(); //Maps cue index from concert to database index
        foreach (var cue in c.LightingCues)
        {
            // Ignore/remap duplicate cues
            if (db.LightingCues.ContainsKey(cue.Key)) continue;
            if (db.LightingCues.Any(x => x.Value.NoteValue == cue.Value.NoteValue))
            {
                cueMap[cue.Key] = db.LightingCues.First(x => x.Value.NoteValue == cue.Value.NoteValue).Key;
                continue;
            }

            // Copy over the other cues
            db.LightingCues.Add(cue.Key, new LightingCueItem(cue.Value.NoteValue, cue.Value.Name));
            cueMap[cue.Key] = cue.Key;
        }

        //Convert songs
        var songMap = new Dictionary<int, int>(); //Maps song index from concert to database index
        for (int i = 0; i < c.Playlist.Count; i++)
        {
            var origSong = c.Playlist[i];
            if (origSong is null || origSong.SpecialEvent) continue; //Only use real songs, not special events(now called markers)

            var id = Random.Shared.Next();
            var newSong = new Data.Song();
            if (config.SongImportDoubleHandling == SongImportDoubleHandling.KeepBoth || config.SongRemapIds[i] is null)
            {
                songMap.Add(i, id);
                db.Songs.Add(id, newSong);
            }
            else
            {
                id = config.SongRemapIds[i]!.Value;
                songMap.Add(i, id);
                newSong = db.Songs[id];
                if (config.SongImportDoubleHandling == SongImportDoubleHandling.KeepOld) continue;
            }

            //Copy over the song data

        }


        errorMsg = null;
        return false;
    }
}
