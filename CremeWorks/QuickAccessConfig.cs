using Melanchall.DryWetMidi.Core;

namespace CremeWorks
{
    public class QuickAccessConfig
    {
        public string[] PatchNames = { "Quick Access A", "Quick Access B", "Quick Access C", "Quick Access D", "Quick Access E", "Quick Access F", "Quick Access G", "Quick Access H",
                                       "Quick Access I", "Quick Access J", "Quick Access K", "Quick Access L", "Quick Access M", "Quick Access N", "Quick Access O", "Quick Access P"};
        public MidiEventType?[] EventType = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        public byte[] EventValue = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public byte TransmitChannel = 1;
        public QuickAccessSwitchType[] ActionType = { QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle,
                                                      QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle, QuickAccessSwitchType.Toggle};

        public enum QuickAccessSwitchType { Linear, OneShot, Toggle  }
    }
}
