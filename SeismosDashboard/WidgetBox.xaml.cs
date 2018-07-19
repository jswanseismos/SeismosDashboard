using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SeismosDashboard
{
    /// <summary>
    /// Interaction logic for WidgetBox.xaml
    /// </summary>
    public partial class WidgetBox : UserControl
    {
        public WidgetBox()
        {
            InitializeComponent();
        }


        [Bindable(true)]
        public string HeaderName
        {
            get { return (string)GetValue(HeaderNameProperty);
            }
            set { SetValue(HeaderNameProperty, value); }
        }

        public static readonly DependencyProperty HeaderNameProperty =
            DependencyProperty.Register("HeaderName",
                typeof(string),
                typeof(WidgetBox),
                new PropertyMetadata("Widget"));





    }
}
