using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks.App;
public class SoloManager
{
    private readonly IDataParent _dataParent;
    private bool _enabled;
    private bool _soloMode;
    private OutputDevice[] _outputDevices = [];

    public SoloManager(IDataParent dataParent)
    {
        _dataParent = dataParent;
        _dataParent.MidiManager.ControllerActionExecuted += HandleSolo;
        UpdateState();
    }

    public void UpdateState()
    {
        Active = false;
        _outputDevices = _dataParent.Database.SoloModeConfig.Devices.Select(x => _dataParent.MidiManager.TryGetMidiDevicePort(x, out _, out var device) ? device : null).Where(x => x is not null).Select(x => x!).ToArray();
        _enabled = _dataParent.Database.SoloModeConfig.Enabled;
    }

    private void HandleSolo(ControllerActionType action, bool? argument)
    {
        if (action != ControllerActionType.SoloMode) return;
        Active = argument ?? !_soloMode;
    }

    public bool Active
    {
        get => _soloMode;
        set
        {
            if (!_enabled) return;
            var soloValue = value ? _dataParent.Database.SoloModeConfig.SoloValue : _dataParent.Database.SoloModeConfig.DefaultValue;
            var evnt = new ControlChangeEvent(new SevenBitNumber(_dataParent.Database.SoloModeConfig.CCNumber), new SevenBitNumber(soloValue));
            foreach (var device in _outputDevices) device.SendEvent(evnt);
            _soloMode = value;
        }
    }
}
