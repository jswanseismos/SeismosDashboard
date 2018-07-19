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
    public class AddClientDialogViewModel : ViewModelBase
    {
        public AddClientDialogViewModel( Action closeAction)
        {
            isChanged = false;
            metaDataService = new SeismosMetaDataService();
            selectSeismosClient = DashboardStorage.Instance.GetValue<SeismosClient>("SelectedSeismosClient");
            if (selectSeismosClient != null)
            {
                isEdit = true;
            }
            else
            {
                selectSeismosClient = new SeismosClient();
            }
            this.closeAction = closeAction;
//            closeCommand = new SimpleCommand(CloseWindow);
        }


        private SeismosMetaDataService metaDataService;
        private bool isChanged;
        private bool isEdit;
        private Action closeAction;

        private SeismosClient selectSeismosClient;
        public SeismosClient SelectSeismosClient
        {
            get { return selectSeismosClient; }
            set
            {
                selectSeismosClient = value;
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
                isChanged = true;
                SelectSeismosClient.Contact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public string SelectedClientName
        {
            get { return SelectSeismosClient.ClientName; }
            set
            {
                isChanged = true;
                SelectSeismosClient.ClientName = value;
                OnPropertyChanged(nameof(SelectedClientName));
            }
        }

        public string SelectedPhoneNumber
        {
            get { return SelectSeismosClient.PhoneNumber; }
            set
            {
                isChanged = true;
                SelectSeismosClient.PhoneNumber = value;
                OnPropertyChanged(nameof(SelectedPhoneNumber));
            }
        }

        public string SelectedEmail
        {
            get { return SelectSeismosClient.Email; }
            set
            {
                isChanged = true;
                SelectSeismosClient.Email = value;
                OnPropertyChanged(nameof(SelectedEmail));
            }
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


        private void closeWindow()
        {
            if (isChanged)
            {
                if (isEdit)
                {
                    metaDataService.UpdateSeismosClient(SelectSeismosClient);
                }
                else
                {
                    metaDataService.AddSeismosClient(SelectSeismosClient);
                }
            }

            selectSeismosClient = metaDataService.GetSeismosClients()
                .FirstOrDefault(sc => sc.Id == SelectSeismosClient.Id);

            DashboardStorage.Instance.AddOrUpdate("SelectedSeismosClient", selectSeismosClient);

//            currWindow.Close();
            closeAction();

        }


        public override Action CloseWindow => closeWindow;
    }
}
