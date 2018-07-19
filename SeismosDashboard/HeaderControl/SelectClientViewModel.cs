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
    public class SelectClientViewModel : ViewModelBase
    {
        public SelectClientViewModel(Action closeAction)
        {
            metaDataService = new SeismosMetaDataService();
            ocSeismosClients = new ObservableCollection<SeismosClient>(metaDataService.GetSeismosClients());
            selectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient") ?? ocSeismosClients[0];
            selectSeismosClient = ocSeismosClients.FirstOrDefault(sc => sc.Id == selectSeismosClient.Id);
            addClientCommand = new SimpleCommand(AddClientAction);
            editClientCommand = new SimpleCommand(EditClientAction);
            this.closeAction = closeAction;
            closeCommand = new SimpleCommand(CloseWindow);

        }


//        public event PropertyChangedEventHandler PropertyChanged;
//        [NotifyPropertyChangedInvocator]
//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }


        
        private SeismosMetaDataService metaDataService;


        private ObservableCollection<SeismosClient> ocSeismosClients;
        public ObservableCollection<SeismosClient> OcSeismosClients
        {
            get { return ocSeismosClients; }
            set
            {
                ocSeismosClients = value;
            }
        }

        private SeismosClient selectSeismosClient;
        public SeismosClient SelectSeismosClient
        {
            get { return selectSeismosClient; }
            set
            {
                selectSeismosClient = value;
                DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClient", selectSeismosClient);
                DashboardStorage.Instance.Remove("SelectedSeismosProject");
                OnPropertyChanged(nameof(SelectSeismosClient));
                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(SelectedPhoneNumber));
                OnPropertyChanged(nameof(SelectedEmail));
            }
        }

        public string SelectedContact
        {
            get { return SelectSeismosClient.Contact; }
            set
            {
                SelectSeismosClient.Contact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public string SelectedPhoneNumber
        {
            get { return SelectSeismosClient.PhoneNumber; }
            set
            {
                SelectSeismosClient.PhoneNumber = value;
                OnPropertyChanged(nameof(SelectedPhoneNumber));
            }
        }

        public string SelectedEmail
        {
            get { return SelectSeismosClient.Email; }
            set
            {
                SelectSeismosClient.Email = value;
                OnPropertyChanged(nameof(SelectedEmail));
            }
        }

        private ICommand addClientCommand;
        public ICommand AddClientCommand
        {
            get { return addClientCommand; }
            set { addClientCommand = value; }
        }

        private ICommand editClientCommand;
        public ICommand EditClientCommand
        {
            get { return editClientCommand; }
            set { editClientCommand = value; }
        }

        private void AddClientAction()
        {
            DashboardStorage.Instance.Remove("SelectedSeismosClient");
//            AddClientDialog addClientDialog = new AddClientDialog(AddClientClosed);
//            addClientDialog.ShowDialog();
        }

        private void EditClientAction()
        {
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClient", selectSeismosClient);
            AddClientDialog addClientDialog = new AddClientDialog(AddClientClosed);
            addClientDialog.ShowDialog();
        }

        private void AddClientClosed()
        {
            SelectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient");

            ocSeismosClients = new ObservableCollection<SeismosClient>(metaDataService.GetSeismosClients());
            // need to update the selected item before updating the list
            SelectSeismosClient = ocSeismosClients.FirstOrDefault(sc => sc.Id == SelectSeismosClient.Id);
            OnPropertyChanged(nameof(OcSeismosClients));

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

        private Action closeAction;
//        public override Action CloseWindow { get; }

        public override Action CloseWindow
        {
                get { return closeWindow; }
    //            set { closeWindow = value; }
        }


        private void closeWindow()
        {
            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClient", selectSeismosClient);

//            currWindow.Close();
            closeAction();
        }



    }
}
