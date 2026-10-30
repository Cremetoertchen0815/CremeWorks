using System.Threading.Tasks;

namespace CremeWorks.App.Midi;

/// <summary>
/// Platform independent access to the MIDI devices of the system.
/// </summary>
public interface IMidiBackend
{
    /// <summary>
    /// Names of all devices that can be opened for input.
    /// </summary>
    string[] GetInputDeviceNames();

    /// <summary>
    /// Names of all devices that can be opened for output.
    /// </summary>
    string[] GetOutputDeviceNames();

    /// <summary>
    /// Opens the input port of the device with the given name. Throws if the device cannot be opened.
    /// </summary>
    Task<IMidiInputPort> OpenInputAsync(string name);

    /// <summary>
    /// Opens the output port of the device with the given name. Throws if the device cannot be opened.
    /// </summary>
    Task<IMidiOutputPort> OpenOutputAsync(string name);
}
