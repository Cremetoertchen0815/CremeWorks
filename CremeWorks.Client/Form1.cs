using CremeWorks.Client.Networking;
using CremeWorks.Common;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;

namespace CremeWorks.Client;

public partial class Form1 : Form
{
    private readonly CommunicationHub _netHub;
    private readonly Metronome _metronome;
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
                break;
            case MessageTypeEnum.CLICK_INFO:
                break;
            case MessageTypeEnum.CHAT_MESSAGE:
                break;
            case MessageTypeEnum.LIGHT_MESSAGE:
                break;
            default:
                break;
        }
    });

}
