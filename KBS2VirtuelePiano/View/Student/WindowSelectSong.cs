using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2VirtuelePiano.Controller;
using System.Runtime.InteropServices;

namespace KBS2VirtuelePiano.View
{

    public partial class WindowSelectSong : Form
    {
        private WindowSelectSongController wsc;
       
        public WindowSelectSong(WindowSelectSongController controller)
        {
            this.wsc = controller;
            InitializeComponent();

        }

        private void WindowSelectSong_Load(object sender, EventArgs e)
        {
            wsc.InitDataGridView();
            comboBox1.SelectedIndex = WindowLoginController.LoggedInUser.Niveau;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            wsc.CancelSelectSong();
        }

        private void OpenSong_Click(object sender, EventArgs e)
        {
            wsc.OpenSong();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            wsc.UpdateDataGridPanelWithSongs(SearchTextBox.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
       
                wsc.UpdateDataGridPanelWithSongsOnLevel(comboBox1.SelectedIndex + 1);
            }
        }

        private void dataGridViewPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            wsc.UpdateSelectedSong();
        }

        private void dataGridViewPanel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            wsc.OpenSong();
        }
    }
}
