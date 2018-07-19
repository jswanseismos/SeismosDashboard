using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosServices
{
    public class WellEntry
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public int NumberOfStages { get; set; }

        public double SurfaceVolume { get; set; }

        public double TotalVolume { get; set; }

        public IEnumerable<CylinderEntry> CylinderEntries { get; set; }


    }

}
