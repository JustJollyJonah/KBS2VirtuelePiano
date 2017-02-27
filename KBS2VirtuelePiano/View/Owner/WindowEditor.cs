using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.View
{
    public partial class WindowEditor : Form
    {
        public WindowSongViewerController wsvc;
        private int counter;
        public List<int> listWithLevels  = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13 , 14 ,15, 16, 17, 18, 19, 20};

        public WindowEditor(WindowSongViewerController w)
        {
            InitializeComponent();
            this.wsvc = w;
            counter = 1;
            Row r = new Row(0, 0);
            this.WindowPanelEditor.Controls.Add(r);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tempScrollValue = this.WindowPanelEditor.VerticalScroll.Value;
            this.WindowPanelEditor.VerticalScroll.Value = 0;
            this.WindowPanelEditor.HorizontalScroll.Value = 0;

            Row r = new Row(counter == 0 ? 0 : (120 * counter), counter);
            r.PositionX = -this.WindowPanelEditor.HorizontalScroll.Value;
            this.WindowPanelEditor.Controls.Add(r);

            counter++;
            this.WindowPanelEditor.VerticalScroll.Value = tempScrollValue;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (authorTextfield.Text.Trim() != "" && titelSongTextField.Text.Trim() != "") 
            {
                int counterForAbsX = 0;
                List<SongComponent> compiledList = new List<SongComponent>();
                foreach (var list in this.WindowPanelEditor.Controls.OfType<Row>())
                {
                    for(int i = 0; i < list.ListWithSongComponents.Count; i++)
                    {
                        SongComponent tempComponent = list.ListWithSongComponents[i];
                        tempComponent.AbsoluteX = counterForAbsX;
                        compiledList.Add(tempComponent);
                        counterForAbsX += 2;
                    }
                }
                if(compiledList.Count == 0)
                {
                    MessageBox.Show("Lied bevat geen componenten");
                    return;
                }
                using (DatabaseContext db = new DatabaseContext())
                {
                    var result = db.Songs.Where(x => x.Name == titelSongTextField.Text && x.Author == authorTextfield.Text);
                    if (result.Count() >= 1)
                    {
                        MessageBox.Show("Lied met dezelfde titel en auteur bestaat al! Kies a.u.b. een andere titel of auteur.");
                        return;
                    }
                    Song song = new Song() { Author = authorTextfield.Text, Level = Int32.Parse(numericUpDown1.Value.ToString()), Name = titelSongTextField.Text };
                    db.Songs.Add(song);
                    db.SaveChanges();
                    int songId = song.SongID;
                    foreach (SongComponent sc in compiledList)
                    {
                        sc.songID = songId;
                        sc.X = (sc.X % 8);
                        db.SongComponents.Add(sc);
                    }
                    db.SaveChanges();
                    this.Hide();
                    wsvc.Show();
                    MessageBox.Show("Het lied is toegevoegd");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            wsvc.Show();
            this.Close();
        }
    }
}
