using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class Rest : SongComponent
    {

        public Rest() { }

        public Rest(ComponentLength length, int x) : base(length, x, 0, 0, Piano.BASE_OCTAAF) { }

        public override string ToString()
        {
            return String.Format(
                "Rest(length={0}, x={1}, absX={2})",
                Length,
                X,
                AbsoluteX
            );
        }

    }
}
