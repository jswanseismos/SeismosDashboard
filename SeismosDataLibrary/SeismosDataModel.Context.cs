﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeismosDataLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class seismosEntities : DbContext
    {
        public seismosEntities()
            : base("name=seismosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SeismosClient> SeismosClients { get; set; }
        public virtual DbSet<SeismosProject> SeismosProjects { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Well> Wells { get; set; }
        public virtual DbSet<DeviationSurvey> DeviationSurveys { get; set; }
        public virtual DbSet<MD> MDs { get; set; }
        public virtual DbSet<TVD> TVDs { get; set; }
        public virtual DbSet<Inclination> Inclinations { get; set; }
        public virtual DbSet<Azimuth> Azimuths { get; set; }
        public virtual DbSet<Easting> Eastings { get; set; }
        public virtual DbSet<Northing> Northings { get; set; }
        public virtual DbSet<WellBore> WellBores { get; set; }
        public virtual DbSet<Cylinder> Cylinders { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Wellhead> Wellheads { get; set; }
        public virtual DbSet<WellheadCoordinate> WellheadCoordinates { get; set; }
        public virtual DbSet<WellheadAssembly> WellheadAssemblies { get; set; }
        public virtual DbSet<WellheadComponent> WellheadComponents { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<DataAcquisition> DataAcquisitions { get; set; }
        public virtual DbSet<Processing> Processings { get; set; }
        public virtual DbSet<DataRecord> DataRecords { get; set; }
        public virtual DbSet<TimePick> TimePicks { get; set; }
        public virtual DbSet<Reflection> Reflections { get; set; }
        public virtual DbSet<UsedParameter> UsedParameters { get; set; }
        public virtual DbSet<UsedFilter> UsedFilters { get; set; }
        public virtual DbSet<BasisSet> BasisSets { get; set; }
        public virtual DbSet<ParamConstraint> ParamConstraints { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<ColumnValue> ColumnValues { get; set; }
        public virtual DbSet<KGraphData> KGraphDatas { get; set; }
        public virtual DbSet<ACGraphData> ACGraphDatas { get; set; }
        public virtual DbSet<Injection> Injections { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Perforation> Perforations { get; set; }
        public virtual DbSet<Plug> Plugs { get; set; }
        public virtual DbSet<HFTreatmentStage> HFTreatmentStages { get; set; }
        public virtual DbSet<Fluid> Fluids { get; set; }
        public virtual DbSet<Proppant> Proppants { get; set; }
        public virtual DbSet<CasingChartLookup> CasingChartLookups { get; set; }
    }
}
