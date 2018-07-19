using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SeismosDashboard.Experiment;

namespace SeismosDashboard
{
    /// <summary>
    /// Interaction logic for MainPanel.xaml
    /// </summary>
    public partial class MainPanel : UserControl
    {
        private DialogService dialogService;
        public MainPanel()
        {
            InitializeComponent();
            DataContext = new MainPanelViewModel();
            dialogService = new DialogService();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            dialogService.LaunchWindow(new BetaViewModel(){SubViewModel = new DeltaViewModel()});

        }
        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            dialogService.UpdateWindow(new EpsilonViewModel());
        }
    }
}
