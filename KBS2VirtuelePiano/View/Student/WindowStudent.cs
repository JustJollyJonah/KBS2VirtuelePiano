using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2VirtuelePiano.View
{
    public partial class WindowStudent : Form
    {

        public static WindowStudentController windowLeerlingController;

        // public PanelSong PanelSong { get { return panelSong; } }
        //public PanelPiano PanelPiano { get { return panelPiano1; } }

        public WindowStudent(WindowStudentController wlc)
        {
            // windowLeerlingController = wlc;
            //WindowStudent.windowLeerlingController = new WindowStudentController(this);

            InitializeComponent();

            //this.panelSong.wlc = wlc;
            // Event handlers voor afhandelen toetsenbord.
            KeyPress += new KeyPressEventHandler(WindowLeerling_KeyPress);
            KeyDown += new KeyEventHandler(WindowLeerling_KeyDown);
            KeyUp += new KeyEventHandler(WindowLeerling_KeyUp);
            windowLeerlingController = wlc;
            // Event handler voor form sluiten.
            FormClosed += new FormClosedEventHandler(WindowLeerling_FormClosed);

            // Disable afspeelknopjes want er is aan het begin nog geen lied geselecteerd.
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            buttonPause.Enabled = false;
            tempoToolStripMenuItem.Enabled = true;
        }

        private void timerRepaint_Tick(object sender, EventArgs e)
        {
            this.panelSong.Refresh();
            this.panelPiano.Refresh();
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            windowLeerlingController.Stop();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            windowLeerlingController.Pause();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            windowLeerlingController.Start();
        }

        private void geluidVanNotenButton_Click(object sender, EventArgs e)
        {
            windowLeerlingController.ToggleSound();
        }

        private void nootLengteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowLeerlingController.ToggleNoteLength();
        }

        private void TimerFollower_Tick(object sender, EventArgs e)
        {
            windowLeerlingController.Tick();
        }

        private void WindowLeerling_FormClosed(object sender, FormClosedEventArgs args)
        {
            Application.Exit();
        }

        // Event handlers voor toetsenbord
        private void WindowLeerling_KeyPress(object sender, KeyPressEventArgs args)
        {
            // Nothing to see here..
        }

        private void WindowLeerling_KeyDown(object sender, KeyEventArgs args)
        {
            // Check if this is a valid button
            windowLeerlingController.ProcessKeyDown(args);
        }

        private void WindowLeerling_KeyUp(object sender, KeyEventArgs args)
        {
            windowLeerlingController.ProcessKeyUp(args);
        }

        private void openLiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSelectSongController wsc = new WindowSelectSongController(windowLeerlingController);
            wsc.Run();
            windowLeerlingController.Stop();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem sendr = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem tsm in tempoToolStripMenuItem.DropDownItems)
            {
                if (tsm == sendr)
                {
                    tsm.Checked = true;
                    windowLeerlingController.ChangeTempo(tempoToolStripMenuItem.DropDownItems.IndexOf(tsm));
                }
                else
                {
                    tsm.Checked = false;
                }
            }
        }

        private void toolStripMenuItemShowProgress_Click(object sender, EventArgs e)
        {
            windowLeerlingController.ShowMyProgress();
        }

        private void logUitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowLeerlingController.LogOut();
        }
    }
}