using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace Assignment3Mvvm.Model
{
    public class MembershipData
    {
        private string filename;
        public MembershipData()
        {
            filename = "Memberships.txt";
        }

        public ObservableCollection<Member> GetMemberships()
        {
            ObservableCollection<Member> m = new ObservableCollection<Member>();
            string currentLine;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                while ((currentLine = file.ReadLine()) != null)
                {
                    string[] memberFields = currentLine.Split(',');
                    m.Add(new Member(memberFields[0], memberFields[1], memberFields[2]));
                }
                file.Close();
                return m;
            }
            catch (FileNotFoundException e)
            {
                
            }
            return null;
        }

        public void SaveMemberships(ObservableCollection<Member> members)
        {
            string filename = "Memberships.txt";
            File.WriteAllText(filename, String.Empty);
            foreach (Member m in members)
            {
                string text = m.FirstName + "," + m.LastName + "," + m.Email + Environment.NewLine;
                File.AppendAllText(filename, text);
            }
        }
    }
}
