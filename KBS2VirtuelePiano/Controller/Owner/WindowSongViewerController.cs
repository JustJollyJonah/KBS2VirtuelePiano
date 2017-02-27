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
    public class WindowSongViewerController
    {
        public UserCollection userCollection;
        private WindowSongViewer windowSongViewer;
        private WindowOwnerMenuController parent;
        public Song SelectedSong { get; set; }

        public WindowSongViewerController(WindowOwnerMenuController parentView)
        {
            userCollection = new UserCollection();
            windowSongViewer = new WindowSongViewer(this);
            this.parent = parentView;

            windowSongViewer.SearchSongByNameDataGrid.DataSource = userCollection.Songs;
        }

        public void Show()
        {
            windowSongViewer.Show();
            UpdateDataGridPanelWithSongs();
            windowSongViewer.SearchSongByNameDataGrid.Columns[1].DisplayIndex = 2;
            windowSongViewer.SearchSongByNameDataGrid.Columns[1].Width = 45;
            windowSongViewer.SearchSongByNameDataGrid.Columns[1].HeaderText = "Niveau";
            windowSongViewer.SearchSongByNameDataGrid.Columns[0].DisplayIndex = 1;
            windowSongViewer.SearchSongByNameDataGrid.Columns[0].HeaderText = "Auteur";
            windowSongViewer.SearchSongByNameDataGrid.Columns[2].HeaderText = "Titel";
        }

        public void Hide()
        {
            windowSongViewer.Hide();
        }

        public void Close()
        {
            windowSongViewer.Close();
        }

        public void OnFormClosed()
        {
            parent.Show();
        }

        public void OnAddSongButtonClick()
        {                        
            WindowEditor yolo = new WindowEditor(this);
            yolo.Show();
            windowSongViewer.Hide();
        }

        public void UpdateListSongsFromDatabase()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                // liederenlijst updaten
                userCollection.Students.Clear();
                List<Song> SongLijst = db.Songs.ToList().Select(x => new Song()
                {
                    SongID = x.SongID,
                    Author = x.Author,
                    Level = x.Level,
                    Name = x.Name,
                    BeatsPerMinute = x.BeatsPerMinute,
                    BeatsPerMeasure = x.BeatsPerMeasure,
                    BeatLength = x.BeatLength
                }).ToList();
                userCollection.Songs = SongLijst;
            }
        }

        public void UpdateDataGridPanelWithSongs()
        {
            UpdateListSongsFromDatabase();
            windowSongViewer.SearchSongByNameDataGrid.DataSource = userCollection.Songs;
        }

        public void UpdateDataGridPanelWithSongs(string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();
            windowSongViewer.SearchSongByNameDataGrid.DataSource = userCollection.Songs.Select(x => x).Where(x => x.Name.ToLower().Contains(searchCriteria) || x.Author.ToLower().Contains(searchCriteria)).ToList();
        }

        public void SetSongInformationInPanel()
        {
            foreach (DataGridViewRow row in windowSongViewer.SearchSongByNameDataGrid.SelectedRows)
            {
                SelectedSong = row.DataBoundItem as Song;
                windowSongViewer.SongNamePlaceholder.Text = SelectedSong.Name;
                windowSongViewer.SongAuthorPlaceholder.Text = SelectedSong.Author;
                windowSongViewer.SongLevelPlaceholder.Text = SelectedSong.Level.ToString();
            }
        }
    }
}
