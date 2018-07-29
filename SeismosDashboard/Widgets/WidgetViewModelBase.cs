using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class WidgetViewModelBase : INotifyPropertyChanged, IWidgetIdentity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Guid WidgetId { get; set; }

        // show or collapse the control
        public bool IsVisible { get; set; } = true;
        // sleepMode should be not visible and state should be serialized
        // and references released to prevent a memory leak
        protected bool sleepMode = false;


        // over this method to implement serialization and release some memory 
        public virtual void ChangeSleepMode(bool isSleepMode)
        {
            sleepMode = isSleepMode;
            IsVisible = !isSleepMode;
            OnPropertyChanged(nameof(IsVisible));
        }

    }
}
