using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using KBS2VirtuelePiano.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace KBS2VirtuelePiano.Controller
{

    public class WindowStudentController
    {

        public WindowStudent windowLeerling;
        private ScorePopup scorePopup;
        public SongPlayer songPlayer;
        private SongProgress songProgress;
        private WindowLoginController parent;
        private Dictionary<int, PianoButton> buttons;

        public WindowStudentController(WindowLoginController wlc)
        {
            this.windowLeerling = new WindowStudent(this);
            windowLeerling.Show();
            this.parent = wlc;

            songPlayer = new SongPlayer(this, null);
            songProgress = new SongProgress(songPlayer);
            scorePopup = new ScorePopup();
            buttons = new Dictionary<int, PianoButton>();

            // Voeg alle knoppen voor het 4e octaaf toe
            buttons[81] = new PianoButton(Piano.BASE_OCTAAF, "C");
            buttons[50] = new PianoButton(Piano.BASE_OCTAAF, "C#");
            buttons[87] = new PianoButton(Piano.BASE_OCTAAF, "D");
            buttons[51] = new PianoButton(Piano.BASE_OCTAAF, "D#");
            buttons[69] = new PianoButton(Piano.BASE_OCTAAF, "E");
            buttons[82] = new PianoButton(Piano.BASE_OCTAAF, "F");
            buttons[53] = new PianoButton(Piano.BASE_OCTAAF, "F#");
            buttons[84] = new PianoButton(Piano.BASE_OCTAAF, "G");
            buttons[54] = new PianoButton(Piano.BASE_OCTAAF, "G#");
            buttons[89] = new PianoButton(Piano.BASE_OCTAAF, "A");
            buttons[55] = new PianoButton(Piano.BASE_OCTAAF, "A#");
            buttons[85] = new PianoButton(Piano.BASE_OCTAAF, "B");

            // Voeg alle knoppen voor het 5e octaaf toe
            buttons[90] = new PianoButton(Piano.BASE_OCTAAF + 1, "C");
            buttons[83] = new PianoButton(Piano.BASE_OCTAAF + 1, "C#");
            buttons[88] = new PianoButton(Piano.BASE_OCTAAF + 1, "D");
            buttons[68] = new PianoButton(Piano.BASE_OCTAAF + 1, "D#");
            buttons[67] = new PianoButton(Piano.BASE_OCTAAF + 1, "E");
            buttons[86] = new PianoButton(Piano.BASE_OCTAAF + 1, "F");
            buttons[71] = new PianoButton(Piano.BASE_OCTAAF + 1, "F#");
            buttons[66] = new PianoButton(Piano.BASE_OCTAAF + 1, "G");
            buttons[72] = new PianoButton(Piano.BASE_OCTAAF + 1, "G#");
            buttons[78] = new PianoButton(Piano.BASE_OCTAAF + 1, "A");
            buttons[74] = new PianoButton(Piano.BASE_OCTAAF + 1, "A#");
            buttons[77] = new PianoButton(Piano.BASE_OCTAAF + 1, "B");
        }

        public void ProcessKeyDown(System.Windows.Forms.KeyEventArgs args)
        {

            int kc = args.KeyValue;

            // Does this button matter? If not, never mind.
            if (!buttons.ContainsKey(kc))
                return;
            PianoButton b = buttons[kc];

            // Is this key already pressed? Nevermind then.
            if (b.pressed)
                return;

            // Light 'em up
            LightUp(b.octave, b.letter, b.black);

            // Play sound
            songPlayer.PlayNote(new Note(
                Note.GetNoteLetterFromLetter(b.letter),
                b.octave,
                b.black,
                ComponentLength.FULL,
                0
            ));

            // Set this button to be pressed
            b.pressed = true;

            // Register the key press
            songProgress.Register(b);
        }

        public void ProcessKeyUp(System.Windows.Forms.KeyEventArgs args)
        {
            int kc = args.KeyValue;

            // Pak de knop. Bestaat ie niet? Laat maar.
            if (!buttons.ContainsKey(kc))
                return;
            PianoButton b = buttons[kc];

            // Light 'em.. down
            LightDown(b.octave, b.letter, b.black);
            b.pressed = false;

            // Stop the sound!
            SoundHelper.StopNote(new Note(Note.GetNoteLetterFromLetter(b.letter), b.octave, b.black, ComponentLength.FULL, 0));
            //SoundHelper.Cleanup();
        }

        public void Run()
        {
            Application.Run(windowLeerling);
        }

        public void Show()
        {
            windowLeerling.Show();
        }

        public void Hide()
        {
            windowLeerling.Hide();
        }

        public void Tick()
        {
            songPlayer.Tick();
        }

        public void Stop()
        {
            songPlayer.Stop();
            windowLeerling.panelPiano.Piano.ResetAll();
            songProgress.Reset();
            windowLeerling.tempoToolStripMenuItem.Enabled = true;
        }

        public void Pause()
        {
            songPlayer.Pause();
            windowLeerling.panelPiano.Piano.ResetAll();
            //windowLeerling.tempoToolStripMenuItem.Enabled = true;
        }

        public void Start()
        {
            scorePopup.Hide();
            songPlayer.Start();
            foreach (Note n in songPlayer.currentNotes)
            {
                windowLeerling.panelPiano.Piano.Enable(n.Octave, n.Letter.ToString(), false);
            }
            windowLeerling.tempoToolStripMenuItem.Enabled = false;

        }

        public void ToggleSound()
        {
            songPlayer.ToggleSound();
        }

        public void ToggleNoteLength()
        {
            songPlayer.ToggleNoteLength();
        }

        public void LightUp(int octave, string name, bool black)
        {
            windowLeerling.panelPiano.Piano.Enable(octave, name, black);
        }

        public void LightDown(int octave, string name, bool black)
        {
            windowLeerling.panelPiano.Piano.Disable(octave, name, black);
        }

        public void SongFinished()
        {
            decimal score = songProgress.GetResultingScore();
            songProgress.Reset();

            // Popup
            scorePopup.SetText(score);
            scorePopup.Show();

            // Build Score object
            Score sc = new Score();
            sc.Percentage = score;
            sc.UserID = WindowLoginController.LoggedInUser.UserID;
            sc.Date = DateTime.Now;

            // Toevoegen aan db
            using (DatabaseContext db = new DatabaseContext())
            {
                sc.SongID = songPlayer.CurrentSong.SongID;

                db.Scores.Add(sc);
                Console.WriteLine("Added Score");
                db.SaveChanges();
            }
            windowLeerling.tempoToolStripMenuItem.Enabled = true;
        }
        public void ChangeTempo(int index)
        {
            int tempo = 0;
            switch (index)
            {
                case 0:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute * 0.25);
                    break;
                case 1:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute * 0.5);
                    break;
                case 2:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute * 0.75);
                    break;
                case 3:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute);
                    break;
                case 4:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute * 2);
                    break;
                case 5:
                    tempo = (int)(songPlayer.CurrentSong.BeatsPerMinute * 4);
                    break;

            }
            songPlayer.Bpm = tempo;
        }

        public void ShowMyProgress()
        {
            new WindowStudentProgressController(this).Show();
            Hide();
        }
        public void LogOut()
        {
            parent.Logout();
            this.Hide();
            parent.Show();
        }
    }
}

