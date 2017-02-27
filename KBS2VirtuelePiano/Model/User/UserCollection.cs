using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class UserCollection
    {
        public List<User> Students;
        public List<Song> Songs;

        public UserCollection()
        {
            Students = new List<User>();
            Songs = new List<Song>();
        }
    }
}
