using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int UserID { get; set; }
        public int SongID { get; set; }
        public decimal Percentage { get; set; }
        public DateTime Date { get; set; }

        public virtual Song Song { get; set; } 
        public virtual User User { get; set; }
    }
}
