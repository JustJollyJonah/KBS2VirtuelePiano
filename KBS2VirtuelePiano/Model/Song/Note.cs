using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    
    public enum NoteLetter
    {
        B, A, G, F, E, D, C
    }

    public class Note : SongComponent
    {
        public NoteLetter Letter {
            get
            {
                return (NoteLetter)Y;
            }
            set
            {
                Y = (int)value;
            }
        }

        public bool Black { get; set; }

        public Note() { }

        public Note(NoteLetter letter, int octave, bool black, ComponentLength length, int x) : base(length, x, (int)letter, 0, octave)
        {
            this.Black = black;
        }

        public Note(NoteLetter letter, int octave, bool black, ComponentLength length, int x, int absoluteX) : base(length, x, (int)letter, absoluteX, octave)
        {
            this.Black = black;
        }

        public int GetLocalKeyNumber()
        {
            switch(Letter) {
                case NoteLetter.E: return 4;
                case NoteLetter.D: return 2 + (Black ? 1 : 0);
                case NoteLetter.C: return 0 + (Black ? 1 : 0);
                case NoteLetter.B: return 11 + (Black ? 1 : 0);
                case NoteLetter.A: return 9 + (Black ? 1 : 0);
                case NoteLetter.G: return 7 + (Black ? 1 : 0);
                case NoteLetter.F: return 5 + (Black ? 1 : 0);
            }
            return -1;
        }

        public int GetAbsoluteKeyNumber()
        {
            return (Octave * 12) + GetLocalKeyNumber() - 8;
        }
        
        public double GetFrequencyInHz()
        {
            return Math.Pow(Math.Pow(2, 1.0d / 12.0d), GetAbsoluteKeyNumber() - 49) * 440;
        }

        public static NoteLetter GetNoteLetterFromLetter(string letter)
        {
            switch(letter)
            {
                case "B": return NoteLetter.B;
                case "A": return NoteLetter.A;
                case "G": return NoteLetter.G;
                case "F": return NoteLetter.F;
                case "E": return NoteLetter.E;
                case "D": return NoteLetter.D;
                default: return NoteLetter.C;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Note)
            {
                Note n = (Note)obj;
                return n.Octave == this.Octave &&
                    n.Letter == this.Letter &&
                    n.Black == this.Black &&
                    n.X == this.X;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format(
                "Note(length={0}, x={1}, letter={2}, black={3}, absX={4}, oct={5})",
                Length.ToString(),
                X,
                Letter.ToString(),
                Black,
                AbsoluteX,
                Octave
            );
        }

        public static NoteLetter GetNoteLetterFromY(int y)
        {
            int tempY = y;
            if(tempY >= 7)
                tempY = tempY % 7;
            switch (tempY)
            {
                case 0: return NoteLetter.B;
                case 1: return NoteLetter.A;
                case 2: return NoteLetter.G;
                case 3: return NoteLetter.F;
                case 4: return NoteLetter.E;
                case 5: return NoteLetter.D;
                case 6: return NoteLetter.C;
                default: return NoteLetter.C;
            }
        }

        public static int GetOctaveFromY(int y)
        {
            if (y < 7)
                return 5;
            else
            {
                int counter = 0;
                while (y >= 7)
                {
                    y -= 7;
                    counter++;
                }
                return 5 - counter;
            }               
        }

    }
}
