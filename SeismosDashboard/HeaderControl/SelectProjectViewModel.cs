using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    class SelectProjectViewModel : ViewModelBase
    {

        public SelectProjectViewModel(Action closeAction)
        {
            var selectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient");

            this.metaDataService = new SeismosMetaDataService();

            if (selectSeismosClient == null)
            {
                selectSeismosProject = new SeismosProject();
                
            }
            else
            {
                ocSeismosProjects = new ObservableCollection<SeismosProject>(metaDataService.GetSeismosProjects(selectSeismosClient.Id));

                if (ocSeismosProjects.Count == 0)
                {
                    selectSeismosProject = new SeismosProject();
                }
                else
                {
                    selectSeismosProject =
                        DashboardStorage.Instance.GetValue<SeismosProject>("SelectedSeismosProject") ??
                        ocSeismosProjects[0];
                    selectSeismosProject = ocSeismosProjects.FirstOrDefault(sp => sp.Id == selectSeismosProject.Id);
                }
            }

            addProjectCommand = new SimpleCommand(AddProjectAction);
            editProjectCommand = new SimpleCommand(EditProjectAction);

            this.closeAction = closeAction;
        }

        private SeismosMetaDataService metaDataService;



        private Action closeAction;

        private ObservableCollection<SeismosProject> ocSeismosProjects;
        public ObservableCollection<SeismosProject> OcSeismosProjects
        {
            get { return ocSeismosProjects; }
            set
            {
                ocSeismosProjects = value;
            }
        }


        private SeismosProject selectSeismosProject;
        public SeismosProject SelectSeismosProject
        {
            get { return selectSeismosProject; }
            set
            {
                selectSeismosProject = value;
                OnPropertyChanged(nameof(SelectSeismosProject));
                OnPropertyChanged(nameof(SelectedProjectAFENum));
                OnPropertyChanged(nameof(SelectedProjectCounty));
                OnPropertyChanged(nameof(SelectedProjectEndDate));
                OnPropertyChanged(nameof(SelectedProjectField));
                OnPropertyChanged(nameof(SelectedProjectFormation));
                OnPropertyChanged(nameof(SelectedProjectJobNum));
                OnPropertyChanged(nameof(SelectedProjectName));
                OnPropertyChanged(nameof(SelectedProjectPad));
                OnPropertyChanged(nameof(SelectedProjectStartDate));
                OnPropertyChanged(nameof(SelectedProjectState));
            }
        }

        #region ViewProperties

        

        public string SelectedProjectName
        {
            get { return selectSeismosProject.Name; }
            set
            {
                selectSeismosProject.Name = value;
                OnPropertyChanged(nameof(SelectedProjectName));
            }
        }

        public string SelectedProjectField
        {
            get { return selectSeismosProject.Field; }
            set
            {
                selectSeismosProject.Field = value;
                OnPropertyChanged(nameof(SelectedProjectField));
            }
        }

        public string SelectedProjectPad
        {
            get { return selectSeismosProject.Pad; }
            set
            {
                selectSeismosProject.Pad = value;
                OnPropertyChanged(nameof(SelectedProjectPad));
            }
        }

        public string SelectedProjectJobNum
        {
            get { return selectSeismosProject.JobNum; }
            set
            {
                selectSeismosProject.JobNum = value;
                OnPropertyChanged(nameof(SelectedProjectJobNum));
            }
        }

        public string SelectedProjectAFENum
        {
            get { return selectSeismosProject.AFENum; }
            set
            {
                selectSeismosProject.AFENum = value;
                OnPropertyChanged(nameof(SelectedProjectAFENum));
            }
        }

        public string SelectedProjectFormation
        {
            get { return selectSeismosProject.Formation; }
            set
            {
                selectSeismosProject.Formation = value;
                OnPropertyChanged(nameof(SelectedProjectFormation));
            }
        }

        public string SelectedProjectCounty
        {
            get { return selectSeismosProject.County; }
            set
            {
                selectSeismosProject.County = value;
                OnPropertyChanged(nameof(SelectedProjectCounty));
            }
        }

        public string SelectedProjectState
        {
            get { return selectSeismosProject.State; }
            set
            {
                selectSeismosProject.State = value;
                OnPropertyChanged(nameof(SelectedProjectState));
            }
        }

        public DateTime SelectedProjectStartDate
        {
            get { return selectSeismosProject.StartDate; }
            set
            {
                selectSeismosProject.StartDate = value;
                OnPropertyChanged(nameof(SelectedProjectStartDate));
            }
        }

        public DateTime SelectedProjectEndDate
        {
            get { return selectSeismosProject.EndDate; }
            set
            {
                selectSeismosProject.EndDate = value;
                OnPropertyChanged(nameof(SelectedProjectEndDate));
            }
        }


        #endregion


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

        private void AddProjectAction()
        {
            DashboardStorage.Instance.Remove("SelectedSeismosProject");
            AddProjectDialog addProjectDialog = new AddProjectDialog(AddProjectClosed);
            addProjectDialog.ShowDialog();
        }

        private void EditProjectAction()
        {
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosProject", selectSeismosProject);
            AddProjectDialog addProjectDialog = new AddProjectDialog(AddProjectClosed);
            addProjectDialog.ShowDialog();
        }

        private void AddProjectClosed()
        {
            SelectSeismosProject = DashboardStorage.Instance.GetValue<SeismosProject>("SelectedSeismosProject");

            ocSeismosProjects = new ObservableCollection<SeismosProject>(metaDataService.GetSeismosProjects(SelectSeismosProject.SeismosClientId));
            // need to update the selected item before updating the list
            SelectSeismosProject = ocSeismosProjects.FirstOrDefault(sc => sc.Id == SelectSeismosProject.Id);
            OnPropertyChanged(nameof(OcSeismosProjects));

        }


        public override Action CloseWindow
        {
            get { return closeWindow; }
        }


        private void closeWindow()
        {
            if (selectSeismosProject == null) return;
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosProject", selectSeismosProject);

            closeAction();
        }

    }
}
