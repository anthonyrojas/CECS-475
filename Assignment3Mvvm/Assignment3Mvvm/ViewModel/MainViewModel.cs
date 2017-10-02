using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Views;
using Assignment3Mvvm.Model;
using System.Windows.Input;
using Assignment3Mvvm.Views;
using Assignment3Mvvm.Messages;
using System.Windows;

namespace Assignment3Mvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private MembershipList members;
        private AddMemberView addMemberView;
        private Member selectedMember;
        public ICommand ShowAddCommand { get; private set; }
        public ICommand DeleteMemberCommand { get; private set; }
        public ICommand ExitAppCommand { get; private set; }

        public ICommand UpdateMemberCommand { get; private set; }
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            members = new MembershipList();
            members.Write();
            ShowAddCommand = new RelayCommand(ShowAddMethod);
            DeleteMemberCommand = new RelayCommand(DeleteMemberMethod);
            ExitAppCommand = new RelayCommand(ExitAppMethod);
            Messenger.Default.Register<ViewModelMessage>(this, OnReceiveMessageAction);

        }
        //this.RaisePropertyChanged(() => this.MemberList);

        //employees = Employee.GetSampleEmployees();
            //this.RaisePropertyChanged(() => this.EmployeeList);
        //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded."));

        public ObservableCollection<Member> MemberList
        {
            get
            {
                return members.Members;
            }
        }

        public Member SelectedMember
        {
            get { return selectedMember; }
            set
            {
                selectedMember = value;
                RaisePropertyChanged("SelectedMember");
            }
        }

        public AddMemberView AddMemberViewWindow { get => addMemberView; set => addMemberView = value; }

        public void ShowAddMethod()
        {
            addMemberView = new AddMemberView();
            addMemberView.Show();
        }

        public void DeleteMemberMethod()
        {
            members.Remove(selectedMember);
            members.Save();
            this.RaisePropertyChanged(() => this.MemberList);
            
        }

        private void OnReceiveMessageAction(ViewModelMessage m)
        {
            if (m.WindowCommandText != null && m.WindowCommandText.Equals("Close"))
            {
                addMemberView.Close();
            }
            else
            {
                members.Add(new Member(m.FirstNameText, m.LastNameText, m.EmailText));
                addMemberView.Close();
                members.Save();
                this.RaisePropertyChanged(() => this.MemberList);
            }
        }

        public void ExitAppMethod()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}