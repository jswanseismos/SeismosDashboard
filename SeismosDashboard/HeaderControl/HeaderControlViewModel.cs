using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeismosDashboard.Annotations;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    public class HeaderControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // TODO clean up the code and remove any actions
        // only have listeners for client or project changes
        // TODO investigate a way to have the current time on the header
        public HeaderControlViewModel()
        {
//            addProjectCommand = new SimpleCommand(AddButtonExecute);
            selectClientCommand = new SimpleCommand(SelectClientButtonExecute);
            selectProjectCommand = new SimpleCommand(SelectProjectButtonExecute);

//            selectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient") ?? new SeismosClient();
            selectSeismosClient = DashboardStorage.Instance.GetValue<KeyValueEntity>("SelectedSeismosClientObject") ?? new KeyValueEntity();
            selectSeismosProject = DashboardStorage.Instance.GetValue<KeyValueEntity>("SelectedSeismosProject") ?? new KeyValueEntity();
            DashboardStorage.Instance.RegisterAction("SelectedSeismosClientObject", SelectedClientChange);
            DashboardStorage.Instance.RegisterAction("SelectedSeismosProject", SelectedProjectChange);
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid selectSeismosClientId;
        private KeyValueEntity selectSeismosClient;
        private KeyValueEntity selectSeismosProject;

        public string SelectClientName
        {
            get { return selectSeismosClient.Name; }
            set
            {
                selectSeismosClient.Name = value;
                OnPropertyChanged(nameof(SelectClientName));
                OnPropertyChanged(nameof(SelectProjectName));
            }

        }

        private void SelectedClientChange()
        {
            selectSeismosClient = DashboardStorage.Instance.GetValue<KeyValueEntity>("SelectedSeismosClientObject") ?? new KeyValueEntity();
            selectSeismosProject = new KeyValueEntity();
            OnPropertyChanged(nameof(SelectClientName));
            OnPropertyChanged(nameof(SelectProjectName));
        }

        private void SelectedProjectChange()
        {
            selectSeismosProject = DashboardStorage.Instance.GetValue<KeyValueEntity>("SelectedSeismosProject") ?? new KeyValueEntity();
            OnPropertyChanged(nameof(SelectProjectName));
        }

        public string SelectProjectName
        {
            get { return selectSeismosProject.Name; }
            set
            {
                selectSeismosProject.Name = value;
                OnPropertyChanged(nameof(SelectProjectName));
            }

        }



        private ICommand addProjectCommand;
        public ICommand AddProjectCommand
        {
            get { return addProjectCommand; }
            set { addProjectCommand = value; }
        }

        private ICommand selectClientCommand;
        public ICommand SelectClientCommand
        {
            get { return selectClientCommand; }
            set { selectClientCommand = value; }
        }

        private ICommand selectProjectCommand;
        public ICommand SelectProjectCommand
        {
            get { return selectProjectCommand; }
            set { selectProjectCommand = value; }
        }


        public void SelectClientButtonExecute()
        {
            SelectClientView selectClientView = new SelectClientView(SelectClientCloseAction);
            selectClientView.ShowDialog();
        }

        public void SelectProjectButtonExecute()
        {
            SelectProjectView selectProjectView = new SelectProjectView(SelectProjectCloseAction);
            selectProjectView.ShowDialog();
        }


//        public void AddButtonExecute()
//        {
//            AddProjectDialog addProjectDialog = new AddProjectDialog();
//            addProjectDialog.Show();
//
//
//        }

        public void SelectClientCloseAction()
        {
//            selectSeismosClient = DashboardStorage.Instance.GetValue<KeyValueEntity>("SelectedSeismosClient") ?? new SeismosClient();
//            selectSeismosProject = DashboardStorage.Instance.GetValue<SeismosProject>("SelectedSeismosProject") ?? new SeismosProject();
            OnPropertyChanged(nameof(SelectClientName));
            OnPropertyChanged(nameof(SelectProjectName));
        }

        public void SelectProjectCloseAction()
        {
//            selectSeismosProject = DashboardStorage.Instance.GetValue<SeismosProject>("SelectedSeismosProject") ?? new SeismosProject();
            OnPropertyChanged(nameof(SelectProjectName));
        }



    }
}
