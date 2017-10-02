using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Assignment3Mvvm.Views;
using Assignment3Mvvm.Messages;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Assignment3Mvvm.Model;

namespace Assignment3Mvvm.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private string firstNameText;
        private string lastNameText;
        private string emailText;

        public AddViewModel()
        {
            AddCommand = new RelayCommand(OnClickAddMember, null);
            CancelCommand = new RelayCommand(OnClickCloseWindow, null);
            
        }

        public string FirstNameTextBox
        {
            get { return firstNameText; }
            set
            {
                firstNameText = value;
                RaisePropertyChanged("FirstNameTextBox");
            }
        }

        public string LastNameTextBox
        {
            get { return lastNameText; }
            set
            {
                lastNameText = value;
                RaisePropertyChanged("LastNameTextBox");
            }
        }

        public string EmailTextBox
        {
            get { return emailText; }
            set
            {
                emailText = value;
                RaisePropertyChanged("EmailTextBox");
            }
        }

        private void OnClickAddMember()
        {
            if (Validator.IsPresent("First name", firstNameText)
                && Validator.IsPresent("Last name", lastNameText) 
                && Validator.IsPresent("Email", emailText)
                && Validator.IsValidEmail(emailText) 
                && Validator.IsWithinRange(firstNameText, 1, 25)
                && Validator.IsWithinRange(lastNameText, 1, 25)
                && Validator.IsWithinRange(emailText, 1, 25))
            {
                var memberMessage = new ViewModelMessage()
                {
                    FirstNameText = FirstNameTextBox,
                    LastNameText = LastNameTextBox,
                    EmailText = EmailTextBox
                };
                string notificationText = String.Format("New member added: {0} {1} - {2}", firstNameText, lastNameText, emailText);
                firstNameText = null;
                lastNameText = null;
                emailText = null;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(notificationText));
                Messenger.Default.Send(memberMessage);
            }
        }

        private void OnClickCloseWindow()
        {
            var closeWindowMessage = new ViewModelMessage()
            {
                WindowCommandText = "Close",
                FirstNameText = null,
                LastNameText = null,
                EmailText = null
            };
            Messenger.Default.Send(closeWindowMessage);
        }
    }
}
