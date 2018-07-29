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

    public class NavigationTreeViewModel : INotifyPropertyChanged
    {
        private NavigationService navigationService;
        private Guid clientId;
        private Guid projectId;
        public NavigationTreeViewModel()
        {
            navigationService = new NavigationService();

            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosProjectId, HandleProjectChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentWellsChanged, HandleWellChange);

        }

        private void Initialize()
        {
            // 
            string selectedId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosClientId);
            if (!Guid.TryParse(selectedId, out clientId))
            {
                clientId = Guid.Empty;
            }

            string selectedProjectId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosProjectId);
            if (!Guid.TryParse(selectedProjectId, out projectId))
            {
                projectId = Guid.Empty;
            }

            string clientName = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosClientName) ?? "";

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
        // adding a command to a treeview is a bit difficult, it is easier to capture the change selected it event
        // so the xaml captures a selected node changed event
        // the code behind will add the selected node to the properties below
        private NavWellNode selectedWellNode;
        public NavWellNode SelectedWellNode
        {
            get { return selectedWellNode; }
            set
            {
                selectedWellNode = value;
                var selectedId = selectedWellNode != null ? selectedWellNode.Id.ToString() : string.Empty;
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.NavWellSelected, selectedId);
            }
        }

        private NavProjectNode selectedProjectNode;
        public NavProjectNode SelectedProjectNode
        {
            get { return selectedProjectNode; }
            set
            {
                selectedProjectNode = value;
                var selectedId = selectedProjectNode != null ? selectedProjectNode.Id.ToString() : string.Empty;
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.NavProjectSelected, selectedId);
            }
        }

        private NavStageNode selectedStageNode;
        public NavStageNode SelectedStageNode
        {
            get { return selectedStageNode; }
            set
            {
                selectedStageNode = value;
                var selectedId = selectedStageNode != null ? selectedStageNode.Id.ToString() : string.Empty;
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.NavStageSelected, selectedId);
            }
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
