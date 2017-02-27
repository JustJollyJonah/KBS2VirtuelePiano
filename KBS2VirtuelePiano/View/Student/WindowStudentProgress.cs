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
using KBS2VirtuelePiano.View;

namespace KBS2VirtuelePiano.View
{
    public partial class WindowStudentProgress : Form
    {
        public WindowStudentProgressController controller;

        public WindowStudentProgress(WindowStudentProgressController controller)
        {
            InitializeComponent();

            this.controller = controller;
        }

        private void WindowStudentProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.OnFormClosed();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.OnComboBoxLevelChanged();
        }
    }
}
