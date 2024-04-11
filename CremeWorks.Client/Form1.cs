using CremeWorks.Client.Networking;
using CremeWorks.Common;
using CremeWorks.Common.Networking;
using Newtonsoft.Json;

namespace CremeWorks.Client;

public partial class Form1 : Form
{
    private readonly CommunicationHub _netHub;
    private readonly Metronome _metronome;
    private SongInformation? _currentSong = null;
    public Form1(CommunicationHub server)
    {
        InitializeComponent();
        _metronome = new Metronome();
        _metronome.Tick += HandleMetronomeTick;
        _netHub = server;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private async void HandleMetronomeTick()
    {
        pnlClick.BackColor = Color.White;
        await Task.Delay(50);
        pnlClick.BackColor = Color.Black;

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
                _currentSong = JsonConvert.DeserializeObject<SongInformation>(data) ?? throw new Exception("Invalid data!");
                lstSet.SelectedIndex = _currentSong.Index;
                lblTitle.Text = _currentSong.SmallName;
                lblTempo.Text = _currentSong.Tempo.ToString() + " BPM";
                lblCurrCue.Text = _currentSong.Cues.Length == 0 ? "-" : _currentSong.Cues[0];
                lblNextCue.Text = _currentSong.Cues.Length < 2 ? "-" : _currentSong.Cues[1];
                lblInstructions.Text = _currentSong.Instructions;
                break;
            case MessageTypeEnum.CUE_INDEX:
                var index = int.Parse(data);
                if (_currentSong?.Cues is null) break;
                lblCurrCue.Text = _currentSong.Cues.Length <= Math.Max(index, 0) ? "-" : _currentSong.Cues[index];
                lblNextCue.Text = _currentSong.Cues.Length <= Math.Max(index, 0) + 1 ? "-" : _currentSong.Cues[index + 1];
                break;
            case MessageTypeEnum.CHAT_MESSAGE:
                lstChat.Items.Add(data);
                lstChat.SelectedIndex = lstChat.Items.Count - 1;
                break;
            case MessageTypeEnum.CLICK_INFO:
                break;
            case MessageTypeEnum.LIGHT_MESSAGE:
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
}
