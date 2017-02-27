using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowStudentProgressController
    {
        private WindowStudentProgress windowStudentProgress;
        private WindowStudentController parent;

        public WindowStudentProgressController(WindowStudentController parent)
        {
            windowStudentProgress = new WindowStudentProgress(this);
            this.parent = parent;

            // Details laten zien van ingelogde gebruiker
            windowStudentProgress.StudentNamePlaceholder.Text = WindowLoginController.LoggedInUser.FirstName + " " + WindowLoginController.LoggedInUser.LastName;
            windowStudentProgress.StudentAgePlaceholder.Text = WindowLoginController.LoggedInUser.CalculateAge().ToString();
            windowStudentProgress.StudentGenderPlaceholder.Text = WindowLoginController.LoggedInUser.Gender;
            windowStudentProgress.StudentAddressPlaceholder.Text = WindowLoginController.LoggedInUser.Address;
            windowStudentProgress.StudentPostalcodePlaceholder.Text = WindowLoginController.LoggedInUser.Postalcode;
            windowStudentProgress.StudentHometownPlaceholder.Text = WindowLoginController.LoggedInUser.Residence;
            windowStudentProgress.StudentEmailPlaceholder.Text = WindowLoginController.LoggedInUser.Email;

            // Toevoegen grafiek veld
            windowStudentProgress.chartProgress.Series.Add("Voortgang");

            // Grafiek properties aanpassen
            windowStudentProgress.chartProgress.Series[0].IsValueShownAsLabel = true;
            windowStudentProgress.chartProgress.Series[0].LabelFormat = "P";
            windowStudentProgress.chartProgress.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            windowStudentProgress.chartProgress.Series[0].MarkerSize = 7;
            windowStudentProgress.chartProgress.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            windowStudentProgress.chartProgress.Series[0].LabelBackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            windowStudentProgress.chartProgress.ChartAreas[0].AxisY.Maximum = 1;
            windowStudentProgress.chartProgress.ChartAreas[0].AxisY.Minimum = 0;
            windowStudentProgress.chartProgress.ChartAreas[0].AxisY.LabelStyle.Format = "P";

            // Update combobox
            UpdateLevelComboBox();

            // Update grafiek
            UpdateLevelGraph();
        }

        public void Show()
        {
            // Toon scherm
            windowStudentProgress.Show();
        }

        public void Hide()
        {
            // Verberg scherm
            windowStudentProgress.Hide();
        }

        public void OnFormClosed()
        {
            // Laat bovenliggend scherm zien als dit scherm wordt gesloten
            parent.Show();
        }

        public void OnComboBoxLevelChanged()
        {
            // Update grafiek
            UpdateLevelGraph();
        }

        public void UpdateLevelComboBox()
        {
            // Pas combobox aan op het niveau van geselecteerde student.
            windowStudentProgress.comboBoxLevel.Items.Clear();
            for (int i = 1; i <= WindowLoginController.LoggedInUser.Niveau; i++)
            {
                windowStudentProgress.comboBoxLevel.Items.Add("Niveau: " + i);
            }

            // Selecteer standaard hoogste level.
            windowStudentProgress.comboBoxLevel.SelectedIndex = windowStudentProgress.comboBoxLevel.Items.Count - 1;
        }

        public void UpdateLevelGraph()
        {
            // Leeg de grafiek
            windowStudentProgress.chartProgress.Series[0].Points.Clear();
            windowStudentProgress.chartProgress.Series[0].IsValueShownAsLabel = true;
            List<Score> tempList = GetListWithScoresFromSelectedUsersAndDatabase();

            if (tempList.Count == 0) // Als er geen scores voor dit niveau zijn, voeg een leeg datapunt toe zodat er een lege grafiek getekent word.
            {
                windowStudentProgress.chartProgress.Series[0].Points.Add();
                windowStudentProgress.chartProgress.Series[0].Points[0].Label = "De geselecteerde gebruiker heeft nog \ngeen nummers van dit niveau afgespeeld.";
                windowStudentProgress.chartProgress.Series[0].IsValueShownAsLabel = false;
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
                    windowStudentProgress.chartProgress.Series[0].Points.AddY(s.Percentage);

                    // Haal score id op.
                    int index = windowStudentProgress.chartProgress.Series[0].Points.Count() - 1;

                    // verander label van de score in de grafiek.
                    windowStudentProgress.chartProgress.Series[0].Points[index].AxisLabel = songname + "\n" + s.Date;
                }
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
                            where song.Level == windowStudentProgress.comboBoxLevel.SelectedIndex + 1 && scores.UserID == WindowLoginController.LoggedInUser.UserID
                            select scores).ToList();
            }
            return tempList;
        }
    }
}
