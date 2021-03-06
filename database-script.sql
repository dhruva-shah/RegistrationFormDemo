﻿USE [master]
GO
/****** Object:  Database [RegistrationDemo]    Script Date: 2020-11-18 9:45:02 AM ******/
CREATE DATABASE [RegistrationDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegistrationDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\RegistrationDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegistrationDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\RegistrationDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RegistrationDemo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegistrationDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegistrationDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegistrationDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegistrationDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegistrationDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegistrationDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegistrationDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegistrationDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegistrationDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegistrationDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegistrationDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegistrationDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegistrationDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegistrationDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegistrationDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegistrationDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RegistrationDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegistrationDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegistrationDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegistrationDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegistrationDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegistrationDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegistrationDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegistrationDemo] SET RECOVERY FULL 
GO
ALTER DATABASE [RegistrationDemo] SET  MULTI_USER 
GO
ALTER DATABASE [RegistrationDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegistrationDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegistrationDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegistrationDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegistrationDemo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RegistrationDemo', N'ON'
GO
ALTER DATABASE [RegistrationDemo] SET QUERY_STORE = OFF
GO
USE [RegistrationDemo]
GO
/****** Object:  User [UFRegistrationDemo]    Script Date: 2020-11-18 9:45:02 AM ******/
CREATE USER [UFRegistrationDemo] FOR LOGIN [UFRegistrationDemo] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UFRegistrationDemo]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 2020-11-18 9:45:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](100) NULL,
	[Position] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 2020-11-18 9:45:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ProvinceId] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrationEvent]    Script Date: 2020-11-18 9:45:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationEvent](
	[RegistrationEventId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
		[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_RegistrationEvent] PRIMARY KEY CLUSTERED 
(
	[RegistrationEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 2020-11-18 9:45:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[AddressLine1] [nvarchar](500) NULL,
	[AddressLine2] [nvarchar](500) NULL,
	[City] [nvarchar](200) NULL,
	[Province] [int] NOT NULL,
	[PostalCode] [nvarchar](7) NULL,
	[DOB] [datetime] NULL,
	[PhoneNumber] [nvarchar](13) NULL,
	[Email] [nvarchar](500) NULL,
	[IsFirstTime] [bit] NULL,
	[SendConfirmationEmail] [bit] NULL,
	[DateRegistered] [datetime] NULL,
 CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (1, N'Dancing', 0, 0)
INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (2, N'Singing', 0, 0)
INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (3, N'Music', 1, 0)
INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (4, N'Art', 1, 0)
INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (5, N'Crafts', 2, 0)
INSERT [dbo].[Events] ([EventId], [EventName], [Position], [IsDeleted]) VALUES (6, N'Shooting', 2, 0)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (1, N'Ontario')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (2, N'British Columbia')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (3, N'Alberta')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (4, N'New Brunswick')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (5, N'Manitoba')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (6, N'Nova Scotia')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (7, N'Nunavat')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (8, N'Newfoundland and Labrador')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (9, N'Northwest Territories')
SET IDENTITY_INSERT [dbo].[Province] OFF
GO
ALTER TABLE [dbo].[RegistrationEvent]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationEvent_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[RegistrationEvent] CHECK CONSTRAINT [FK_RegistrationEvent_Events]
GO
ALTER TABLE [dbo].[RegistrationEvent]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationEvent_Registrations] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registrations] ([RegistrationId])
GO
ALTER TABLE [dbo].[RegistrationEvent] CHECK CONSTRAINT [FK_RegistrationEvent_Registrations]
GO
USE [master]
GO
ALTER DATABASE [RegistrationDemo] SET  READ_WRITE 
GO
