using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class PianoButton
    {
        public int octave;
        public string letter;
        public bool black;
        public bool pressed;

        public PianoButton(int oct, string ltr)
        {
            octave = oct;
            black = ltr.EndsWith("#");
            letter = ltr.Substring(0, 1);
            pressed = false;
        }

        public override bool Equals(object obj)
        {
            if (obj is PianoButton)
            {
                PianoButton pb = (PianoButton)obj;
                return pb.octave == this.octave &&
                    pb.letter == this.letter &&
                    pb.black == this.black;
            } else if (obj is Note)
            {
                Note note = (Note)obj;
                return note.Octave == this.octave &&
                    note.Letter.ToString() == this.letter &&
                    note.Black == this.black;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
