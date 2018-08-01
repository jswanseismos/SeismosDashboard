using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Input;
using SeismosDataLibrary;
using SeismosServices;

namespace SeismosDashboard
{
    public class WellVolumesWidgetViewModel : WidgetViewModelBase
    {

        public WellVolumesWidgetViewModel()
        {
            wellDataService = new WellDataService();

            saveWellCommand = new RelayCommand(SaveWellAction);

        }

        private void Initialize()
        {
            var result = wellDataService.GetWellEntry(currentWellId);

            CurrWellEntry = result;
        }

        private WellDataService wellDataService;

        private Guid currentWellId;
        public Guid CurrentWellId
        {
            get => currentWellId;
            set
            {
                currentWellId = value;
                Initialize();
            }
        }


        private ICommand saveWellCommand;
        public ICommand SaveWellCommand
        {
            get { return saveWellCommand; }
            set { saveWellCommand = value; }
        }

        public void SaveWellAction(object param)
        {

            wellDataService.UpdateWellEntry(currWellEntry);

        }


        private WellEntry currWellEntry;
        public WellEntry CurrWellEntry
        {
            get { return currWellEntry; }
            set
            {
                currWellEntry = value;
                OnPropertyChanged(nameof(CurrWellEntry));
            }
        }


    }



}
