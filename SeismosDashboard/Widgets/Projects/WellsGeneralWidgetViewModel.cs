using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SeismosServices;

namespace SeismosDashboard
{



    public class WellsGeneralWidgetViewModel : WidgetViewModelBase
    {
        private WellDataService wellDataService;
        private Guid selectSeismosProjectId;


        public WellsGeneralWidgetViewModel()
        {
            wellDataService = new WellDataService();


            Initialize();

            saveCommand = new SimpleCommand(SaveAction);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosProjectId, SelectedProjectChange);

        }

        private void Initialize()
        {
            string selectedProjectId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosProjectId);
            if (!Guid.TryParse(selectedProjectId, out selectSeismosProjectId))
            {
                selectSeismosProjectId = Guid.Empty;
            }

            wellNameList = wellDataService.GetWellNamesEntity(selectSeismosProjectId);

        }


        private KeyValueEntity wellNameList;

        public KeyValueEntity WellNameList
        {
            get { return wellNameList; }
            set
            {
                wellNameList = value;
                OnPropertyChanged(nameof(WellNameList));
            }
        }

        #region Commands


        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        private void SaveAction()
        {
            wellDataService.AddWells(wellNameList, selectSeismosProjectId);
            Initialize();
            OnPropertyChanged(nameof(WellNameList));
            DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentWellsChanged, selectSeismosProjectId.ToString());
        }

        private void SelectedProjectChange()
        {
            Initialize();
            OnPropertyChanged(nameof(WellNameList));
        }
        #endregion


    }
}
