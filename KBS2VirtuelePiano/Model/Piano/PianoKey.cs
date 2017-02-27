using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KBS2VirtuelePiano.Model
{
    public class PianoKey
    {

        public int Octave { get; }
        public string Name { get; }
        public bool Black { get; }
        public bool Enabled { get; set; }

        public PianoKey(int octave, string name)
        {
            Octave = octave;
            Name = name;
            Black = name.EndsWith("#");
            Enabled = false;
        }

        public override bool Equals(object obj)
        {
            if (obj is PianoKey)
            {
                PianoKey pk = (PianoKey)obj;
                return pk.Octave == Octave &&
                    pk.Name == Name &&
                    pk.Black == Black;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}
