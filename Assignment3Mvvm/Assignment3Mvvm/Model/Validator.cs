using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Assignment3Mvvm.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Assignment3Mvvm.Model
{
    public class Validator
    {
        private static string title = "Entity Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(string textBox, string text)
        {
            if (text == null)
            {
                MessageBox.Show(textBox + " is required", Title);
                //textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsDecimal(string textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox + " must be a decimal value.", Title);
                //textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(string textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox + " must be an integer.", Title);
                //textBox.Focus();
                return false;
            }
        }

        public static bool IsWithinRange(string textBox, decimal min, decimal max)
        {
            int number = textBox.Length;
            if (number < min || number > max)
            {
                MessageBox.Show(textBox + " must be between " + min + " and " + max + " characters.", Title);
                //textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string textBox)
        {
            if (textBox.IndexOf("@") == -1 || textBox.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox + " must be a valid email address", Title);
                //textBox.Focus()
                return false;
            }
            return true;
        }
    }
}
