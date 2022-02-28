using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks
{
    public class Concert
    {
        public string FilePath;
        public MIDIDevice[] Devices;
        public (MidiEventType, short, short)[] FootSwitchConfig;
        public object LightingConfig;
        public List<Song> Playlist;

        public MIDIMatrix MidiMatrix;
        public Action<bool> ConnectionChangeHandler = (x) => {return; };

        public Concert() { MidiMatrix = new MIDIMatrix(this); }

        public void Connect()
        {
            foreach (var element in Devices)
            {
                if (element.Name == null || element.Name == string.Empty) continue;
                try
                {
                    if (element.Input == null) element.Input = InputDevice.GetByName(element.Name);
                }
                catch { }
                try
                {
                    if (element.Output == null) element.Output = OutputDevice.GetByName(element.Name);
                }
                catch { }
            }


            ConnectionChangeHandler(true);
        }

        public void Disconnect()
        {
            foreach (var element in Devices)
            {
                if (element.Name == null || element.Name == string.Empty) continue;
                if (element.Input != null) { element.Input.Dispose(); element.Input = null; }
                if (element.Output != null) { element.Output.Dispose(); element.Output = null; }
            }

            ConnectionChangeHandler(false);
        }

        public static Concert Empty()
        {
            var lol = new Concert();
            lol.Devices = new MIDIDevice[] { new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice(), new MIDIDevice() };
            lol.FootSwitchConfig = new (MidiEventType, short, short)[] { (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0) };
            lol.Playlist = new List<Song>();
            return lol;
        }
    }

    public class MIDIDevice
    {
        public InputDevice Input;
        public OutputDevice Output;
        public string Name;
    }
}
