using CremeWorks.App;
using CremeWorks.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class SongCueEditor : Form
    {
        private Song _s;
        private IDataParent _parent;

        private SongCueEditor(IDataParent parent, Song s)
        {
            InitializeComponent();
            _s = s;
            _parent = parent;
            comboBox1.Items.AddRange(parent.Database.LightingCues.ToArray());
        }
    }
}
