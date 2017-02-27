using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2VirtuelePiano.View;
using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowLoginController
    {
        public static User LoggedInUser { get; private set; }

        public WindowLogin windowLogin;

        public WindowLoginController()
        {
            windowLogin = new WindowLogin(this);
        }

        public void Run()
        {
            Application.Run(windowLogin);
        }

        public void Hide()
        {
            windowLogin.Hide();
        }

        public void Show()
        {
            windowLogin.Show();
        }

        public void EnterPressInTextBoxes(KeyPressEventArgs args)
        {
            // Als er op enter wordt gedrukt in een van de login textboxes, wordt er geporbeerd in te loggen.
            if (args.KeyChar == (char)Keys.Return)
                Login();
        }

        public void Login()
        {
            // Haal ingevoerde waardes op.
            string username = windowLogin.textBoxUsername.Text;
            string password = windowLogin.textBoxPassword.Text;

            // Toon error als velden leeg zijn (of als de standaardwaardes ingevuld zijn).
            if (username == "" || password == "")
            {
                windowLogin.labelError.Text = "Één of meer velden zijn leeg!";
                return;
            }

            // Verifiëer login informatie
            if (EncryptionHelper.VerifyLogin(username, password))
            {
                // Sla ingelogde gebruiker op
                LoggedInUser = GetUserByUsername(username);

                // leeg de tekstboxen
                windowLogin.labelError.Text = "";
                windowLogin.textBoxUsername.Text = "";
                windowLogin.textBoxPassword.Text = "";

                // Als User.IsOwner == true dan is de gebruiker een eigenaar en moet het eigenaarscherm gestart worden.
                if (GetIsOwnerByUsername(username))
                {
                    // start het eigenaar scherm
                    WindowOwnerMenuController woc = new WindowOwnerMenuController(this);
                    woc.Show();
                }
                // Als de gebruiker een student is (User.IsOwner == false) dan moet het pianoscherm gestart worden.
                else
                {
                    // Start het pianoscherm
                    WindowStudentController wl = new WindowStudentController(this); //controller laten bestaan enzo anders krijg je nullpointers
                    wl.Show();

                }

                // Verberg het login scherm
                this.Hide();
            }
            else
                windowLogin.labelError.Text = "Gebruikersnaam en/of wachtwoord incorrect!";
        }

        public void Logout()
        {
            // Zet ingelogde user op null;
            LoggedInUser = null;
        }

        private bool GetIsOwnerByUsername(string username)
        {
            bool isOwner;

            // Haal niveau op d.m.v. username.
            using (DatabaseContext db = new DatabaseContext())
            {
                isOwner = (from u in db.Users
                           where u.Email == username
                           select u.IsOwner).Single();
            }

            return isOwner;
        }

        private User GetUserByUsername(string username)
        {
            User user;

            // Haal user op d.m.v. username.
            using (DatabaseContext db = new DatabaseContext())
            {
                user = (from u in db.Users
                        where u.Email == username
                        select u).Single();
            }

            return user;
        }
    }
}
