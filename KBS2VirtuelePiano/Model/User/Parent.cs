using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model
{
    public class Parent
    {
        public int ParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Residence { get; set; }
        public string Postalcode { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public Parent() { }
        public Parent(string fn, string ln, string ad, string rs, string pc, string em, string ge)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Address = ad;
            this.Residence = rs;
            this.Postalcode = pc;
            this.Email = em;
            this.Gender = ge;
        }
    }
}
