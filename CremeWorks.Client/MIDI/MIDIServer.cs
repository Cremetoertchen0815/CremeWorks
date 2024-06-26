﻿using TobiasErichsen.teVirtualMIDI;

namespace CremeWorks.Client.MIDI;
public class MIDIServer
{
    private TeVirtualMIDI? _midiDevice = null;

    public bool Create()
    {
        Guid manufacturer = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
        Guid product = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");

        try
        {
            _midiDevice = new TeVirtualMIDI("CremeWorks", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref manufacturer, ref product);
        }
        catch
        {
            _midiDevice = null;
            return false;
        }

        return true;
    }

    public void SendData(byte[] data) => _midiDevice?.sendCommand(data);

    public void Close() => _midiDevice?.shutdown();
}
