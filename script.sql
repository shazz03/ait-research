USE [AitResearch]
GO
/****** Object:  StoredProcedure [dbo].[spGetRespondentSearchResult]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP PROCEDURE [dbo].[spGetRespondentSearchResult]
GO
ALTER TABLE [dbo].[Respondent] DROP CONSTRAINT [FK_Respondent_Survey]
GO
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_QuestionType]
GO
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Answer_Respondent]
GO
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK__Answer__SurveyId__4E88ABD4]
GO
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK__Answer__Question__4F7CD00D]
GO
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK__Answer__OptionId__4D94879B]
GO
ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_State]
GO
ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_AddressType]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Survey]
GO
/****** Object:  Table [dbo].[State]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Staff]
GO
/****** Object:  Table [dbo].[RespondentProfile]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[RespondentProfile]
GO
/****** Object:  Table [dbo].[Respondent]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Respondent]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[QuestionType]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Question]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Option]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Gender]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Answer]
GO
/****** Object:  Table [dbo].[AgeGroup]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[AgeGroup]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[AddressType]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP TABLE [dbo].[Address]
GO
USE [master]
GO
/****** Object:  Database [AitResearch]    Script Date: 5/1/2023 5:20:40 PM ******/
DROP DATABASE [AitResearch]
GO
/****** Object:  Database [AitResearch]    Script Date: 5/1/2023 5:20:40 PM ******/
CREATE DATABASE [AitResearch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AitResearch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AitResearch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AitResearch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AitResearch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AitResearch] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AitResearch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AitResearch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AitResearch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AitResearch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AitResearch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AitResearch] SET ARITHABORT OFF 
GO
ALTER DATABASE [AitResearch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AitResearch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AitResearch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AitResearch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AitResearch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AitResearch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AitResearch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AitResearch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AitResearch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AitResearch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AitResearch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AitResearch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AitResearch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AitResearch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AitResearch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AitResearch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AitResearch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AitResearch] SET RECOVERY FULL 
GO
ALTER DATABASE [AitResearch] SET  MULTI_USER 
GO
ALTER DATABASE [AitResearch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AitResearch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AitResearch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AitResearch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AitResearch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AitResearch', N'ON'
GO
ALTER DATABASE [AitResearch] SET QUERY_STORE = OFF
GO
USE [AitResearch]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Suburb] [varchar](50) NOT NULL,
	[Postcode] [varchar](20) NOT NULL,
	[StateId] [int] NOT NULL,
	[AddressTypeId] [int] NULL,
	[RespondentId] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgeGroup]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgeGroup] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AgeGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OptionId] [int] NOT NULL,
	[SurveyId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[RespondentId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[AnswerText] [varchar](500) NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [varchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[GroupId] [int] NOT NULL,
	[SortOrder] [int] NULL,
	[SurveyId] [int] NOT NULL,
	[QuestionTypeId] [int] NULL,
	[MinOptionSelection] [int] NULL,
	[DependsOnOptionIds] [varchar](500) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](20) NULL,
 CONSTRAINT [PK_QuestionType_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respondent]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respondent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[DateCreated] [datetime] NOT NULL,
	[IpAddress] [varchar](50) NOT NULL,
	[SurveyId] [int] NOT NULL,
 CONSTRAINT [PK_Respondent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RespondentProfile]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RespondentProfile](
	[RespondentProfileId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[GenderId] [int] NULL,
	[AgeGroupId] [int] NULL,
	[ContactNumber] [varchar](50) NULL,
	[RespondentId] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_RespondentProfile] PRIMARY KEY CLUSTERED 
(
	[RespondentProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [varchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [Suburb], [Postcode], [StateId], [AddressTypeId], [RespondentId], [DateCreated]) VALUES (18, N'Sydney', N'2000', 1, 2, 78, CAST(N'2023-05-01T17:08:04.007' AS DateTime))
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[AddressType] ON 

INSERT [dbo].[AddressType] ([AddressTypeId], [TypeName]) VALUES (1, N'Home')
INSERT [dbo].[AddressType] ([AddressTypeId], [TypeName]) VALUES (2, N'Work')
INSERT [dbo].[AddressType] ([AddressTypeId], [TypeName]) VALUES (3, N'Billing')
INSERT [dbo].[AddressType] ([AddressTypeId], [TypeName]) VALUES (4, N'Shipping')
SET IDENTITY_INSERT [dbo].[AddressType] OFF
SET IDENTITY_INSERT [dbo].[AgeGroup] ON 

INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (1, N'15 - 20')
INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (2, N'21 - 30')
INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (3, N'31 - 40')
INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (4, N'41 - 50')
INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (5, N'51 - 60')
INSERT [dbo].[AgeGroup] ([Id], [AgeGroup]) VALUES (6, N'61 - Above')
SET IDENTITY_INSERT [dbo].[AgeGroup] OFF
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (126, 1, 1, 2, 78, CAST(N'2023-05-01T17:08:26.173' AS DateTime), N'Commonwealth Bank')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (127, 8, 1, 6, 78, CAST(N'2023-05-01T17:08:26.283' AS DateTime), N'Internet Banking')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (128, 38, 1, 8, 78, CAST(N'2023-05-01T17:08:26.293' AS DateTime), N'Yes')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (129, 13, 1, 11, 78, CAST(N'2023-05-01T17:08:26.303' AS DateTime), N'Sport')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (130, 23, 1, 13, 78, CAST(N'2023-05-01T17:08:26.320' AS DateTime), N'Cricket')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (131, 40, 1, 14, 78, CAST(N'2023-05-01T17:08:26.323' AS DateTime), N'Yes')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (132, 30, 1, 15, 78, CAST(N'2023-05-01T17:08:26.323' AS DateTime), N'Europe')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (133, 31, 1, 15, 78, CAST(N'2023-05-01T17:08:26.330' AS DateTime), N'Pacific')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (134, 32, 1, 15, 78, CAST(N'2023-05-01T17:08:26.333' AS DateTime), N'North America')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (135, 33, 1, 15, 78, CAST(N'2023-05-01T17:08:26.337' AS DateTime), N'South America')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (136, 4, 1, 2, 79, CAST(N'2023-05-01T17:08:51.320' AS DateTime), N'Wespac')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (137, 10, 1, 6, 79, CAST(N'2023-05-01T17:08:51.373' AS DateTime), N'Credit card')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (138, 39, 1, 8, 79, CAST(N'2023-05-01T17:08:51.383' AS DateTime), N'No')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (139, 40, 1, 14, 79, CAST(N'2023-05-01T17:08:51.393' AS DateTime), N'Yes')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (140, 30, 1, 15, 79, CAST(N'2023-05-01T17:08:51.403' AS DateTime), N'Europe')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (141, 33, 1, 15, 79, CAST(N'2023-05-01T17:08:51.403' AS DateTime), N'South America')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (142, 36, 1, 15, 79, CAST(N'2023-05-01T17:08:51.407' AS DateTime), N'Africa')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (143, 6, 1, 2, 80, CAST(N'2023-05-01T17:09:21.473' AS DateTime), N'ANZ')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (144, 9, 1, 6, 80, CAST(N'2023-05-01T17:09:21.497' AS DateTime), N'Home Loan')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (145, 38, 1, 8, 80, CAST(N'2023-05-01T17:09:21.507' AS DateTime), N'Yes')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (146, 13, 1, 11, 80, CAST(N'2023-05-01T17:09:21.510' AS DateTime), N'Sport')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (147, 25, 1, 13, 80, CAST(N'2023-05-01T17:09:21.523' AS DateTime), N'Motorsport')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (148, 41, 1, 14, 80, CAST(N'2023-05-01T17:09:21.567' AS DateTime), N'No')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (149, 4, 1, 2, 81, CAST(N'2023-05-01T17:09:51.080' AS DateTime), N'Wespac')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (150, 39, 1, 8, 81, CAST(N'2023-05-01T17:09:51.107' AS DateTime), N'No')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (151, 40, 1, 14, 81, CAST(N'2023-05-01T17:09:51.110' AS DateTime), N'Yes')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (152, 29, 1, 15, 81, CAST(N'2023-05-01T17:09:51.117' AS DateTime), N'Australia')
INSERT [dbo].[Answer] ([Id], [OptionId], [SurveyId], [QuestionId], [RespondentId], [DateCreated], [AnswerText]) VALUES (153, 35, 1, 15, 81, CAST(N'2023-05-01T17:09:51.120' AS DateTime), N'Middle East')
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [Gender]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([Id], [Gender]) VALUES (2, N'Female')
INSERT [dbo].[Gender] ([Id], [Gender]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[Gender] OFF
SET IDENTITY_INSERT [dbo].[Option] ON 

INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (1, N'Commonwealth Bank', 2)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (4, N'Wespac', 2)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (6, N'ANZ', 2)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (8, N'Internet Banking', 6)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (9, N'Home Loan', 6)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (10, N'Credit card', 6)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (11, N'Share Investment', 6)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (12, N'Property', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (13, N'Sport', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (15, N'Financial', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (16, N'Entertainment', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (17, N'Lifestyle', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (18, N'Travel', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (19, N'Politics', 11)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (20, N'AFL', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (22, N'Football', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (23, N'Cricket', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (24, N'Racing', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (25, N'Motorsport', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (27, N'Basketball', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (28, N'Tennis', 13)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (29, N'Australia', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (30, N'Europe', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (31, N'Pacific', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (32, N'North America', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (33, N'South America', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (34, N'Asia', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (35, N'Middle East', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (36, N'Africa', 15)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (38, N'Yes', 8)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (39, N'No', 8)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (40, N'Yes', 14)
INSERT [dbo].[Option] ([Id], [Description], [QuestionId]) VALUES (41, N'No', 14)
SET IDENTITY_INSERT [dbo].[Option] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (2, N'What kind of Bank you use?', 1, 1, 1, 1, NULL, N'Null')
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (6, N'What bank services do you use?', 1, 2, 1, 1, NULL, N'1,4,6')
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (8, N'Do you read news paper?', 2, 3, 1, 1, NULL, NULL)
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (11, N'What type of topic do you like to read in news paper?', 2, 4, 1, 1, NULL, N'38')
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (13, N'What type of Sports do you like?', 2, 5, 1, 1, NULL, N'13')
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (14, N'Are you intereted in Travel?', 3, 6, 1, 1, NULL, NULL)
INSERT [dbo].[Question] ([Id], [Description], [GroupId], [SortOrder], [SurveyId], [QuestionTypeId], [MinOptionSelection], [DependsOnOptionIds]) VALUES (15, N'Where would you like to travel?', 3, 7, 1, 2, 2, N'40')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[QuestionType] ON 

INSERT [dbo].[QuestionType] ([Id], [TypeName]) VALUES (1, N'SingleChoice')
INSERT [dbo].[QuestionType] ([Id], [TypeName]) VALUES (2, N'MultipleChoice')
SET IDENTITY_INSERT [dbo].[QuestionType] OFF
SET IDENTITY_INSERT [dbo].[Respondent] ON 

INSERT [dbo].[Respondent] ([Id], [Email], [DateCreated], [IpAddress], [SurveyId]) VALUES (78, N'hafsa.shariq@gmail.com', CAST(N'2023-05-01T17:07:27.587' AS DateTime), N'::1', 1)
INSERT [dbo].[Respondent] ([Id], [Email], [DateCreated], [IpAddress], [SurveyId]) VALUES (79, N'hafsa@gmail.com', CAST(N'2023-05-01T17:08:33.953' AS DateTime), N'::1', 1)
INSERT [dbo].[Respondent] ([Id], [Email], [DateCreated], [IpAddress], [SurveyId]) VALUES (80, N'john.smith@live.com', CAST(N'2023-05-01T17:09:06.460' AS DateTime), N'::1', 1)
INSERT [dbo].[Respondent] ([Id], [Email], [DateCreated], [IpAddress], [SurveyId]) VALUES (81, N'learn@gmail.com', CAST(N'2023-05-01T17:09:35.713' AS DateTime), N'::1', 1)
SET IDENTITY_INSERT [dbo].[Respondent] OFF
SET IDENTITY_INSERT [dbo].[RespondentProfile] ON 

INSERT [dbo].[RespondentProfile] ([RespondentProfileId], [FirstName], [LastName], [DateOfBirth], [GenderId], [AgeGroupId], [ContactNumber], [RespondentId], [DateCreated]) VALUES (20, N'Hafsa', N'Shariq', CAST(N'2002-06-14T00:00:00.000' AS DateTime), 2, 2, N'0413895030', 78, CAST(N'2023-05-01T17:07:56.097' AS DateTime))
SET IDENTITY_INSERT [dbo].[RespondentProfile] OFF
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [Username], [Password]) VALUES (1, N'username', N'password')
SET IDENTITY_INSERT [dbo].[Staff] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [State]) VALUES (1, N'NSW')
INSERT [dbo].[State] ([Id], [State]) VALUES (2, N'VIC')
INSERT [dbo].[State] ([Id], [State]) VALUES (3, N'TAS')
INSERT [dbo].[State] ([Id], [State]) VALUES (4, N'NT')
INSERT [dbo].[State] ([Id], [State]) VALUES (5, N'ACT')
INSERT [dbo].[State] ([Id], [State]) VALUES (6, N'QLD')
SET IDENTITY_INSERT [dbo].[State] OFF
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([Id], [Title], [Description], [DateCreated]) VALUES (1, N'AITR Market Research', N'AITR Market Research on people''s buying habbits', CAST(N'2023-04-10T13:34:05.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Survey] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressType] FOREIGN KEY([AddressTypeId])
REFERENCES [dbo].[AddressType] ([AddressTypeId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressType]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_State]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([OptionId])
REFERENCES [dbo].[Option] ([Id])
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([Id])
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Respondent] FOREIGN KEY([RespondentId])
REFERENCES [dbo].[Respondent] ([Id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Respondent]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionType] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionType]
GO
ALTER TABLE [dbo].[Respondent]  WITH CHECK ADD  CONSTRAINT [FK_Respondent_Survey] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([Id])
GO
ALTER TABLE [dbo].[Respondent] CHECK CONSTRAINT [FK_Respondent_Survey]
GO
/****** Object:  StoredProcedure [dbo].[spGetRespondentSearchResult]    Script Date: 5/1/2023 5:20:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRespondentSearchResult]
    @FirstName varchar(50) = NULL,
    @LastName varchar(50) = NULL,
    @Email varchar(50) = NULL,
    @AgeGroupId int = NULL,
    @StateId int = NULL,
    @GenderId int = NULL,
    @Suburb varchar(50) = NULL,
    @Postcode varchar(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT r.Id,r.SurveyId,
	isnull(rp.FirstName,'Anonymous') as FirstName, 
	isnull(rp.LastName,'Anonymous') as LastName, 
	rp.DateOfBirth,
	r.Email, r.IpAddress,r.DateCreated,
	rp.RespondentProfileId as RespondentProfileId,  rp.ContactNumber,
	s.State, a.Suburb, a.Postcode, a.AddressId,s.Id AS StateId,
	g.Id AS GenderId,g.Gender 
	,ag.AgeGroup, ag.Id AS AgeGroupId, ag.AgeGroup
    FROM 
    dbo.Respondent r 
    LEFT JOIN dbo.RespondentProfile rp ON r.Id = rp.RespondentId
    LEFT JOIN dbo.Gender g ON rp.GenderId = g.Id    
	LEFT JOIN dbo.AgeGroup ag ON ag.Id = rp.AgeGroupId
	LEFT JOIN dbo.Address a ON a.RespondentId = r.Id
	LEFT JOIN dbo.State s ON s.Id = a.StateId
    WHERE (@FirstName IS NULL OR rp.FirstName = @FirstName)
        AND (@LastName IS NULL OR rp.LastName = @LastName)
        AND (@Email IS NULL OR r.Email = @Email)
        AND (@Suburb IS NULL OR a.Suburb = @Suburb)
        AND (@Postcode IS NULL OR a.Postcode = @Postcode)
        AND (@AgeGroupId IS NULL OR ag.Id = @AgeGroupId)
        AND (@StateId IS NULL OR s.Id = @StateId)
		AND (@GenderId IS NULL OR s.Id = @GenderId)
END
GO
USE [master]
GO
ALTER DATABASE [AitResearch] SET  READ_WRITE 
GO
