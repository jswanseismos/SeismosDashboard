using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    public class ProjectWidgetViewModel : WidgetViewModelBase
    {

        private const String AddButtonName = "Add Project";
        private const String UpdateButtonName = "Update Project";

        private SeismosMetaDataService metaDataService;
        private Guid selectSeismosClientId;
        private Guid selectSeismosProjectId;


        public ProjectWidgetViewModel()
        {
            this.metaDataService = new SeismosMetaDataService();
            Initialize();
            InitializeProject();
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosClientId, SelectedProjectChange);
            saveCommand = new SimpleCommand(SaveAction);

        }

        private void Initialize()
        {
            // get the selected client id
            string selectedId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosClientId);
            if (!Guid.TryParse(selectedId, out selectSeismosClientId))
            {
                selectSeismosClientId = Guid.Empty;
            }

        }

        // this initializes a new project as it is selected
        private void InitializeProject()
        {
            seismosProjects = metaDataService.GetSeismosProjects(selectSeismosClientId);
            ocSeismosProjects = new ObservableCollection<KeyValueEntity>(seismosProjects);

            // get the selected project from the observable collection
            string selectedProjectId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosProjectId);
            if (!Guid.TryParse(selectedProjectId, out selectSeismosProjectId))
            {
                selectSeismosProjectId = Guid.Empty;
            }

            // get the selected project from the observable collection
            SelectSeismosProject = ocSeismosProjects.FirstOrDefault(sp => sp.Id == selectSeismosProjectId);


        }

        private List<KeyValueEntity> seismosProjects;
        public List<KeyValueEntity> SeismosProjects
        {
            get { return seismosProjects; }
            set { seismosProjects = value; }
        }


        private KeyValueEntity selectSeismosProject;
        public KeyValueEntity SelectSeismosProject
        {
            get { return selectSeismosProject; }
            set
            {
                selectSeismosProject = value;

                var updateId = selectSeismosProject?.Id ?? Guid.Empty;
                var updateName = selectSeismosProject?.Name ?? string.Empty;

                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosProjectId, updateId.ToString());
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosProjectName, updateName);
                AddUpdateButtonName = String.IsNullOrEmpty(updateName) ? AddButtonName : UpdateButtonName;
                OnPropertyChanged(nameof(SelectSeismosProject));
            }
        }

        private ObservableCollection<KeyValueEntity> ocSeismosProjects;
        public ObservableCollection<KeyValueEntity> OcSeismosProjects
        {
            get { return ocSeismosProjects; }
            set
            {
                ocSeismosProjects = value;
            }
        }


        private string addUpdateButtonName;
        public string AddUpdateButtonName
        {
            get { return addUpdateButtonName; }
            set
            {
                addUpdateButtonName = value;
                OnPropertyChanged(nameof(AddUpdateButtonName));
            }
        }


        #region Commands
        
        // this reacts to the change in the current client id 
        private void SelectedProjectChange()
        {

            Initialize();
            InitializeProject();
            OnPropertyChanged(nameof(OcSeismosProjects));
            OnPropertyChanged(nameof(SelectSeismosProject));

        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        private void SaveAction()
        {
            // this is to save the data entered into the datagrid
            //            SelectedSeismosClient.KeyValuePairs = OcSeismosClientData.ToList();
            //            var updatedGuid = seismosMetaDataService.UpdateSeismosClient(SelectedSeismosClient);
            // push changes to the database. get the updated guid of the selected object
            var updatedGuid = metaDataService.UpdateSeismosProject(SelectSeismosProject, selectSeismosClientId);

            DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosProjectId, updatedGuid.ToString());
            InitializeProject();
            OnPropertyChanged(nameof(OcSeismosProjects));
            OnPropertyChanged(nameof(SelectSeismosProject));
            addUpdateButtonName = AddUpdateButtonName;


        }

        #endregion

    }
}
