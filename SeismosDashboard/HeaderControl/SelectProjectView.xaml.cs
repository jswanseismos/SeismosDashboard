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

namespace SeismosDashboard
{
    /// <summary>
    /// Interaction logic for SelectProjectView.xaml
    /// </summary>
    public partial class SelectProjectView : Window
    {
        public SelectProjectView(Action closeAction)
        {
            InitializeComponent();
            DataContext = new SelectProjectViewModel(closeAction);
        }

        private void CloseWindowHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((IWindowClose)DataContext).CloseWindow();
        }

    }
}
