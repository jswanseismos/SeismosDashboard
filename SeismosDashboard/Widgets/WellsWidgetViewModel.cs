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
            wellDataService.UpdateWellEntry(wellEntry);


        }


        private ObservableCollection<WellEntry> wellEntries;

        public ObservableCollection<WellEntry> WellEntries
        {
            get { return wellEntries; }
            set { wellEntries = value; }
        }

    }



}
