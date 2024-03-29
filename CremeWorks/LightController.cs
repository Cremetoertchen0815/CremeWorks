﻿using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks
{

    public class LightController
    {
        public string[] Names;
        public int[] ToggleGroups;
        public bool[] ResetWhenSongChange;
        public bool[] IsToggleable;

        private readonly bool[] _isSrcToggled;
        private readonly Concert _c;

        public void SetState(int note, bool? value = null)
        {
            if (note < 0) return;

            if (!IsToggleable[note] || (IsToggleable[note] && (value == null || _isSrcToggled[note] != value)))
            {
                _isSrcToggled[note] = value ?? !_isSrcToggled[note];
                _c?.Devices[1].Output?.SendEvent(new NoteOnEvent(new SevenBitNumber((byte)note), new SevenBitNumber(127)));
                System.Threading.Thread.Sleep(10);
            } 

            int grp = ToggleGroups[note];
            if (grp <= 0 || !IsToggleable[note] || value == false) return;

            for (int i = 0; i < 127; i++)
            {
                if (i == note || grp != ToggleGroups[i] || !IsToggleable[i] || !_isSrcToggled[i]) continue;
                _c?.Devices[1].Output?.SendEvent(new NoteOnEvent(new SevenBitNumber((byte)i), new SevenBitNumber(127)));
                System.Threading.Thread.Sleep(10);

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
