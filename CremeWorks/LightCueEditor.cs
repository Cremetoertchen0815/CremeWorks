﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightCueEditor : Form
    {
        private (string comment, LightSwitchType[] data) _dat;
        private LightController _lConfig;

        private LightCueEditor() => InitializeComponent();


        public static bool EditCue(LightController lConfig, ref (string comment, LightSwitchType[] data) item)
        {
            var inst = new LightCueEditor() { _dat = item, _lConfig = lConfig };
            if (inst.ShowDialog() == DialogResult.OK)
            {
                item = inst._dat;
                return true;
            }
            return false;
        }

        public static bool AddToCue(LightController lConfig, List<(string comment, LightSwitchType[] data)> cue)
        {
            var datArr = new LightSwitchType[128];
            for (int i = 0; i < 128; i++) datArr[i] = LightSwitchType.Ignore;
            var inst = new LightCueEditor() { _dat = ("Empty", datArr), _lConfig = lConfig };
            if (inst.ShowDialog() == DialogResult.OK)
            {
                cue.Add(inst._dat);
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _dat.comment = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void RefreshData()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 128; i++)
            {
                listBox1.Items.Add((i + 1).ToString() + ". " + (_lConfig.Names[i] ?? "Empty") + ": " + _dat.data[i].ToString());
            }
            textBox1.Text = _dat.comment;
        }
        private void LightCueEditor_Load(object sender, EventArgs e) => RefreshData();

        private bool ignoreValChange = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreValChange) return;

            _dat.data[(int)numericUpDown1.Value - 1] = (LightSwitchType)(comboBox1.SelectedIndex - 1);
            RefreshData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ignoreValChange = true;
            var val = _dat.data[(int)numericUpDown1.Value - 1];
            comboBox1.SelectedIndex = ((int)val + 1);
            comboBox1.Text = val.ToString();
            ignoreValChange = false;
        }
    }
}
