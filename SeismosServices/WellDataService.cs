using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public class WellDataService
    {

        public List<WellEntry> GetWellEntries()
        {
            List<WellEntry> wellEntries = new List<WellEntry>();
            List<Well> wells;

            using (var seismosContext = new seismosEntities())
            {
                wells = seismosContext.Wells.Include(w => w.WellBore.Cylinders).ToList();


            }
            wellEntries.AddRange(wells.Select(well => new WellEntry()
            {
                Id = well.Id,
                Name = well.WellName,
                SurfaceVolume = well.WellBore.SurfaceVolume,
                TotalVolume = well.WellBore.TotalVolume,
                CylinderEntries = GetCylinderEntries(well.WellBore)
            }));

            return wellEntries;
        }

        public WellEntry GetWellEntry(Guid wellId)
        {
            Well getWell;

            using (var seismosContext = new seismosEntities())
            {
                getWell = seismosContext.Wells.Where(w => w.Id == wellId).Include(w => w.WellBore.Cylinders).FirstOrDefault();
            }

            if (getWell == null) return null;


            var wellEntry = new WellEntry()
            {
                Id = getWell.Id,
                Name = getWell.WellName,
                SurfaceVolume = getWell.WellBore.SurfaceVolume,
                TotalVolume = getWell.WellBore.TotalVolume,
                CylinderEntries = GetCylinderEntries(getWell.WellBore)
            };

            return wellEntry;
        }

        private List<CylinderEntry> GetCylinderEntries (WellBore wellBore)
        {
            List<CylinderEntry> cylinderEntries = new List<CylinderEntry>();
            if (wellBore.Cylinders == null) return cylinderEntries;

            cylinderEntries.AddRange(wellBore.Cylinders.Select(cylinder => new CylinderEntry()
            {
                Id = cylinder.Id,
                CasingOrderType = Enum.GetName(typeof(CasingOrderTypeEnum), cylinder.CasingOrderType),
                OuterDiameter = cylinder.OuterDiameter,
                Grade = cylinder.Grade,
                Weight = cylinder.Weight,
                MeasuredDepth = cylinder.MeasuredDepth,
                InnerDiameter = cylinder.InnerDiameter,
                TopOfLiner = cylinder.TopOfLiner,
                CalculatedVolume = cylinder.CalculatedVolume
            }).OrderBy(ce => ce.CasingOrderType));


            return cylinderEntries;
        }

        public void UpdateWellEntry(WellEntry wellEntry)
        {
            Well currWell;

            using (var seismosContext = new seismosEntities())
            {
                currWell = seismosContext.Wells.Where(w => w.Id == wellEntry.Id).Include(w => w.WellBore.Cylinders).FirstOrDefault();
                if (currWell == null) return;

                currWell.WellName = wellEntry.Name;
                currWell.WellBore.Name = wellEntry.Name;
                currWell.WellBore.SurfaceVolume = wellEntry.SurfaceVolume;
                currWell.WellBore.TotalVolume = wellEntry.TotalVolume;
                foreach (var wellBoreCylinder in currWell.WellBore.Cylinders)
                {
                    var entryCylinder = wellEntry.CylinderEntries.FirstOrDefault(ce => ce.Id == wellBoreCylinder.Id);
                    if (entryCylinder == null) continue;
                    wellBoreCylinder.CalculatedVolume = entryCylinder.CalculatedVolume;
                    wellBoreCylinder.CasingOrderType = (CasingOrderTypeEnum) Enum.Parse(typeof(CasingOrderTypeEnum), entryCylinder.CasingOrderType) ;
                    wellBoreCylinder.Grade = entryCylinder.Grade;
                    wellBoreCylinder.InnerDiameter = entryCylinder.InnerDiameter;
                    wellBoreCylinder.MeasuredDepth = entryCylinder.MeasuredDepth;
                    wellBoreCylinder.OuterDiameter = entryCylinder.OuterDiameter;
                    wellBoreCylinder.TopOfLiner = entryCylinder.TopOfLiner;
                    wellBoreCylinder.Weight = entryCylinder.Weight;

                }
                // TODO handle the number of stages here
                seismosContext.SaveChanges();
            }


        }

    }
}
