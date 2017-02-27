using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.Helper;
using System.ComponentModel;

namespace KBS2VirtuelePiano.Model
{
    public class User
    {
        [Browsable(false)]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Browsable(false)]
        public string Address { get; set; }
        [Browsable(false)]
        public string Residence { get; set; }
        [Browsable(false)]
        public string Postalcode { get; set; }
        [Browsable(false)]
        public string Email { get; set; }
        [Browsable(false)]
        public DateTime DateOfBirth { get; set; }
        [Browsable(false)]
        public string Gender { get; set; }
        [Browsable(false)]
        public string Password { get; set; }
        [Browsable(false)]
        public int Niveau { get; set; }
        [Browsable(false)]
        public bool IsOwner { get; set; }
        [Browsable(false)]
        public int? ParentID { get; set; }
        [Browsable(false)]
        public virtual Parent Parent { get; set; }

        //Default Constructor for lambda expressions

        public User() { }
        
        public User(string fn, string ln, string ge, string ad, string re, string pc, string em, string pw, int lv, bool ow, DateTime dt)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Gender = ge;
            this.Address = ad;
            this.Postalcode = pc;
            this.Residence = re;
            this.Email = em;
            this.Password = EncryptionHelper.HashStringSHA512(pw); // Gehashte wachtwoord opslaan
            this.Niveau = lv;
            this.IsOwner = ow;
            this.DateOfBirth = dt;
        }

        public int CalculateAge()
        {
            // Reken leeftijd uit met behulp van geboortedatum.
            DateTime today = DateTime.Today; // 2016
            int age = today.Year - DateOfBirth.Year; // 2016 - 1998 = 18
            if (DateOfBirth > today.AddYears(-age)) age--; // if (1998 > (2016 + -18)) 18--; Voor het geval dat ze in jaren al 18 zijn maar in dagen nog 17.
            return age;
        }
    }
}
