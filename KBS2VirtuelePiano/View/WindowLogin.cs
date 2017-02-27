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
namespace KBS2VirtuelePiano.View
{   
    
    public partial class WindowLogin : Form
    {
        public WindowLoginController windowLoginController;
        

        public WindowLogin(WindowLoginController wlc)
        {
            windowLoginController = wlc;
            InitializeComponent();

            // Event handlers voor login invoer velden.
            textBoxUsername.KeyPress += new KeyPressEventHandler(textBoxUsernamePassword_EnterPress);
            textBoxPassword.KeyPress += new KeyPressEventHandler(textBoxUsernamePassword_EnterPress);
        }

        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WindowLogin_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Applicatie sluit af als er op annuleren wordt gedrukt.
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            windowLoginController.Login();
        }

        private void textBoxUsernamePassword_EnterPress(object sender, KeyPressEventArgs args)
        {
            windowLoginController.EnterPressInTextBoxes(args);
        }
    }
}
