using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDashboard.Annotations;

namespace SeismosDashboard.Experiment
{
    public class GammaViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private GammaViewModelBase subViewModel;
        public GammaViewModelBase SubViewModel
        {
            get { return subViewModel; }
            set
            {
                subViewModel = value;
                OnPropertyChanged(nameof(SubViewModel));
            }
        }



    }
}
