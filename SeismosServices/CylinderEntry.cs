using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public class CylinderEntry
    {
        public Guid Id { get; set; }
        public string CasingOrderType { get; set; }
        public double MeasuredDepth { get; set; }
        public double InnerDiameter { get; set; }
        public double OuterDiameter { get; set; }
        public double TopOfLiner { get; set; }
        public double Weight { get; set; }
        public string Grade { get; set; }
        public double CalculatedVolume { get; set; }

    }
}
