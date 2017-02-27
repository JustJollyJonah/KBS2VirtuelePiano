using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace KBS2VirtuelePiano.Controller
{
    public class WindowSelectSongController
    {
        private WindowSelectSong windowSelectSong;
        List<Song> songList;
        public Song SelectedSong { get; set; }
        private WindowStudentController parent;
        public WindowSelectSongController(WindowStudentController p)
        {
            this.parent = p;
            windowSelectSong = new WindowSelectSong(this);
            PopulateLevelCombobox();
            songList = new List<Song>();
        }

        public void Run()
        {
            windowSelectSong.ShowDialog();
        }

        public void UpdateListSongsFromDatabase()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                songList.Clear();
                var songs = db.Songs.ToList().Select(x => new Song()
                {
                    SongID = x.SongID,
                    Name = x.Name,
                    Author = x.Author,
                    Level = x.Level,
                    BeatsPerMinute = x.BeatsPerMinute,
                    BeatsPerMeasure = x.BeatsPerMeasure,
                    BeatLength = x.BeatLength
                }).ToList();
                songList = songs;
            }
        }
        public void InitDataGridView() //call op form load
        {
            UpdateListSongsFromDatabase();
            windowSelectSong.dataGridViewPanel.DataSource = songList;
            windowSelectSong.dataGridViewPanel.Columns[1].DisplayIndex = 2;
            windowSelectSong.dataGridViewPanel.Columns[1].Width = 45;
            windowSelectSong.dataGridViewPanel.Columns[1].HeaderText = "Niveau";
            windowSelectSong.dataGridViewPanel.Columns[0].DisplayIndex = 1;
            windowSelectSong.dataGridViewPanel.Columns[0].HeaderText = "Auteur";
            windowSelectSong.dataGridViewPanel.Columns[2].HeaderText = "Titel";

            foreach (DataGridViewRow row in windowSelectSong.dataGridViewPanel.SelectedRows)
            {
                SelectedSong = row.DataBoundItem as Song;
            }
        }

        public void UpdateDataGridPanelWithSongsOnLevel(int searchCritiria)
        {
            if (searchCritiria > WindowLoginController.LoggedInUser.Niveau)
            {
                var result = songList.Where(x => x.Level <= WindowLoginController.LoggedInUser.Niveau).ToList();
                result = result.Where(x => x.Author.Contains(windowSelectSong.SearchTextBox.Text) || x.Name.Contains(windowSelectSong.SearchTextBox.Text)).ToList();
                windowSelectSong.dataGridViewPanel.DataSource = result;
            }
            else
            {
                var result = songList.Where(x => x.Level.Equals(searchCritiria)).ToList();
                result = result.Where(x => x.Author.Contains(windowSelectSong.SearchTextBox.Text) || x.Name.Contains(windowSelectSong.SearchTextBox.Text)).ToList();
                windowSelectSong.dataGridViewPanel.DataSource = result;
            }
        }

        public void UpdateDataGridPanelWithSongs(string searchCritiria)
        {
            if (windowSelectSong.comboBox1.SelectedIndex > WindowLoginController.LoggedInUser.Niveau)
            {
                var result = songList.Where(x => x.Author.ToLower().Contains(searchCritiria.ToLower()) || x.Name.ToLower().Contains(searchCritiria.ToLower())).ToList();
                result = result.Where(x => x.Level <= WindowLoginController.LoggedInUser.Niveau).ToList();
                windowSelectSong.dataGridViewPanel.DataSource = result;
            }
            else
            {
                var result = songList.Where((x => x.Author.ToLower().Contains(searchCritiria.ToLower()) || x.Name.ToLower().Contains(searchCritiria.ToLower()))).ToList();
                result = result.Where((x => x.Level.Equals(windowSelectSong.comboBox1.SelectedIndex))).ToList();
                windowSelectSong.dataGridViewPanel.DataSource = result;
            }

        }

        public void UpdateSelectedSong()
        {
            foreach (DataGridViewRow row in windowSelectSong.dataGridViewPanel.SelectedRows)
            {
                SelectedSong = row.DataBoundItem as Song;
            }
        }

        public void PopulateLevelCombobox() // call op load
        {
            for (int i = 1; i <= WindowLoginController.LoggedInUser.Niveau; i++)
            {
                windowSelectSong.comboBox1.Items.Add("Niveau " + i);
            }
            string AllNiveau = "Alle Niveau's";
            windowSelectSong.comboBox1.Items.Add(AllNiveau);
        }

        public void CancelSelectSong()
        {
            windowSelectSong.Close();
        }

        public void OpenSong()
        {
            List<SongComponent> selectedSongComponents = new List<SongComponent>();
            using (DatabaseContext db = new DatabaseContext())
            {
                //var ding = db.SongComponents;
                var comps = from sc in db.SongComponents.ToList() where sc.songID == SelectedSong.SongID orderby sc.AbsoluteX ascending select sc;
                selectedSongComponents = comps.ToList();
            }
            SelectedSong.Measures.Clear();

            //Song songToLoad = new Song(SelectedSong.BeatsPerMeasure, (int)SelectedSong.BeatLength);
            if (selectedSongComponents.Count > 0) { 
            Measure measure = new Measure();

            int getal = 0;
            foreach (SongComponent sc in selectedSongComponents)
            {

                getal += (int)sc.Length;

                if (getal > SelectedSong.MeasureLength)
                {
                    SelectedSong.Measures.Add(measure);
                    measure = new Measure();
                    getal = 0 + (int)sc.Length;
                }

                if (sc is Note)
                {
                    Note s = (Note)sc;
                    Note note = new Note((NoteLetter)sc.Y, sc.Octave, s.Black, sc.Length, sc.X);
                    measure.Components.Add(note);
                }
                else
                {
                    Rest rest = new Rest(sc.Length, sc.X);
                    measure.Components.Add(rest);
                }
            }

            if (measure.Components.Count > 0)
            {
                SelectedSong.Measures.Add(measure);
            }

            parent.songPlayer.CurrentSong = SelectedSong;
            parent.songPlayer.Bpm = SelectedSong.BeatsPerMinute;

            // Enable afspeelknopjes
            parent.windowLeerling.buttonStart.Enabled = true;
            parent.windowLeerling.buttonStop.Enabled = true;
            parent.windowLeerling.buttonPause.Enabled = true;
            windowSelectSong.Close();
            parent.windowLeerling.xToolStripMenuItem2.Checked = true;
            parent.windowLeerling.xToolStripMenuItem1.Checked = false;
            parent.windowLeerling.xToolStripMenuItem.Checked = false;
            parent.windowLeerling.xToolStripMenuItem3.Checked = false;
            parent.windowLeerling.toolStripMenuItem2.Checked = false;
            parent.windowLeerling.xToolStripMenuItem4.Checked = false;
            } else
            {
                MessageBox.Show("Liedje heeft geen noten!");
            }

        }

    }
}
