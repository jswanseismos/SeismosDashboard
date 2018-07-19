using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeismosDashboard.Experiment
{
    public class DialogService
    {
        private AlphaWindow alphaWindow;
//        private BetaViewModel betaViewModel;

        public void LaunchDialog(GammaViewModelBase viewModel)
        {
            alphaWindow = new AlphaWindow(viewModel);
            alphaWindow.ShowDialog();

        }

        public void LaunchWindow(GammaViewModelBase viewModel)
        {
//            betaViewModel = (BetaViewModel) viewModel;
            alphaWindow = new AlphaWindow(viewModel);
            alphaWindow.Show();


        }

        public void UpdateWindow(GammaViewModelBase viewModel)
        {
//            betaViewModel.BetaText = "Trying something different to test bindings";
            ((GammaViewModelBase)alphaWindow.DataContext).SubViewModel = viewModel;

        }



    }
}
