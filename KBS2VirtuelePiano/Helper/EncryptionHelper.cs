using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.Helper
{
    public static class EncryptionHelper
    {
        public static string HashStringSHA512(string s)
        {
            // Sla de string op als een byte-array.
            byte[] encodedString = Encoding.UTF8.GetBytes(s);

            byte[] hashedString;

            // Hash de string.
            using (SHA512 sha512 = new SHA512Managed())
            {
                hashedString = sha512.ComputeHash(encodedString);
            }

            // Return hash als string.
            return BitConverter.ToString(hashedString).Replace("-", string.Empty);
        }

        public static bool VerifyLogin(string username, string password)
        {
            List<User> query;

            // Username naar lowercase. invoeren van username is niet hooflettergevoelig.
            string usernameLower = username.ToLower();

            // Hash het wachtwoord
            string hashedPassword = HashStringSHA512(password);

            using (DatabaseContext db = new DatabaseContext())
            {
                // Zoek gebruiker met ingevoerde gebruikersnaam (email) en wachtwoord.
                query = (from user in db.Users
                         where user.Email.ToLower() == usernameLower
                         && user.Password == hashedPassword
                         select user).ToList();
            }

            if (query.Count() == 1) // Als deze user bestaat is er juist ingelogd.
                return true;
            else
                return false;
        }
    }
}
