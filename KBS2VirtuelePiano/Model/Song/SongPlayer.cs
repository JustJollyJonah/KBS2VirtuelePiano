using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Helper;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class SongPlayer
    {

        private WindowStudentController windowLeerlingController;
        public Song CurrentSong;

        // Timing
        public Stopwatch stopwatch;
        public long lastUpdate;
        public int Bpm
        {
            get;
            set;
        }

        // State
        public List<Note> currentNotes;
        public int currentX;

        public double Progress
        {
            get
            {
                // Deze property returnt de voortgang in het liedje als een double.
                // Als we bijv. halverwege de 2e noot (index=1) zijn, dan returnt hij X=1.5.

                double msPerX = CurrentSong.GetMillisecondsPerX(Bpm); // TODO: bpm
                return stopwatch.ElapsedMilliseconds / msPerX;
            }
        }

        public bool IsRunning { get { return stopwatch.IsRunning; } }

        // Audio
        public SineWaveProvider32 sineWaveProvider;
        public WaveOut waveOut;
        private float volume;

        // Settings
        public bool SoundEnabled { get; set; }
        public bool NoteLengthEnabled { get; set; }

        public SongPlayer(WindowStudentController wlc, Song song)
        {
            windowLeerlingController = wlc;
            
            // Create standard Song if none provided
            if (song == null)
            {
                // Standard song
                song = new Song(4, 4);
                //song.AutoGenerate();
                volume = 0.25f;
            }
            CurrentSong = song;
            Bpm = CurrentSong.BeatsPerMinute;

            // Timing
            stopwatch = new Stopwatch();
            lastUpdate = 0;

            // State
            currentNotes = new List<Note>();
            currentX = 0;

            SoundHelper.InitializeOutput();

            // Settings
            SoundEnabled = true;
        }
        //constructor voor editor
        public SongPlayer(Song song) 
        {
            CurrentSong = song;
            stopwatch = new Stopwatch();
            lastUpdate = 0;
        }
        
        public void PlayNote(Note note)
        {
            SineWaveProvider32 newWave = new SineWaveProvider32();
            newWave.SetWaveFormat(44100, 2);
            newWave.Amplitude = volume;
            newWave.Frequency = (float)note.GetFrequencyInHz();
            SoundHelper.PlaySound(newWave);
        }

        private void PlayNotes(int x)
        {
            int absX = currentX + x;
           
            for (int i = 0; i < currentNotes.Count; i++)
            {
                Note no = currentNotes[i];
                int noteX = no.AbsoluteX + (int)no.Length;
                if (noteX <= absX)
                {
                    StopNote(no);
                    SoundHelper.Cleanup();
                    currentNotes.RemoveAt(i--);

                    windowLeerlingController.LightDown(no.Octave, no.Letter.ToString(), no.Black);
                }
            }

            if (absX >= CurrentSong.GetXPerMeasure() * CurrentSong.Measures.Count)
            {
                if (currentNotes.Count == 0)
                {
                    Stop();
                    windowLeerlingController.SongFinished();
                }
                return;
            }


            for (int i = currentX; i < currentX + x; i++)
            {
                var songComponentsIsDat = CurrentSong.GetSongComponentsAtX(i);
                foreach (var temp in songComponentsIsDat)
                {
                    if (temp is Note)
                    {
                        Note no = (Note)temp;
                        no.AbsoluteX = i;

                        PlayNote(no);
                        currentNotes.Add(no);
                        
                        if (windowLeerlingController != null)
                            windowLeerlingController.LightUp(no.Octave, no.Letter.ToString(), no.Black);
                    }
                }
            }
            currentX += x;
        }

        public void StopNote(Note note)
        {
            SoundHelper.StopNote(note);
        }

        public void StopNote()
        {
            SoundHelper.StopAll();
        }


        /* SongPlayer functies */

        public void Start()
        {
            stopwatch.Start();
        }

        public void Pause(Note note)
        {
            StopNote(note);
            stopwatch.Stop();
        }
        public void Pause()
        {
            StopNote();
            stopwatch.Stop();
        }

        public void Stop(Note note)
        {
            Pause(note);
            currentX = 0;
            stopwatch.Reset();
            
        }
        public void Stop()
        {
            Pause();
            currentX = 0;
            stopwatch.Reset();
            currentNotes.Clear();
        }

        public void Tick()
        {
            // Kijken hoe veel tijd er gepasseerd is
            long dt = stopwatch.ElapsedMilliseconds - lastUpdate;

            // Kijk hoe veel milliseconden 1 x-coordinaat is
            // TODO: BPM bepalen en ergens vandaan halen
            double msPerX = CurrentSong.GetMillisecondsPerX(Bpm);

            // Bereken de delta X
            double elapsedX = dt / msPerX;
            int realX = (int)Math.Floor(elapsedX);

            // Bereken de milliseconden die we gebruikt hebben voor deze X-coordinaten
            lastUpdate += realX * (long)msPerX;

            // Noten afspelen
            if (realX > 0)
                PlayNotes(realX);
        }

        public void ToggleSound()
        {
            SoundEnabled = !SoundEnabled;
            volume = SoundEnabled ? 0.25f : 0f;
        }

        public void ToggleNoteLength()
        {
            NoteLengthEnabled = !NoteLengthEnabled;
        }
       
    }
}
