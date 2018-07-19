using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    public static class SeismosExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>
            (this IEnumerable<T> en)
        {
            return new ObservableCollection<T>(en);
        }

        public static Double Delta { get; set; } = 0.0001;

        public static bool ApproxEquals(this Double double1, Double double2)
        {
            return Math.Abs(double1 - double2) <= Delta;
        }
    }
}
