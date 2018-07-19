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

        private SeismosMetaDataService seismosMetaDataService = new SeismosMetaDataService();

        public ClientWidgetViewModel()
        {
            Initialize();            
            saveCommand = new SimpleCommand(SaveAction);
        }

        private void Initialize()
        {
            // get the current selected client id
            string selectedId = DashboardStorage.Instance.GetValue<string>("SelectedSeismosClientId");
            Guid selectedGuid;
            if (!Guid.TryParse(selectedId, out selectedGuid))
            {
                selectedGuid = Guid.Empty;
            }

            // get list of clients as KeyValueEntity
            seismosClients = seismosMetaDataService.GetSeismosClientsAlt();
            ocSeismosClients = new ObservableCollection<KeyValueEntity>(seismosClients);

            // get the selected client object
            SelectedSeismosClient =
                ocSeismosClients.FirstOrDefault(sc => sc.Id == selectedGuid) ?? new KeyValueEntity();

        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        private void SaveAction()
        {
            // push changes to the database. get the updated guid of the selected object
            var updatedGuid = seismosMetaDataService.UpdateSeismosClientAlt(SelectedSeismosClient);
            // store the selected guid
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClientId", updatedGuid.ToString());
            // reload the data for the control
            Initialize();
            // just adding this for the name.
            // TODO find a better way to save the name
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClientObject", SelectedSeismosClient);
            OnPropertyChanged(nameof(OcSeismosClients));
            OnPropertyChanged(nameof(SelectedSeismosClient));
        }


        private List<KeyValueEntity> seismosClients;
        public List<KeyValueEntity> SeismosClients
        {
            get { return seismosClients; }
            set { seismosClients = value; }
        }

        private ObservableCollection<KeyValueEntity> ocSeismosClients;
        public ObservableCollection<KeyValueEntity> OcSeismosClients
        {
            get { return ocSeismosClients; }
            set { ocSeismosClients = value; }
        }



        private KeyValueEntity selectedSeismosClient;
        public KeyValueEntity SelectedSeismosClient
        {
            get { return selectedSeismosClient; }
            set
            {
                selectedSeismosClient = value;
                OnPropertyChanged(nameof(SelectedSeismosClient));
            }
        }

    }
}
