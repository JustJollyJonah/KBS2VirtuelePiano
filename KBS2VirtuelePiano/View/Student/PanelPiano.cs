using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Model;
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
    public partial class PanelPiano : Panel
    {

        public Piano Piano;

        public PanelPiano()
        {
            Piano = new Piano();

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Render de Piano
            Renderer.RenderPiano(Piano, ClientSize, pe.Graphics);
        }
    }
}
