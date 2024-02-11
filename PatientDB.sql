USE [master]
GO
/****** Object:  Database [PatientDB]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE DATABASE [PatientDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PatientDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PatientDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PatientDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PatientDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PatientDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PatientDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PatientDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PatientDB] SET  MULTI_USER 
GO
ALTER DATABASE [PatientDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PatientDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PatientDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PatientDB', N'ON'
GO
ALTER DATABASE [PatientDB] SET QUERY_STORE = OFF
GO
USE [PatientDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[AllergiesId] [int] IDENTITY(1,1) NOT NULL,
	[AllergiesName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[AllergiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies_details]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies_details](
	[Allergies_DetailsId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[AllergiesId] [int] NOT NULL,
	[PatientInformationPatientId] [int] NULL,
 CONSTRAINT [PK_Allergies_details] PRIMARY KEY CLUSTERED 
(
	[Allergies_DetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformation]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformation](
	[DiseaseId] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DiseaseInformation] PRIMARY KEY CLUSTERED 
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD](
	[NCDId] [int] IDENTITY(1,1) NOT NULL,
	[NCDName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NCD] PRIMARY KEY CLUSTERED 
(
	[NCDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDDetails]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDDetails](
	[NCD_DetailsId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[NCDId] [int] NOT NULL,
	[PatientInformationPatientId] [int] NULL,
 CONSTRAINT [PK_NCDDetails] PRIMARY KEY CLUSTERED 
(
	[NCD_DetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientInformation]    Script Date: 2/10/2024 9:30:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientInformation](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](max) NOT NULL,
	[DiseaseId] [int] NOT NULL,
	[Epilepsy] [int] NOT NULL,
 CONSTRAINT [PK_PatientInformation] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240209130906_Migrations', N'6.0.19')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (1, N'Drugs - Penicillin')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (2, N'Drugs - Others')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (3, N'Animals')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (4, N'Food')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (5, N'Ointments')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (6, N'Plant')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (7, N'Sprays')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (8, N'Others')
INSERT [dbo].[Allergies] ([AllergiesId], [AllergiesName]) VALUES (9, N'No Allergies')
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[Allergies_details] ON 

INSERT [dbo].[Allergies_details] ([Allergies_DetailsId], [PatientId], [AllergiesId], [PatientInformationPatientId]) VALUES (1, 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[Allergies_details] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformation] ON 

INSERT [dbo].[DiseaseInformation] ([DiseaseId], [DiseaseName]) VALUES (1, N'Conjunctivitis')
INSERT [dbo].[DiseaseInformation] ([DiseaseId], [DiseaseName]) VALUES (2, N'Diarrhea')
INSERT [dbo].[DiseaseInformation] ([DiseaseId], [DiseaseName]) VALUES (3, N'Headaches')
INSERT [dbo].[DiseaseInformation] ([DiseaseId], [DiseaseName]) VALUES (4, N'Mononucleosis')
INSERT [dbo].[DiseaseInformation] ([DiseaseId], [DiseaseName]) VALUES (5, N'Stomach Aches')
SET IDENTITY_INSERT [dbo].[DiseaseInformation] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD] ON 

INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (1, N'Asthma')
INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (2, N'Cancer')
INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (3, N'Disorders or ear')
INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (4, N'Disorder of eye')
INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (5, N'Mental illness')
INSERT [dbo].[NCD] ([NCDId], [NCDName]) VALUES (6, N'Oral health problems')
SET IDENTITY_INSERT [dbo].[NCD] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDDetails] ON 

INSERT [dbo].[NCDDetails] ([NCD_DetailsId], [PatientId], [NCDId], [PatientInformationPatientId]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[NCDDetails] ([NCD_DetailsId], [PatientId], [NCDId], [PatientInformationPatientId]) VALUES (2, 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[NCDDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientInformation] ON 

INSERT [dbo].[PatientInformation] ([PatientId], [PatientName], [DiseaseId], [Epilepsy]) VALUES (1, N'Atiqur Rahman', 3, 0)
INSERT [dbo].[PatientInformation] ([PatientId], [PatientName], [DiseaseId], [Epilepsy]) VALUES (2, N'Atiqur Rahman', 2, 1)
SET IDENTITY_INSERT [dbo].[PatientInformation] OFF
GO
/****** Object:  Index [IX_Allergies_details_AllergiesId]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_Allergies_details_AllergiesId] ON [dbo].[Allergies_details]
(
	[AllergiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Allergies_details_PatientInformationPatientId]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_Allergies_details_PatientInformationPatientId] ON [dbo].[Allergies_details]
(
	[PatientInformationPatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCDDetails_NCDId]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCDDetails_NCDId] ON [dbo].[NCDDetails]
(
	[NCDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCDDetails_PatientInformationPatientId]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCDDetails_PatientInformationPatientId] ON [dbo].[NCDDetails]
(
	[PatientInformationPatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatientInformation_DiseaseId]    Script Date: 2/10/2024 9:30:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_PatientInformation_DiseaseId] ON [dbo].[PatientInformation]
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Allergies_details]  WITH CHECK ADD  CONSTRAINT [FK_Allergies_details_Allergies_AllergiesId] FOREIGN KEY([AllergiesId])
REFERENCES [dbo].[Allergies] ([AllergiesId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergies_details] CHECK CONSTRAINT [FK_Allergies_details_Allergies_AllergiesId]
GO
ALTER TABLE [dbo].[Allergies_details]  WITH CHECK ADD  CONSTRAINT [FK_Allergies_details_PatientInformation_PatientInformationPatientId] FOREIGN KEY([PatientInformationPatientId])
REFERENCES [dbo].[PatientInformation] ([PatientId])
GO
ALTER TABLE [dbo].[Allergies_details] CHECK CONSTRAINT [FK_Allergies_details_PatientInformation_PatientInformationPatientId]
GO
ALTER TABLE [dbo].[NCDDetails]  WITH CHECK ADD  CONSTRAINT [FK_NCDDetails_NCD_NCDId] FOREIGN KEY([NCDId])
REFERENCES [dbo].[NCD] ([NCDId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCDDetails] CHECK CONSTRAINT [FK_NCDDetails_NCD_NCDId]
GO
ALTER TABLE [dbo].[NCDDetails]  WITH CHECK ADD  CONSTRAINT [FK_NCDDetails_PatientInformation_PatientInformationPatientId] FOREIGN KEY([PatientInformationPatientId])
REFERENCES [dbo].[PatientInformation] ([PatientId])
GO
ALTER TABLE [dbo].[NCDDetails] CHECK CONSTRAINT [FK_NCDDetails_PatientInformation_PatientInformationPatientId]
GO
ALTER TABLE [dbo].[PatientInformation]  WITH CHECK ADD  CONSTRAINT [FK_PatientInformation_DiseaseInformation_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[DiseaseInformation] ([DiseaseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientInformation] CHECK CONSTRAINT [FK_PatientInformation_DiseaseInformation_DiseaseId]
GO
USE [master]
GO
ALTER DATABASE [PatientDB] SET  READ_WRITE 
GO
