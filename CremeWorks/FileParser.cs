using CremeWorks.App.Data;
using CremeWorks.App.Data.Patches;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using System.Xml;

namespace CremeWorks.App;
public class FileParser
{
    private const string VERSION = "v1.0-base";

    public static Database? ParseFile(string path)
    {
        var db = new Database();
        var doc = new XmlDocument();
        doc.Load(path);

        var root = doc.DocumentElement;
        if (root?.Name != "cwdb") return null;
        if (root.Attributes["version"]?.Value != VERSION) return null;
        if (bool.TryParse(root.Attributes["binary"]?.Value, out bool binary) && binary)
        {
            // Parse binary data
            return null;
        }

        // Parse cloud id
        if (int.TryParse(root.Attributes["cloudid"]?.Value, out int cloudId)) db.CloudId = cloudId;

        // Parse body
        foreach (XmlNode node in root.ChildNodes)
        {
            switch (node.Name)
            {
                case "devices":
                    foreach (XmlNode deviceNode in node.ChildNodes)
                    {
                        var id = int.Parse(deviceNode.Attributes?["id"]?.Value ?? throw new Exception("Device id cannot be null!"));
                        var name = deviceNode.Attributes["name"]?.Value ?? throw new Exception("Device name cannot be null!");
                        var midiId = deviceNode.Attributes["midiid"]?.Value ?? throw new Exception("Device midi id cannot be null!");
                        var isRemoteSrc = bool.Parse(deviceNode.Attributes["isremote"]?.Value ?? "false");
                        var type = Enum.Parse<MidiDeviceType>(deviceNode.Attributes["type"]?.Value ?? throw new Exception("Device type cannot be null!"));
                        var device = new MidiDevice(name, midiId, isRemoteSrc, type);
                        db.Devices[id] = device;
                    }
                    break;
                case "patches":
                    foreach (XmlNode patchNode in node.ChildNodes)
                    {
                        var id = int.Parse(patchNode.Attributes?["id"]?.Value ?? throw new Exception("Patch id cannot be null!"));
                        var name = patchNode.Attributes["name"]?.Value ?? throw new Exception("Patch name cannot be null!");
                        var type = Enum.Parse<MidiDeviceType>(patchNode.Attributes["type"]?.Value ?? throw new Exception("Patch type cannot be null!"));
                        IDevicePatch devicePatch = type switch
                        {
                            MidiDeviceType.GenericKeyboard => new ProgramChangePatch(name),
                            MidiDeviceType.RefaceCS => new CSPatch(name),
                            MidiDeviceType.RefaceCP => new CPPatch(name),
                            MidiDeviceType.RefaceYC => new YCPatch(name),
                            _ => throw new Exception("Unknown patch type!")
                        };
                        devicePatch.Deserialize(patchNode);

                        db.Patches[id] = devicePatch;
                    }
                    break;
                case "cues":
                    foreach (XmlNode cueNode in node.ChildNodes)
                    {
                        var id = int.Parse(cueNode.Attributes?["id"]?.Value ?? throw new Exception("Cue id cannot be null!"));
                        var name = cueNode.Attributes["name"]?.Value ?? throw new Exception("Cue name cannot be null!");
                        var noteValue = byte.Parse(cueNode.Attributes["note"]?.Value ?? throw new Exception("Cue note value cannot be null!"));
                        db.LightingCues[id] = new LightingCueItem(noteValue, name);
                    }
                    break;
                case "actions":
                    foreach (XmlNode actionNode in node.ChildNodes)
                    {
                        var srcEventType = Enum.Parse<MidiEventType>(actionNode.Attributes?["event"]?.Value ?? throw new Exception("Action source event type cannot be null!"));
                        var srcEventChannel = FourBitNumber.Parse(actionNode.Attributes["channel"]?.Value ?? throw new Exception("Action source event channel cannot be null!"));
                        var srcEventValue = byte.Parse(actionNode.Attributes["value"]?.Value ?? throw new Exception("Action source event value cannot be null!"));
                        var type = Enum.Parse<ControllerActionType>(actionNode.Attributes["type"]?.Value ?? throw new Exception("Action type cannot be null!"));
                        int? arg = int.TryParse(actionNode.Attributes["arg"]?.Value, out var val) ? val : null;
                        db.Actions.Add(new ControllerAction(srcEventType, srcEventChannel, srcEventValue, type, arg));
                    }
                    break;
                case "songs":
                    foreach (XmlNode songNode in node.ChildNodes)
                    {
                        // Parse basic song data
                        var id = int.Parse(songNode.Attributes?["id"]?.Value ?? throw new Exception("Song id cannot be null!"));
                        var song = new Song
                        {
                            Title = songNode.Attributes["title"]?.Value ?? throw new Exception("Song title cannot be null!"),
                            Artist = songNode.Attributes["artist"]?.Value ?? string.Empty,
                            Key = songNode.Attributes["key"]?.Value ?? string.Empty,
                            ExpectedDurationSeconds = int.Parse(songNode.Attributes["duration"]?.Value ?? "0"),
                            Tempo = byte.Parse(songNode.Attributes["tempo"]?.Value ?? "120"),
                            Click = bool.Parse(songNode.Attributes["click"]?.Value ?? "false")
                        };

                        // Parse complex song data
                        foreach (XmlNode subNode in songNode.ChildNodes)
                        {
                            switch (subNode.Name)
                            {
                                case "lyrics":
                                    db.Songs[id].Lyrics = subNode.InnerText;
                                    break;
                                case "instructions":
                                    db.Songs[id].Instructions = subNode.InnerText;
                                    break;
                                case "routing":
                                    foreach (XmlNode routingNode in subNode.ChildNodes)
                                    {
                                        var srcId = int.Parse(routingNode.Attributes?["src"]?.Value ?? throw new Exception("Routing source id cannot be null!"));
                                        var destId = int.Parse(routingNode.Attributes["dest"]?.Value ?? throw new Exception("Routing destination id cannot be null!"));
                                        var type = Enum.Parse<MidiMatrixNodeType>(routingNode.Attributes["type"]?.Value ?? throw new Exception("Routing type cannot be null!"));
                                        db.Songs[id].RoutingOverrides.Add(new MidiMatrixNode(srcId, destId, type));
                                    }
                                    break;
                                case "patches":
                                    foreach (XmlNode patchNode in subNode.ChildNodes)
                                    {
                                        var patchId = int.Parse(patchNode.Attributes?["id"]?.Value ?? throw new Exception("Patch id cannot be null!"));
                                        var deviceId = int.Parse(patchNode.Attributes["device"]?.Value ?? throw new Exception("Patch device id cannot be null!"));
                                        db.Songs[id].Patches.Add(new PatchInstance(patchId, deviceId));
                                    }
                                    break;
                                case "cues":
                                    foreach (XmlNode cueNode in subNode.ChildNodes)
                                    {
                                        var cueId = int.Parse(cueNode.Attributes?["id"]?.Value ?? throw new Exception("Cue id cannot be null!"));
                                        var description = cueNode.Attributes["description"]?.Value ?? string.Empty;
                                        db.Songs[id].Cues.Add(new CueInstance(cueId, description));
                                    }
                                    break;
                                case "macro":
                                    db.Songs[id].ChordMacroSourceDeviceId = int.Parse(subNode.Attributes?["src"]?.Value ?? throw new Exception("Macro source device id cannot be null!"));
                                    db.Songs[id].ChordMacroDestinationDeviceId = int.Parse(subNode.Attributes["dest"]?.Value ?? throw new Exception("Macro destination device id cannot be null!"));
                                    foreach (XmlNode macroNode in subNode.ChildNodes)
                                    {
                                        var name = macroNode.Attributes?["name"]?.Value ?? throw new Exception("Macro name cannot be null!");
                                        var triggerNote = int.Parse(macroNode.Attributes["trigger"]?.Value ?? throw new Exception("Macro trigger note cannot be null!"));
                                        var velocity = int.Parse(macroNode.Attributes["velocity"]?.Value ?? throw new Exception("Macro velocity cannot be null!"));
                                        var notes = macroNode.Attributes["notes"]?.Value.Split(',').Select(int.Parse).ToList() ?? throw new Exception("Macro notes cannot be null!");
                                        db.Songs[id].ChordMacros.Add(new ChordMacro(name, triggerNote, velocity, notes));
                                    }
                                    break;
                            }
                        }

                        db.Songs[id] = song;
                    }
                    break;
                case "playlists":
                    foreach (XmlNode playlistNode in node.ChildNodes)
                    {
                        var playlist = new Playlist
                        {
                            Name = playlistNode.Attributes?["name"]?.Value ?? throw new Exception("Playlist name cannot be null!"),
                            Date = DateOnly.Parse(playlistNode.Attributes["date"]?.Value ?? throw new Exception("Playlist date cannot be null!"))
                        };

                        foreach (XmlNode elementNode in playlistNode.ChildNodes)
                        {
                            var type = Enum.Parse<PlaylistEntryType>(elementNode.Attributes?["type"]?.Value ?? throw new Exception("Playlist entry type cannot be null!"));
                            IPlaylistEntry entry = type switch
                            {
                                PlaylistEntryType.Song => new SongPlaylistEntry(int.Parse(elementNode.Attributes["id"]?.Value ?? throw new Exception("Song id cannot be null!"))),
                                PlaylistEntryType.Marker => MarkerPlaylistEntry.Deserialize(elementNode),
                                _ => throw new Exception("Unknown playlist entry type!")
                            };
                            playlist.Elements.Add(entry);
                        }

                        db.Playlists.Add(playlist);
                    }
                    break;
                case "routing":
                    foreach (XmlNode routingNode in node.ChildNodes)
                    {
                        var srcId = int.Parse(routingNode.Attributes?["src"]?.Value ?? throw new Exception("Routing source id cannot be null!"));
                        var destId = int.Parse(routingNode.Attributes["dest"]?.Value ?? throw new Exception("Routing destination id cannot be null!"));
                        var type = Enum.Parse<MidiMatrixNodeType>(routingNode.Attributes["type"]?.Value ?? throw new Exception("Routing type cannot be null!"));
                        db.DefaultRouting.Add(new MidiMatrixNode(srcId, destId, type));
                    }
                    break;
            }
        }


        return db;
    }

    public static void SaveFile(string path, Database db)
    {
        var doc = new XmlDocument();
        var root = doc.CreateElement("database");
        doc.AppendChild(root);

        doc.Save(path);
    }
}
