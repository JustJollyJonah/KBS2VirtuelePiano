using KBS2VirtuelePiano.Controller;
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
    public partial class WindowAddStudent : Form
    {
        private int OriginalWidth;
        public Boolean wijzigen;
        private WindowAddStudentController windowAddStudent;
        public WindowAddStudent(WindowAddStudentController wac)
        {
            this.OriginalWidth = this.Width;
            this.windowAddStudent = wac;
            InitializeComponent();
            this.Size = new Size((int)(OriginalWidth * 1.95), this.Height);
            
        }
        
        private void DialogCloseButton_Click(object sender, EventArgs e)
        {
            windowAddStudent.Close();
        }

        private void DialogAddStudentButton_Click(object sender, EventArgs e)
        {
            if (!windowAddStudent.Edit)
            {
                if (windowAddStudent.IsAdult)
                {
                    windowAddStudent.AddStudentToDatabase();
                    if (windowAddStudent.StudentWasFilledInCorrectly)
                        windowAddStudent.Close();
                }
                else
                {
                    windowAddStudent.AddParentToDatabase();
                    windowAddStudent.AddStudentToDatabase();
                    if (windowAddStudent.StudentWasFilledInCorrectly)
                        windowAddStudent.Close();
                }
            }
            else
            {
                windowAddStudent.EditUserDatabase();
                if (windowAddStudent.StudentWasFilledInCorrectly)
                    windowAddStudent.Close();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (CalculateAge(dateTimePicker1.Value) < 18)
            {
                windowAddStudent.IsAdult = false;
                groupBox2.Enabled = true;
                windowAddStudent.ParentWasFilledInCorrectly = false;
            }
            else
            {
                windowAddStudent.IsAdult = true;
                windowAddStudent.ParentWasFilledInCorrectly = true;
                groupBox2.Enabled = false;
            }
        }

        private int CalculateAge(DateTime dt)
        {
            var today = DateTime.Today;
            var age = today.Year - dt.Year;
            if (dt > today.AddYears(-age)) age--;
            return age;
        }
    }
}
