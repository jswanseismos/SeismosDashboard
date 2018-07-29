using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class HeaderControlViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        // code needs for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        // TODO investigate a way to have the current time on the header
        public HeaderControlViewModel()
        {
            selectClientName =
                DashboardStorage.Instance.GetValue<String>(DashboardEventsEnum.CurrentSeismosClientName) ?? "";
            selectProjectName =
                DashboardStorage.Instance.GetValue<String>(DashboardEventsEnum.CurrentSeismosProjectName) ?? "";
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosClientName,
                SelectedClientChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.CurrentSeismosProjectName,
                SelectedProjectChange);
        }

        #region Binding Properties

        private string selectClientName;

        public string SelectClientName
        {
            get { return selectClientName; }
            set
            {
                selectClientName = value;
                OnPropertyChanged(nameof(SelectClientName));
                OnPropertyChanged(nameof(SelectProjectName));
            }
        }

        private string selectProjectName;

        public string SelectProjectName
        {
            get { return selectProjectName; }
            set
            {
                selectProjectName = value;
                OnPropertyChanged(nameof(SelectProjectName));
            }
        }

        #endregion

        #region Change handlers
        // when client and project is changed, update the display
        private void SelectedClientChange()
        {
            selectClientName =
                DashboardStorage.Instance.GetValue<String>(DashboardEventsEnum.CurrentSeismosClientName) ?? "";
            OnPropertyChanged(nameof(SelectClientName));
            OnPropertyChanged(nameof(SelectProjectName));
        }

        private void SelectedProjectChange()
        {
            selectProjectName =
                DashboardStorage.Instance.GetValue<String>(DashboardEventsEnum.CurrentSeismosProjectName) ?? "";
            OnPropertyChanged(nameof(SelectProjectName));
        }

        #endregion
    }
}