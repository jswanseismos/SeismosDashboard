using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDashboard.Annotations;
using SeismosServices;

namespace SeismosDashboard
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private SavedStateService savedStateService = new SavedStateService();

        private ProjectWidgetController projectWidgetController;
        private WellWidgetController wellWidgetController;
        

        public MainWindowViewModel()
        {
            LoadSavedState();

            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosClientId, SaveClientId);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosProjectId, SaveProjectId);

            // WidgetPanelControlViewModel is instansiated here so it can be injected into the controllers

            widgetPanelControlViewModel = new WidgetPanelControlViewModel();

            // controllers go here
            // they control the state of a set of related widgets (project widgets, well widgets, stage widgets)
            // if there are any other groups of widgets which the state needs to be controlled add them here
            projectWidgetController = new ProjectWidgetController(widgetPanelControlViewModel);
            wellWidgetController = new WellWidgetController(widgetPanelControlViewModel);
        }

        private void SaveProjectId()
        {
            string value = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosProjectId);
            savedStateService.AddState(Enum.GetName(typeof(DashboardEventsEnum), DashboardEventsEnum.CurrentSeismosProjectId), value);
        }

        private void SaveClientId()
        {
            string value = DashboardStorage.Instance.GetValue<string>(DashboardEventsEnum.CurrentSeismosClientId);
            savedStateService.AddState(Enum.GetName(typeof(DashboardEventsEnum), DashboardEventsEnum.CurrentSeismosClientId), value);
        }

        private void LoadSavedState()
        {
            string projectId = savedStateService.GetStateValue(Enum.GetName(typeof(DashboardEventsEnum), DashboardEventsEnum.CurrentSeismosProjectId));

            DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosProjectId, projectId);

            string clientId = savedStateService.GetStateValue(Enum.GetName(typeof(DashboardEventsEnum), DashboardEventsEnum.CurrentSeismosClientId));

            DashboardStorage.Instance.AddOrUpdate(DashboardEventsEnum.CurrentSeismosClientId, clientId);
        }


        private WidgetPanelControlViewModel widgetPanelControlViewModel;
        public WidgetPanelControlViewModel PanelViewModel
        {
            get { return widgetPanelControlViewModel; }
            set
            {
                widgetPanelControlViewModel = value;
                OnPropertyChanged(nameof(PanelViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
