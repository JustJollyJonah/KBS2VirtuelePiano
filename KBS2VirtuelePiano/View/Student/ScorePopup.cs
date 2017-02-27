using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2VirtuelePiano.View
{
    public partial class ScorePopup : Form
    {
        public ScorePopup()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetText(decimal score)
        {
            if(score >= 0.8M)
            {
                this.LabelScore.Text = String.Format("Goed gedaan!\r\nJe hebt {0} van de noten correct aangeslagen.", score.ToString("P"));
            } else if (score >= 0.5M)
            {
                this.LabelScore.Text = String.Format("Je komt in de buurt, nog iets meer oefenen en je bent er!\r\nJe hebt {0} van de noten correct aangeslagen.", score.ToString("P"));
            } else
            {
                this.LabelScore.Text = String.Format("Je moet nog wat meer oefenen.\r\nJe hebt {0} van de noten correct aangeslagen.", score.ToString("P"));
            }
        }
    }
}