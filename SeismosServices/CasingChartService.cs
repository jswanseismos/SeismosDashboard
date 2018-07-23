using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public struct CasingChartRecord
    {
        public double OuterDiameter { get; set; }
        public double Weight { get; set; }
        public string Grade { get; set; }
        public double InnerDiameter { get; set; }
    }

    public class CasingChartService
    {
        private List<CasingChartRecord> casingChart;

        private void LoadCasingChart()
        {
            using (var seismosContext = new seismosEntities())
            {
                casingChart = new List<CasingChartRecord>();
                foreach (var chartLookup in seismosContext.CasingChartLookups)
                {
                    casingChart.Add(new CasingChartRecord()
                    {
                        Grade = chartLookup.Grade,
                        InnerDiameter = chartLookup.InnerDiameter,
                        OuterDiameter = chartLookup.OuterDiameter,
                        Weight = chartLookup.Weight
                    });
                }
            }
        }

        public List<Double> GetWeightList(double outerDiameter)
        {
            if (casingChart == null)
            {
                LoadCasingChart();
            }

            List<Double> weightList = new List<double>();

            weightList.AddRange(casingChart
                .Where(chartLookup => Math.Abs(chartLookup.OuterDiameter - outerDiameter) < 0.0001)
                .Select(chartLookup => chartLookup.Weight).Distinct());

            return weightList;
        }

        public List<String> GetGradeList(double outerDiameter, double weight)
        {
            if (casingChart == null)
            {
                LoadCasingChart();
            }
            List<String> gradeList = new List<string>();


            gradeList.AddRange(casingChart
                .Where(chartLookup => Math.Abs(chartLookup.OuterDiameter - outerDiameter) < 0.0001)
                .Where(chartLookup => Math.Abs(chartLookup.Weight - weight) < 0.0001)
                .Select(chartLookup => chartLookup.Grade).Distinct());



            return gradeList;
        }

        public Double GetInnerDiameter(double outerDiameter, double weight, String grade)
        {
            if (casingChart == null)
            {
                LoadCasingChart();
            }
            double retValue = 0.0;
            foreach (var chartLookup in casingChart)
            {
                if (chartLookup.OuterDiameter.ApproxEquals(outerDiameter) &&
                    chartLookup.Weight.ApproxEquals(weight) && chartLookup.Grade == grade)
                {
                    retValue = chartLookup.InnerDiameter;
                    break;
                }

            }


            return retValue;
        }


    }

}
