﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{


    public class WellDataService
    {
        private CasingChartService casingChartService = new CasingChartService();
        private static readonly CasingOrderTypeEnum MaxCasingOrder = (CasingOrderTypeEnum)Enum.GetValues(typeof(CasingOrderTypeEnum)).Cast<short>().Max();

        public void AddWells(KeyValueEntity wells, Guid targetProjectId)
        {
            SeismosProject targetProject;

            using (var seismosContext = new seismosEntities())
            {
                targetProject = seismosContext.SeismosProjects.FirstOrDefault(sp => sp.Id == targetProjectId);
                if (targetProject == null) return;

                var currWells = targetProject.Wells.ToList();
                foreach (var wellsKeyValuePair in wells.KeyValuePairs)
                {
                    if (wellsKeyValuePair == null) continue;
                    var existingWell = currWells.FirstOrDefault(cw => cw.WellName == wellsKeyValuePair.Id);
                    if (existingWell != null) continue;

                    if (!Int32.TryParse(wellsKeyValuePair.Text.ToString(), out var iStagesToCreate))
                    {
                        iStagesToCreate = 0;
                    }

                    var insertWell = new Well
                    {
                        Id = Guid.NewGuid(),
                        WellName = wellsKeyValuePair.Id,
                        SeismosProject = targetProject
                    };

                    var hfTreatment = new HydraulicFracturingTreatment()
                    {
                        Id = Guid.NewGuid(),
                        Name = insertWell.WellName + " HF",
                        Type = TreatmentTypeEnum.HydraulicFracturing,
                        Stages = new List<Stage>()
                    };


                    for (int index = 0; index < iStagesToCreate; index++)
                    {
                        hfTreatment.Stages.Add(new Stage() { Id = Guid.NewGuid(), Number = index, StartTime = DateTime.Now, StopTime = DateTime.Now });
                    }

                    insertWell.Treatments.Add(hfTreatment);

                    seismosContext.Wells.Add(insertWell);


                }

                seismosContext.SaveChanges();

            }

        }

        private int GetStageCount(Well well)
        {
            int result = 0;

            if (well.Treatments == null || well.Treatments.Count == 0) return 0;
            foreach (var treatment in well.Treatments)
            {
                if (treatment is HydraulicFracturingTreatment fracturingTreatment)
                {
                    result += fracturingTreatment.Stages.Count();
                }
            }

            return result;
        }


        public KeyValueEntity GetWellNamesEntity(Guid seismosProjectId)
        {
            KeyValueEntity wellsEntity = new KeyValueEntity();

            SeismosProject targetProject;
            List<Well> wells;
            
            using (var seismosContext = new seismosEntities())
            {
                targetProject = seismosContext.SeismosProjects.FirstOrDefault(sp => sp.Id == seismosProjectId);
                if (targetProject == null) return null;

//                wells = seismosContext.Wells.Where(w => w.SeismosProject.Id == targetProject.Id).ToList();
                wells = targetProject.Wells.ToList();


                wellsEntity.Id = targetProject.Id;
                wellsEntity.Name = targetProject.Name;
                foreach (var well in wells)
                {
                    int numStages = 0;
                    var treatments = seismosContext.Treatments.Where(tr => tr.WellId == well.Id).ToList();
                    foreach (var treatment in treatments)
                    {
                        if (treatment is HydraulicFracturingTreatment fracturingTreatment)
                        {
                            numStages += fracturingTreatment.Stages.Count();
                        }
                    }


                    wellsEntity.KeyValuePairs.Add(new KeyValueMutable<string, object>(well.WellName, numStages.ToString()));

                }

            }


            return wellsEntity;
        }


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
                CylinderEntries = new ObservableCollection<CylinderEntry>(GetCylinderEntries(well.WellBore))
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

            double surfaceVolume = getWell.WellBore?.SurfaceVolume ?? 0.0;
            double totalVolume = getWell.WellBore?.TotalVolume ?? 0.0;

            var wellEntry = new WellEntry()
            {
                Id = getWell.Id,
                Name = getWell.WellName,
                SurfaceVolume = surfaceVolume,
                TotalVolume = totalVolume,
                CylinderEntries = new ObservableCollection<CylinderEntry>(GetCylinderEntries(getWell.WellBore))
            };

            return wellEntry;
        }


        private List<CylinderEntry> GetCylinderEntries (WellBore wellBore)
        {
            List<CylinderEntry> cylinderEntries = new List<CylinderEntry>();
//            casingChartService = new CasingChartService();

            // at present only upto two liners have been used
            if (wellBore?.Cylinders == null || wellBore.Cylinders.Count == 0)
            {
                cylinderEntries.Add(GetBlankCylinderEntry(CasingOrderTypeEnum.Casing));
//                cylinderEntries.Add(GetBlankCylinderEntry(CasingOrderTypeEnum.Liner1));
//                cylinderEntries.Add(GetBlankCylinderEntry(CasingOrderTypeEnum.Liner2));
                return cylinderEntries;
            }

            var listCylinders = wellBore.Cylinders.Select(cylinder => new CylinderEntry(casingChartService)
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
            }).OrderBy(ce => ce.CasingOrderType).ToList();

            var lastCasingOrder = listCylinders[listCylinders.Count - 1].CasingOrderType;
            var blankCylinder = GetNextCylinderEntry(lastCasingOrder);
            listCylinders.Add(blankCylinder);

//            double currentDepth = 0.0;
//            foreach (var cylinderEntry in listCylinders)
//            {
//                if (currentDepth.ApproxEquals(0.0)) currentDepth = cylinderEntry.MeasuredDepth;
//                cylinderEntry.ActualMeasuredDepth = currentDepth - cylinderEntry.TopOfLiner;
//                currentDepth = cylinderEntry.TopOfLiner;
//                cylinderEntries.Add(cylinderEntry);
//            }

            return listCylinders;
        }

        public CylinderEntry GetNextCylinderEntry(string currCasingOrder)
        {
            CasingOrderTypeEnum currEnum = (CasingOrderTypeEnum) Enum.Parse(typeof(CasingOrderTypeEnum), currCasingOrder);
            if (currEnum == MaxCasingOrder) return null;
            return GetBlankCylinderEntry(currEnum + 1);
        }

        public CylinderEntry GetNextCylinderEntry(CasingOrderTypeEnum currCasingOrder)
        {
            if (currCasingOrder == MaxCasingOrder) return null;
            return GetBlankCylinderEntry(currCasingOrder + 1);
        }

        private CylinderEntry GetBlankCylinderEntry(CasingOrderTypeEnum casingOrder)
        {
            CylinderEntry resultCylinderEntry =
                new CylinderEntry(casingChartService)
                {
                    Id = Guid.Empty,
                    CasingOrderType = Enum.GetName(typeof(CasingOrderTypeEnum), casingOrder),
                    OuterDiameter = 0.0,
                    Grade = string.Empty,
                    Weight = 0.0,
                    ActualMeasuredDepth = 0.0,
                    MeasuredDepth = 0.0,
                    InnerDiameter = 0.0,
                    TopOfLiner = 0.0,
                    CalculatedVolume = 0.0
                };
            return resultCylinderEntry;
        }

        public void UpdateWellEntry(WellEntry wellEntry)
        {
            using (var seismosContext = new seismosEntities())
            {
                var currWell = seismosContext.Wells.Where(w => w.Id == wellEntry.Id).Include(w => w.WellBore.Cylinders).FirstOrDefault();
                if (currWell == null) return;

                currWell.WellName = wellEntry.Name;

                if (currWell.WellBore == null)
                {
                    currWell.WellBore = new WellBore {Id = Guid.NewGuid()};
                }

                currWell.WellBore.Name = wellEntry.Name;
                currWell.WellBore.SurfaceVolume = wellEntry.SurfaceVolume;
                currWell.WellBore.TotalVolume = wellEntry.TotalVolume;
                foreach (var cylinderEntry in wellEntry.CylinderEntries)
                {
                    if (cylinderEntry.CalculatedVolume.ApproxEquals(0.0)) break;
                    if (cylinderEntry.Id == Guid.Empty)
                    {
                        cylinderEntry.Id = Guid.NewGuid();
                    }

                    bool isNew = false;
                    var wellBoreCylinder =
                        currWell.WellBore.Cylinders.FirstOrDefault(cy => cy.Id == cylinderEntry.Id);
                    if (wellBoreCylinder == null)
                    {
                        wellBoreCylinder = new Cylinder {Id = Guid.NewGuid()};
                        isNew = true;

                    }
                    wellBoreCylinder.CalculatedVolume = cylinderEntry.CalculatedVolume;
                    wellBoreCylinder.CasingOrderType = (CasingOrderTypeEnum) Enum.Parse(typeof(CasingOrderTypeEnum),
                        cylinderEntry.CasingOrderType);
                    wellBoreCylinder.Grade = cylinderEntry.Grade;
                    wellBoreCylinder.InnerDiameter = cylinderEntry.InnerDiameter;
                    wellBoreCylinder.MeasuredDepth = cylinderEntry.MeasuredDepth;
                    wellBoreCylinder.OuterDiameter = cylinderEntry.OuterDiameter;
                    wellBoreCylinder.TopOfLiner = cylinderEntry.TopOfLiner;
                    wellBoreCylinder.Weight = cylinderEntry.Weight;

                    if (isNew)
                    {
                        currWell.WellBore.Cylinders.Add(wellBoreCylinder);
                    }
                }

                
                seismosContext.SaveChanges();
            }


        }


        public void AddWellEntry(WellEntry wellEntry, Guid targetProjectId)
        {

            using (var seismosContext = new seismosEntities())
            {
                var targetProject = seismosContext.SeismosProjects.FirstOrDefault(sp => sp.Id == targetProjectId);
                if (targetProject == null) return;

                var insertWell = new Well
                {
                    Id = Guid.NewGuid(),
                    WellName = wellEntry.Name,
                    SeismosProject = targetProject,
                    WellBore = new WellBore
                    {
                        Id = Guid.NewGuid(),
                        Name = wellEntry.Name,
                        SurfaceVolume = wellEntry.SurfaceVolume,
                        TotalVolume = wellEntry.TotalVolume
                    }
                };

                foreach (var wellEntryCylinderEntry in wellEntry.CylinderEntries)
                {
                    var wellBoreCylinder = new Cylinder
                    {
                        Id = Guid.NewGuid(),
                        CalculatedVolume = wellEntryCylinderEntry.CalculatedVolume,
                        CasingOrderType = (CasingOrderTypeEnum) Enum.Parse(typeof(CasingOrderTypeEnum),
                            wellEntryCylinderEntry.CasingOrderType),
                        Grade = wellEntryCylinderEntry.Grade,
                        InnerDiameter = wellEntryCylinderEntry.InnerDiameter,
                        MeasuredDepth = wellEntryCylinderEntry.MeasuredDepth,
                        OuterDiameter = wellEntryCylinderEntry.OuterDiameter,
                        TopOfLiner = wellEntryCylinderEntry.TopOfLiner,
                        Weight = wellEntryCylinderEntry.Weight,
                        InnerInterfaceState = InterfaceStateTypeEnum.NoSlip,
                        OuterInterfaceState = InterfaceStateTypeEnum.NoSlip
                    };
                    insertWell.WellBore.Cylinders.Add(wellBoreCylinder);
                }

                
//                var hfTreatment = new HydraulicFracturingTreatment()
//                {
//                    Id = Guid.NewGuid(),
//                    Name = insertWell + " HF",
//                    Type = TreatmentTypeEnum.HydraulicFracturing,
//                    Stages = new List<Stage>()
//                };
//
//
//                for (int index = 0; index < wellEntry.NumberOfStages; index++)
//                {
//                    hfTreatment.Stages.Add(new Stage(){Id = Guid.NewGuid(), Number = index, StartTime = DateTime.Now, StopTime = DateTime.Now});
//                }
//
//                insertWell.Treatments.Add(hfTreatment);

                seismosContext.Wells.Add(insertWell);
                seismosContext.SaveChanges();
            }


        }



    }
}
