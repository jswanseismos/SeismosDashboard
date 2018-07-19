using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SeismosDashboard.Annotations;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    public class AddProjectDialogViewModel : ViewModelBase
    {

        public AddProjectDialogViewModel(Action closeAction)
        {
            isChanged = false;
            metaDataService = new SeismosMetaDataService();
            selectSeismosProject = DashboardStorage.Instance.GetValue<SeismosProject>("SelectedSeismosProject");
            selectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient");

            if (selectSeismosProject != null)
            {
                isEdit = true;
            }
            else
            {
                selectSeismosProject = new SeismosProject();
                selectSeismosProject.StartDate = DateTime.Now;
                selectSeismosProject.EndDate = DateTime.Now;
                selectSeismosProject.LastModified = DateTime.Now;
                selectSeismosProject.SeismosClientId = selectSeismosClient.Id;
            }

            this.closeAction = closeAction;

            closeCommand = new SimpleCommand(CloseWindow);
//            addProjectCommand = new SimpleCommand(AddProjectAction);
//            editProjectCommand = new SimpleCommand(EditProjectAction);
        }

//        public event PropertyChangedEventHandler PropertyChanged;
//        [NotifyPropertyChangedInvocator]
//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

        private SeismosMetaDataService metaDataService;
        private bool isChanged;
        private bool isEdit;
        private Action closeAction;


//        private ObservableCollection<SeismosClient> ocSeismosClients;
//        public ObservableCollection<SeismosClient> OcSeismosClients
//        {
//            get { return ocSeismosClients; }
//            set
//            {
//                ocSeismosClients = value;
//            }
//        }

        private SeismosProject selectSeismosProject;

        private SeismosClient selectSeismosClient;
        public SeismosClient SelectSeismosClient
        {
            get { return selectSeismosClient; }
            set
            {
                selectSeismosClient = value;
                OnPropertyChanged(nameof(SelectSeismosClient));
            }
        }


        private ICommand addProjectCommand;
        public ICommand AddProjectCommand
        {
            get { return addProjectCommand; }
            set { addProjectCommand = value; }
        }

        private ICommand editProjectCommand;
        public ICommand EditProjectCommand
        {
            get { return editProjectCommand; }
            set { editProjectCommand = value; }
        }


        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get { return closeCommand; }
            set { closeCommand = value; }
        }

        private Window currWindow;
        public Window CurrWindow
        {
            get { return currWindow; }
            set { currWindow = value; }
        }


//        private void AddClientClosed()
//        {
//
//            ocSeismosClients = new ObservableCollection<SeismosClient>(metaDataService.GetSeismosClients());
//            // need to update the selected item before updating the list
//            SelectSeismosClient = ocSeismosClients.FirstOrDefault(sc => sc.Id == selectSeismosClient.Id);
//            OnPropertyChanged(nameof(OcSeismosClients));
//
//        }

        public string SelectedProjectName
        {
            get { return selectSeismosProject.Name; }
            set
            {
                isChanged = true;
                selectSeismosProject.Name = value;
                OnPropertyChanged(nameof(SelectedProjectName));
            }
        }

        public string SelectedProjectField
        {
            get { return selectSeismosProject.Field; }
            set
            {
                isChanged = true;
                selectSeismosProject.Field = value;
                OnPropertyChanged(nameof(SelectedProjectField));
            }
        }

        public string SelectedProjectPad
        {
            get { return selectSeismosProject.Pad; }
            set
            {
                isChanged = true;
                selectSeismosProject.Pad = value;
                OnPropertyChanged(nameof(SelectedProjectPad));
            }
        }

        public string SelectedProjectJobNum
        {
            get { return selectSeismosProject.JobNum; }
            set
            {
                isChanged = true;
                selectSeismosProject.JobNum = value;
                OnPropertyChanged(nameof(SelectedProjectJobNum));
            }
        }

        public string SelectedProjectAFENum
        {
            get { return selectSeismosProject.AFENum; }
            set
            {
                isChanged = true;
                selectSeismosProject.AFENum = value;
                OnPropertyChanged(nameof(SelectedProjectAFENum));
            }
        }

        public string SelectedProjectFormation
        {
            get { return selectSeismosProject.Formation; }
            set
            {
                isChanged = true;
                selectSeismosProject.Formation = value;
                OnPropertyChanged(nameof(SelectedProjectFormation));
            }
        }

        public string SelectedProjectCounty
        {
            get { return selectSeismosProject.County; }
            set
            {
                isChanged = true;
                selectSeismosProject.County = value;
                OnPropertyChanged(nameof(SelectedProjectCounty));
            }
        }

        public string SelectedProjectState
        {
            get { return selectSeismosProject.State; }
            set
            {
                isChanged = true;
                selectSeismosProject.State = value;
                OnPropertyChanged(nameof(SelectedProjectState));
            }
        }

        public DateTime SelectedProjectStartDate
        {
            get { return selectSeismosProject.StartDate; }
            set
            {
                isChanged = true;
                selectSeismosProject.StartDate = value;
                OnPropertyChanged(nameof(SelectedProjectStartDate));
            }
        }

        public DateTime SelectedProjectEndDate
        {
            get { return selectSeismosProject.EndDate; }
            set
            {
                isChanged = true;
                selectSeismosProject.EndDate = value;
                OnPropertyChanged(nameof(SelectedProjectEndDate));
            }
        }

//        private void AddProjectAction()
//        {
//            selectSeismosClient = new SeismosClient();
//            AddClientDialog addClientDialog = new AddClientDialog(AddClientClosed);
//            addClientDialog.Show();
//        }
//
//        private void EditProjectAction()
//        {
//            AddClientDialog addClientDialog = new AddClientDialog(AddClientClosed);
//            addClientDialog.Show();
//        }


        private void closeWindow()
        {
            if (isChanged)
            {
                if (isEdit)
                {
                    metaDataService.UpdateSeismosProject(selectSeismosProject);
                }
                else
                {
                    metaDataService.AddSeismosProject(selectSeismosProject);

                }
            }
            selectSeismosProject = metaDataService.GetSeismosProjects(selectSeismosClient.Id)
                .FirstOrDefault(sc => sc.Id == selectSeismosProject.Id);

            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosProject", selectSeismosProject);

            closeAction();
        }

        public override Action CloseWindow => closeWindow;



    }
}
