using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;
using SeismosServices.Annotations;

namespace SeismosServices
{
    public class CylinderEntry : INotifyPropertyChanged
    {
        private CasingChartService casingChart;

        public CylinderEntry(CasingChartService casingChart)
        {
            this.casingChart = casingChart;
            Weights = new List<double>();
        }


        public Guid Id { get; set; }
        public string CasingOrderType { get; set; }

        private double measuredDepth;
        public double MeasuredDepth
        {
            get { return measuredDepth; }
            set
            {
                measuredDepth = value; 
                OnPropertyChanged(nameof(MeasuredDepth));
                CalculateVolume();
            }
        }

        private double innerDiameter;
        public double InnerDiameter
        {
            get { return innerDiameter; }
            set
            {
                innerDiameter = value;
                OnPropertyChanged(nameof(InnerDiameter));
                CalculateVolume();
            }
        }

        private double outerDiameter;
        public double OuterDiameter
        {
            get => outerDiameter;
            set
            {
                outerDiameter = value;
                GetWeights();
                OnPropertyChanged(nameof(OuterDiameter));
                CalculateVolume();
            }
        }

        public double TopOfLiner { get; set; }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                GetGrades();
                OnPropertyChanged(nameof(Weight));
                CalculateVolume();
            }
        }

        private string grade;
        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                GetInnerDiameter();
                OnPropertyChanged(nameof(Grade));
                CalculateVolume();
            }
        }

        private double calculatedVolume;
        public double CalculatedVolume
        {
            get { return calculatedVolume; }
            set
            {
                calculatedVolume = value; 
                OnPropertyChanged(nameof(CalculatedVolume));
            }
        }

        private List<Double> weights;
        public List<double> Weights
        {
            get { return weights; }
            set
            {
                weights = value;
                OnPropertyChanged(nameof(Weights));
            }
        }

        private List<String> grades;
        public List<string> Grades
        {
            get { return grades; }
            set
            {
                grades = value; 
                OnPropertyChanged(nameof(Grades));
            }
        }


        private void GetWeights()
        {
            Weights = casingChart.GetWeightList(outerDiameter);
        }

        private void GetGrades()
        {
            Grades = casingChart.GetGradeList(outerDiameter, weight);
        }

        private void GetInnerDiameter()
        {
            InnerDiameter = casingChart.GetInnerDiameter(outerDiameter, weight, grade);
        }

        private void CalculateVolume()
        {
            CalculatedVolume = Math.Pow(InnerDiameter, 2) * MeasuredDepth / 1029.4;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
