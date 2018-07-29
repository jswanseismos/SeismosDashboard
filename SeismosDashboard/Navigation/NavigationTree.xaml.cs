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
using SeismosServices;

namespace SeismosDashboard
{
    /// <summary>
    /// Interaction logic for NavigationTree.xaml
    /// </summary>
    public partial class NavigationTree : UserControl
    {
        private NavigationTreeViewModel navigationTreeVm;

        public NavigationTree()
        {
            InitializeComponent();
            navigationTreeVm = new NavigationTreeViewModel();
            DataContext = navigationTreeVm;
        }

        // this is an imperfect solution, but inserting commands on each node of a treeview is problematic
        // this event returns which node was selected which is exactly what is needed
        // the node is passed to the view model and it is handled from there
        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            switch (e.OldValue)
            {
                case NavProjectNode navProjectNode:
                    navigationTreeVm.SelectedProjectNode = null;
                    break;
                case NavWellNode navWellNode:
                    navigationTreeVm.SelectedWellNode = null;
                    break;
                case NavStageNode navStageNode:
                    navigationTreeVm.SelectedStageNode = null;
                    break;
                case NavClientNode navClientNode:
                    navigationTreeVm.SelectedClientNode = null;
                    break;
            }

            switch (e.NewValue)
            {
                case NavProjectNode navProjectNode:
                    navigationTreeVm.SelectedProjectNode = navProjectNode;
                    break;
                case NavWellNode navWellNode:
                    navigationTreeVm.SelectedWellNode = navWellNode;
                    break;
                case NavStageNode navStageNode:
                    navigationTreeVm.SelectedStageNode = navStageNode;
                    break;
                case NavClientNode navClientNode:
                    navigationTreeVm.SelectedClientNode = navClientNode;
                    break;
            }
        }
    }
}
