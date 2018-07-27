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
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        private SidebarViewModel sidebarVM;

        public SideBar()
        {
            InitializeComponent();
            sidebarVM = new SidebarViewModel();
            DataContext = sidebarVM;
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            switch (e.OldValue)
            {
                case NavProjectNode navProjectNode:
                    sidebarVM.SelectedProjectNode = null;
                    break;
                case NavWellNode navWellNode:
                    sidebarVM.SelectedWellNode = null;
                    break;
                case NavStageNode navStageNode:
                    sidebarVM.SelectedStageNode = null;
                    break;
                case NavClientNode navClientNode:
                    sidebarVM.SelectedClientNode = null;
                    break;
            }

            switch (e.NewValue)
            {
                case NavProjectNode navProjectNode:
                    sidebarVM.SelectedProjectNode = navProjectNode;
                    break;
                case NavWellNode navWellNode:
                    sidebarVM.SelectedWellNode = navWellNode;
                    break;
                case NavStageNode navStageNode:
                    sidebarVM.SelectedStageNode = navStageNode;
                    break;
                case NavClientNode navClientNode:
                    sidebarVM.SelectedClientNode = navClientNode;
                    break;
            }
        }
    }
}
