USE [master]
GO

/****** Object:  Database [Seismos]    Script Date: 6/26/2018 9:56:10 AM ******/
DROP DATABASE [Seismos]
GO

/****** Object:  Database [Seismos]    Script Date: 6/26/2018 9:56:10 AM ******/
CREATE DATABASE [Seismos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Seismos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Seismos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Seismos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Seismos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Seismos] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Seismos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Seismos] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Seismos] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Seismos] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Seismos] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Seismos] SET ARITHABORT OFF 
GO

ALTER DATABASE [Seismos] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Seismos] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Seismos] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Seismos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Seismos] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Seismos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Seismos] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Seismos] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Seismos] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Seismos] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Seismos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Seismos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Seismos] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Seismos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Seismos] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Seismos] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Seismos] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Seismos] SET RECOVERY FULL 
GO

ALTER DATABASE [Seismos] SET  MULTI_USER 
GO

ALTER DATABASE [Seismos] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Seismos] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Seismos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Seismos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Seismos] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Seismos] SET QUERY_STORE = OFF
GO

USE [Seismos]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [Seismos] SET  READ_WRITE 
GO


