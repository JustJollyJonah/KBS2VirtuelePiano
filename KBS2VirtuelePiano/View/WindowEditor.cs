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
        public int teller;
        public List<int> listWithLevels  = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 , 13 , 14 ,15, 16, 17, 18, 19, 20};

        public WindowEditor(WindowSongViewerController w)
        {
            InitializeComponent();
            this.wsvc = w;
            this.levelSelectBox.DataSource = listWithLevels;
            counter = 0;
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
            if (counter == 0)
                this.WindowPanelEditor.Controls.Add(new Row(0, counter));
            else
                this.WindowPanelEditor.Controls.Add(new Row((120 * counter), counter));
            counter++;
            this.WindowPanelEditor.VerticalScroll.Value = tempScrollValue;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.WindowPanelEditor.Controls.Count != 0)
            {
                if (authorTextfield.Text.Trim() != "" && titelSongTextField.Text.Trim() != "")
                {
                    int counterForAbsX = 0;
                    List<SongComponent> compiledList = new List<SongComponent>();
                    foreach (var list in this.WindowPanelEditor.Controls.OfType<Row>())
                    {
                        for (int i = 0; i < list.ListWithSongComponents.Count; i++)
                        {
                            SongComponent tempComponent = list.ListWithSongComponents[i];
                            tempComponent.AbsoluteX = counterForAbsX;
                            compiledList.Add(tempComponent);
                            counterForAbsX += 2;
                        }
                    }
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        db.Songs.Add(new Song()
                        {
                            Author = authorTextfield.Text,
                            Level = Int32.Parse(levelSelectBox.SelectedValue.ToString()),
                            Name = titelSongTextField.Text
                        });
                        db.SaveChanges();
                        Song song =
                            db.Songs.Select(x => x)
                                .Where(x => x.Name == titelSongTextField.Text && x.Author == authorTextfield.Text)
                                .FirstOrDefault();
                        int songId = song.SongID;
                        foreach (SongComponent sc in compiledList)
                        {
                            sc.songID = songId;
                            sc.X = (sc.X % 8);
                            db.SongComponents.Add(sc);
                        }
                        db.SaveChanges();
                        MessageBox.Show("Het lied is toegevoegd");
                        wsvc.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("U heeft geen rijen aangemaakt");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            wsvc.Show();
            this.Close();
        }
    }
}
