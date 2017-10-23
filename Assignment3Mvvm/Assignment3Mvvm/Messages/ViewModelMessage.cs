using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Assignment3Mvvm.Messages
{
    public class ViewModelMessage : MessageBase
    {
        public string FirstNameText { get; set; }
        public string LastNameText { get; set; }
        public string EmailText { get; set; }
        public string WindowCommandText { get; set; }
    }
}
