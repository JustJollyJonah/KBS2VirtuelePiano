using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System.Windows.Forms;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowOwnerMenuController
    {
        private WindowOwnerMenu windowOwnerMenu;
        private WindowLoginController parent;
        public WindowOwnerMenuController(WindowLoginController parent)
        {
            windowOwnerMenu = new WindowOwnerMenu(this);
            this.parent = parent;
        }

        public void Show()
        {
            // Laat scherm zien
            windowOwnerMenu.Show();
        }

        public void Hide()
        {
            windowOwnerMenu.Hide();
        }

        public void Run()
        {
            Application.Run(windowOwnerMenu);
        }

        public void SongButton()
        {
            new WindowSongViewerController(this).Show();
            Hide();
        }

        public void StudentButton()
        {
            // Start studenten overzicht.
            new WindowStudentViewerController(this).Show();
            Hide();
        }
        public void LogOut()
        {
            parent.Show();
            parent.Logout();
            this.Hide();

        }
    }
}
