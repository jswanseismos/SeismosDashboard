using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosServices.Annotations;

namespace SeismosServices
{
    public class WellEntry: INotifyPropertyChanged
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public double SurfaceVolume
        {
            get => surfaceVolume;
            set
            {
                surfaceVolume = value;
                RecalculateVolumes();
                OnPropertyChanged(nameof(SurfaceVolume));
            }
        }

        public double TotalVolume
        {
            get => totalVolume;
            set
            {
                totalVolume = value;
                OnPropertyChanged(nameof(TotalVolume));
            }
        }

        private ObservableCollection<CylinderEntry> cylinderEntries;
        private double totalVolume;
        private double surfaceVolume;

        // when the cylinder entries are set, an event handler is added so when the cylinders change the handler here will be called
        // the handler here will calculate the volumes based on data in all of the rows
        // hence the need to handle the calculations here instead of per row
        public ObservableCollection<CylinderEntry> CylinderEntries
        {
            get => cylinderEntries;
            set
            {
                cylinderEntries = value;
                foreach (var observable in cylinderEntries)
                {
                    observable.PropertyChanged += ItemPropertyChanged;
                }

                OnPropertyChanged(nameof(CylinderEntries));
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (((CylinderEntry)sender).Equals(this.CylinderEntries[CylinderEntries.Count - 1]) && e.PropertyName != "CalculatedVolume")
            { 
                // this adds a new line in the table if the last row is starting to be edited
                WellDataService wellDataService = new WellDataService();
                var nextEntry =
                    wellDataService.GetNextCylinderEntry(
                        this.CylinderEntries[CylinderEntries.Count - 1].CasingOrderType);
                // there are only 10 casings so past that no new rows will be added
                if (nextEntry == null) return;
                nextEntry.PropertyChanged += ItemPropertyChanged;
                CylinderEntries.Add(nextEntry);
            }
            if (e.PropertyName == "MeasuredDepth" || e.PropertyName == "TopOfLiner")
            {
                RecalculateVolumes();
            }

        }

        private void RecalculateVolumes()
        {
            double currentDepth = 0.0;
            TotalVolume = SurfaceVolume;
            if (cylinderEntries == null) return;
            for (var index = cylinderEntries.Count - 1; index >= 0; index--)
            {
                var cylinderEntry = cylinderEntries[index];
                if (currentDepth.ApproxEquals(0.0)) currentDepth = cylinderEntry.MeasuredDepth;
                cylinderEntry.ActualMeasuredDepth = currentDepth - cylinderEntry.TopOfLiner;
                cylinderEntry.CalculateVolume();
                currentDepth = cylinderEntry.TopOfLiner;
                TotalVolume += cylinderEntry.CalculatedVolume;
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
