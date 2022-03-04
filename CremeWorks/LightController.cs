﻿using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks
{

    public class LightController
    {
        public string[] Names;
        public int[] ToggleGroups;
        public bool[] ResetWhenSongChange;
        public bool[] IsToggleable;

        private bool[] _isSrcToggled;
        private Concert _c;

        public void SetState(int note, bool value)
        {
            if (!IsToggleable[note] || (IsToggleable[note] && _isSrcToggled[note] != value))
            {
                _isSrcToggled[note] = value;
                _c?.Devices[1].Output?.SendEvent(new NoteOnEvent(new SevenBitNumber((byte)note), new SevenBitNumber(127)));
            }

            var grp = ToggleGroups[note];
            if (grp <= 0 || !value) return;

            for (int i = 0; i < 127; i++)
            {
                if (i == note || grp != ToggleGroups[i] || !IsToggleable[i] || !_isSrcToggled[i]) continue;
                _c?.Devices[1].Output?.SendEvent(new NoteOnEvent(new SevenBitNumber((byte)i), new SevenBitNumber(127)));
                _isSrcToggled[i] = false;
            }
        }

        public LightController(Concert c)
        {
            _c = c;
            Names = new string[128];
            ToggleGroups = new int[128];
            ResetWhenSongChange = new bool[128];
            IsToggleable = new bool[128];
            _isSrcToggled = new bool[128];
            for (int i = 0; i < 128; i++) _isSrcToggled[i] = false;
        }
    }
}
