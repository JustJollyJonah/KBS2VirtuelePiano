using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KBS2VirtuelePiano.Helper
{   
    static class InputInformationValidator
    {
        //Validation for studentfields with password 
        public static bool ValidateAddStudentInputWithPassword(WindowAddStudent windowAddStudent, ref string errorMessage)
        {
            bool errorBool = true;
            errorBool = ValidateAddStudentInput(windowAddStudent, ref errorMessage) ? CheckPasswordField(windowAddStudent, ref errorMessage) : false;
            return errorBool;
        }
        //Validation for parentfields 
        public static bool ValidateAddParentInput(WindowAddStudent windowAddStudent, ref string errorMessage)
        {
            bool errorBool = true;

            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentFirstName.Text))
            {
                errorMessage += "Ouder voornaam is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentLastName.Text))
            {
                errorMessage += "Ouder achternaam is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentStreet.Text))
            {
                errorMessage += "Ouder adres is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentPostalcode.Text))
            {
                errorMessage += "Ouder postcode is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentResidence.Text))
            {
                errorMessage += "Ouder woonplaats is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.AddParentEmail.Text))
            {
                errorMessage += "Ouder email is niet ingevuld\n";
            }
            if(windowAddStudent.AddParentGender.SelectedItem == null)
            {
                errorMessage += "Ouder geslacht is niet geselecteerd";
            }
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                errorBool = false;
            }
            return errorBool;
        }

        //Validation for parentfields when they must be empty
        public static bool ValidateAddParentInputReturnTrueWhenFieldsAreEmpty(WindowAddStudent windowAddStudent)
        {
            bool errorBool = true;

            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentFirstName.Text))
                errorBool = false;
            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentLastName.Text))
                errorBool = false;
            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentStreet.Text))
                errorBool = false;
            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentPostalcode.Text))
                errorBool = false;
            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentResidence.Text))
                errorBool = false;
            if (!string.IsNullOrWhiteSpace(windowAddStudent.AddParentEmail.Text))
                errorBool = false;
            if (windowAddStudent.AddParentGender.SelectedItem != null)
                errorBool = false; 
            return errorBool;
        }

        //Validate student without password field
        public static bool ValidateAddStudentInput(WindowAddStudent windowAddStudent, ref string errorMessage)
        {
            bool errorBool = false;
            if (string.IsNullOrWhiteSpace(windowAddStudent.NameTextbox.Text))
            {
                errorMessage += "Leerling voornaam is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.LastNameTextBox.Text))
            {
                errorMessage += "Leerling achternaam is niet ingevuld\n";
            }
            if (windowAddStudent.addStudentGenderComboBox.SelectedItem == null)
            {
                errorMessage += "Leerling geslacht is niet geselecteerd\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.StreetTextBox.Text))
            {
                errorMessage += "Leerling adres is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.PostalcodeTextBox.Text))
            {
                errorMessage += "Leerling postcode is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.DialogAddResidence.Text))
            {
                errorMessage += "Leerling woonplaats is niet ingevuld\n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.EmailTextBox.Text))
            {
                errorMessage += "Leerling email is niet ingevuld\n";
            }
            int domGetal;
            if (!Int32.TryParse(windowAddStudent.DialogAddLevel.Text, out domGetal))
            {
                errorMessage += "Leerling level moet een cijfer zijn \n";
            }
            if (string.IsNullOrWhiteSpace(windowAddStudent.DialogAddLevel.Text))
            {
                errorMessage += "Leerling level is niet (goed) ingevuld\n";
            }
            if (!IsValidEmail(windowAddStudent.EmailTextBox.Text))
                errorMessage += "Gebruikersnaam moet een email zijn";

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                errorBool = true;
            }
            return errorBool;
        }
        //Validate student password field
        private static bool CheckPasswordField(WindowAddStudent windowAddStudent, ref string errorMessage)
        {
            bool errorBool = false;
            if (string.IsNullOrWhiteSpace(windowAddStudent.PasswordTextBox.Text))
            {
                errorMessage += "Leerling wachtwoord is niet ingevuld\n";
            }
            if(string.IsNullOrWhiteSpace(errorMessage))
            {
                errorBool = true;
            }
            return errorBool;
        }
        //Validate email format
        public static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
