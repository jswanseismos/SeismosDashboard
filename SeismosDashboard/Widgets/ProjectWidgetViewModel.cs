﻿using System;
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
//        private ObservableCollection<KeyValueMutable<string, string>> ocSeismosProjectData;


        public ProjectWidgetViewModel()
        {
            this.metaDataService = new SeismosMetaDataService();
            Initialize();
            InitializeProject();
            DashboardStorage.Instance.RegisterAction("SelectedSeismosClientId", SelectedProjectChange);
            saveCommand = new SimpleCommand(SaveAction);

        }

        private void Initialize()
        {
            // get the selected client id
            string selectedId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosClientId");
            if (!Guid.TryParse(selectedId, out selectSeismosClientId))
            {
                selectSeismosClientId = Guid.Empty;
            }
            


        }

        private void InitializeProject()
        {
            // if there is no selected client then the rest is no necessary
            if (selectSeismosClientId == Guid.Empty) return;
            // get the projects for the selected client and put into observable collection
            seismosProjects = metaDataService.GetSeismosProjectsAlt(selectSeismosClientId);
            ocSeismosProjects = new ObservableCollection<KeyValueEntity>(seismosProjects);

            // get the selected project from the observable collection
            string selectedProjectId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosProjectId");
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


        private SeismosMetaDataService metaDataService;

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
            //            var updatedGuid = seismosMetaDataService.UpdateSeismosClientAlt(SelectedSeismosClient);
            // push changes to the database. get the updated guid of the selected object
            var updatedGuid = metaDataService.UpdateSeismosProjectAlt(SelectSeismosProject);

            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosProjectId", updatedGuid.ToString());
            // this is just to show the name to the header
            // TODO need to change this to get the name from the id
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosProject", SelectSeismosProject);
            InitializeProject();
//            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClientObject", SelectedSeismosClient);
//            OnPropertyChanged(nameof(OcSeismosProjectData));
            OnPropertyChanged(nameof(OcSeismosProjects));
            OnPropertyChanged(nameof(SelectSeismosProject));
            return;


        }

        private KeyValueEntity selectSeismosProject;
        public KeyValueEntity SelectSeismosProject
        {
            get { return selectSeismosProject; }
            set
            {
                selectSeismosProject = value;
//                ocSeismosProjectData = new ObservableCollection<KeyValueMutable<string, string>>(
//                    SelectSeismosProject?.KeyValuePairs ?? new List<KeyValueMutable<string, string>>());
//                OnPropertyChanged(nameof(SelectSeismosProject));
//                OnPropertyChanged(nameof(OcSeismosProjectData));

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


        //        private ObservableCollection<SeismosProject> ocSeismosProjects;
        //        public ObservableCollection<SeismosProject> OcSeismosProjects
        //        {
        //            get { return ocSeismosProjects; }
        //            set
        //            {
        //                ocSeismosProjects = value;
        //            }
        //        }

//        public ObservableCollection<KeyValueMutable<string, string>> OcSeismosProjectData
//        {
//            get { return ocSeismosProjectData; }
//            set { ocSeismosProjectData = value; }
//        }


        private Guid selectSeismosClientId;
        private Guid selectSeismosProjectId;

        private void SelectedProjectChange()
        {
//            string selectedId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosClientId");
//            if (!Guid.TryParse(selectedId, out selectSeismosClientId))
//            {
//                selectSeismosClientId = Guid.Empty;
//            }

            Initialize();
            InitializeProject();
            OnPropertyChanged(nameof(OcSeismosProjects));
            OnPropertyChanged(nameof(SelectSeismosProject));
        }

    }
}
