using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.Controller;

namespace KBS2VirtuelePiano.View
{
    public partial class WindowOwnerMenu : Form
    {
        private WindowOwnerMenuController windowOwnerMenuController;
        public ImageList icons;

        public WindowOwnerMenu(WindowOwnerMenuController controller)
        {
            icons = new ImageList();
            icons.ImageSize = new Size(64, 64);
            icons.Images.Add(KBS2VirtuelePiano.Properties.Resources.people_icon_clip_art);
            icons.Images.Add(KBS2VirtuelePiano.Properties.Resources.Icons8_Windows_8_Computer_Hardware_Shutdownwhite);
            icons.Images.Add(KBS2VirtuelePiano.Properties.Resources.musical_note_xxl);
            icons.Images.Add(KBS2VirtuelePiano.Properties.Resources.logout_512);
            InitializeComponent();
            this.button2.ImageList = icons;
            this.buttonStudent.ImageList = icons;
            this.button2.ImageIndex = 1;
            this.buttonStudent.ImageIndex = 0;
            this.button1.ImageList = icons;
            this.button1.ImageIndex = 3;
            this.buttonSong.ImageList = icons;
            this.buttonSong.ImageIndex = 2;
            windowOwnerMenuController = controller;
            
        }

        private void buttonSong_Click(object sender, EventArgs e)
        {
            windowOwnerMenuController.SongButton();
        }

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            windowOwnerMenuController.StudentButton();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Sluit applicatie af. :)
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            windowOwnerMenuController.LogOut();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
