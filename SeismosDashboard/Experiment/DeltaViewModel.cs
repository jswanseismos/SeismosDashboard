using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard.Experiment
{
    public class DeltaViewModel : GammaViewModelBase
    {

        private string aText;
        public string AText
        {
            get { return aText; }
            set
            {
                aText = value; 
                OnPropertyChanged(nameof(AText));
            }
        }

        private string bText;

        public DeltaViewModel()
        {
            aText = "See, using another data template";
            bText = "does really work";
        }

        public string BText
        {
            get { return bText; }
            set
            {
                bText = value;
                OnPropertyChanged(nameof(BText));
            }
        }



    }
}
