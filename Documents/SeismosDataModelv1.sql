USE [master]
GO
/****** Object:  Table [dbo].[Azimuth]    Script Date: 6/25/2018 10:58:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Azimuth](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Azimuth] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 6/25/2018 10:58:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cylinder]    Script Date: 6/25/2018 10:58:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder](
	[ID] [uniqueidentifier] NOT NULL,
	[Length] [float] NOT NULL,
	[InnerDiameter] [float] NULL,
	[OuterDiameter] [float] NULL,
	[StartMD] [float] NULL,
	[InnerInterfaceState] [smallint] NULL,
	[OuterInterfaceState] [smallint] NULL,
	[WellboreId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Cylinder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviationSurveys]    Script Date: 6/25/2018 10:58:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviationSurveys](
	[ID] [uniqueidentifier] NOT NULL,
	[WellId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DeviationSurveys] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Easting]    Script Date: 6/25/2018 10:58:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Easting](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Easting] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inclination]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inclination](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Inclination] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterfaceStateEnum]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceStateEnum](
	[ID] [smallint] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InterfaceStateEnum] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Density] [float] NULL,
	[BulkModulus] [float] NULL,
	[ConsumerId] [uniqueidentifier] NULL,
	[ConsumerName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MD] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Northing]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Northing](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Northing] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[ID] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
	[SourceId] [uniqueidentifier] NULL,
	[SourceDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeismosProjects]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeismosProjects](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[LastModified] [datetime] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[Field] [nvarchar](50) NULL,
	[PadName] [nvarchar](50) NULL,
	[JobNumber] [nvarchar](50) NULL,
	[Basin] [nvarchar](50) NULL,
	[AFENumber] [nvarchar](50) NULL,
	[Formation] [nvarchar](50) NULL,
	[County] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SeismosProjects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TVD]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TVD](
	[Key] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
	[ReferenceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TVD] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wellbores]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wellbores](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[WellId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Wellbores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WellGeometryEnum]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WellGeometryEnum](
	[ID] [smallint] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WellGeometryEnum] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WellheadAssemblies]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WellheadAssemblies](
	[ID] [uniqueidentifier] NOT NULL,
	[WellheadId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_WellheadAssemblies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WellheadComponentEnum]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WellheadComponentEnum](
	[ID] [smallint] NOT NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_WellheadComponentEnum] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WellheadComponents]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WellheadComponents](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ComponentType] [smallint] NULL,
	[InternalDiameter] [float] NULL,
	[OuterDiameter] [float] NULL,
	[Length] [float] NULL,
	[WellheadAssemblyId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_WellheadComponents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WellheadCoordinates]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WellheadCoordinates](
	[ID] [uniqueidentifier] NOT NULL,
	[X] [float] NULL,
	[Y] [float] NULL,
	[KB] [float] NULL,
	[CoordinateSystem] [nvarchar](50) NULL,
	[Lat] [nvarchar](50) NULL,
	[Long] [nvarchar](50) NULL,
	[WellheadId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_WellheadCoordinates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wellheads]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wellheads](
	[ID] [uniqueidentifier] NOT NULL,
	[WellId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Wellheads] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wells]    Script Date: 6/25/2018 10:58:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wells](
	[ID] [uniqueidentifier] NOT NULL,
	[WellName] [nvarchar](50) NOT NULL,
	[WellGeometry] [smallint] NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Wells] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Azimuth]  WITH CHECK ADD  CONSTRAINT [FK_Azimuth_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[Azimuth] CHECK CONSTRAINT [FK_Azimuth_DeviationSurveys]
GO
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Wellbores] FOREIGN KEY([WellboreId])
REFERENCES [dbo].[Wellbores] ([ID])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Wellbores]
GO
ALTER TABLE [dbo].[DeviationSurveys]  WITH CHECK ADD  CONSTRAINT [FK_DeviationSurveys_Wells] FOREIGN KEY([WellId])
REFERENCES [dbo].[Wells] ([ID])
GO
ALTER TABLE [dbo].[DeviationSurveys] CHECK CONSTRAINT [FK_DeviationSurveys_Wells]
GO
ALTER TABLE [dbo].[Easting]  WITH CHECK ADD  CONSTRAINT [FK_Easting_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[Easting] CHECK CONSTRAINT [FK_Easting_DeviationSurveys]
GO
ALTER TABLE [dbo].[Inclination]  WITH CHECK ADD  CONSTRAINT [FK_Inclination_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[Inclination] CHECK CONSTRAINT [FK_Inclination_DeviationSurveys]
GO
ALTER TABLE [dbo].[MD]  WITH CHECK ADD  CONSTRAINT [FK_MD_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[MD] CHECK CONSTRAINT [FK_MD_DeviationSurveys]
GO
ALTER TABLE [dbo].[Northing]  WITH CHECK ADD  CONSTRAINT [FK_Northing_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[Northing] CHECK CONSTRAINT [FK_Northing_DeviationSurveys]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_SeismosProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[SeismosProjects] ([ID])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_SeismosProjects]
GO
ALTER TABLE [dbo].[SeismosProjects]  WITH CHECK ADD  CONSTRAINT [FK_SeismosProjects_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[SeismosProjects] CHECK CONSTRAINT [FK_SeismosProjects_Clients]
GO
ALTER TABLE [dbo].[TVD]  WITH CHECK ADD  CONSTRAINT [FK_TVD_DeviationSurveys] FOREIGN KEY([ReferenceID])
REFERENCES [dbo].[DeviationSurveys] ([ID])
GO
ALTER TABLE [dbo].[TVD] CHECK CONSTRAINT [FK_TVD_DeviationSurveys]
GO
ALTER TABLE [dbo].[Wellbores]  WITH CHECK ADD  CONSTRAINT [FK_Wellbores_Wells] FOREIGN KEY([WellId])
REFERENCES [dbo].[Wells] ([ID])
GO
ALTER TABLE [dbo].[Wellbores] CHECK CONSTRAINT [FK_Wellbores_Wells]
GO
ALTER TABLE [dbo].[WellheadAssemblies]  WITH CHECK ADD  CONSTRAINT [FK_WellheadAssemblies_Wellheads] FOREIGN KEY([WellheadId])
REFERENCES [dbo].[Wellheads] ([ID])
GO
ALTER TABLE [dbo].[WellheadAssemblies] CHECK CONSTRAINT [FK_WellheadAssemblies_Wellheads]
GO
ALTER TABLE [dbo].[WellheadComponents]  WITH CHECK ADD  CONSTRAINT [FK_WellheadComponents_WellheadAssemblies] FOREIGN KEY([WellheadAssemblyId])
REFERENCES [dbo].[WellheadAssemblies] ([ID])
GO
ALTER TABLE [dbo].[WellheadComponents] CHECK CONSTRAINT [FK_WellheadComponents_WellheadAssemblies]
GO
ALTER TABLE [dbo].[WellheadCoordinates]  WITH CHECK ADD  CONSTRAINT [FK_WellheadCoordinates_Wellheads1] FOREIGN KEY([WellheadId])
REFERENCES [dbo].[Wellheads] ([ID])
GO
ALTER TABLE [dbo].[WellheadCoordinates] CHECK CONSTRAINT [FK_WellheadCoordinates_Wellheads1]
GO
ALTER TABLE [dbo].[Wellheads]  WITH CHECK ADD  CONSTRAINT [FK_Wellheads_Wells] FOREIGN KEY([WellId])
REFERENCES [dbo].[Wells] ([ID])
GO
ALTER TABLE [dbo].[Wellheads] CHECK CONSTRAINT [FK_Wellheads_Wells]
GO
ALTER TABLE [dbo].[Wells]  WITH CHECK ADD  CONSTRAINT [FK_Wells_SeismosProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[SeismosProjects] ([ID])
GO
ALTER TABLE [dbo].[Wells] CHECK CONSTRAINT [FK_Wells_SeismosProjects]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Short description of the source of the note.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notes', @level2type=N'COLUMN',@level2name=N'SourceDescription'
GO
