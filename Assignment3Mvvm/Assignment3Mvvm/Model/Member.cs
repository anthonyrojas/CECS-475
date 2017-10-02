using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Assignment3Mvvm.Model
{
    public class Member : ObservableObject
    {
        private string firstName;
        private string lastName;
        private string email;

        public Member()
        {

        }

        public Member(string _firstName, string _lastName, string _email)
        {
            firstName = _firstName;
            lastName = _lastName;
            email = _email;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                Set<string>(() => this.FirstName, ref firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                Set<string>(() => this.LastName, ref lastName, value);
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Set<string>(() => this.Email, ref email, value);
            }
        }

        public string GetDisplayText
        {
            get { return firstName + " " + lastName + " - " + email; }   
        }
    }
}
