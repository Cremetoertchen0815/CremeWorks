using CremeWorks.Common;
using System.Diagnostics;
using System.Net;

namespace CremeWorks.Client;

public partial class Form1 : Form
{
    private Metronome _metronome = new();
    private Stopwatch _stopwatch = new();
    public Form1(IPAddress server)
    {
        InitializeComponent();
        _metronome.Tick += HandleTick;
        _metronome.Start(174);
        _stopwatch.Start();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private async void HandleTick()
    {
        pnlClick.BackColor = Color.White;
        await Task.Delay(50);
        pnlClick.BackColor = Color.Black;
        var ms = 60000 / _stopwatch.ElapsedMilliseconds;
        listBox2.Invoke(() =>
        {
            listBox2.Items.Add(ms);
        });
        _stopwatch.Restart();
        
    }
}
