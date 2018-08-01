using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class WidgetViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // gives each instance an id (this could be used to find a widget in a list)
        public Guid WidgetId { get; } = Guid.NewGuid();

        // show or collapse the control
        private bool isVisible = true;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        // sleepMode should be not visible and state should be serialized
        // and references released to prevent a memory leak
        protected bool SleepMode = false;


        // over this method to implement serialization and release some memory 
        public virtual void ChangeSleepMode(bool isSleepMode)
        {
            SleepMode = isSleepMode;
            IsVisible = !isSleepMode;
            OnPropertyChanged(nameof(IsVisible));
        }

    }
}
