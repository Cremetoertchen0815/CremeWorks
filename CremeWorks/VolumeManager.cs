using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks.App;
public class VolumeManager
{
    private readonly IDataParent _dataParent;
    private bool _enabled;
    private bool _soloMode;
    private bool _muteMode;
    private OutputDevice[] _outputDevices = [];

    public event Action<VolumeLevel>? StateChanged;

    public VolumeManager(IDataParent dataParent)
    {
        _dataParent = dataParent;
        _dataParent.MidiManager.ControllerActionExecuted += HandleAction;
        UpdateState();
    }

    public void UpdateState()
    {
        _outputDevices = _dataParent.Database.SoloModeConfig.Devices.Select(x => _dataParent.MidiManager.TryGetMidiDevicePort(x, out _, out var device) ? device : null).Where(x => x is not null).Select(x => x!).ToArray();

        if (!_dataParent.Database.SoloModeConfig.Enabled && _soloMode) Solo = false;
        _enabled = _dataParent.Database.SoloModeConfig.Enabled;

        // Update state event
        var level = VolumeLevel.Regular;
        if (_dataParent.MidiManager.IsConnected)
        {
            if (_soloMode)
            {
                level = VolumeLevel.Solo;
            }
            else if (_muteMode)
            {
                level = VolumeLevel.Off;
            }
        }
        else
        {
            level = VolumeLevel.Disconnected;
        }
        StateChanged?.Invoke(level);
    }

    private void HandleAction(ControllerActionType action, bool? argument)
    {
        if (action == ControllerActionType.SoloMode)
        {
            Solo = argument ?? !_soloMode;
        }
        else if (action == ControllerActionType.MuteMode)
        {
            Mute = argument ?? !_muteMode;
        }
    }

    public bool Solo
    {
        get => _soloMode;
        set
        {
            if (!_enabled || Mute) return;
            var soloValue = value ? _dataParent.Database.SoloModeConfig.SoloValue : _dataParent.Database.SoloModeConfig.DefaultValue;
            var evnt = new ControlChangeEvent(new SevenBitNumber(_dataParent.Database.SoloModeConfig.CCNumber), new SevenBitNumber(soloValue));
            foreach (var device in _outputDevices) device.SendEvent(evnt);
            _soloMode = value;
            StateChanged?.Invoke(value ? VolumeLevel.Solo : VolumeLevel.Regular);
        }
    }

    public bool Mute
    {
        get => _muteMode;
        set
        {
            if (_muteMode == value) return;
            _muteMode = value;
            if (value)
            {
                var evnt = new ControlChangeEvent(new SevenBitNumber(_dataParent.Database.SoloModeConfig.CCNumber), new SevenBitNumber(0));
                foreach (var device in _outputDevices) device.SendEvent(evnt);
                StateChanged?.Invoke(VolumeLevel.Off);
            }
            else
            {
                 Solo = _soloMode;
            }

        }
    }

    public enum VolumeLevel
    {
        Disconnected,
        Off,
        Regular,
        Solo
    }
}
