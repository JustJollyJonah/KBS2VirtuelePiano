using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Diagnostics;
using NAudio.Wave;
using System.Collections.Generic;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Controller;

namespace KBS2VirtuelePiano.View
{
    public partial class PanelSong : System.Windows.Forms.Panel
    {


        // SongPlayer is een Model en een Controller in een.
        // PanelSong heeft altijd maar één SongPlayer!
       // private SongPlayer songPlayer { get { return wlc.songPlayer; } }

        private int LastWidth;
        private int LastHeight;

        public bool RenderNoteLength { get; set; }

        public Graphics g { get; set; }

        public PanelSong()
        {
            RenderNoteLength = false;

            // Update LastWidth en LastHeight
            LastWidth = ClientSize.Width;
            LastHeight = ClientSize.Height;

            // Enable double buffering
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs p)
        {
            base.OnPaint(p);
            g = p.Graphics;

            //Anti alias
            if (!Launcher.DEBUG)
                g.SmoothingMode = SmoothingMode.AntiAlias;

            // Maak het scherm weer leeg
            g.Clear(Color.White);

            // Render het liedje
            if (WindowStudent.windowLeerlingController != null) { //moet anders gaat designer zeuren.
                Renderer.RenderSong(WindowStudent.windowLeerlingController.songPlayer, ClientSize, g);
            }
        }

        // Veranderd het variable RenderNoteLength tussen False en true
        public void ToggleNoteLength()
        {
            RenderNoteLength = !RenderNoteLength;
        }
    }
}
