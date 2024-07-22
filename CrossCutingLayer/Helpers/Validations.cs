using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrossCutingLayer.Helpers
{
    public class Validations
    {
        public static void ValidateOnlyLetters(KeyPressEventArgs key)
        {
            if (char.IsLetter(key.KeyChar) || key.KeyChar == Convert.ToChar(Keys.Back))
                key.Handled = false;
            else
                key.Handled = true;
        }

        public static void ValidateOnlyNumbers(KeyPressEventArgs key)
        {
            if (char.IsNumber(key.KeyChar) || key.KeyChar == Convert.ToChar(Keys.Back))
                key.Handled = false;
            else
                key.Handled = true;
        }

        public static bool ValidateEmail(string email)
        {
            const string pattern = @"^\w+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}