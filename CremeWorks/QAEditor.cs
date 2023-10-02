using System;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class QAEditor : Form
    {
        private readonly Concert _c;
        private readonly Button[] _mapQA;

        public QAEditor(Concert c)
        {
            InitializeComponent();

            _c = c;
            _mapQA = new Button[] { button12, button5, button11, button6, button10 };


            for (int i = 0; i < _mapQA.Length; i++)
            {
                sbyte val = _c.QA[i];
                if (i < 5) _mapQA[i].Text = val < 0 ? "Quick Access " + Buchstaben[i] : _c.LightConfig.Names[val];
            }
        }

        private void QAButtonClicked(object sender, EventArgs e)
        {
            var src = (Button)sender;
            int nr = int.Parse((string)src.Tag);
            new QASelector(_c, nr).ShowDialog();
            sbyte val = _c.QA[nr];
            if (nr < 5) src.Text = val < 0 ? "Quick Access " + Buchstaben[nr] : _c.LightConfig.Names[val];
        }

        private readonly string[] Buchstaben = { "A", "B", "C", "D", "E" };
    }
}
