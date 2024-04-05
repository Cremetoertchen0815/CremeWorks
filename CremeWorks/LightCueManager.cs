using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightCueManager : Form
    {
        private readonly Concert _c;

        public LightCueManager(Concert c)
        {
            _c = c;
            InitializeComponent();
        }
    }
}
