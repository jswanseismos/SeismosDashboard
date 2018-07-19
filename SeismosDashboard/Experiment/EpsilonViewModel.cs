using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard.Experiment
{
    public class EpsilonViewModel : GammaViewModelBase
    {
        private string eText;
        public string EText
        {
            get { return eText; }
            set
            {
                eText = value;
                OnPropertyChanged(nameof(EText));
            }
        }

        public EpsilonViewModel()
        {
            eText = "Epsilon control working";
        }
    }
}
