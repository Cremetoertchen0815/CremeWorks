using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class MIDISetUp : Form
    {

        private readonly Concert _c;
        private List<string> _deviceList;
        public MIDISetUp(Concert c)
        {
            InitializeComponent();
            _c = c;
            _c.MidiMatrix.Unregister();
        }

        private void MIDISetUp_Load(object sender, EventArgs e)
        {
            _c.Disconnect();
            RefreshAll();
            comboBox1.Text = _c.Devices[0].Name;
            comboBox2.Text = _c.Devices[1].Name;
            comboBox3.Text = _c.Devices[2].Name;
            comboBox4.Text = _c.Devices[3].Name;
            comboBox5.Text = _c.Devices[4].Name;
            comboBox6.Text = _c.Devices[5].Name;
        }

        private void RefreshButton_Click(object sender, EventArgs e) => RefreshAll();
        private void comboBoxValueChange(object sender, EventArgs e)
        {
            var snd = (ComboBox)sender;
            int id = int.Parse(snd.Name.Replace("comboBox", "")) - 1;
            _c.Devices[id].Name = snd.Text;
        }

        private void RefreshAll()
        {
            var dev_list = OutputDevice.GetAll();
            _deviceList = dev_list.Select((x) => x.Name).ToList();
            foreach (var el in dev_list) el.Dispose();

            string[] nu_lst = _deviceList.ToArray();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox1.Items.AddRange(nu_lst);
            comboBox2.Items.AddRange(nu_lst);
            comboBox3.Items.AddRange(nu_lst);
            comboBox4.Items.AddRange(nu_lst);
            comboBox5.Items.AddRange(nu_lst);
            comboBox6.Items.AddRange(nu_lst);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).Name.Replace("button", "")) - 1;
            _c.Connect();
            var play_dev = _c.Devices[id].Output;
            if (play_dev != null)
            {
                play_dev.SendEvent(new NoteOnEvent(new SevenBitNumber(84), new SevenBitNumber(80)));
                System.Threading.Thread.Sleep(200);
                play_dev.SendEvent(new NoteOffEvent(new SevenBitNumber(84), new SevenBitNumber(80)));
            }
            _c.Disconnect();
        }
    }
}
