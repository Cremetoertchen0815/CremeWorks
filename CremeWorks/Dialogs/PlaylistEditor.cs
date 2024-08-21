using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.App.Dialogs;
public partial class PlaylistEditor : Form
{
    private readonly IDataParent _parent;
    public PlaylistEditor(IDataParent parent)
    {
        _parent = parent;
        InitializeComponent();
    }
}
