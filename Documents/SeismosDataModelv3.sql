
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/18/2018 10:08:26
-- Generated from EDMX file: C:\projects\SeismosDashboard\SeismosDataLibrary\SeismosDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Seismos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SeismosProjectsWells]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wells] DROP CONSTRAINT [FK_SeismosProjectsWells];
GO
IF OBJECT_ID(N'[dbo].[FK_WellsDeviationSurveys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wells] DROP CONSTRAINT [FK_WellsDeviationSurveys];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyInclination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inclinations] DROP CONSTRAINT [FK_DeviationSurveyInclination];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyEasting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Eastings] DROP CONSTRAINT [FK_DeviationSurveyEasting];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyNorthing]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Northings] DROP CONSTRAINT [FK_DeviationSurveyNorthing];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyAzimuth]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Azimuths] DROP CONSTRAINT [FK_DeviationSurveyAzimuth];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyTVD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TVDs] DROP CONSTRAINT [FK_DeviationSurveyTVD];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviationSurveyMD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MDs] DROP CONSTRAINT [FK_DeviationSurveyMD];
GO
IF OBJECT_ID(N'[dbo].[FK_WellBoreCylinder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cylinders] DROP CONSTRAINT [FK_WellBoreCylinder];
GO
IF OBJECT_ID(N'[dbo].[FK_WellWellBore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wells] DROP CONSTRAINT [FK_WellWellBore];
GO
IF OBJECT_ID(N'[dbo].[FK_WellheadComponentMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_WellheadComponentMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_SeismosClientSeismosProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeismosProjects] DROP CONSTRAINT [FK_SeismosClientSeismosProject];
GO
IF OBJECT_ID(N'[dbo].[FK_SeismosProjectNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_SeismosProjectNote];
GO
IF OBJECT_ID(N'[dbo].[FK_WellheadAssemblyWellheadComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WellheadComponents] DROP CONSTRAINT [FK_WellheadAssemblyWellheadComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_WellheadWellheadCoordinate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wellheads] DROP CONSTRAINT [FK_WellheadWellheadCoordinate];
GO
IF OBJECT_ID(N'[dbo].[FK_WellWellhead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wells] DROP CONSTRAINT [FK_WellWellhead];
GO
IF OBJECT_ID(N'[dbo].[FK_WellheadWellheadAssembly]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wellheads] DROP CONSTRAINT [FK_WellheadWellheadAssembly];
GO
IF OBJECT_ID(N'[dbo].[FK_WellTreatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments] DROP CONSTRAINT [FK_WellTreatment];
GO
IF OBJECT_ID(N'[dbo].[FK_WellDataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions] DROP CONSTRAINT [FK_WellDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_DataAcquisitionProcessing]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Processings] DROP CONSTRAINT [FK_DataAcquisitionProcessing];
GO
IF OBJECT_ID(N'[dbo].[FK_DataRecordTimePick]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimePicks] DROP CONSTRAINT [FK_DataRecordTimePick];
GO
IF OBJECT_ID(N'[dbo].[FK_DataRecordReflection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reflections] DROP CONSTRAINT [FK_DataRecordReflection];
GO
IF OBJECT_ID(N'[dbo].[FK_StartReflectionTimePick]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reflections] DROP CONSTRAINT [FK_StartReflectionTimePick];
GO
IF OBJECT_ID(N'[dbo].[FK_EndReflectionTimePick]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reflections] DROP CONSTRAINT [FK_EndReflectionTimePick];
GO
IF OBJECT_ID(N'[dbo].[FK_DataAcquisitionDataRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataRecords] DROP CONSTRAINT [FK_DataAcquisitionDataRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcessingUsedParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Processings] DROP CONSTRAINT [FK_ProcessingUsedParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_UsedParameterReflection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reflections] DROP CONSTRAINT [FK_UsedParameterReflection];
GO
IF OBJECT_ID(N'[dbo].[FK_UsedFilterBasisSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasisSets] DROP CONSTRAINT [FK_UsedFilterBasisSet];
GO
IF OBJECT_ID(N'[dbo].[FK_UsedParameterUsedFilter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsedFilters] DROP CONSTRAINT [FK_UsedParameterUsedFilter];
GO
IF OBJECT_ID(N'[dbo].[FK_UsedParameterParamConstraint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParamConstraints] DROP CONSTRAINT [FK_UsedParameterParamConstraint];
GO
IF OBJECT_ID(N'[dbo].[FK_ColumnColumnValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ColumnValues] DROP CONSTRAINT [FK_ColumnColumnValue];
GO
IF OBJECT_ID(N'[dbo].[FK_KGraphDataColumn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Columns] DROP CONSTRAINT [FK_KGraphDataColumn];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcessingKGraphData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KGraphDatas] DROP CONSTRAINT [FK_ProcessingKGraphData];
GO
IF OBJECT_ID(N'[dbo].[FK_ACGraphDataColumn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Columns] DROP CONSTRAINT [FK_ACGraphDataColumn];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcessingACGraphData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ACGraphDatas] DROP CONSTRAINT [FK_ProcessingACGraphData];
GO
IF OBJECT_ID(N'[dbo].[FK_InjectionDataAcquisitionInjection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Injections] DROP CONSTRAINT [FK_InjectionDataAcquisitionInjection];
GO
IF OBJECT_ID(N'[dbo].[FK_StagePerforation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perforations] DROP CONSTRAINT [FK_StagePerforation];
GO
IF OBJECT_ID(N'[dbo].[FK_PlugMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plugs] DROP CONSTRAINT [FK_PlugMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_StagePlug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plugs] DROP CONSTRAINT [FK_StagePlug];
GO
IF OBJECT_ID(N'[dbo].[FK_HFTreatmentStageFluid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fluids] DROP CONSTRAINT [FK_HFTreatmentStageFluid];
GO
IF OBJECT_ID(N'[dbo].[FK_HFTreatmentStageProppant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proppants] DROP CONSTRAINT [FK_HFTreatmentStageProppant];
GO
IF OBJECT_ID(N'[dbo].[FK_StageHFTreatmentStage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HFTreatmentStages] DROP CONSTRAINT [FK_StageHFTreatmentStage];
GO
IF OBJECT_ID(N'[dbo].[FK_HydraulicFracturingTreatmentStage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stages] DROP CONSTRAINT [FK_HydraulicFracturingTreatmentStage];
GO
IF OBJECT_ID(N'[dbo].[FK_InjectionDataAcquisition_inherits_DataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions_InjectionDataAcquisition] DROP CONSTRAINT [FK_InjectionDataAcquisition_inherits_DataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_HydraulicFracturingTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_HydraulicFracturingTreatment] DROP CONSTRAINT [FK_HydraulicFracturingTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_SteamInjectionTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_SteamInjectionTreatment] DROP CONSTRAINT [FK_SteamInjectionTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_AcidTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_AcidTreatment] DROP CONSTRAINT [FK_AcidTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_CasingRepairTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_CasingRepairTreatment] DROP CONSTRAINT [FK_CasingRepairTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_CleanOutTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_CleanOutTreatment] DROP CONSTRAINT [FK_CleanOutTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_JunkBasketTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_JunkBasketTreatment] DROP CONSTRAINT [FK_JunkBasketTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_PlugDrillOutTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_PlugDrillOutTreatment] DROP CONSTRAINT [FK_PlugDrillOutTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_PlugRecovery_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_PlugRecovery] DROP CONSTRAINT [FK_PlugRecovery_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_RefracTreatment_inherits_Treatment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treatments_RefracTreatment] DROP CONSTRAINT [FK_RefracTreatment_inherits_Treatment];
GO
IF OBJECT_ID(N'[dbo].[FK_HydraulicFracturingDataAcquisition_inherits_DataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition] DROP CONSTRAINT [FK_HydraulicFracturingDataAcquisition_inherits_DataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_OffsetWellDataAcquisition_inherits_DataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions_OffsetWellDataAcquisition] DROP CONSTRAINT [FK_OffsetWellDataAcquisition_inherits_DataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductionDataAcquisition_inherits_DataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions_ProductionDataAcquisition] DROP CONSTRAINT [FK_ProductionDataAcquisition_inherits_DataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_IntegrityDataAcquisition_inherits_DataAcquisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataAcquisitions_IntegrityDataAcquisition] DROP CONSTRAINT [FK_IntegrityDataAcquisition_inherits_DataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_inherits_Note]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes_Event] DROP CONSTRAINT [FK_Event_inherits_Note];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SeismosClients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeismosClients];
GO
IF OBJECT_ID(N'[dbo].[SeismosProjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeismosProjects];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Wells]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wells];
GO
IF OBJECT_ID(N'[dbo].[DeviationSurveys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviationSurveys];
GO
IF OBJECT_ID(N'[dbo].[MDs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MDs];
GO
IF OBJECT_ID(N'[dbo].[TVDs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TVDs];
GO
IF OBJECT_ID(N'[dbo].[Inclinations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inclinations];
GO
IF OBJECT_ID(N'[dbo].[Azimuths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Azimuths];
GO
IF OBJECT_ID(N'[dbo].[Eastings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eastings];
GO
IF OBJECT_ID(N'[dbo].[Northings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Northings];
GO
IF OBJECT_ID(N'[dbo].[WellBores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WellBores];
GO
IF OBJECT_ID(N'[dbo].[Cylinders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cylinders];
GO
IF OBJECT_ID(N'[dbo].[Materials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materials];
GO
IF OBJECT_ID(N'[dbo].[Wellheads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wellheads];
GO
IF OBJECT_ID(N'[dbo].[WellheadCoordinates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WellheadCoordinates];
GO
IF OBJECT_ID(N'[dbo].[WellheadAssemblies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WellheadAssemblies];
GO
IF OBJECT_ID(N'[dbo].[WellheadComponents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WellheadComponents];
GO
IF OBJECT_ID(N'[dbo].[Treatments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions];
GO
IF OBJECT_ID(N'[dbo].[Processings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Processings];
GO
IF OBJECT_ID(N'[dbo].[DataRecords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataRecords];
GO
IF OBJECT_ID(N'[dbo].[TimePicks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimePicks];
GO
IF OBJECT_ID(N'[dbo].[Reflections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reflections];
GO
IF OBJECT_ID(N'[dbo].[UsedParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsedParameters];
GO
IF OBJECT_ID(N'[dbo].[UsedFilters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsedFilters];
GO
IF OBJECT_ID(N'[dbo].[BasisSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BasisSets];
GO
IF OBJECT_ID(N'[dbo].[ParamConstraints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParamConstraints];
GO
IF OBJECT_ID(N'[dbo].[Columns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Columns];
GO
IF OBJECT_ID(N'[dbo].[ColumnValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColumnValues];
GO
IF OBJECT_ID(N'[dbo].[KGraphDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KGraphDatas];
GO
IF OBJECT_ID(N'[dbo].[ACGraphDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ACGraphDatas];
GO
IF OBJECT_ID(N'[dbo].[Injections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Injections];
GO
IF OBJECT_ID(N'[dbo].[Stages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stages];
GO
IF OBJECT_ID(N'[dbo].[Perforations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perforations];
GO
IF OBJECT_ID(N'[dbo].[Plugs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Plugs];
GO
IF OBJECT_ID(N'[dbo].[HFTreatmentStages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HFTreatmentStages];
GO
IF OBJECT_ID(N'[dbo].[Fluids]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fluids];
GO
IF OBJECT_ID(N'[dbo].[Proppants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proppants];
GO
IF OBJECT_ID(N'[dbo].[CasingChartLookups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CasingChartLookups];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions_InjectionDataAcquisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions_InjectionDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[Treatments_HydraulicFracturingTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_HydraulicFracturingTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_SteamInjectionTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_SteamInjectionTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_AcidTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_AcidTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_CasingRepairTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_CasingRepairTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_CleanOutTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_CleanOutTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_JunkBasketTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_JunkBasketTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_PlugDrillOutTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_PlugDrillOutTreatment];
GO
IF OBJECT_ID(N'[dbo].[Treatments_PlugRecovery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_PlugRecovery];
GO
IF OBJECT_ID(N'[dbo].[Treatments_RefracTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treatments_RefracTreatment];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions_OffsetWellDataAcquisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions_OffsetWellDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions_ProductionDataAcquisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions_ProductionDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[DataAcquisitions_IntegrityDataAcquisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataAcquisitions_IntegrityDataAcquisition];
GO
IF OBJECT_ID(N'[dbo].[Notes_Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes_Event];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SeismosClients'
CREATE TABLE [dbo].[SeismosClients] (
    [Id] uniqueidentifier  NOT NULL,
    [Contact] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [ClientName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SeismosProjects'
CREATE TABLE [dbo].[SeismosProjects] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Field] nvarchar(max)  NULL,
    [Pad] nvarchar(max)  NULL,
    [JobNum] nvarchar(max)  NOT NULL,
    [AFENum] nvarchar(max)  NULL,
    [Formation] nvarchar(max)  NULL,
    [County] nvarchar(max)  NULL,
    [State] nvarchar(max)  NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [LastModified] datetime  NOT NULL,
    [LastModifiedBy] nvarchar(max)  NULL,
    [SeismosClientId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [Id] uniqueidentifier  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [SourceId] uniqueidentifier  NULL,
    [SourceDescription] nvarchar(max)  NULL,
    [ProjectId] nvarchar(max)  NOT NULL,
    [SeismosProjectId] uniqueidentifier  NULL
);
GO

-- Creating table 'Wells'
CREATE TABLE [dbo].[Wells] (
    [Id] uniqueidentifier  NOT NULL,
    [WellName] nvarchar(max)  NOT NULL,
    [WellGeometryType] smallint  NOT NULL,
    [SeismosProject_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DeviationSurveys'
CREATE TABLE [dbo].[DeviationSurveys] (
    [Id] uniqueidentifier  NOT NULL,
    [WellId] nvarchar(max)  NOT NULL,
    [Well_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'MDs'
CREATE TABLE [dbo].[MDs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TVDs'
CREATE TABLE [dbo].[TVDs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Inclinations'
CREATE TABLE [dbo].[Inclinations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Azimuths'
CREATE TABLE [dbo].[Azimuths] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Eastings'
CREATE TABLE [dbo].[Eastings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Northings'
CREATE TABLE [dbo].[Northings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [DeviationSurveyId] uniqueidentifier  NOT NULL,
    [DeviationSurvey_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WellBores'
CREATE TABLE [dbo].[WellBores] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [SurfaceVolume] float  NOT NULL,
    [TotalVolume] float  NOT NULL,
    [Well_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Cylinders'
CREATE TABLE [dbo].[Cylinders] (
    [Id] uniqueidentifier  NOT NULL,
    [MeasuredDepth] float  NOT NULL,
    [InnerDiameter] float  NOT NULL,
    [OuterDiameter] float  NOT NULL,
    [TopOfLiner] float  NOT NULL,
    [InnerInterfaceState] smallint  NOT NULL,
    [OuterInterfaceState] smallint  NOT NULL,
    [WellBoreId] uniqueidentifier  NOT NULL,
    [Weight] float  NOT NULL,
    [Grade] nvarchar(max)  NOT NULL,
    [CasingOrderType] smallint  NOT NULL,
    [CalculatedVolume] float  NOT NULL
);
GO

-- Creating table 'Materials'
CREATE TABLE [dbo].[Materials] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Density] float  NOT NULL,
    [BulkModulus] float  NOT NULL,
    [WellheadComponent_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Wellheads'
CREATE TABLE [dbo].[Wellheads] (
    [Id] uniqueidentifier  NOT NULL,
    [WellheadCoordinate_Id] uniqueidentifier  NOT NULL,
    [Well_Id] uniqueidentifier  NOT NULL,
    [WellheadAssembly_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WellheadCoordinates'
CREATE TABLE [dbo].[WellheadCoordinates] (
    [Id] uniqueidentifier  NOT NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL,
    [KB] float  NOT NULL,
    [CoordinateSystem] nvarchar(max)  NOT NULL,
    [Lat] nvarchar(max)  NOT NULL,
    [Long] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WellheadAssemblies'
CREATE TABLE [dbo].[WellheadAssemblies] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WellheadComponents'
CREATE TABLE [dbo].[WellheadComponents] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [InternalDiameter] float  NOT NULL,
    [OuterDiameter] float  NOT NULL,
    [Length] float  NOT NULL,
    [WellheadAssemblyId] uniqueidentifier  NULL,
    [Type] smallint  NOT NULL
);
GO

-- Creating table 'Treatments'
CREATE TABLE [dbo].[Treatments] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] smallint  NOT NULL,
    [WellId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataAcquisitions'
CREATE TABLE [dbo].[DataAcquisitions] (
    [Id] uniqueidentifier  NOT NULL,
    [WellId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Processings'
CREATE TABLE [dbo].[Processings] (
    [Id] uniqueidentifier  NOT NULL,
    [DataAcquisitionId] uniqueidentifier  NULL,
    [Type] smallint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProcessingStartTime] datetime  NOT NULL,
    [LastModified] datetime  NOT NULL,
    [NearFieldConductivity] float  NOT NULL,
    [C1] float  NOT NULL,
    [C2] float  NOT NULL,
    [C3] float  NOT NULL,
    [C4] float  NOT NULL,
    [Q1] float  NOT NULL,
    [Q2] float  NOT NULL,
    [Q3] float  NOT NULL,
    [Q4] float  NOT NULL,
    [FarFieldConductivity] float  NOT NULL,
    [TimeOfMeasurement] int  NOT NULL,
    [EffectivePropperLength] float  NOT NULL,
    [Residual] float  NOT NULL,
    [Final] bit  NOT NULL,
    [UsedParameter_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataRecords'
CREATE TABLE [dbo].[DataRecords] (
    [Id] bigint  NOT NULL,
    [Filename] nvarchar(max)  NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Seconds] float  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [SampleRate] bigint  NOT NULL,
    [DataAcquisitionId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TimePicks'
CREATE TABLE [dbo].[TimePicks] (
    [Id] bigint  NOT NULL,
    [Type] smallint  NOT NULL,
    [SampleNumber] bigint  NOT NULL,
    [DataRecordId] bigint  NOT NULL
);
GO

-- Creating table 'Reflections'
CREATE TABLE [dbo].[Reflections] (
    [Id] bigint  NOT NULL,
    [Type] smallint  NOT NULL,
    [Weight] float  NOT NULL,
    [DataRecordId] bigint  NULL,
    [StartTimePick_Id] bigint  NOT NULL,
    [EndTimePick_Id] bigint  NOT NULL,
    [UsedParameter_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'UsedParameters'
CREATE TABLE [dbo].[UsedParameters] (
    [Id] uniqueidentifier  NOT NULL,
    [Viscosity] float  NOT NULL,
    [BulkModulus] float  NOT NULL,
    [FluidCompressibility] float  NOT NULL,
    [NumberOfFractures] int  NOT NULL,
    [FractureWidth] float  NOT NULL,
    [Permeability] float  NOT NULL
);
GO

-- Creating table 'UsedFilters'
CREATE TABLE [dbo].[UsedFilters] (
    [Id] uniqueidentifier  NOT NULL,
    [Type] smallint  NOT NULL,
    [LowerFrequency] float  NOT NULL,
    [UpperFrequency] float  NOT NULL,
    [TaperFunction] nvarchar(max)  NOT NULL,
    [UsedParameterId] uniqueidentifier  NULL
);
GO

-- Creating table 'BasisSets'
CREATE TABLE [dbo].[BasisSets] (
    [Id] uniqueidentifier  NOT NULL,
    [BasisFunction] nvarchar(max)  NOT NULL,
    [UsedFilterId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ParamConstraints'
CREATE TABLE [dbo].[ParamConstraints] (
    [Id] uniqueidentifier  NOT NULL,
    [MinimumC1] float  NOT NULL,
    [MinimumC2] float  NOT NULL,
    [MinimumC3] float  NOT NULL,
    [MinimumC4] float  NOT NULL,
    [MinimumQ1] float  NOT NULL,
    [MinimumQ2] float  NOT NULL,
    [MinimumQ3] float  NOT NULL,
    [MinimumQ4] float  NOT NULL,
    [MaximumC1] float  NOT NULL,
    [MaximumC2] float  NOT NULL,
    [MaximumC3] float  NOT NULL,
    [MaximumC4] float  NOT NULL,
    [MaximumQ1] float  NOT NULL,
    [MaximumQ2] float  NOT NULL,
    [MaximumQ3] float  NOT NULL,
    [MaximumQ4] float  NOT NULL,
    [UsedParameterId] uniqueidentifier  NULL
);
GO

-- Creating table 'Columns'
CREATE TABLE [dbo].[Columns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [KGraphDataId] uniqueidentifier  NOT NULL,
    [ACGraphDataId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ColumnValues'
CREATE TABLE [dbo].[ColumnValues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [ColumnId] int  NULL
);
GO

-- Creating table 'KGraphDatas'
CREATE TABLE [dbo].[KGraphDatas] (
    [Id] uniqueidentifier  NOT NULL,
    [Processing_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ACGraphDatas'
CREATE TABLE [dbo].[ACGraphDatas] (
    [Id] uniqueidentifier  NOT NULL,
    [Processing_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Injections'
CREATE TABLE [dbo].[Injections] (
    [Id] uniqueidentifier  NOT NULL,
    [Type] smallint  NOT NULL,
    [Volume] float  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [StopTime] datetime  NOT NULL,
    [InjectionDataAcquisitionId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Stages'
CREATE TABLE [dbo].[Stages] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] int  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [StopTime] datetime  NOT NULL,
    [HydraulicFracturingTreatmentId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Perforations'
CREATE TABLE [dbo].[Perforations] (
    [Id] uniqueidentifier  NOT NULL,
    [MD] float  NOT NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL,
    [Depth] float  NOT NULL,
    [ShapeType] smallint  NOT NULL,
    [StageId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Plugs'
CREATE TABLE [dbo].[Plugs] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [OuterDiameter] float  NOT NULL,
    [OpeningDiameter] float  NOT NULL,
    [TopMD] float  NOT NULL,
    [Length] float  NOT NULL,
    [Material_Id] uniqueidentifier  NOT NULL,
    [Stage_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'HFTreatmentStages'
CREATE TABLE [dbo].[HFTreatmentStages] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StageNumber] int  NOT NULL,
    [TotalVolume] float  NOT NULL,
    [StageId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Fluids'
CREATE TABLE [dbo].[Fluids] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] smallint  NOT NULL,
    [Density] float  NOT NULL,
    [BulkModulus] float  NOT NULL,
    [Volume] float  NOT NULL,
    [Viscosity] float  NOT NULL,
    [HFTreatmentStageId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Proppants'
CREATE TABLE [dbo].[Proppants] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] smallint  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [Volume] float  NOT NULL,
    [ConcentrationInPPG] float  NOT NULL,
    [HFTreatmentStageId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CasingChartLookups'
CREATE TABLE [dbo].[CasingChartLookups] (
    [Key] int  NOT NULL,
    [OuterDiameter] float  NULL,
    [Weight] float  NULL,
    [Grade] varchar(50)  NULL,
    [Collapse] float  NULL,
    [InternalMinYield] float  NULL,
    [JointStrengthSTC] float  NULL,
    [JointStrengthLTC] float  NULL,
    [JointStrengthBTC] float  NULL,
    [BodyYield] float  NULL,
    [Wall] float  NULL,
    [InnerDiameter] float  NULL,
    [DriftDiameterAPI] float  NULL,
    [DriftDiameterSPDR] float  NULL,
    [MaximumSettingDepthSTC] float  NULL
);
GO

-- Creating table 'DataAcquisitions_InjectionDataAcquisition'
CREATE TABLE [dbo].[DataAcquisitions_InjectionDataAcquisition] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_HydraulicFracturingTreatment'
CREATE TABLE [dbo].[Treatments_HydraulicFracturingTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_SteamInjectionTreatment'
CREATE TABLE [dbo].[Treatments_SteamInjectionTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_AcidTreatment'
CREATE TABLE [dbo].[Treatments_AcidTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_CasingRepairTreatment'
CREATE TABLE [dbo].[Treatments_CasingRepairTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_CleanOutTreatment'
CREATE TABLE [dbo].[Treatments_CleanOutTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_JunkBasketTreatment'
CREATE TABLE [dbo].[Treatments_JunkBasketTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_PlugDrillOutTreatment'
CREATE TABLE [dbo].[Treatments_PlugDrillOutTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_PlugRecovery'
CREATE TABLE [dbo].[Treatments_PlugRecovery] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Treatments_RefracTreatment'
CREATE TABLE [dbo].[Treatments_RefracTreatment] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataAcquisitions_HydraulicFracturingDataAcquisition'
CREATE TABLE [dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataAcquisitions_OffsetWellDataAcquisition'
CREATE TABLE [dbo].[DataAcquisitions_OffsetWellDataAcquisition] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataAcquisitions_ProductionDataAcquisition'
CREATE TABLE [dbo].[DataAcquisitions_ProductionDataAcquisition] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'DataAcquisitions_IntegrityDataAcquisition'
CREATE TABLE [dbo].[DataAcquisitions_IntegrityDataAcquisition] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Notes_Event'
CREATE TABLE [dbo].[Notes_Event] (
    [EventType] smallint  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SeismosClients'
ALTER TABLE [dbo].[SeismosClients]
ADD CONSTRAINT [PK_SeismosClients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SeismosProjects'
ALTER TABLE [dbo].[SeismosProjects]
ADD CONSTRAINT [PK_SeismosProjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Wells'
ALTER TABLE [dbo].[Wells]
ADD CONSTRAINT [PK_Wells]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeviationSurveys'
ALTER TABLE [dbo].[DeviationSurveys]
ADD CONSTRAINT [PK_DeviationSurveys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MDs'
ALTER TABLE [dbo].[MDs]
ADD CONSTRAINT [PK_MDs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TVDs'
ALTER TABLE [dbo].[TVDs]
ADD CONSTRAINT [PK_TVDs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Inclinations'
ALTER TABLE [dbo].[Inclinations]
ADD CONSTRAINT [PK_Inclinations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Azimuths'
ALTER TABLE [dbo].[Azimuths]
ADD CONSTRAINT [PK_Azimuths]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Eastings'
ALTER TABLE [dbo].[Eastings]
ADD CONSTRAINT [PK_Eastings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Northings'
ALTER TABLE [dbo].[Northings]
ADD CONSTRAINT [PK_Northings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WellBores'
ALTER TABLE [dbo].[WellBores]
ADD CONSTRAINT [PK_WellBores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cylinders'
ALTER TABLE [dbo].[Cylinders]
ADD CONSTRAINT [PK_Cylinders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [PK_Materials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Wellheads'
ALTER TABLE [dbo].[Wellheads]
ADD CONSTRAINT [PK_Wellheads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WellheadCoordinates'
ALTER TABLE [dbo].[WellheadCoordinates]
ADD CONSTRAINT [PK_WellheadCoordinates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WellheadAssemblies'
ALTER TABLE [dbo].[WellheadAssemblies]
ADD CONSTRAINT [PK_WellheadAssemblies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WellheadComponents'
ALTER TABLE [dbo].[WellheadComponents]
ADD CONSTRAINT [PK_WellheadComponents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [PK_Treatments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions'
ALTER TABLE [dbo].[DataAcquisitions]
ADD CONSTRAINT [PK_DataAcquisitions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Processings'
ALTER TABLE [dbo].[Processings]
ADD CONSTRAINT [PK_Processings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataRecords'
ALTER TABLE [dbo].[DataRecords]
ADD CONSTRAINT [PK_DataRecords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimePicks'
ALTER TABLE [dbo].[TimePicks]
ADD CONSTRAINT [PK_TimePicks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reflections'
ALTER TABLE [dbo].[Reflections]
ADD CONSTRAINT [PK_Reflections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsedParameters'
ALTER TABLE [dbo].[UsedParameters]
ADD CONSTRAINT [PK_UsedParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsedFilters'
ALTER TABLE [dbo].[UsedFilters]
ADD CONSTRAINT [PK_UsedFilters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BasisSets'
ALTER TABLE [dbo].[BasisSets]
ADD CONSTRAINT [PK_BasisSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParamConstraints'
ALTER TABLE [dbo].[ParamConstraints]
ADD CONSTRAINT [PK_ParamConstraints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Columns'
ALTER TABLE [dbo].[Columns]
ADD CONSTRAINT [PK_Columns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColumnValues'
ALTER TABLE [dbo].[ColumnValues]
ADD CONSTRAINT [PK_ColumnValues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KGraphDatas'
ALTER TABLE [dbo].[KGraphDatas]
ADD CONSTRAINT [PK_KGraphDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ACGraphDatas'
ALTER TABLE [dbo].[ACGraphDatas]
ADD CONSTRAINT [PK_ACGraphDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Injections'
ALTER TABLE [dbo].[Injections]
ADD CONSTRAINT [PK_Injections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [PK_Stages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perforations'
ALTER TABLE [dbo].[Perforations]
ADD CONSTRAINT [PK_Perforations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Plugs'
ALTER TABLE [dbo].[Plugs]
ADD CONSTRAINT [PK_Plugs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HFTreatmentStages'
ALTER TABLE [dbo].[HFTreatmentStages]
ADD CONSTRAINT [PK_HFTreatmentStages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fluids'
ALTER TABLE [dbo].[Fluids]
ADD CONSTRAINT [PK_Fluids]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proppants'
ALTER TABLE [dbo].[Proppants]
ADD CONSTRAINT [PK_Proppants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Key] in table 'CasingChartLookups'
ALTER TABLE [dbo].[CasingChartLookups]
ADD CONSTRAINT [PK_CasingChartLookups]
    PRIMARY KEY CLUSTERED ([Key] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions_InjectionDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_InjectionDataAcquisition]
ADD CONSTRAINT [PK_DataAcquisitions_InjectionDataAcquisition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_HydraulicFracturingTreatment'
ALTER TABLE [dbo].[Treatments_HydraulicFracturingTreatment]
ADD CONSTRAINT [PK_Treatments_HydraulicFracturingTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_SteamInjectionTreatment'
ALTER TABLE [dbo].[Treatments_SteamInjectionTreatment]
ADD CONSTRAINT [PK_Treatments_SteamInjectionTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_AcidTreatment'
ALTER TABLE [dbo].[Treatments_AcidTreatment]
ADD CONSTRAINT [PK_Treatments_AcidTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_CasingRepairTreatment'
ALTER TABLE [dbo].[Treatments_CasingRepairTreatment]
ADD CONSTRAINT [PK_Treatments_CasingRepairTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_CleanOutTreatment'
ALTER TABLE [dbo].[Treatments_CleanOutTreatment]
ADD CONSTRAINT [PK_Treatments_CleanOutTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_JunkBasketTreatment'
ALTER TABLE [dbo].[Treatments_JunkBasketTreatment]
ADD CONSTRAINT [PK_Treatments_JunkBasketTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_PlugDrillOutTreatment'
ALTER TABLE [dbo].[Treatments_PlugDrillOutTreatment]
ADD CONSTRAINT [PK_Treatments_PlugDrillOutTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_PlugRecovery'
ALTER TABLE [dbo].[Treatments_PlugRecovery]
ADD CONSTRAINT [PK_Treatments_PlugRecovery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Treatments_RefracTreatment'
ALTER TABLE [dbo].[Treatments_RefracTreatment]
ADD CONSTRAINT [PK_Treatments_RefracTreatment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions_HydraulicFracturingDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition]
ADD CONSTRAINT [PK_DataAcquisitions_HydraulicFracturingDataAcquisition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions_OffsetWellDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_OffsetWellDataAcquisition]
ADD CONSTRAINT [PK_DataAcquisitions_OffsetWellDataAcquisition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions_ProductionDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_ProductionDataAcquisition]
ADD CONSTRAINT [PK_DataAcquisitions_ProductionDataAcquisition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataAcquisitions_IntegrityDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_IntegrityDataAcquisition]
ADD CONSTRAINT [PK_DataAcquisitions_IntegrityDataAcquisition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notes_Event'
ALTER TABLE [dbo].[Notes_Event]
ADD CONSTRAINT [PK_Notes_Event]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SeismosProject_Id] in table 'Wells'
ALTER TABLE [dbo].[Wells]
ADD CONSTRAINT [FK_SeismosProjectsWells]
    FOREIGN KEY ([SeismosProject_Id])
    REFERENCES [dbo].[SeismosProjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeismosProjectsWells'
CREATE INDEX [IX_FK_SeismosProjectsWells]
ON [dbo].[Wells]
    ([SeismosProject_Id]);
GO

-- Creating foreign key on [Well_Id] in table 'DeviationSurveys'
ALTER TABLE [dbo].[DeviationSurveys]
ADD CONSTRAINT [FK_WellsDeviationSurveys]
    FOREIGN KEY ([Well_Id])
    REFERENCES [dbo].[Wells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellsDeviationSurveys'
CREATE INDEX [IX_FK_WellsDeviationSurveys]
ON [dbo].[DeviationSurveys]
    ([Well_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'Inclinations'
ALTER TABLE [dbo].[Inclinations]
ADD CONSTRAINT [FK_DeviationSurveyInclination]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyInclination'
CREATE INDEX [IX_FK_DeviationSurveyInclination]
ON [dbo].[Inclinations]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'Eastings'
ALTER TABLE [dbo].[Eastings]
ADD CONSTRAINT [FK_DeviationSurveyEasting]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyEasting'
CREATE INDEX [IX_FK_DeviationSurveyEasting]
ON [dbo].[Eastings]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'Northings'
ALTER TABLE [dbo].[Northings]
ADD CONSTRAINT [FK_DeviationSurveyNorthing]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyNorthing'
CREATE INDEX [IX_FK_DeviationSurveyNorthing]
ON [dbo].[Northings]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'Azimuths'
ALTER TABLE [dbo].[Azimuths]
ADD CONSTRAINT [FK_DeviationSurveyAzimuth]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyAzimuth'
CREATE INDEX [IX_FK_DeviationSurveyAzimuth]
ON [dbo].[Azimuths]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'TVDs'
ALTER TABLE [dbo].[TVDs]
ADD CONSTRAINT [FK_DeviationSurveyTVD]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyTVD'
CREATE INDEX [IX_FK_DeviationSurveyTVD]
ON [dbo].[TVDs]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [DeviationSurvey_Id] in table 'MDs'
ALTER TABLE [dbo].[MDs]
ADD CONSTRAINT [FK_DeviationSurveyMD]
    FOREIGN KEY ([DeviationSurvey_Id])
    REFERENCES [dbo].[DeviationSurveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviationSurveyMD'
CREATE INDEX [IX_FK_DeviationSurveyMD]
ON [dbo].[MDs]
    ([DeviationSurvey_Id]);
GO

-- Creating foreign key on [WellBoreId] in table 'Cylinders'
ALTER TABLE [dbo].[Cylinders]
ADD CONSTRAINT [FK_WellBoreCylinder]
    FOREIGN KEY ([WellBoreId])
    REFERENCES [dbo].[WellBores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellBoreCylinder'
CREATE INDEX [IX_FK_WellBoreCylinder]
ON [dbo].[Cylinders]
    ([WellBoreId]);
GO

-- Creating foreign key on [Well_Id] in table 'WellBores'
ALTER TABLE [dbo].[WellBores]
ADD CONSTRAINT [FK_WellWellBore]
    FOREIGN KEY ([Well_Id])
    REFERENCES [dbo].[Wells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellWellBore'
CREATE INDEX [IX_FK_WellWellBore]
ON [dbo].[WellBores]
    ([Well_Id]);
GO

-- Creating foreign key on [WellheadComponent_Id] in table 'Materials'
ALTER TABLE [dbo].[Materials]
ADD CONSTRAINT [FK_WellheadComponentMaterial]
    FOREIGN KEY ([WellheadComponent_Id])
    REFERENCES [dbo].[WellheadComponents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellheadComponentMaterial'
CREATE INDEX [IX_FK_WellheadComponentMaterial]
ON [dbo].[Materials]
    ([WellheadComponent_Id]);
GO

-- Creating foreign key on [SeismosClientId] in table 'SeismosProjects'
ALTER TABLE [dbo].[SeismosProjects]
ADD CONSTRAINT [FK_SeismosClientSeismosProject]
    FOREIGN KEY ([SeismosClientId])
    REFERENCES [dbo].[SeismosClients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeismosClientSeismosProject'
CREATE INDEX [IX_FK_SeismosClientSeismosProject]
ON [dbo].[SeismosProjects]
    ([SeismosClientId]);
GO

-- Creating foreign key on [SeismosProjectId] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_SeismosProjectNote]
    FOREIGN KEY ([SeismosProjectId])
    REFERENCES [dbo].[SeismosProjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeismosProjectNote'
CREATE INDEX [IX_FK_SeismosProjectNote]
ON [dbo].[Notes]
    ([SeismosProjectId]);
GO

-- Creating foreign key on [WellheadAssemblyId] in table 'WellheadComponents'
ALTER TABLE [dbo].[WellheadComponents]
ADD CONSTRAINT [FK_WellheadAssemblyWellheadComponent]
    FOREIGN KEY ([WellheadAssemblyId])
    REFERENCES [dbo].[WellheadAssemblies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellheadAssemblyWellheadComponent'
CREATE INDEX [IX_FK_WellheadAssemblyWellheadComponent]
ON [dbo].[WellheadComponents]
    ([WellheadAssemblyId]);
GO

-- Creating foreign key on [WellheadCoordinate_Id] in table 'Wellheads'
ALTER TABLE [dbo].[Wellheads]
ADD CONSTRAINT [FK_WellheadWellheadCoordinate]
    FOREIGN KEY ([WellheadCoordinate_Id])
    REFERENCES [dbo].[WellheadCoordinates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellheadWellheadCoordinate'
CREATE INDEX [IX_FK_WellheadWellheadCoordinate]
ON [dbo].[Wellheads]
    ([WellheadCoordinate_Id]);
GO

-- Creating foreign key on [Well_Id] in table 'Wellheads'
ALTER TABLE [dbo].[Wellheads]
ADD CONSTRAINT [FK_WellWellhead]
    FOREIGN KEY ([Well_Id])
    REFERENCES [dbo].[Wells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellWellhead'
CREATE INDEX [IX_FK_WellWellhead]
ON [dbo].[Wellheads]
    ([Well_Id]);
GO

-- Creating foreign key on [WellheadAssembly_Id] in table 'Wellheads'
ALTER TABLE [dbo].[Wellheads]
ADD CONSTRAINT [FK_WellheadWellheadAssembly]
    FOREIGN KEY ([WellheadAssembly_Id])
    REFERENCES [dbo].[WellheadAssemblies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellheadWellheadAssembly'
CREATE INDEX [IX_FK_WellheadWellheadAssembly]
ON [dbo].[Wellheads]
    ([WellheadAssembly_Id]);
GO

-- Creating foreign key on [WellId] in table 'Treatments'
ALTER TABLE [dbo].[Treatments]
ADD CONSTRAINT [FK_WellTreatment]
    FOREIGN KEY ([WellId])
    REFERENCES [dbo].[Wells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellTreatment'
CREATE INDEX [IX_FK_WellTreatment]
ON [dbo].[Treatments]
    ([WellId]);
GO

-- Creating foreign key on [WellId] in table 'DataAcquisitions'
ALTER TABLE [dbo].[DataAcquisitions]
ADD CONSTRAINT [FK_WellDataAcquisition]
    FOREIGN KEY ([WellId])
    REFERENCES [dbo].[Wells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WellDataAcquisition'
CREATE INDEX [IX_FK_WellDataAcquisition]
ON [dbo].[DataAcquisitions]
    ([WellId]);
GO

-- Creating foreign key on [DataAcquisitionId] in table 'Processings'
ALTER TABLE [dbo].[Processings]
ADD CONSTRAINT [FK_DataAcquisitionProcessing]
    FOREIGN KEY ([DataAcquisitionId])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataAcquisitionProcessing'
CREATE INDEX [IX_FK_DataAcquisitionProcessing]
ON [dbo].[Processings]
    ([DataAcquisitionId]);
GO

-- Creating foreign key on [DataRecordId] in table 'TimePicks'
ALTER TABLE [dbo].[TimePicks]
ADD CONSTRAINT [FK_DataRecordTimePick]
    FOREIGN KEY ([DataRecordId])
    REFERENCES [dbo].[DataRecords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataRecordTimePick'
CREATE INDEX [IX_FK_DataRecordTimePick]
ON [dbo].[TimePicks]
    ([DataRecordId]);
GO

-- Creating foreign key on [DataRecordId] in table 'Reflections'
ALTER TABLE [dbo].[Reflections]
ADD CONSTRAINT [FK_DataRecordReflection]
    FOREIGN KEY ([DataRecordId])
    REFERENCES [dbo].[DataRecords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataRecordReflection'
CREATE INDEX [IX_FK_DataRecordReflection]
ON [dbo].[Reflections]
    ([DataRecordId]);
GO

-- Creating foreign key on [StartTimePick_Id] in table 'Reflections'
ALTER TABLE [dbo].[Reflections]
ADD CONSTRAINT [FK_StartReflectionTimePick]
    FOREIGN KEY ([StartTimePick_Id])
    REFERENCES [dbo].[TimePicks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StartReflectionTimePick'
CREATE INDEX [IX_FK_StartReflectionTimePick]
ON [dbo].[Reflections]
    ([StartTimePick_Id]);
GO

-- Creating foreign key on [EndTimePick_Id] in table 'Reflections'
ALTER TABLE [dbo].[Reflections]
ADD CONSTRAINT [FK_EndReflectionTimePick]
    FOREIGN KEY ([EndTimePick_Id])
    REFERENCES [dbo].[TimePicks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndReflectionTimePick'
CREATE INDEX [IX_FK_EndReflectionTimePick]
ON [dbo].[Reflections]
    ([EndTimePick_Id]);
GO

-- Creating foreign key on [DataAcquisitionId] in table 'DataRecords'
ALTER TABLE [dbo].[DataRecords]
ADD CONSTRAINT [FK_DataAcquisitionDataRecord]
    FOREIGN KEY ([DataAcquisitionId])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataAcquisitionDataRecord'
CREATE INDEX [IX_FK_DataAcquisitionDataRecord]
ON [dbo].[DataRecords]
    ([DataAcquisitionId]);
GO

-- Creating foreign key on [UsedParameter_Id] in table 'Processings'
ALTER TABLE [dbo].[Processings]
ADD CONSTRAINT [FK_ProcessingUsedParameter]
    FOREIGN KEY ([UsedParameter_Id])
    REFERENCES [dbo].[UsedParameters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcessingUsedParameter'
CREATE INDEX [IX_FK_ProcessingUsedParameter]
ON [dbo].[Processings]
    ([UsedParameter_Id]);
GO

-- Creating foreign key on [UsedParameter_Id] in table 'Reflections'
ALTER TABLE [dbo].[Reflections]
ADD CONSTRAINT [FK_UsedParameterReflection]
    FOREIGN KEY ([UsedParameter_Id])
    REFERENCES [dbo].[UsedParameters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsedParameterReflection'
CREATE INDEX [IX_FK_UsedParameterReflection]
ON [dbo].[Reflections]
    ([UsedParameter_Id]);
GO

-- Creating foreign key on [UsedFilterId] in table 'BasisSets'
ALTER TABLE [dbo].[BasisSets]
ADD CONSTRAINT [FK_UsedFilterBasisSet]
    FOREIGN KEY ([UsedFilterId])
    REFERENCES [dbo].[UsedFilters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsedFilterBasisSet'
CREATE INDEX [IX_FK_UsedFilterBasisSet]
ON [dbo].[BasisSets]
    ([UsedFilterId]);
GO

-- Creating foreign key on [UsedParameterId] in table 'UsedFilters'
ALTER TABLE [dbo].[UsedFilters]
ADD CONSTRAINT [FK_UsedParameterUsedFilter]
    FOREIGN KEY ([UsedParameterId])
    REFERENCES [dbo].[UsedParameters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsedParameterUsedFilter'
CREATE INDEX [IX_FK_UsedParameterUsedFilter]
ON [dbo].[UsedFilters]
    ([UsedParameterId]);
GO

-- Creating foreign key on [UsedParameterId] in table 'ParamConstraints'
ALTER TABLE [dbo].[ParamConstraints]
ADD CONSTRAINT [FK_UsedParameterParamConstraint]
    FOREIGN KEY ([UsedParameterId])
    REFERENCES [dbo].[UsedParameters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsedParameterParamConstraint'
CREATE INDEX [IX_FK_UsedParameterParamConstraint]
ON [dbo].[ParamConstraints]
    ([UsedParameterId]);
GO

-- Creating foreign key on [ColumnId] in table 'ColumnValues'
ALTER TABLE [dbo].[ColumnValues]
ADD CONSTRAINT [FK_ColumnColumnValue]
    FOREIGN KEY ([ColumnId])
    REFERENCES [dbo].[Columns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColumnColumnValue'
CREATE INDEX [IX_FK_ColumnColumnValue]
ON [dbo].[ColumnValues]
    ([ColumnId]);
GO

-- Creating foreign key on [KGraphDataId] in table 'Columns'
ALTER TABLE [dbo].[Columns]
ADD CONSTRAINT [FK_KGraphDataColumn]
    FOREIGN KEY ([KGraphDataId])
    REFERENCES [dbo].[KGraphDatas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KGraphDataColumn'
CREATE INDEX [IX_FK_KGraphDataColumn]
ON [dbo].[Columns]
    ([KGraphDataId]);
GO

-- Creating foreign key on [Processing_Id] in table 'KGraphDatas'
ALTER TABLE [dbo].[KGraphDatas]
ADD CONSTRAINT [FK_ProcessingKGraphData]
    FOREIGN KEY ([Processing_Id])
    REFERENCES [dbo].[Processings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcessingKGraphData'
CREATE INDEX [IX_FK_ProcessingKGraphData]
ON [dbo].[KGraphDatas]
    ([Processing_Id]);
GO

-- Creating foreign key on [ACGraphDataId] in table 'Columns'
ALTER TABLE [dbo].[Columns]
ADD CONSTRAINT [FK_ACGraphDataColumn]
    FOREIGN KEY ([ACGraphDataId])
    REFERENCES [dbo].[ACGraphDatas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ACGraphDataColumn'
CREATE INDEX [IX_FK_ACGraphDataColumn]
ON [dbo].[Columns]
    ([ACGraphDataId]);
GO

-- Creating foreign key on [Processing_Id] in table 'ACGraphDatas'
ALTER TABLE [dbo].[ACGraphDatas]
ADD CONSTRAINT [FK_ProcessingACGraphData]
    FOREIGN KEY ([Processing_Id])
    REFERENCES [dbo].[Processings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcessingACGraphData'
CREATE INDEX [IX_FK_ProcessingACGraphData]
ON [dbo].[ACGraphDatas]
    ([Processing_Id]);
GO

-- Creating foreign key on [InjectionDataAcquisitionId] in table 'Injections'
ALTER TABLE [dbo].[Injections]
ADD CONSTRAINT [FK_InjectionDataAcquisitionInjection]
    FOREIGN KEY ([InjectionDataAcquisitionId])
    REFERENCES [dbo].[DataAcquisitions_InjectionDataAcquisition]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InjectionDataAcquisitionInjection'
CREATE INDEX [IX_FK_InjectionDataAcquisitionInjection]
ON [dbo].[Injections]
    ([InjectionDataAcquisitionId]);
GO

-- Creating foreign key on [StageId] in table 'Perforations'
ALTER TABLE [dbo].[Perforations]
ADD CONSTRAINT [FK_StagePerforation]
    FOREIGN KEY ([StageId])
    REFERENCES [dbo].[Stages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StagePerforation'
CREATE INDEX [IX_FK_StagePerforation]
ON [dbo].[Perforations]
    ([StageId]);
GO

-- Creating foreign key on [Material_Id] in table 'Plugs'
ALTER TABLE [dbo].[Plugs]
ADD CONSTRAINT [FK_PlugMaterial]
    FOREIGN KEY ([Material_Id])
    REFERENCES [dbo].[Materials]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlugMaterial'
CREATE INDEX [IX_FK_PlugMaterial]
ON [dbo].[Plugs]
    ([Material_Id]);
GO

-- Creating foreign key on [Stage_Id] in table 'Plugs'
ALTER TABLE [dbo].[Plugs]
ADD CONSTRAINT [FK_StagePlug]
    FOREIGN KEY ([Stage_Id])
    REFERENCES [dbo].[Stages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StagePlug'
CREATE INDEX [IX_FK_StagePlug]
ON [dbo].[Plugs]
    ([Stage_Id]);
GO

-- Creating foreign key on [HFTreatmentStageId] in table 'Fluids'
ALTER TABLE [dbo].[Fluids]
ADD CONSTRAINT [FK_HFTreatmentStageFluid]
    FOREIGN KEY ([HFTreatmentStageId])
    REFERENCES [dbo].[HFTreatmentStages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HFTreatmentStageFluid'
CREATE INDEX [IX_FK_HFTreatmentStageFluid]
ON [dbo].[Fluids]
    ([HFTreatmentStageId]);
GO

-- Creating foreign key on [HFTreatmentStageId] in table 'Proppants'
ALTER TABLE [dbo].[Proppants]
ADD CONSTRAINT [FK_HFTreatmentStageProppant]
    FOREIGN KEY ([HFTreatmentStageId])
    REFERENCES [dbo].[HFTreatmentStages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HFTreatmentStageProppant'
CREATE INDEX [IX_FK_HFTreatmentStageProppant]
ON [dbo].[Proppants]
    ([HFTreatmentStageId]);
GO

-- Creating foreign key on [StageId] in table 'HFTreatmentStages'
ALTER TABLE [dbo].[HFTreatmentStages]
ADD CONSTRAINT [FK_StageHFTreatmentStage]
    FOREIGN KEY ([StageId])
    REFERENCES [dbo].[Stages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StageHFTreatmentStage'
CREATE INDEX [IX_FK_StageHFTreatmentStage]
ON [dbo].[HFTreatmentStages]
    ([StageId]);
GO

-- Creating foreign key on [HydraulicFracturingTreatmentId] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [FK_HydraulicFracturingTreatmentStage]
    FOREIGN KEY ([HydraulicFracturingTreatmentId])
    REFERENCES [dbo].[Treatments_HydraulicFracturingTreatment]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HydraulicFracturingTreatmentStage'
CREATE INDEX [IX_FK_HydraulicFracturingTreatmentStage]
ON [dbo].[Stages]
    ([HydraulicFracturingTreatmentId]);
GO

-- Creating foreign key on [Id] in table 'DataAcquisitions_InjectionDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_InjectionDataAcquisition]
ADD CONSTRAINT [FK_InjectionDataAcquisition_inherits_DataAcquisition]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_HydraulicFracturingTreatment'
ALTER TABLE [dbo].[Treatments_HydraulicFracturingTreatment]
ADD CONSTRAINT [FK_HydraulicFracturingTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_SteamInjectionTreatment'
ALTER TABLE [dbo].[Treatments_SteamInjectionTreatment]
ADD CONSTRAINT [FK_SteamInjectionTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_AcidTreatment'
ALTER TABLE [dbo].[Treatments_AcidTreatment]
ADD CONSTRAINT [FK_AcidTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_CasingRepairTreatment'
ALTER TABLE [dbo].[Treatments_CasingRepairTreatment]
ADD CONSTRAINT [FK_CasingRepairTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_CleanOutTreatment'
ALTER TABLE [dbo].[Treatments_CleanOutTreatment]
ADD CONSTRAINT [FK_CleanOutTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_JunkBasketTreatment'
ALTER TABLE [dbo].[Treatments_JunkBasketTreatment]
ADD CONSTRAINT [FK_JunkBasketTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_PlugDrillOutTreatment'
ALTER TABLE [dbo].[Treatments_PlugDrillOutTreatment]
ADD CONSTRAINT [FK_PlugDrillOutTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_PlugRecovery'
ALTER TABLE [dbo].[Treatments_PlugRecovery]
ADD CONSTRAINT [FK_PlugRecovery_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Treatments_RefracTreatment'
ALTER TABLE [dbo].[Treatments_RefracTreatment]
ADD CONSTRAINT [FK_RefracTreatment_inherits_Treatment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Treatments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DataAcquisitions_HydraulicFracturingDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_HydraulicFracturingDataAcquisition]
ADD CONSTRAINT [FK_HydraulicFracturingDataAcquisition_inherits_DataAcquisition]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DataAcquisitions_OffsetWellDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_OffsetWellDataAcquisition]
ADD CONSTRAINT [FK_OffsetWellDataAcquisition_inherits_DataAcquisition]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DataAcquisitions_ProductionDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_ProductionDataAcquisition]
ADD CONSTRAINT [FK_ProductionDataAcquisition_inherits_DataAcquisition]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'DataAcquisitions_IntegrityDataAcquisition'
ALTER TABLE [dbo].[DataAcquisitions_IntegrityDataAcquisition]
ADD CONSTRAINT [FK_IntegrityDataAcquisition_inherits_DataAcquisition]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[DataAcquisitions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Notes_Event'
ALTER TABLE [dbo].[Notes_Event]
ADD CONSTRAINT [FK_Event_inherits_Note]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Notes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------