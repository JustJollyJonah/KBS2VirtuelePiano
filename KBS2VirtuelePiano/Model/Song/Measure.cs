using KBS2VirtuelePiano.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class Measure
    {
        public List<SongComponent> Components;

        public Measure()
        {
            Components = new List<SongComponent>();
        }

        public List<SongComponent> GetComponentsAt(int x)
        {
            return (from c in Components
                    where c.X == x
                    select c).ToList();
        }

    }
}
