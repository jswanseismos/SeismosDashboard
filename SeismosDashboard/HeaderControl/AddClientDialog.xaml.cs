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
using System.Windows.Shapes;
using SeismosDataLibrary;

namespace SeismosDashboard
{
    /// <summary>
    /// Interaction logic for AddClientDialog.xaml
    /// </summary>
    public partial class AddClientDialog : Window
    {
        public AddClientDialog(Action closeAction)
        {
            InitializeComponent();
            
            DataContext = new AddClientDialogViewModel(closeAction);
//            addClientVM.CurrWindow = this;
        }

        private void CloseWindowHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((IWindowClose)DataContext).CloseWindow();
        }

    }
}
