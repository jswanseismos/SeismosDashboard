using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeismosDashboard.Annotations;
using SeismosServices;

namespace SeismosDashboard
{

    public class SidebarViewModel : INotifyPropertyChanged
    {
        private NavigationService navigationService;
        private Guid clientId;
        private Guid projectId;
        public SidebarViewModel()
        {
            navigationService = new NavigationService();
//            NavClientNode clientNode = new NavClientNode() {Id = new Guid("1249c479-b6bd-4a23-9a17-10a87b09615e"), Name = "Client 2"};

            NavClientNode clientNode = new NavClientNode();
            //            clientNode.Projects = navigationService.GetProjectNodes(clientNode.Id);
            //
            //            clientTrees = new List<NavClientNode>(){clientNode};

            DashboardStorage.Instance.RegisterAction("SelectedSeismosProjectId", HandleProjectChange);
            DashboardStorage.Instance.RegisterAction("WellsChanged", HandleWellChange);

            projectCommand = new SimpleCommand(projectAction);


        }

        private void Initialize()
        {
            string selectedId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosClientId");
            if (!Guid.TryParse(selectedId, out clientId))
            {
                clientId = Guid.Empty;
            }


            string selectedProjectId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosProjectId");
            if (!Guid.TryParse(selectedProjectId, out projectId))
            {
                projectId = Guid.Empty;
            }

            string clientName = DashboardStorage.Instance.GetValue<String>("SelectedSeismosClientName") ?? "";

            NavClientNode clientNode = new NavClientNode
            {
                Id = clientId,
                Name = clientName,
                Projects = new List<NavProjectNode>() {navigationService.GetProjectNode(projectId)}
            };

            clientTrees = new List<NavClientNode>() { clientNode };
        }

         

        private List<NavClientNode> clientTrees;
        public List<NavClientNode> ClientTrees
        {
            get { return clientTrees; }
            set { clientTrees = value; }
        }

        #region SelectedNodeHandlers
        // this is a bit of an imperfect solution
        // adding a command to a treeview is a bit difficult
        // so the xaml captures a selected node changed event
        // the code behind will add the selected node to the properties below
        private NavWellNode selectedWellNode;
        public NavWellNode SelectedWellNode
        {
            get { return selectedWellNode; }
            set { selectedWellNode = value; }
        }

        private NavProjectNode selectedProjectNode;
        public NavProjectNode SelectedProjectNode
        {
            get { return selectedProjectNode; }
            set { selectedProjectNode = value; }
        }

        private NavStageNode selectedStageNode;
        public NavStageNode SelectedStageNode
        {
            get { return selectedStageNode; }
            set { selectedStageNode = value; }
        }

        private NavClientNode selectedClientNode;
        public NavClientNode SelectedClientNode
        {
            get { return selectedClientNode; }
            set { selectedClientNode = value; }
        }
        #endregion


        private void HandleProjectChange()
        {
            Initialize();
            OnPropertyChanged(nameof(ClientTrees));

        }

        private void HandleWellChange()
        {
            Initialize();
            OnPropertyChanged(nameof(ClientTrees));

        }

        private ICommand projectCommand;
        public ICommand ProjectCommand
        {
            get { return projectCommand; }
            set { projectCommand = value; }
        }

        private void projectAction()
        {
            string r = "something";
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
