using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowStudentViewerController
    {
        public UserCollection userCollection;
        private WindowStudentViewer windowOwner;
        private WindowOwnerMenuController parent;
        public User SelectedStudent { get; set; }

        public WindowStudentViewerController(WindowOwnerMenuController parentView)
        {
            userCollection = new UserCollection();
            windowOwner = new WindowStudentViewer(this);
            this.parent = parentView;

            windowOwner.SearchStudentByNameDataGrid.DataSource = userCollection.Students;

            // Toevoegen grafiek veld.
            windowOwner.chartStudentProgress.Series.Add("Voortgang");

            // Grafiek properties aanpassen.
            windowOwner.chartStudentProgress.Series[0].IsValueShownAsLabel = true;
            windowOwner.chartStudentProgress.Series[0].LabelFormat = "P";
            windowOwner.chartStudentProgress.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            windowOwner.chartStudentProgress.Series[0].MarkerSize = 7;
            windowOwner.chartStudentProgress.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            windowOwner.chartStudentProgress.Series[0].LabelBackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            windowOwner.chartStudentProgress.ChartAreas[0].AxisY.Maximum = 1;
            windowOwner.chartStudentProgress.ChartAreas[0].AxisY.Minimum = 0;
            windowOwner.chartStudentProgress.ChartAreas[0].AxisY.LabelStyle.Format = "P";
        }

        public void Run()
        {
            Application.Run(windowOwner);
        }

        public void Show()
        {
            windowOwner.Show();
        }

        public void Hide()
        {
            windowOwner.Hide();
        }

        public void Close()
        {
            windowOwner.Close();
        }

        public void OnFormClosed()
        {
            parent.Show();
        }

        public void UpdateListStudentsFromDatabase()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                // Studentenlijst updaten
                userCollection.Students.Clear();
                List<User> UserLijst = db.Users.ToList().Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Residence = x.Residence,
                    Postalcode = x.Postalcode,
                    Email = x.Email,
                    Password = x.Password,
                    Niveau = x.Niveau,
                    Gender = x.Gender,
                    DateOfBirth = x.DateOfBirth,
                    ParentID = x.ParentID,
                    UserID = x.UserID,
                    IsOwner = x.IsOwner
                }).ToList();
                userCollection.Students = UserLijst;
            }
        }
        public void UpdateDataGridPanelWithStudent()
        {
            UpdateListStudentsFromDatabase();
            windowOwner.SearchStudentByNameDataGrid.DataSource = userCollection.Students;
        }

        public void UpdateDataGridPanelWithStudent(string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();
            windowOwner.SearchStudentByNameDataGrid.DataSource = userCollection.Students.Select(x => x).Where(x => x.FirstName.ToLower().Contains(searchCriteria) || x.LastName.ToLower().Contains(searchCriteria)).ToList();
        }

        public void SetUserInformationInPanel()
        {
            foreach (DataGridViewRow row in windowOwner.SearchStudentByNameDataGrid.SelectedRows)
            {
                // Vul info in van geselecteerde gebruiker
                SelectedStudent = row.DataBoundItem as User;
                windowOwner.StudentNamePlaceholder.Text = SelectedStudent.FirstName + " " + SelectedStudent.LastName;                    
                windowOwner.StudentAgePlaceholder.Text = SelectedStudent.CalculateAge().ToString();
                windowOwner.StudentGenderPlaceholder.Text = SelectedStudent.Gender;
                windowOwner.StudentAddressPlaceholder.Text = SelectedStudent.Address;
                windowOwner.StudentPostalcodePlaceholder.Text = SelectedStudent.Postalcode;
                windowOwner.StudentHometownPlaceholder.Text = SelectedStudent.Residence;
                windowOwner.StudentEmailPlaceholder.Text = SelectedStudent.Email;
                windowOwner.StudentLevelLabel.Text = SelectedStudent.Niveau.ToString();

                if (SelectedStudent.IsOwner) // Laat combobox en grafiek niet zien als geselecteerde gebruiker een eigenaar is. (en voeg '(eigenaar)' toe achter de naam.
                {
                    windowOwner.StudentNamePlaceholder.Text += " (Eigenaar)";
                    windowOwner.SelectDifficultyComboBox.Visible = false;
                    windowOwner.chartStudentProgress.Visible = false;
                }
                else
                {
                    // Als de geselecteerde gebruiker geen eigenaar is laat de combobox en de grafiek zien.
                    windowOwner.SelectDifficultyComboBox.Visible = true;
                    windowOwner.chartStudentProgress.Visible = true;

                    UpdateLevelComboBox();


                    if (SelectedStudent.Niveau >= 0)
                        windowOwner.SelectDifficultyComboBox.SelectedIndex = SelectedStudent.Niveau - 1;
                    else
                    {
                        // Als een niet geldig niveau is geselecteerd voor een gebruiker laat een opmerking zien.
                        windowOwner.chartStudentProgress.Series["Voortgang"].Points.Clear();
                        windowOwner.chartStudentProgress.Series["Voortgang"].Points.Add();
                        windowOwner.SelectDifficultyComboBox.Text = "Niveau is niet geldig";
                    }
                }
            }
        }

        public void OpenWindowAddStudent()
        {
            WindowAddStudentController addDialog = new WindowAddStudentController(this);
            addDialog.Show();
            windowOwner.Hide();
        }

        public void OpenWindowAddStudentWithInformation()
        {
            if (SelectedStudent != null)
            {
                WindowAddStudentController editDialog = new WindowAddStudentController(this, SelectedStudent);
                editDialog.Show();
                windowOwner.Hide();
            }
        }

        public List<Score> GetListWithScoresFromSelectedUsersAndDatabase()
        {
            // Haal lijst van scores op van de geselecteerde gebruiker
            List<Score> tempList = new List<Score>();
            using (DatabaseContext db = new DatabaseContext())
            {
                tempList = (from scores in db.Scores
                            join song in db.Songs on scores.SongID equals song.SongID
                            where song.Level == windowOwner.SelectDifficultyComboBox.SelectedIndex + 1 && scores.UserID == SelectedStudent.UserID
                            select scores).ToList();
            }
            return tempList;
        }

        public void UpdateLevelComboBox()
        {
            // Pas combobox aan op het niveau van geselecteerde student.
            windowOwner.SelectDifficultyComboBox.Items.Clear();
            for (int i = 1; i <= SelectedStudent.Niveau; i++)
            {
                windowOwner.SelectDifficultyComboBox.Items.Add("Niveau: " + i);
            }
        }

        public void UpdateLevelGraph()
        {
            // Leeg de grafiek
            windowOwner.chartStudentProgress.Series[0].Points.Clear();
            windowOwner.chartStudentProgress.Series[0].IsValueShownAsLabel = true;
            List<Score> tempList = GetListWithScoresFromSelectedUsersAndDatabase();

            if (tempList.Count == 0) // Als er geen scores voor dit niveau zijn, voeg een leeg datapunt toe zodat er een lege grafiek getekent word.
            {
                windowOwner.chartStudentProgress.Series[0].Points.Add();
                windowOwner.chartStudentProgress.Series[0].Points[0].Label = "De geselecteerde gebruiker heeft nog \ngeen nummers van dit niveau afgespeeld.";
                windowOwner.chartStudentProgress.Series[0].IsValueShownAsLabel = false;
                return;
            }

            using (DatabaseContext db = new DatabaseContext())
            {
                foreach (Score s in tempList) // Ga alle scores langs in de lijst
                {
                    // Haal naam van liedje van score op.
                    string songname = (from song in db.Songs
                                       where song.SongID == s.SongID
                                       select song.Name).Single();

                    // Voeg score toe aan grafiek.
                    windowOwner.chartStudentProgress.Series[0].Points.AddY(s.Percentage);

                    // Haal score id op.
                    int index = windowOwner.chartStudentProgress.Series[0].Points.Count() - 1;

                    // verander label van de score in de grafiek.
                    windowOwner.chartStudentProgress.Series[0].Points[index].AxisLabel = songname + "\n" + s.Date;
                }
            }
        }
    }
}
