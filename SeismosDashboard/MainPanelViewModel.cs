using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class MainPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPanelViewModel()
        {
            KvPairs = new List<KvPair>
            {
                new KvPair() {PairKey = "Name", Value = "George"},
                new KvPair() {PairKey = "Phone Number", Value = "555-555-5555"},
                new KvPair() {PairKey = "Email", Value = "George@email.com"},
                new KvPair() {PairKey = "Company", Value = "Companies R Us"}
            };

            ProjectKvPairs = new List<KvPair>()
            {
                new KvPair() {PairKey = "Project Name", Value = "Project 101"},
                new KvPair() {PairKey = "Job #", Value = "DV12345"},
                new KvPair() {PairKey = "AFE #", Value = "AFE3452"},
                new KvPair() {PairKey = "Field", Value = "field A"},
                new KvPair() {PairKey = "Pad", Value = "Pad A"},
                new KvPair() {PairKey = "Formation", Value = ""},
                new KvPair() {PairKey = "County", Value = "Wellington"},
                new KvPair() {PairKey = "State", Value = "US"},
                new KvPair() {PairKey = "Start Date", Value = "7/9/2018"},
                new KvPair() {PairKey = "End Date", Value = "9/9/2018"}
            };

        }

        private List<KvPair> kvPairs;
        public List<KvPair> KvPairs
        {
            get { return kvPairs; }
            set { kvPairs = value; }
        }

        private List<KvPair> projectKvPairs;
        public List<KvPair> ProjectKvPairs
        {
            get { return projectKvPairs; }
            set { projectKvPairs = value; }
        }



    }
}
