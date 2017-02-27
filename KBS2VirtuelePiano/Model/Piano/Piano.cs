using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class Piano
    {

        public static readonly int BASE_OCTAAF = 4;
        public static readonly int OCTAVEN = 2;

        public List<PianoKey> Keys { get; set; }

        public Piano()
        {
            Keys = new List<PianoKey>();

            for (int i = OCTAVEN - 1; i >= 0; i--)
            {
                Keys = Keys.Concat(new List<PianoKey>() {
                    new PianoKey(BASE_OCTAAF + i, "C"),
                    new PianoKey(BASE_OCTAAF + i, "C#"),
                    new PianoKey(BASE_OCTAAF + i, "D"),
                    new PianoKey(BASE_OCTAAF + i, "D#"),
                    new PianoKey(BASE_OCTAAF + i, "E"),
                    new PianoKey(BASE_OCTAAF + i, "F"),
                    new PianoKey(BASE_OCTAAF + i, "F#"),
                    new PianoKey(BASE_OCTAAF + i, "G"),
                    new PianoKey(BASE_OCTAAF + i, "G#"),
                    new PianoKey(BASE_OCTAAF + i, "A"),
                    new PianoKey(BASE_OCTAAF + i, "A#"),
                    new PianoKey(BASE_OCTAAF + i, "B")
                }).ToList();
            }
        }

        public PianoKey FindKey(int octave, string name, bool black)
        {
            var keys =
                from key in Keys
                where key.Octave == octave
                    && key.Name.StartsWith(name)
                    && key.Black == black
                select key;
            return keys.Count() > 0 ? keys.First() : null;
        }

        public List<PianoKey> FindKeys(int octave, bool black)
        {
            return (
                from key in Keys
                where key.Octave == octave
                    && key.Black == black
                select key
            ).ToList();
        }

        public void Enable(int octave, string name, bool black)
        {
            var key = FindKey(octave, name, black);
            if (key != null)
                key.Enabled = true;
           
        }

        public void Disable(int octave, string name, bool black)
        {
            var key = FindKey(octave, name, black);
            if (key != null)
                key.Enabled = false;
        }

        public void ResetAll()
        {
            foreach (PianoKey key in Keys)
                key.Enabled = false;
        }

    }
}
