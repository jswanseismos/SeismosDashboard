using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeismosDashboard.Annotations;

namespace SeismosDashboard.Experiment
{
    public class BetaViewModel : GammaViewModelBase
    {

        public BetaViewModel()
        {
            betaText = "This is a test for the dialog service";

            btnCommand = new SimpleCommand(btnAction);
        }

        private string betaText;
        public string BetaText
        {
            get => betaText;

            set
            {
                betaText = value;
                OnPropertyChanged(nameof(BetaText));
            }

        }

        private ICommand btnCommand;
        public ICommand BtnCommand
        {
            get { return btnCommand; }
            set { btnCommand = value; }
        }

        private void btnAction()
        {

        }


        public void UpdateBetaText(string input)
        {
            BetaText = input;
        }


    }
}
