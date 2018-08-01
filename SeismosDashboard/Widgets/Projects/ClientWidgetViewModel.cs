using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SeismosServices;

namespace SeismosDashboard
{
    public class ClientWidgetViewModel : WidgetViewModelBase
    {

        private const String AddButtonName = "Add Client";
        private const String UpdateButtonName = "Update Client";

        private SeismosMetaDataService seismosMetaDataService;

        public ClientWidgetViewModel()
        {
            seismosMetaDataService = new SeismosMetaDataService();
            Initialize();            
            saveCommand = new SimpleCommand(SaveAction);
        }

        private void Initialize()
        {
            // get the current selected client id
            string selectedId = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosClientId);
            if (!Guid.TryParse(selectedId, out var selectedGuid)) selectedGuid = Guid.Empty;
            

            // get list of clients as KeyValueEntity
            seismosClients = seismosMetaDataService.GetSeismosClients();
            ocSeismosClients = new ObservableCollection<KeyValueEntity>(seismosClients);

            // get the selected client object
            SelectedSeismosClient =
                ocSeismosClients.FirstOrDefault(sc => sc.Id == selectedGuid) ?? new KeyValueEntity();

        }

        // initial set of seismos clients
        private List<KeyValueEntity> seismosClients;
        public List<KeyValueEntity> SeismosClients
        {
            get { return seismosClients; }
            set { seismosClients = value; }
        }

        // observable collection of seismos clients
        private ObservableCollection<KeyValueEntity> ocSeismosClients;
        public ObservableCollection<KeyValueEntity> OcSeismosClients
        {
            get { return ocSeismosClients; }
            set { ocSeismosClients = value; }
        }

        // change the button whether it is an add or update
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


        private KeyValueEntity selectedSeismosClient;
        public KeyValueEntity SelectedSeismosClient
        {
            get { return selectedSeismosClient; }
            set
            {
                selectedSeismosClient = value;
                // trigger change in selected client event
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosClientId, selectedSeismosClient.Id.ToString());
                // client name is for the header since the header only displays it
                DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosClientName,
                    selectedSeismosClient.Name);

                // there is an empty seismos client in the list, if that is selected than the button turns to 'Add'
                AddUpdateButtonName = selectedSeismosClient.Name != String.Empty ? UpdateButtonName : AddButtonName;

                OnPropertyChanged(nameof(SelectedSeismosClient));
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
            // push changes to the database. get the updated guid of the selected object
            var updatedGuid = seismosMetaDataService.UpdateSeismosClient(SelectedSeismosClient);
            // store the selected guid
            DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosClientId, updatedGuid.ToString());
            // reload the data for the control
            Initialize();
            // just adding this for the name.
            // TODO find a better way to save the name
            //            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClientObject", SelectedSeismosClient);
            OnPropertyChanged(nameof(OcSeismosClients));
            OnPropertyChanged(nameof(SelectedSeismosClient));
            addUpdateButtonName = AddUpdateButtonName;
        }


        #endregion


    }
}
