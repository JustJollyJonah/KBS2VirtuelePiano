using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Model;
using System.Drawing;

namespace KBS2VirtuelePiano.View
{
    public partial class PanelEditor : System.Windows.Forms.Panel
    {
        SongPlayer sp = new SongPlayer(new Song(4, 4));
        Pen pen = new Pen(Color.FromArgb(100, 255, 0, 0));
        public Note componentj = new Note(NoteLetter.F, 5, false, ComponentLength.HALF, 0, 0);

        public int mouseX;
        public int mouseY;

        public PanelEditor(IContainer container)
        {
            container.Add(this);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = System.Drawing.Color.White;
            int counter = 18;
            for (int i = 0; i < 4; i++) {
                Renderer.RenderRowLines(e.Graphics, ClientSize, counter);
                counter += Renderer.ROW_TOTAL_HEIGHT;
            }
            if (Launcher.DEBUG)
            {
                for (int i = 0; i < ClientSize.Width / Renderer.NOTE_FULL_WIDTH; i++)
                {
                    e.Graphics.DrawLine(pen, i * Renderer.NOTE_FULL_WIDTH, 0, i * Renderer.NOTE_FULL_WIDTH, ClientSize.Height);
                }
                for (int i = 0; i < ClientSize.Height / Renderer.LINE_PADDING_VERTICAL; i++)
                {
                    e.Graphics.DrawLine(pen, 0, i * Renderer.LINE_PADDING_VERTICAL, ClientSize.Width, i * Renderer.LINE_PADDING_VERTICAL);
                }
            }

            int gridX = Renderer.NOTE_FULL_WIDTH;
            int gridY = Renderer.LINE_PADDING_VERTICAL;

            // X en Y moeten 'snappen' naar de grid
            int x = gridX * (int)Math.Floor(((double)mouseX) / gridX);
            int y = gridY * (int)Math.Floor(((double)mouseY) / gridY);

            // Bereken hoe veel Y er over is nadat we ROW_TOTAL_HEIGHT er af hebben gehaald
            int rowBaseY = (int)Math.Floor(((double)mouseY) / Renderer.ROW_TOTAL_HEIGHT);
            rowBaseY = Renderer.ROW_PADDING_VERTICAL + (Renderer.ROW_TOTAL_HEIGHT * rowBaseY);
            int rowRemainingY = y % Renderer.ROW_TOTAL_HEIGHT;

            // Limiteer dit nummer tot binnen het gewenste bereik (excl ROW_PADDING_VERTICAL)
            //if (rowY < Renderer.ROW_PADDING_VERTICAL) rowY = Renderer.ROW_PADDING_VERTICAL;
            //if (rowY > Renderer.ROW_HEIGHT + Renderer.ROW_PADDING_VERTICAL) rowY = Renderer.ROW_HEIGHT + Renderer.ROW_PADDING_VERTICAL;

            // Kijk hoe veel Y we hebben
            int compY = (int)Math.Floor(((double)rowRemainingY) / Renderer.LINE_PADDING_VERTICAL);

            int oct = (int)Math.Floor(((double)compY) / 7);
            compY = compY % 7;

            componentj.Octave = Piano.BASE_OCTAAF + (Piano.OCTAVEN - 1) - oct;
            componentj.Letter = (NoteLetter)compY;

            Console.WriteLine(String.Format("{0} {1} {2}", componentj.Octave, componentj.Letter, rowRemainingY));
            Renderer.RenderSongComponent(e.Graphics, componentj, x, rowBaseY);
        }
    }
}
