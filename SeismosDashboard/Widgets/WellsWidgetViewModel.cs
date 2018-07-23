using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Input;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    public class WellsWidgetViewModel : WidgetViewModelBase
    {
        public WellsWidgetViewModel()
        {
            wellDataService = new WellDataService();

            var result = wellDataService.GetWellEntries();
            saveWellCommand = new RelayCommand(SaveWellAction);

            wellEntries = new ObservableCollection<WellEntry>(result);

//            var weightList = wellDataService.GetWeightList(4.5);
//            var gradeList = wellDataService.GetGradeList(4.5, 9.5);
//            double innerDiameter = wellDataService.GetInnerDiameter(4.5, 9.5, "K-55");

        }
        private WellDataService wellDataService;

        private ICommand saveWellCommand;
        public ICommand SaveWellCommand
        {
            get { return saveWellCommand; }
            set { saveWellCommand = value; }
        }

        public void SaveWellAction(object param)
        {
            Guid id = (Guid) param;

            var wellEntry = wellEntries.FirstOrDefault(we => we.Id == id);
            //            wellDataService.UpdateWellEntry(wellEntry);
             
            string selectedProjectId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosProjectId");
            if (!Guid.TryParse(selectedProjectId, out var selectSeismosProjectId))
            {
                selectSeismosProjectId = Guid.Empty;
            }

            wellDataService.AddWellEntry(wellEntry, selectSeismosProjectId);

        }


        private ObservableCollection<WellEntry> wellEntries;

        public ObservableCollection<WellEntry> WellEntries
        {
            get { return wellEntries; }
            set { wellEntries = value; }
        }

    }



}
