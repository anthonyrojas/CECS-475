using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace Assignment3Mvvm.Model
{
    public class MembershipList : ObservableObject
    {
        public event ChangeHandler Changed;
        private ObservableCollection<Member> members;
        private int propertyCount;
        public MembershipList()
        {
            members = new ObservableCollection<Member>();
            propertyCount = 0;
        }

        public int PropertyCount
        {
            get
            {
                return propertyCount;
            }
            
            set
            {
                Set<int>(() => this.PropertyCount, ref propertyCount, value);
            }
        }

        public Member this[int i]
        {
            get
            {
                return members[i];
            }
            set
            {
                var m = members.ElementAt(i);
                Set(()=>Members[i], ref m, value);
                members[i] = m;
            }
        }

        public void Add(Member m)
        {
            members.Add(m);
            propertyCount++;
            OnChange(EventArgs.Empty);
        }

        public void Remove(Member m)
        {
            members.Remove(m);
            propertyCount--;
            OnChange(EventArgs.Empty);
        }

        public void Write()
        {
            MembershipData data = new MembershipData();
            ObservableCollection<Member> tempM = data.GetMemberships();
            if (tempM != null)
            {
                foreach (Member m in tempM)
                {
                    members.Add(m);
                }
            }
        }

        public void Save()
        {
            MembershipData data = new MembershipData();
            data.SaveMemberships(members);
        }

        public ObservableCollection<Member> Members
        {
            get
            {
                return members;
            }
            set
            {
                Set<ObservableCollection<Member>>(() => this.Members, ref members, value);
            }
        }

        protected virtual void OnChange(EventArgs e)
        {
            Changed?.Invoke(this);
        }

        
    }

    public delegate void ChangeHandler(MembershipList m);
}
