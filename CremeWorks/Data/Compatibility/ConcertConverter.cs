using Melanchall.DryWetMidi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Data.Compatibility;
public class ConcertConverter
{
    public static bool Convert(Database db, Concert c, ConcertConversionConfig config, out string? errorMsg)
    {
        //Convert devices
        var deviceMap = new Dictionary<int, int>(); //Maps device index from concert to database index
        var devicesForRemappingRouting = new List<int>();
        for (int i = 0; i < c.MIDIDevices.Length; i++)
        {
            if (c.MIDIDevices[i] == null) continue;

            // If we are not importing devices, we need to find the old device that matches the new one
            var oldId = db.Devices.FirstOrDefault(x => x.Value.MidiId == c.MIDIDevices[i]!).Key;
            if (oldId != 0)
            {
                deviceMap.Add(i, oldId);
                continue;
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

                var toBeRemoved = db.Actions.Where(x => x.SourceEventType == eventType && x.SourceEventChannel == channel && x.SourceEventValue == value).ToArray();
                foreach (var item in toBeRemoved) db.Actions.Remove(item);
                db.Actions.Add(new ControllerAction(eventType, new FourBitNumber(channel), (byte)value, actionType));
            }
        }

        //Convert cues
        var cueMap = new Dictionary<ulong, int>(); //Maps cue index from concert to database id
        foreach (var cue in c.LightingCues)
        {
            // Ignore/remap duplicate cues
            if (db.LightingCues.Any(x => x.Value.NoteValue == cue.NoteValue))
            {
                cueMap[cue.ID] = db.LightingCues.First(x => x.Value.NoteValue == cue.NoteValue).Key;
                continue;
            }

            // Copy over the other cues
            var id = Random.Shared.Next();
            db.LightingCues.Add(id, new LightingCueItem(cue.NoteValue, cue.Name));
            cueMap[cue.ID] = id;
        }

        //Convert songs
        var songMap = new Dictionary<int, int>(); //Maps song index from concert to database id
        int listIndex = -1;
        for (int i = 0; i < c.Playlist.Count; i++)
        {
            var origSong = c.Playlist[i];
            if (origSong is null || origSong.SpecialEvent) continue; //Only use real songs, not special events(now called markers)
            listIndex++;

            var id = Random.Shared.Next();
            var newSong = new Data.Song();
            if (config.SongImportDoubleHandling == SongImportDoubleHandling.KeepBoth || config.SongRemapIds[listIndex] is null)
            {
                songMap.Add(i, id);
                db.Songs.Add(id, newSong);
            }
            else
            {
                id = config.SongRemapIds[listIndex]!.Value;
                songMap.Add(i, id);
                newSong = db.Songs[id];
                if (config.SongImportDoubleHandling == SongImportDoubleHandling.KeepOld) continue;
            }

            //Copy over the song data
            newSong.Title = origSong.Title;
            newSong.Artist = origSong.Artist;
            newSong.Key = origSong.Key;
            newSong.Lyrics = origSong.Lyrics;
            newSong.Instructions = origSong.Instructions;
            newSong.Tempo = origSong.Tempo;
            newSong.Click = origSong.Click;

            newSong.ChordMacros.Clear();
            newSong.ChordMacros.AddRange(origSong.ChordMacros);
            newSong.ChordMacroDestinationDeviceId = deviceMap[origSong.ChordMacroDst];
            newSong.ChordMacroSourceDeviceId = deviceMap[origSong.ChordMacroSrc];

            newSong.Cues.Clear();
            newSong.Cues.AddRange(origSong.CueQueue.Select(x => new CueInstance(cueMap[x.ID], x.comment)));

            newSong.Patches.Clear();
            foreach (var patch in origSong.AutoPatchSlots)
            {

            }





            //Convert default routing and routing overrides if needed
            if (config.DefaultRoutingConversionMethod == DefaultRoutingConversionType.CalculateRoutingFromMajority)
            {
                //Calculate default routing from majority
                var newDefaultRouting = new Dictionary<(int, int), MidiMatrixNodeType>();
                foreach (var source in db.Devices)
                {
                    foreach (var destination in db.Devices)
                    {
                        var defaultValue = db.DefaultRouting.FirstOrDefault(x => x.SourceDeviceId == source.Key && x.DestinationDeviceId == destination.Key).Type;
                        var overrides = db.Songs.Values.Select(x => x.RoutingOverrides.FirstOrDefault(y => y.SourceDeviceId == source.Key && y.DestinationDeviceId == destination.Key)).Select(x => x == default ? defaultValue : x.Type).ToList();
                        var majority = overrides.GroupBy(x => x).MaxBy(x => x.Count())?.Key ?? MidiMatrixNodeType.None;
                        newDefaultRouting.Add((source.Key, destination.Key), majority);
                    }
                }

                //Remap routing overrides
                foreach (var song in db.Songs.Values)
                {
                    var newSongRouting = new Dictionary<(int, int), MidiMatrixNodeType>();
                    foreach (var source in db.Devices)
                    {
                        foreach (var destination in db.Devices)
                        {
                            //Get old value for this routing pair
                            var oldBase = db.DefaultRouting.FirstOrDefault(x => x.SourceDeviceId == source.Key && x.DestinationDeviceId == destination.Key).Type;
                            var hasOverride = song.RoutingOverrides.Any(x => x.SourceDeviceId == source.Key && x.DestinationDeviceId == destination.Key);
                            var oldOverride = hasOverride ? song.RoutingOverrides.First(x => x.SourceDeviceId == source.Key && x.DestinationDeviceId == destination.Key).Type : oldBase;

                            //If the value is the same as the new default, we don't need to add it
                            if (oldOverride == MidiMatrixNodeType.None && !newDefaultRouting.ContainsKey((source.Key, destination.Key))) continue;
                            if (oldOverride == newDefaultRouting[(source.Key, destination.Key)]) continue;
                            newSongRouting.Add((source.Key, destination.Key), oldOverride);
                        }
                    }

                    //Update the song
                    song.RoutingOverrides.Clear();
                    foreach (var item in newSongRouting)
                    {
                        song.RoutingOverrides.Add(new MidiMatrixNode(item.Key.Item1, item.Key.Item2, item.Value));
                    }
                }

                //Update default routing
                db.DefaultRouting.Clear();
                foreach (var item in newDefaultRouting)
                {
                    db.DefaultRouting.Add(new MidiMatrixNode(item.Key.Item1, item.Key.Item2, item.Value));
                }
            }
        }


        errorMsg = null;
        return true;
    }
}
