using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public enum ComponentLength
    {
        FULL = 8, HALF = 4, QUARTER = 2, EIGHTH = 1
    }

    public abstract class SongComponent
    {
        public int songComponentID { get; set; }
        public int songID { get; set; }
        public ComponentLength Length { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AbsoluteX { get; set; }
        public int Octave { get; set; }
        public virtual Song Song { get; set; }

        public SongComponent() { }

        public SongComponent(ComponentLength length, int x, int y, int absoluteX, int octave)
        {
            this.Length = length;
            this.X = x;
            this.Y = y;
            this.AbsoluteX = absoluteX;
            this.Octave = octave;
        }

        public int GetLengthAsNumber()
        {
            return (int)Length;
        }
        
        public override string ToString()
        {
            return String.Format(
                "SongComponent(length={0}, x={1}, y={2}, absX={3}, oct={4})",
                Length.ToString(),
                X,
                Y,
                AbsoluteX,
                Octave
            ); 
        }
    }
}
