using CremeWorks.App.Data;
using CremeWorks.Client.MIDI;
using CremeWorks.Client.Networking;
using Newtonsoft.Json;

namespace CremeWorks.Client;

public partial class Form1 : Form
{
    private readonly CommunicationHub _netHub;
    private PlaylistEntryCommonInfo _currentSong = PlaylistEntryCommonInfo.None;
    private MIDIServer _midiServer = new();

    public Form1(CommunicationHub server)
    {
        InitializeComponent();
        _netHub = server;

        server.Disconnected += Server_Disconnected;
        if (!_midiServer.Create() && MessageBox.Show("Virtual MIDI device could not be registered! This probably means the driver is not installed. Continue anyway?", "Registering virtual MIDI device failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
        {
            Application.Exit();
            return;
        }
    }

    private void Server_Disconnected() => new Disconnected(_netHub).ShowDialog();

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        _midiServer.Close();
        Application.Exit();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    internal void HandleIncomingMessage(MessageTypeEnum type, string? data) => Invoke(() =>
    {

        if (data is null) return;

        switch (type)
        {
            case MessageTypeEnum.CONCERT_NAME:
                lblSetName.Text = data;
                break;
            case MessageTypeEnum.SET_DATA:
                var setData = JsonConvert.DeserializeObject<string[]>(data) ?? throw new Exception("Invalid data!");
                lstSet.Items.Clear();
                lstSet.Items.AddRange(setData);
                break;
            case MessageTypeEnum.CURRENT_SONG:
                _currentSong = JsonConvert.DeserializeObject<PlaylistEntryCommonInfo>(data);
                lstSet.SelectedIndex = _currentSong.Index;
                lblTitle.Text = _currentSong.Title;
                lblTempo.Text = _currentSong.Tempo.ToString() + " BPM";
                lblCurrCue.Text = _currentSong.Cues!.Count == 0 ? "-" : _currentSong.Cues[0].Description;
                lblNextCue.Text = _currentSong.Cues.Count < 2 ? "-" : _currentSong.Cues[1].Description;
                lblInstructions.Text = _currentSong.Instructions;
                break;
            case MessageTypeEnum.CUE_INDEX:
                var index = int.Parse(data);
                if (_currentSong.Cues is null) break;
                lblCurrCue.Text = _currentSong.Cues.Count <= Math.Max(index, 0) ? "-" : _currentSong.Cues[index].Description;
                lblNextCue.Text = _currentSong.Cues.Count <= Math.Max(index, 0) + 1 ? "-" : _currentSong.Cues[index + 1].Description;
                break;
            case MessageTypeEnum.CHAT_MESSAGE:
                lstChat.Items.Add(data);
                lstChat.SelectedIndex = lstChat.Items.Count - 1;
                LightUpChatbox();
                break;
            case MessageTypeEnum.LIGHT_MESSAGE:
                _midiServer?.SendData(Convert.FromBase64String(data));
                break;
            default:
                break;
        }
    });

    private void btnChat_Click(object sender, EventArgs e)
    {
        if (txtChat.Text == string.Empty) return;
        _netHub.SendData(MessageTypeEnum.CHAT_MESSAGE, txtChat.Text);
        txtChat.Text = string.Empty;
    }

    private bool _instructionChanging = false;
    private async void lblInstructions_TextChanged(object sender, EventArgs e)
    {
        if (lblInstructions.Text == string.Empty || _instructionChanging) return;
        _instructionChanging = true;
        var ctrl = (TextBox)sender;
        Color original = ctrl.BackColor;
        (ctrl.BackColor, ctrl.ForeColor) = (Color.Lime, Color.Black);
        await Task.Delay(500);
        (ctrl.BackColor, ctrl.ForeColor) = (original, Color.White);
        _instructionChanging = false;
    }

    private bool _chatChanging = false;
    private async void LightUpChatbox()
    {
        if (lstChat.SelectedIndex == -1 || _chatChanging) return;
        _chatChanging = true;
        Color original = lstChat.BackColor;
        (lstChat.BackColor, lstChat.ForeColor) = (Color.Lime, Color.Black);
        await Task.Delay(500);
        (lstChat.BackColor, lstChat.ForeColor) = (original, Color.White);
        _chatChanging = false;
    }
}
