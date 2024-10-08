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
        var db = new Database() { FilePath = path };
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

        //Parse last saved
        if (long.TryParse(root.Attributes["lastsaved"]?.Value, out var localdate)) db.LastLocalSave = DateTime.FromBinary(localdate);

        //Parse last server sync
        if (long.TryParse(root.Attributes["lastsynced"]?.Value, out var serverdate)) db.LastServerSync = DateTime.FromBinary(serverdate);

        // Parse body
        ParseXmlBody(root, db);


        return db;
    }

    public static bool ParseFromXmlString(string data, Database db)
    {
        var doc = new XmlDocument();
        doc.LoadXml(data);
        var root = doc.DocumentElement;

        if (root?.Name != "cwdb") return false;
        ParseXmlBody(root, db);

        return true;
    }

    public static void SaveFile(string path, Database db, bool binary = false)
    {
        db.LastLocalSave = DateTime.UtcNow;

        var doc = new XmlDocument();
        var root = doc.CreateElement("cwdb");
        root.SetAttribute("version", VERSION);
        if (db.CloudId.HasValue) root.SetAttribute("cloudid", db.CloudId.Value.ToString());
        root.SetAttribute("lastsaved", db.LastLocalSave.ToBinary().ToString());
        if (db.LastServerSync.HasValue) root.SetAttribute("lastsynced", db.LastServerSync.Value.ToBinary().ToString());
        root.SetAttribute("binary", "false");
        if (binary)
        {
            // Save binary data
            root.SetAttribute("binary", "true");
            return;
        }

        // Save body(XML)
        FillXmlBody(doc, root, db);

        doc.AppendChild(root);

        doc.Save(path);
    }

    public static string GetContentXmlString(Database db)
    {
        var doc = new XmlDocument();
        var root = doc.CreateElement("cwdb");
        FillXmlBody(doc, root, db);
        doc.AppendChild(root);

        return doc.OuterXml;
    }

    private static void ParseXmlBody(XmlElement root, Database db)
    {
        foreach (XmlNode node in root.ChildNodes)
        {
            switch (node.Name)
            {
                case "devices":
                    db.Devices.Clear();
                    foreach (XmlNode deviceNode in node.ChildNodes)
                    {
                        var id = int.Parse(deviceNode.Attributes?["id"]?.Value ?? throw new Exception("Device id cannot be null!"));
                        var name = deviceNode.Attributes["name"]?.Value ?? throw new Exception("Device name cannot be null!");
                        var midiId = deviceNode.Attributes["midiname"]?.Value ?? throw new Exception("Device midi id cannot be null!");
                        var isRemoteSrc = bool.Parse(deviceNode.Attributes["isremote"]?.Value ?? "false");
                        var type = Enum.Parse<MidiDeviceType>(deviceNode.Attributes["type"]?.Value ?? throw new Exception("Device type cannot be null!"));
                        var device = new MidiDevice(name, midiId, isRemoteSrc, type);
                        db.Devices[id] = device;
                    }
                    break;
                case "patches":
                    db.Patches.Clear();
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
                    db.LightingCues.Clear();
                    foreach (XmlNode cueNode in node.ChildNodes)
                    {
                        var id = int.Parse(cueNode.Attributes?["id"]?.Value ?? throw new Exception("Cue id cannot be null!"));
                        var name = cueNode.Attributes["name"]?.Value ?? throw new Exception("Cue name cannot be null!");
                        var noteValue = byte.Parse(cueNode.Attributes["note"]?.Value ?? throw new Exception("Cue note value cannot be null!"));
                        db.LightingCues[id] = new LightingCueItem(noteValue, name);
                    }
                    break;
                case "actions":
                    db.Actions.Clear();
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
                    db.Songs.Clear();
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
                                    song.Lyrics = subNode.InnerText;
                                    break;
                                case "instructions":
                                    song.Instructions = subNode.InnerText;
                                    break;
                                case "routing":
                                    foreach (XmlNode routingNode in subNode.ChildNodes)
                                    {
                                        var srcId = int.Parse(routingNode.Attributes?["src"]?.Value ?? throw new Exception("Routing source id cannot be null!"));
                                        var destId = int.Parse(routingNode.Attributes["dest"]?.Value ?? throw new Exception("Routing destination id cannot be null!"));
                                        var type = Enum.Parse<MidiMatrixNodeType>(routingNode.Attributes["type"]?.Value ?? throw new Exception("Routing type cannot be null!"));
                                        song.RoutingOverrides.Add(new MidiMatrixNode(srcId, destId, type));
                                    }
                                    break;
                                case "patches":
                                    foreach (XmlNode patchNode in subNode.ChildNodes)
                                    {
                                        var patchId = int.Parse(patchNode.Attributes?["id"]?.Value ?? throw new Exception("Patch id cannot be null!"));
                                        var deviceId = int.Parse(patchNode.Attributes["device"]?.Value ?? throw new Exception("Patch device id cannot be null!"));
                                        song.Patches.Add(new PatchInstance(patchId, deviceId));
                                    }
                                    break;
                                case "cues":
                                    foreach (XmlNode cueNode in subNode.ChildNodes)
                                    {
                                        var cueId = int.Parse(cueNode.Attributes?["id"]?.Value ?? throw new Exception("Cue id cannot be null!"));
                                        var description = cueNode.Attributes["description"]?.Value ?? string.Empty;
                                        song.Cues.Add(new CueInstance(cueId, description));
                                    }
                                    break;
                                case "macro":
                                    song.ChordMacroSourceDeviceId = int.Parse(subNode.Attributes?["src"]?.Value ?? "-1");
                                    song.ChordMacroDestinationDeviceId = int.Parse(subNode.Attributes?["dest"]?.Value ?? "-1");
                                    foreach (XmlNode macroNode in subNode.ChildNodes)
                                    {
                                        var name = macroNode.Attributes?["name"]?.Value ?? throw new Exception("Macro name cannot be null!");
                                        var triggerNote = int.Parse(macroNode.Attributes["trigger"]?.Value ?? throw new Exception("Macro trigger note cannot be null!"));
                                        var velocity = int.Parse(macroNode.Attributes["velocity"]?.Value ?? throw new Exception("Macro velocity cannot be null!"));
                                        var notes = macroNode.Attributes["notes"]?.Value.Split(',').Select(int.Parse).ToList() ?? throw new Exception("Macro notes cannot be null!");
                                        song.ChordMacros.Add(new ChordMacro(name, triggerNote, velocity, notes));
                                    }
                                    break;
                            }
                        }

                        db.Songs[id] = song;
                    }
                    break;
                case "playlists":
                    db.Playlists.Clear();
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
                    db.DefaultRouting.Clear();
                    foreach (XmlNode routingNode in node.ChildNodes)
                    {
                        var srcId = int.Parse(routingNode.Attributes?["src"]?.Value ?? throw new Exception("Routing source id cannot be null!"));
                        var destId = int.Parse(routingNode.Attributes["dest"]?.Value ?? throw new Exception("Routing destination id cannot be null!"));
                        var type = Enum.Parse<MidiMatrixNodeType>(routingNode.Attributes["type"]?.Value ?? throw new Exception("Routing type cannot be null!"));
                        db.DefaultRouting.Add(new MidiMatrixNode(srcId, destId, type));
                    }
                    break;
                case "solo":
                    db.SoloModeConfig.Devices.Clear();
                    var fadeRaw = node.Attributes?["fade"]?.Value;
                    db.SoloModeConfig.Enabled = bool.Parse(node.Attributes!["enabled"]?.Value ?? throw new Exception("Solo enabled cannot be null!"));
                    db.SoloModeConfig.CCNumber = byte.Parse(node.Attributes["cc"]?.Value ?? throw new Exception("Solo cc number cannot be null!"));
                    db.SoloModeConfig.DefaultValue = byte.Parse(node.Attributes["regular"]?.Value ?? throw new Exception("Solo regular value cannot be null!"));
                    db.SoloModeConfig.SoloValue = byte.Parse(node.Attributes["solo"]?.Value ?? throw new Exception("Solo solo value cannot be null!"));
                    db.SoloModeConfig.FadeDurationSeconds = fadeRaw is null or "null" ? null : float.Parse(fadeRaw);

                    foreach (XmlNode deviceNode in node.ChildNodes)
                    {
                        if (deviceNode.Name != "device") continue;
                        db.SoloModeConfig.Devices.Add(int.Parse(deviceNode.Attributes!["id"]?.Value ?? throw new Exception("Solo device id cannot be null!")));
                    }
                    break;
            }
        }
    }

    private static void FillXmlBody(XmlDocument doc, XmlElement root, Database db)
    {
        // Save devices
        var devices = doc.CreateElement("devices");
        foreach (var device in db.Devices)
        {
            var deviceNode = doc.CreateElement("device");
            deviceNode.SetAttribute("id", device.Key.ToString());
            deviceNode.SetAttribute("name", device.Value.Name);
            deviceNode.SetAttribute("midiname", device.Value.MidiId);
            deviceNode.SetAttribute("isremote", device.Value.IsRemoteSource.ToString());
            deviceNode.SetAttribute("type", device.Value.Type.ToString());
            devices.AppendChild(deviceNode);
        }
        root.AppendChild(devices);

        // Save patches
        var patches = doc.CreateElement("patches");
        foreach (var patch in db.Patches)
        {
            var patchNode = doc.CreateElement("patch");
            patchNode.SetAttribute("id", patch.Key.ToString());
            patchNode.SetAttribute("name", patch.Value.Name);
            patchNode.SetAttribute("type", patch.Value.DeviceType.ToString());
            patch.Value.Serialize(patchNode);
            patches.AppendChild(patchNode);
        }
        root.AppendChild(patches);

        // Save cues
        var cues = doc.CreateElement("cues");
        foreach (var cue in db.LightingCues)
        {
            var cueNode = doc.CreateElement("cue");
            cueNode.SetAttribute("id", cue.Key.ToString());
            cueNode.SetAttribute("name", cue.Value.Name);
            cueNode.SetAttribute("note", cue.Value.NoteValue.ToString());
            cues.AppendChild(cueNode);
        }
        root.AppendChild(cues);

        // Save actions
        var actions = doc.CreateElement("actions");
        foreach (var action in db.Actions)
        {
            var actionNode = doc.CreateElement("action");
            actionNode.SetAttribute("event", action.SourceEventType.ToString());
            actionNode.SetAttribute("channel", action.SourceEventChannel.ToString());
            actionNode.SetAttribute("value", action.SourceEventValue.ToString());
            actionNode.SetAttribute("type", action.Action.ToString());
            if (action.Argument.HasValue) actionNode.SetAttribute("arg", action.Argument.Value.ToString());
            actions.AppendChild(actionNode);
        }
        root.AppendChild(actions);

        // Save songs
        var songs = doc.CreateElement("songs");
        foreach (var song in db.Songs)
        {
            // Save basic song data
            var songNode = doc.CreateElement("song");
            songNode.SetAttribute("id", song.Key.ToString());
            songNode.SetAttribute("title", song.Value.Title);
            songNode.SetAttribute("artist", song.Value.Artist);
            songNode.SetAttribute("key", song.Value.Key);
            songNode.SetAttribute("duration", song.Value.ExpectedDurationSeconds.ToString());
            songNode.SetAttribute("tempo", song.Value.Tempo.ToString());
            songNode.SetAttribute("click", song.Value.Click.ToString());

            // Save lyrics
            if (!string.IsNullOrWhiteSpace(song.Value.Lyrics))
            {
                var lyrics = doc.CreateElement("lyrics");
                lyrics.InnerText = song.Value.Lyrics;
                songNode.AppendChild(lyrics);
            }

            // Save instructions
            if (!string.IsNullOrWhiteSpace(song.Value.Instructions))
            {
                var instructions = doc.CreateElement("instructions");
                instructions.InnerText = song.Value.Instructions;
                songNode.AppendChild(instructions);
            }

            // Save routing overrides
            if (song.Value.RoutingOverrides.Count > 0)
            {
                var routes = doc.CreateElement("routing");
                foreach (var routingOverride in song.Value.RoutingOverrides)
                {
                    var routingNode = doc.CreateElement("route");
                    routingNode.SetAttribute("src", routingOverride.SourceDeviceId.ToString());
                    routingNode.SetAttribute("dest", routingOverride.DestinationDeviceId.ToString());
                    routingNode.SetAttribute("type", routingOverride.Type.ToString());
                    routes.AppendChild(routingNode);
                }
                songNode.AppendChild(routes);
            }

            // Save patches
            if (song.Value.Patches.Count > 0)
            {
                patches = doc.CreateElement("patches");
                foreach (var patch in song.Value.Patches)
                {
                    var patchNode = doc.CreateElement("patch");
                    patchNode.SetAttribute("id", patch.PatchId.ToString());
                    patchNode.SetAttribute("device", patch.DeviceId.ToString());
                    patches.AppendChild(patchNode);
                }
                songNode.AppendChild(patches);
            }

            // Save cues
            if (song.Value.Cues.Count > 0)
            {
                var songCues = doc.CreateElement("cues");
                foreach (var cue in song.Value.Cues)
                {
                    var cueNode = doc.CreateElement("cue");
                    cueNode.SetAttribute("id", cue.CueId.ToString());
                    cueNode.SetAttribute("description", cue.Description);
                    songCues.AppendChild(cueNode);
                }
                songNode.AppendChild(songCues);
            }

            // Save chord macros
            if (song.Value.ChordMacros.Count > 0)
            {
                var macro = doc.CreateElement("macro");
                if (song.Value.ChordMacroSourceDeviceId < 0) macro.SetAttribute("src", song.Value.ChordMacroSourceDeviceId.ToString());
                if (song.Value.ChordMacroDestinationDeviceId < 0) macro.SetAttribute("dest", song.Value.ChordMacroDestinationDeviceId.ToString());
                foreach (var chordMacro in song.Value.ChordMacros)
                {
                    var macroNode = doc.CreateElement("chord");
                    macroNode.SetAttribute("name", chordMacro.Name);
                    macroNode.SetAttribute("trigger", chordMacro.TriggerNote.ToString());
                    macroNode.SetAttribute("velocity", chordMacro.Velocity.ToString());
                    macroNode.SetAttribute("notes", string.Join(",", chordMacro.PlayNotes));
                    macro.AppendChild(macroNode);
                }
                songNode.AppendChild(macro);
            }

            songs.AppendChild(songNode);
        }
        root.AppendChild(songs);

        // Save playlists
        var playlists = doc.CreateElement("playlists");
        foreach (var playlist in db.Playlists)
        {
            var playlistNode = doc.CreateElement("playlist");
            playlistNode.SetAttribute("name", playlist.Name);
            playlistNode.SetAttribute("date", playlist.Date.ToString());

            foreach (var element in playlist.Elements)
            {
                var elementNode = doc.CreateElement("element");
                elementNode.SetAttribute("type", element.Type.ToString());
                switch (element)
                {
                    case SongPlaylistEntry songEntry:
                        elementNode.SetAttribute("id", songEntry.SongId.ToString());
                        break;
                    case MarkerPlaylistEntry markerEntry:
                        markerEntry.Serialize(elementNode);
                        break;
                }
                playlistNode.AppendChild(elementNode);
            }

            playlists.AppendChild(playlistNode);
        }
        root.AppendChild(playlists);

        // Save default routing
        var routing = doc.CreateElement("routing");
        foreach (var routingOverride in db.DefaultRouting)
        {
            var routingNode = doc.CreateElement("route");
            routingNode.SetAttribute("src", routingOverride.SourceDeviceId.ToString());
            routingNode.SetAttribute("dest", routingOverride.DestinationDeviceId.ToString());
            routingNode.SetAttribute("type", routingOverride.Type.ToString());
            routing.AppendChild(routingNode);
        }
        root.AppendChild(routing);

        // Save solo mode configuration
        var solo = doc.CreateElement("solo");
        solo.SetAttribute("enabled", db.SoloModeConfig.Enabled.ToString());
        solo.SetAttribute("cc", db.SoloModeConfig.CCNumber.ToString());
        solo.SetAttribute("regular", db.SoloModeConfig.DefaultValue.ToString());
        solo.SetAttribute("solo", db.SoloModeConfig.SoloValue.ToString());
        if (db.SoloModeConfig.FadeDurationSeconds.HasValue) solo.SetAttribute("fade", db.SoloModeConfig.FadeDurationSeconds.Value.ToString());
        foreach (var deviceId in db.SoloModeConfig.Devices)
        {
            var deviceNode = doc.CreateElement("device");
            deviceNode.SetAttribute("id", deviceId.ToString());
            solo.AppendChild(deviceNode);
        }
        root.AppendChild(solo);
    }
}
