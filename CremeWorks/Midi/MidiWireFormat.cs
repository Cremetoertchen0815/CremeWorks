using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Midi;

/// <summary>
/// Translates between DryWetMIDI events and the raw bytes that are sent over the wire.
/// DryWetMIDI's converters use the SMF layout for system exclusive messages (a length is written
/// after the 0xF0 status byte), which is not valid on a MIDI cable, so those are handled manually.
/// </summary>
internal static class MidiWireFormat
{
    private const byte SysExStart = 0xF0;
    private const byte SysExEnd = 0xF7;

    public static byte[] ToBytes(MidiEvent e, MidiEventToBytesConverter converter)
    {
        if (e is not NormalSysExEvent sysEx) return converter.Convert(e);

        var data = sysEx.Data ?? [];
        var bytes = new byte[data.Length + 1];
        bytes[0] = SysExStart;
        data.CopyTo(bytes, 1);
        return bytes;
    }

    public static List<MidiEvent> FromBytes(byte[] data, int start, int length, BytesToMidiEventConverter converter)
    {
        var events = new List<MidiEvent>(1);
        var end = Math.Min(start + length, data.Length);
        var pos = start;

        while (pos < end)
        {
            var status = data[pos];
            if (status < 0x80) break; //Running status is not supported by any of the backends

            if (status == SysExStart)
            {
                var dataEnd = Array.IndexOf(data, SysExEnd, pos + 1, end - pos - 1);
                if (dataEnd < 0) dataEnd = end - 1;
                events.Add(new NormalSysExEvent(data[(pos + 1)..(dataEnd + 1)]));
                pos = dataEnd + 1;
                continue;
            }

            var size = Math.Min(GetMessageSize(status), end - pos);
            try
            {
                events.Add(converter.Convert(data, pos, size));
            }
            catch (Exception)
            {
                //Ignore malformed messages instead of killing the listening thread
            }
            pos += size;
        }

        return events;
    }

    private static int GetMessageSize(byte status) => (status & 0xF0) switch
    {
        0xC0 or 0xD0 => 2, //Program change, channel aftertouch
        0xF0 => status switch
        {
            0xF1 or 0xF3 => 2, //MIDI time code, song select
            0xF2 => 3, //Song position pointer
            _ => 1, //System real time messages
        },
        _ => 3, //Note on/off, aftertouch, control change, pitch bend
    };
}
