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
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.View
{
    public partial class WindowSongViewer : Form
    {
        WindowSongViewerController wec;

        public WindowSongViewer(WindowSongViewerController controller)
        {
            InitializeComponent();

            wec = controller;

            FormClosed += new FormClosedEventHandler(WindowEditor_FormClosed);
        }

        private void WindowEditor_FormClosed(object sender, FormClosedEventArgs args)
        {
            wec.OnFormClosed();
        }

        private void SearchSongByNameTextBox_TextChanged(object sender, EventArgs e)
        {
            wec.UpdateDataGridPanelWithSongs(SearchSongByNameTextBox.Text);
        }

        private void SearchSongByNameDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            wec.SetSongInformationInPanel();
        }

        private void AddSongButton_Click(object sender, EventArgs e)
        {
            wec.OnAddSongButtonClick();
        }

        private void buttonTerug_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
