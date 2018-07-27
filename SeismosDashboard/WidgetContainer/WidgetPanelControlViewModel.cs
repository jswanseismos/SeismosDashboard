using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class WidgetPanelControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // TODO design a way to add/remove widgetviewmodels and widgets,
        // TODO design a way to save/restore state
       
        public WidgetPanelControlViewModel()
        {
            viewModels = new ObservableCollection<WidgetViewModelBase>();
//            {
//                new ClientWidgetViewModel(),
//                new ProjectWidgetViewModel(),
//                new WellsGeneralWidgetViewModel()
//            };
        }


        // TODO determine if there should be a controller with this viewmodel as a dependency
        // or should it be a service, a mediator
        public void AddWidget(WidgetViewModelBase addWidgetViewModel)
        {
            viewModels.Add(addWidgetViewModel);

        }

        public void RemoveWidget(Guid widgetId)
        {
            // TODO implement removing widget

        }

        public void ShowWidget(Guid widgetId, bool bShow)
        {

        }

        private ObservableCollection<WidgetViewModelBase> viewModels;

        public ObservableCollection<WidgetViewModelBase> ViewModels
        {
            get => viewModels;
            set { viewModels = value; }
        }






    }
}
