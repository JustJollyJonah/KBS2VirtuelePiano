using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class SongProgress
    {

        private SongPlayer SongPlayer { get; }

        private Dictionary<SongComponent, bool> Hits;
        public int HitCount { get; private set; }

        public SongProgress(SongPlayer songPlayer)
        {
            SongPlayer = songPlayer;
            Reset();
        }

        public void Register(PianoButton pb)
        {
            // Ignore if we're not playing
            if (!SongPlayer.IsRunning)
                return;

            List<Note> notes = SongPlayer.currentNotes;

            // Iterate over all current notes to see if the pressed button
            // should've been pressed at all.
            foreach(Note n in notes)
            {
                // A PianoButton equals a Note when it's the same octave, letter and key color.
                if (pb.Equals(n))
                {
                    // We know the user pressed a button he should have; but now we need to check
                    // if he has already hit the button before.

                    // If it was already hit, decrease score, otherwise increase it.
                    if (Hits.ContainsKey(n))
                    {
                        HitCount--;
                    }else
                    {
                        HitCount++;
                        Hits[n] = true;
                    }
                    return;
                }
            }
            HitCount--;
        }

        public decimal GetResultingScore()
        {
            int maximumScore = GetMaximumScore();

            // Calculate the fraction of hits as a percentage
            decimal score = (decimal) ((double) HitCount / (double)maximumScore);

            return score < 0 ? 0 : score;
        }

        public int GetMaximumScore()
        {
            Song s = SongPlayer.CurrentSong;
            if (s == null)
                return 0;

            // Calculate the maximum possible score for this song
            return s.Measures.Aggregate(0, (a, measure) =>
            {
                return measure.Components.Aggregate(a, (b, component) =>
                {
                    return b + ((component is Note) ? 1 : 0);
                });
            });
        }

        public void Reset()
        {
            Hits = new Dictionary<SongComponent, bool>();
            HitCount = 0;
        }
        
    }
}
