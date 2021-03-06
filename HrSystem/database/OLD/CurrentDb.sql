USE [HRSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetStage]    Script Date: 24-01-2022 08:02:13 ******/
GO
/****** Object:  Table [dbo].[vacancy]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vacancy]') AND type in (N'U'))
DROP TABLE [dbo].[vacancy]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[system_settings]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_settings]') AND type in (N'U'))
DROP TABLE [dbo].[system_settings]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stage]') AND type in (N'U'))
DROP TABLE [dbo].[Stage]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'U'))
DROP TABLE [dbo].[Login]
GO
/****** Object:  Table [dbo].[Home]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Home]') AND type in (N'U'))
DROP TABLE [dbo].[Home]
GO
/****** Object:  Table [dbo].[application]    Script Date: 24-01-2022 08:02:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND type in (N'U'))
DROP TABLE [dbo].[application]
GO
USE [master]
GO
/****** Object:  Database [HRSystem]    Script Date: 24-01-2022 08:02:13 ******/
DROP DATABASE [HRSystem]
GO
/****** Object:  Database [HRSystem]    Script Date: 24-01-2022 08:02:13 ******/
CREATE DATABASE [HRSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HRSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HRSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HRSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HRSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HRSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HRSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HRSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HRSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HRSystem] SET QUERY_STORE = OFF
GO
USE [HRSystem]
GO
/****** Object:  Table [dbo].[application]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[application](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Gender] [varchar](20) NULL,
	[Address] [nchar](10) NULL,
	[Experience] [int] NULL,
	[Status] [varchar](20) NULL,
	[Resume] [varchar](50) NULL,
	[VacancyId] [int] NULL,
	[StageId] [int] NULL,
	[DateCreated] [datetime2](7) NULL,
 CONSTRAINT [PK__applicat__3213E83F33EAE46B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Home]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Home](
	[NewApplicant] [int] NULL,
	[ActiveVacancy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StatusLabel] [varchar](200) NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK__recruitm__3213E83FD32681C7] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[system_settings]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[system_settings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NOT NULL,
	[email] [varchar](200) NOT NULL,
	[contact] [varchar](20) NOT NULL,
	[cover_img] [text] NOT NULL,
	[about_content] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacancy]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacancy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [varchar](200) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[status] [varchar](20) NOT NULL,
	[date_created] [datetime2](7) NOT NULL,
	[Experience] [decimal](10, 3) NOT NULL,
	[Skills] [varchar](max) NOT NULL,
	[Document] [nvarchar](max) NULL,
 CONSTRAINT [PK__vacancy__3213E83F287E3D1C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[application] ON 

INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (4, N'Nikita', N's', N'Parve', N'n@gmail.com', N'23232', N'Female', N'a         ', 2, N'Active', N'N', 1, 1, CAST(N'2021-12-22T08:42:08.1933333' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (5, N'ABhij', N'a', N'Joshi', N'aj@gmail.com', N'4254', N'Male', N'b         ', 2, N'Active', N'A', 2, 1, CAST(N'2021-12-22T08:43:36.6666667' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (7, N'Pooja', N'd', N'Pagar', N'p@gmail.com', N'3435465', N'Female', N'c         ', 3, N'Active', N'P', 3, 1, CAST(N'2021-12-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (8, N'Manisha ', N'v', N'Olimbe', N'mo@gmail.com', N'657567', N'Female', N'd         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (11, N'Manish', N'a', N'Kulkarni', N'manish@gmail.com', N'46323', N'Male', N'e         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (12, N'Anushka', N's', N'Joshi', N'anushka@gmail.com', N'32653', N'Female', N'f         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (13, N'Rashmi', N'd', N'Ghodke', N'r@gmail.com', N'87978', N'Female', N'g         ', 2, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (14, N'Rahul', N'h', N'Kapale', N'rk@gmail.com', N'896789', N'Male', N'h         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (17, N'Abheejit', N'k', N'Bankar', N'ab@gmail.com', N'47864', N'Male', N'i         ', 3, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (18, N'Rushikesh', N'v', N'Pasarker', N'rp@gmail.com', N'78476', N'Male', N'j         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (19, N'Priya', N'p', N'Lahot', N'pl@gmail.com', N'7845674', N'Female', N'k         ', 1, N'Active', N'Manisha_Resume', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (20, N'abhijeet', NULL, N'joshi', N'abhi@gmail.com', NULL, N'Male', NULL, NULL, NULL, N'Resume_JoshiAbhijeetA..pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (22, N'abhi', N'a', N'joshi', N'abhi@gmail.com', N'705770', N'male', N'wagholi   ', 1, N'active', N'Resume_JoshiAbhijeetA..pdf', 1, 5, CAST(N'2022-01-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (23, N'abhi', N'a', N'joshi', N'abhi@gmail.com', N'acvd', N'male', N'wagholi   ', 1, N'active', N'Resume_JoshiAbhijeetA..pdf', 1, 5, CAST(N'2022-01-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (24, N'abhi', NULL, N'joshi', N'abhi@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Resume_JoshiAbhijeetA..pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (25, N'abhi', NULL, N'joshi', N'abhi@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Resume_JoshiAbhijeetA..pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (26, N'abhi', NULL, N'joshi', N'abhi@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Resume_JoshiAbhijeetA..pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (27, N'aniket', N'a', N'mahajan', N'ani@gmail.com', N'705770', N'male', NULL, NULL, NULL, N'Booklet-1_v6.pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (28, N'xyz', N'a', N'joshi', N'ax@gmail.com', N'705770', N'sccs', N'wagholi   ', 5, N'active', N'Booklet Solar Photovoltic.pdf', 3, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (29, N'abc', N'd', N'joshi', N'ax@gmail.com', N'705770', N'male', N'asd       ', 5, N'active', N'MxP12.pdf', 3, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (30, N'abc', N'ax', N'joshi', N'ax@gmail.com', NULL, NULL, NULL, NULL, N'active', N'MxP12.pdf', 1, 5, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (31, N'abhij', N'a', N'joshiii', N'annni@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Booklet-1_v6.pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (32, N'ganesh', N'p', N'dhabale', N'gax@gmail.com', NULL, N'male', NULL, NULL, NULL, N'SER Brochure.pdf', 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (33, N'Priyaa', N'a', N'mahajan', N'gax@gmail.com', N'acvd', N'male', N'scd       ', 5, N'active', N'SER Brochure.pdf', 3, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (34, N'abhiii', N'a', N'joshi', N'ax@gmail.com', N'acvd', N'male', N'asd       ', 5, N'active', N'MxP60c (XXX = 250 - 270) Brochure.pdf', 2, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (36, N'abhijeeta', N'a', N'joshi', N'annni@gmail.com', N'acvd', N'male', N'wagholi   ', 5, N'active', N'Resume_JoshiAbhijeetA..pdf', 2, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (37, N'aniket', N'd', N'ax', N'ax@gmail.com', N'705770', N'male', N'wagholi   ', 5, N'active', N'Resume_JoshiAbhijeetA..pdf', 3, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Phone], [Gender], [Address], [Experience], [Status], [Resume], [VacancyId], [StageId], [DateCreated]) VALUES (38, N'anik', N'a', N'a', N'a@a.com', N'1234567890', N'M', N'111       ', 1, N'Active', NULL, 1, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[application] OFF
GO
INSERT [dbo].[Login] ([UserName], [Password]) VALUES (N'Abhi', N'A123')
GO
SET IDENTITY_INSERT [dbo].[Stage] ON 

INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (1, N'Stage 0 Passed', NULL)
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (2, N'Stage 0 Failed', NULL)
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (3, N'Stage I Passed', NULL)
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (4, N'Stage I Failed', N'1')
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (5, N'Stage II Passed', N'1')
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (6, N'Stage II Failed', NULL)
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (7, N'Job Offer', N'1')
INSERT [dbo].[Stage] ([id], [StatusLabel], [Status]) VALUES (9, N'Stage 0', N'1')
SET IDENTITY_INSERT [dbo].[Stage] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (1, N'Abhijit', N'Wagholi', N'9090096', N'AJ', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (2, N'nikita', N'nagar', N'8080909', N'NP', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (3, N'suraj', N'kolhapur', N'7907680', N'SB', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (4, N'aniket', N'jaysinghpur', N'8986532', N'AM', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (5, N'karmaveer', N'kolhapur', N'8907632', N'KD', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (6, N'Shubham', N'pune', N'0876523', N'SM', N'abc', N'Admin')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (8, N'AbhiJeet', N'Kolhapur', N'7057701143', N'AJ1143', N'abc', N'manager')
INSERT [dbo].[User] ([Id], [Name], [Address], [Contact], [UserName], [Password], [Role]) VALUES (10, N'Manoj ', N'Wagholi', N'98907732', N'Manojm', N'abc', N'manager')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[vacancy] ON 

INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (2, N'WebDevoloper', N'bb', N'Active', CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), CAST(2.000 AS Decimal(10, 3)), N'html css asp .net', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (3, N'DotNetDevoloper', N'cc', N'Active', CAST(N'2021-12-22T09:12:19.0400000' AS DateTime2), CAST(3.000 AS Decimal(10, 3)), N'c#', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (4, N'AndroidDevoloper', N'dd', N'Active', CAST(N'2020-10-11T00:00:00.0000000' AS DateTime2), CAST(1.000 AS Decimal(10, 3)), N'java', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (6, N'JavaDevoloper', N'aaaa', N'Active', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(2.000 AS Decimal(10, 3)), N'Java,CPP', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (7, N'.net developer', N'Wee want asp net developer', N'1', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(2.000 AS Decimal(10, 3)), N'ASP.net', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (8, N'web developer', N'we want web developer having basic knowledge', N'active', CAST(N'2022-01-22T00:00:00.0000000' AS DateTime2), CAST(1.000 AS Decimal(10, 3)), N'html css asp .net', NULL)
INSERT [dbo].[vacancy] ([id], [position], [description], [status], [date_created], [Experience], [Skills], [Document]) VALUES (9, N'.net developer', N'we want web developer having basic knowledge', N'active', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), CAST(5.000 AS Decimal(10, 3)), N'ASP.net', NULL)
SET IDENTITY_INSERT [dbo].[vacancy] OFF
GO
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__proce__2C3393D0]  DEFAULT ((0)) FOR [StageId]
GO
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__date___2D27B809]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__status__300424B4]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__date_cr__30F848ED]  DEFAULT (getdate()) FOR [date_created]
GO
/****** Object:  StoredProcedure [dbo].[GetNewStageData]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetNewStageData]
	 
	@Id int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 'a' as  Name, 'ss' as  Data From Stage Where ID =isNUll(@Id,ID)
END
GO
/****** Object:  StoredProcedure [dbo].[GetStage]    Script Date: 24-01-2022 08:02:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetStage]
	 
	@Id int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Stage Where ID =isNUll(@Id,ID)
END
 
GO
USE [master]
GO
ALTER DATABASE [HRSystem] SET  READ_WRITE 
GO