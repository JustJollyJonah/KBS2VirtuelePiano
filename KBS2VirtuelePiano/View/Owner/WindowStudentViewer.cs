using KBS2VirtuelePiano.Controller;
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
    public partial class WindowStudentViewer : Form
    {
        public WindowStudentViewerController woc;
        public WindowStudentViewer(WindowStudentViewerController woc)
        {
            InitializeComponent();
            this.woc = woc;
            woc.UpdateListStudentsFromDatabase();

            FormClosed += new FormClosedEventHandler(WindowStudentViewer_FormClosed);
        }

        private void SearchStudentByNameTextBox_TextChanged(object sender, EventArgs e)
        {
            woc.UpdateDataGridPanelWithStudent(SearchStudentByNameTextBox.Text);
        }

        private void SearchStudentByNameDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            woc.SetUserInformationInPanel();
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            woc.OpenWindowAddStudent();
        }

        private void EditStudentButton_Click(object sender, EventArgs e)
        {
            woc.OpenWindowAddStudentWithInformation();          
        }

        private void SelectDifficultyComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            woc.UpdateLevelGraph();
        }

        private void WindowStudentViewer_FormClosed(object sender, FormClosedEventArgs args)
        {
            woc.OnFormClosed();
        }

        private void buttonTerug_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
