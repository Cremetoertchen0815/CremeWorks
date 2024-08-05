using CremeWorks.App.Data;
using System.Data;

namespace CremeWorks.App.Dialogs;

public partial class SongRoutingEditor : Form
{
    private IDataParent parent;
    private Song? song;

    private bool wasCCPreviouslySelected = false;
    private readonly DataTable table = new DataTable();
    private readonly (int key, MidiDevice device)[] devices;
    private readonly bool[,] routingNotes;
    private readonly bool[,] routingControlChange;


    public SongRoutingEditor(IDataParent _parent, Song? s)
    {
        InitializeComponent();
        parent = _parent;
        song = s;

        devices = parent.Database.Devices.Where(x => x.Value.IsInstrument).Select(x => (x.Key, x.Value)).ToArray();
        routingNotes = new bool[devices.Length, devices.Length];
        routingControlChange = new bool[devices.Length, devices.Length];

        // Initialize the grid with default routing
        foreach (var item in parent.Database.DefaultRouting)
        {
            var fromIndex = GetDeviceIndexByDeviceId(item.SourceDeviceId);
            var toIndex = GetDeviceIndexByDeviceId(item.DestinationDeviceId);
            switch (item.Type)
            {
                case MidiMatrixNodeType.Notes:
                    routingNotes[fromIndex, toIndex] = true;
                    break;
                case MidiMatrixNodeType.ControlChange:
                    routingControlChange[fromIndex, toIndex] = true;
                    break;
                case MidiMatrixNodeType.Both:
                    routingNotes[fromIndex, toIndex] = true;
                    routingControlChange[fromIndex, toIndex] = true;
                    break;
                default:
                    break;
            }
        }

        // Apply song specific routing overrides
        if (song is null) return;
        foreach (var item in song.RoutingOverrides)
        {
            var fromIndex = GetDeviceIndexByDeviceId(item.SourceDeviceId);
            var toIndex = GetDeviceIndexByDeviceId(item.DestinationDeviceId);
            switch (item.Type)
            {
                case MidiMatrixNodeType.None:
                    routingNotes[fromIndex, toIndex] = false;
                    routingControlChange[fromIndex, toIndex] = false;
                    break;
                case MidiMatrixNodeType.Notes:
                    routingNotes[fromIndex, toIndex] = true;
                    routingControlChange[fromIndex, toIndex] = false;
                    break;
                case MidiMatrixNodeType.ControlChange:
                    routingNotes[fromIndex, toIndex] = false;
                    routingControlChange[fromIndex, toIndex] = true;
                    break;
                case MidiMatrixNodeType.Both:
                    routingNotes[fromIndex, toIndex] = true;
                    routingControlChange[fromIndex, toIndex] = true;
                    break;
                default:
                    break;
            }
        }

        // Populate the grid
        table.Columns.Add(string.Empty, typeof(string));
        foreach (var device in devices)
        {
            table.Columns.Add(device.device.Name, typeof(bool));
        }
        for (int i = 0; i < devices.Length; i++)
        {
            var row = table.NewRow();
            row[0] = devices[i].device.Name;
            for (int j = 0; j < devices.Length; j++)
            {
                row[j + 1] = routingNotes[i, j];
            }
            table.Rows.Add(row);
        }
        dataGridView1.DataSource = table;
    }

    private int GetDeviceIndexByDeviceId(int deviceId)
    {
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].key == deviceId)
            {
                return i;
            }
        }
        return -1;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Store the routing data
        bool[,] routingArray = wasCCPreviouslySelected ? routingNotes : routingControlChange;
        for (int i = 0; i < devices.Length; i++)
        {
            for (int j = 0; j < devices.Length; j++)
            {
                routingArray[i, j] = (bool)table.Rows[i][j + 1];
            }
        }

        // Update the grid
        wasCCPreviouslySelected = selSelection.SelectedIndex == 0;
        routingArray = wasCCPreviouslySelected ? routingNotes : routingControlChange;

        for (int i = 0; i < devices.Length; i++)
        {
            var row = table.Rows[i];
            row[0] = devices[i].device.Name;
            for (int j = 0; j < devices.Length; j++)
            {
                row[j + 1] = routingArray[i, j];
            }
            table.Rows.Add(row);
        }
    }

    private void SongRoutingEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Store the routing data
        bool[,] routingArray = wasCCPreviouslySelected ? routingNotes : routingControlChange;
        for (int i = 0; i < devices.Length; i++)
        {
            for (int j = 0; j < devices.Length; j++)
            {
                routingArray[i, j] = (bool)table.Rows[i][j + 1];
            }
        }

        // Store the routing data in the song
        if (song is null)
        {
            parent.Database.DefaultRouting.Clear();
            for (int i = 0; i < devices.Length; i++)
            {
                for (int j = 0; j < devices.Length; j++)
                {
                    var type = routingNotes[i, j] ? MidiMatrixNodeType.Notes : MidiMatrixNodeType.None;
                    if (routingControlChange[i, j]) type = routingNotes[i, j] ? MidiMatrixNodeType.Both : MidiMatrixNodeType.ControlChange;

                    if (type != MidiMatrixNodeType.None)
                    {
                        parent.Database.DefaultRouting.Add(new MidiMatrixNode
                        {
                            SourceDeviceId = devices[i].key,
                            DestinationDeviceId = devices[j].key,
                            Type = type
                        });
                    }
                }
            }
            return;
        }

        // Store the override routing data in the song
        song.RoutingOverrides.Clear();
        for (int i = 0; i < devices.Length; i++)
        {
            for (int j = 0; j < devices.Length; j++)
            {
                var type = routingNotes[i, j] ? MidiMatrixNodeType.Notes : MidiMatrixNodeType.None;
                if (routingControlChange[i, j]) type = routingNotes[i, j] ? MidiMatrixNodeType.Both : MidiMatrixNodeType.ControlChange;

                var originalType = parent.Database.DefaultRouting.FirstOrDefault(x => x.SourceDeviceId == devices[i].key && x.DestinationDeviceId == devices[j].key).Type;

                if (type != originalType)
                {
                    song.RoutingOverrides.Add(new MidiMatrixNode
                    {
                        SourceDeviceId = devices[i].key,
                        DestinationDeviceId = devices[j].key,
                        Type = type
                    });
                }
            }
        }
    }
}
