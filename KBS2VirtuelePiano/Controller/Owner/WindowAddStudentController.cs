using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowAddStudentController
    {
        private WindowAddStudent windowAddStudent;
        private WindowStudentViewerController windowOwner;

        //Om bij te houden of leerling 18 jaar of ouder is
        public bool IsAdult { get; set; }
        //Om bij te houden welke student er is geselecteerd in het datagridview
        public User SelectedStudent { get; set; }
        //Om bij te houden als gebruike gewijzigd moet worden of toegevoegd
        public bool Edit { get; set; }
        //Een string die aangevuld word met foutmelding door de klasse InputInformationValidator
        public string errorMessage = null;
        //Als er een ouder toegevoegd moet worden zal deze bijgehouden worden. Als ouder niet goed wordt opgeslagen dan zal een leerling niet toegevoegd kunnen worden
        public bool ParentWasFilledInCorrectly = false;
        // Als er een student wordt toegevoegd moeten we onthouden of het gelukt is of niet
        public bool StudentWasFilledInCorrectly = false;

        //Constructor voor het aanmaken van leerlingen/ouders
        public WindowAddStudentController(WindowStudentViewerController ownerWindow)
        {
            windowAddStudent = new WindowAddStudent(this);
            this.windowOwner = ownerWindow;
            Edit = false;
            windowAddStudent.DialogAddStudentButton.Text = "Toevoegen";
        }
        //Constructor voor het wijzigen van leerlingen/ouders
        public WindowAddStudentController(WindowStudentViewerController ownerWindow, User user)
        {
            windowAddStudent = new WindowAddStudent(this);
            this.windowOwner = ownerWindow;
            SelectedStudent = user;
            Edit = true;
            FillFields();
            windowAddStudent.DialogAddStudentButton.Text = "Wijzigen";
        }
        //Laat scherm zien
        public void Show()
        {
            windowAddStudent.Show();
        }
        //Verbergt scherm
        public void Hide()
        {
            windowAddStudent.Hide();
        }

        //Sluit scherm
        public void Close()
        {
            windowOwner.Show();
            windowOwner.UpdateDataGridPanelWithStudent("");
            windowAddStudent.Close();
        }
        //Voegt student toe aan database
        public void AddStudentToDatabase()
        {
            StudentWasFilledInCorrectly = false;
            if (ParentWasFilledInCorrectly)
            {
                //Kijkt of input valide is
                if (InputInformationValidator.ValidateAddStudentInputWithPassword(windowAddStudent, ref errorMessage))
                {
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        //Creeer een leerling object
                        User newUser = new User()
                        {
                            FirstName = windowAddStudent.NameTextbox.Text,
                            LastName = windowAddStudent.LastNameTextBox.Text,
                            Gender = windowAddStudent.addStudentGenderComboBox.SelectedItem.ToString(),
                            Address = windowAddStudent.StreetTextBox.Text,
                            Postalcode = windowAddStudent.PostalcodeTextBox.Text,
                            Residence = windowAddStudent.DialogAddResidence.Text,
                            Email = windowAddStudent.EmailTextBox.Text,
                            Password = EncryptionHelper.HashStringSHA512(windowAddStudent.PasswordTextBox.Text),
                            Niveau = Int32.Parse(windowAddStudent.DialogAddLevel.Text),
                            DateOfBirth = windowAddStudent.dateTimePicker1.Value,
                            IsOwner = false
                        };
                        if (!IsAdult)
                            newUser.ParentID = db.Parents.Max(x => x.ParentID);
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        windowOwner.UpdateDataGridPanelWithStudent();
                        var result = MessageBox.Show("Leerling toegevoegd");
                        db.Dispose();
                        if(result == DialogResult.Yes)
                        {
                            this.Close();
                        }                        

                    }
                    windowOwner.UpdateListStudentsFromDatabase();
                    StudentWasFilledInCorrectly = true;
                }
                else
                {
                    MessageBox.Show(errorMessage);
                    errorMessage = null;
                }
            }
        }

        public void AddParentToDatabase()
        {
            //Kijkt of input valide is
            if (InputInformationValidator.ValidateAddParentInput(windowAddStudent, ref errorMessage))
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    //Creeer een ouder object
                    Parent parent = new Parent()
                    {
                        FirstName = windowAddStudent.AddParentFirstName.Text,
                        LastName = windowAddStudent.AddParentLastName.Text,
                        Address = windowAddStudent.AddParentStreet.Text,
                        Postalcode = windowAddStudent.AddParentPostalcode.Text,
                        Residence = windowAddStudent.AddParentResidence.Text,
                        Email = windowAddStudent.AddParentEmail.Text,
                        Gender = windowAddStudent.AddParentGender.SelectedItem.ToString()
                    };
                    //Check for next step, if it was false, a student cannot be added.
                    ParentWasFilledInCorrectly = true;
                    db.Parents.Add(parent);
                    db.SaveChanges();
                    windowOwner.UpdateDataGridPanelWithStudent();
                }
            }
            else
            {
                //Shows specified errors in a messagebox
                MessageBox.Show(errorMessage);
                ParentWasFilledInCorrectly = false;
                errorMessage = null;
            }
        }

        public void EditUserDatabase()
        {
            StudentWasFilledInCorrectly = false;
            if (EditParentDatabase())
            {
                if (InputInformationValidator.ValidateAddStudentInput(windowAddStudent, ref errorMessage))
                {
                    User userTempUser;
                    //Get user from database
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        userTempUser = db.Users.Select(x => x).Where(x => x.UserID == SelectedStudent.UserID).SingleOrDefault();
                    }
                    //If selected user exists, get information from form
                    if (userTempUser != null)
                    {
                        userTempUser.FirstName = windowAddStudent.NameTextbox.Text;
                        userTempUser.LastName = windowAddStudent.LastNameTextBox.Text;
                        userTempUser.DateOfBirth = windowAddStudent.dateTimePicker1.Value;
                        userTempUser.Email = windowAddStudent.EmailTextBox.Text;
                        userTempUser.Gender = windowAddStudent.addStudentGenderComboBox.SelectedItem.ToString();
                        userTempUser.Address = windowAddStudent.StreetTextBox.Text;
                        userTempUser.Postalcode = windowAddStudent.PostalcodeTextBox.Text;
                        userTempUser.Residence = windowAddStudent.DialogAddResidence.Text;
                        userTempUser.Niveau = Int32.Parse(windowAddStudent.DialogAddLevel.Text);
                        if (userTempUser.IsOwner)
                            userTempUser.Niveau = 100;
                        if (windowAddStudent.PasswordTextBox.Text != "")
                        {
                            userTempUser.Password = EncryptionHelper.HashStringSHA512(windowAddStudent.PasswordTextBox.Text);
                        }
                    }
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        // Mark entity as modified
                        db.Entry(userTempUser).State = System.Data.Entity.EntityState.Modified;

                        //Save changes to database
                        db.SaveChanges();
                        windowOwner.UpdateListStudentsFromDatabase();
                        MessageBox.Show("Gegevens zijn gewijzigd.");
                    }
                    windowOwner.UpdateListStudentsFromDatabase();
                    StudentWasFilledInCorrectly = true;
                }
                else
                {
                    MessageBox.Show(errorMessage);
                    errorMessage = null;
                }
            }
        }

        private bool EditParentDatabase()
        {
            bool succes = true;
            Parent parentTemp;
            //Get parents from database

            using (DatabaseContext db = new DatabaseContext())
            {
                parentTemp = db.Parents.Select(x => x).Where(x => x.ParentID == SelectedStudent.ParentID).SingleOrDefault();
            }
            //If selected user exists, get information from form
            if (parentTemp != null)
            {
                if (InputInformationValidator.ValidateAddParentInput(windowAddStudent, ref errorMessage))
                {
                    parentTemp.FirstName = windowAddStudent.AddParentFirstName.Text;
                    parentTemp.LastName = windowAddStudent.AddParentLastName.Text;
                    parentTemp.Email = windowAddStudent.AddParentEmail.Text;
                    parentTemp.Gender = windowAddStudent.AddParentGender.SelectedItem.ToString();
                    parentTemp.Address = windowAddStudent.AddParentStreet.Text;
                    parentTemp.Postalcode = windowAddStudent.AddParentPostalcode.Text;
                    parentTemp.Residence = windowAddStudent.AddParentResidence.Text;

                    using (DatabaseContext db = new DatabaseContext())
                    {
                        // Mark entity as modified
                        db.Entry(parentTemp).State = System.Data.Entity.EntityState.Modified;

                        //Sla wijzigen op
                        db.SaveChanges();
                        windowOwner.UpdateDataGridPanelWithStudent();
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                    errorMessage = null;
                    succes = false;
                }
            }
            else
            {
                if (!InputInformationValidator.ValidateAddParentInputReturnTrueWhenFieldsAreEmpty(windowAddStudent))
                {
                    if (InputInformationValidator.ValidateAddParentInput(windowAddStudent, ref errorMessage))
                    {
                        Parent parent = new Parent()
                        {
                            FirstName = windowAddStudent.AddParentFirstName.Text,
                            LastName = windowAddStudent.AddParentLastName.Text,
                            Email = windowAddStudent.AddParentEmail.Text,
                            Gender = windowAddStudent.AddParentGender.SelectedItem.ToString(),
                            Address = windowAddStudent.AddParentStreet.Text,
                            Postalcode = windowAddStudent.AddParentPostalcode.Text,
                            Residence = windowAddStudent.AddParentResidence.Text
                        };
                        using (DatabaseContext db = new DatabaseContext())
                        {
                            db.Parents.Add(parent);
                            db.SaveChanges();
                            int tempParentIDforUser = db.Parents.Max(x => x.ParentID);
                            var queryUser = db.Users.Select(x => x).Where(x => x.UserID == SelectedStudent.UserID).FirstOrDefault();
                            queryUser.ParentID = tempParentIDforUser;

                            // Mark entity as modified
                            db.Entry(queryUser).State = System.Data.Entity.EntityState.Modified;

                            //Sla wijzigen op
                            db.SaveChanges();
                            windowOwner.UpdateDataGridPanelWithStudent();
                            MessageBox.Show("Ouder informatie is opgeslagen.");
                        }
                    }
                    else
                    {
                        succes = false;
                        MessageBox.Show(errorMessage);
                        errorMessage = null;
                    }
                }
            }
            return succes;
        }

        private void FillFields()
        {
            windowAddStudent.NameTextbox.Text = SelectedStudent.FirstName;
            windowAddStudent.LastNameTextBox.Text = SelectedStudent.LastName;
            windowAddStudent.dateTimePicker1.Value = SelectedStudent.DateOfBirth;
            windowAddStudent.EmailTextBox.Text = SelectedStudent.Email;
            windowAddStudent.addStudentGenderComboBox.SelectedItem = SelectedStudent.Gender;
            windowAddStudent.StreetTextBox.Text = SelectedStudent.Address;
            windowAddStudent.PostalcodeTextBox.Text = SelectedStudent.Postalcode;
            windowAddStudent.DialogAddResidence.Text = SelectedStudent.Residence;
            windowAddStudent.DialogAddLevel.Text = SelectedStudent.Niveau.ToString();
            Console.WriteLine(SelectedStudent.ParentID.ToString());

            //Als geselecteerde user een eigenaar is zal deze zijn level niet kunnen aanpassen
            if (SelectedStudent.IsOwner)
                windowAddStudent.DialogAddLevel.Enabled = false;

            //Als de geselecteerde leerling een ouderheeft zal deze informatie ook zichtbaar worden
            if (SelectedStudent.ParentID != null)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var parent = db.Parents.Select(x => x).Where(x => x.ParentID == SelectedStudent.ParentID).SingleOrDefault();
                    windowAddStudent.AddParentFirstName.Text = parent.FirstName;
                    windowAddStudent.AddParentLastName.Text = parent.LastName;
                    windowAddStudent.AddParentStreet.Text = parent.Address;
                    windowAddStudent.AddParentPostalcode.Text = parent.Postalcode;
                    windowAddStudent.AddParentResidence.Text = parent.Residence;
                    windowAddStudent.AddParentEmail.Text = parent.Residence;
                    windowAddStudent.AddParentGender.SelectedItem = parent.Gender;
                }
            }
            else if (SelectedStudent.CalculateAge() < 18)
                windowAddStudent.groupBox2.Enabled = true;
            else
                windowAddStudent.groupBox2.Enabled = false;
        }
    }
}
