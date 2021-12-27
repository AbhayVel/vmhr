USE [HRSystem]
GO
ALTER TABLE [dbo].[vacancy] DROP CONSTRAINT [DF__vacancy__date_cr__30F848ED]
GO
ALTER TABLE [dbo].[vacancy] DROP CONSTRAINT [DF__vacancy__status__300424B4]
GO
ALTER TABLE [dbo].[users] DROP CONSTRAINT [DF__users__type__2F10007B]
GO
ALTER TABLE [dbo].[recruitment_status] DROP CONSTRAINT [DF__recruitme__statu__2E1BDC42]
GO
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF__applicati__date___2D27B809]
GO
ALTER TABLE [dbo].[application] DROP CONSTRAINT [DF__applicati__proce__2C3393D0]
GO
/****** Object:  Table [dbo].[vacancy]    Script Date: 26-12-2021 19:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vacancy]') AND type in (N'U'))
DROP TABLE [dbo].[vacancy]
GO
/****** Object:  Table [dbo].[users]    Script Date: 26-12-2021 19:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[system_settings]    Script Date: 26-12-2021 19:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_settings]') AND type in (N'U'))
DROP TABLE [dbo].[system_settings]
GO
/****** Object:  Table [dbo].[recruitment_status]    Script Date: 26-12-2021 19:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[recruitment_status]') AND type in (N'U'))
DROP TABLE [dbo].[recruitment_status]
GO
/****** Object:  Table [dbo].[application]    Script Date: 26-12-2021 19:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[application]') AND type in (N'U'))
DROP TABLE [dbo].[application]
GO
USE [master]
GO
/****** Object:  Database [HRSystem]    Script Date: 26-12-2021 19:04:50 ******/
DROP DATABASE [HRSystem]
GO
/****** Object:  Database [HRSystem]    Script Date: 26-12-2021 19:04:50 ******/
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
/****** Object:  Table [dbo].[application]    Script Date: 26-12-2021 19:04:50 ******/
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
	[Position] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Gender] [varchar](20) NULL,
	[Address] [nchar](10) NULL,
	[AppliedFor] [varchar](50) NULL,
	[Experience] [int] NULL,
	[Status] [varchar](20) NULL,
	[Resume] [varchar](50) NULL,
	[PositionId] [int] NULL,
	[ProcessId] [int] NULL,
	[DateCreated] [datetime2](7) NULL,
 CONSTRAINT [PK__applicat__3213E83F33EAE46B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recruitment_status]    Script Date: 26-12-2021 19:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recruitment_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_label] [varchar](200) NOT NULL,
	[status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[system_settings]    Script Date: 26-12-2021 19:04:50 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 26-12-2021 19:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[address] [text] NOT NULL,
	[contact] [text] NOT NULL,
	[username] [varchar](100) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[type] [tinyint] NOT NULL,
	[Action] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacancy]    Script Date: 26-12-2021 19:04:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacancy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [varchar](200) NOT NULL,
	[availability] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[status] [varchar](20) NULL,
	[date_created] [datetime2](7) NULL,
	[Experience] [decimal](10, 3) NULL,
	[Skills] [varchar](max) NULL,
 CONSTRAINT [PK__vacancy__3213E83F287E3D1C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[application] ON 

INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (4, N'Nikita', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123', 2, N'a', NULL, 1, 1, CAST(N'2021-12-22T08:42:08.1933333' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (5, N'ABhij', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'a', NULL, N'a', NULL, 2, 1, CAST(N'2021-12-22T08:43:36.6666667' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (7, N'Pooja', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'098876', NULL, N'a', NULL, 3, 1, CAST(N'2021-12-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (8, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (11, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (12, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (13, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (14, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (17, N'Manisha S. Olimbe', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (18, N'Manisha', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[application] ([id], [FirstName], [MiddleName], [LastName], [Email], [Position], [Phone], [Gender], [Address], [AppliedFor], [Experience], [Status], [Resume], [PositionId], [ProcessId], [DateCreated]) VALUES (19, N'Manisha', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'DotNet Devoloper', 1, N'Active', N'Manisha_Resume', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[application] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [name], [address], [contact], [username], [password], [type], [Action]) VALUES (1, N'Nikita', N'aa', N'a', N'nikita', N'abc', 1, NULL)
INSERT [dbo].[users] ([id], [name], [address], [contact], [username], [password], [type], [Action]) VALUES (2, N'abhijit', N'a', N'a', N'abhijit', N'xyz', 2, NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[vacancy] ON 

INSERT [dbo].[vacancy] ([id], [position], [availability], [description], [status], [date_created], [Experience], [Skills]) VALUES (1, N'JavaDevoloper', 7, N'aa', N'Active', CAST(N'2021-12-22T00:00:00.0000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[vacancy] ([id], [position], [availability], [description], [status], [date_created], [Experience], [Skills]) VALUES (2, N'WebDevoloper', 5, N'bb', N'Active', CAST(N'2021-11-21T00:00:00.0000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[vacancy] ([id], [position], [availability], [description], [status], [date_created], [Experience], [Skills]) VALUES (3, N'DotNetDevoloper', 10, N'cc', N'Active', CAST(N'2021-12-22T09:12:19.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[vacancy] ([id], [position], [availability], [description], [status], [date_created], [Experience], [Skills]) VALUES (4, N'AndroidDevoloper', 5, N'dd', N'Active', CAST(N'2020-10-11T00:00:00.0000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[vacancy] ([id], [position], [availability], [description], [status], [date_created], [Experience], [Skills]) VALUES (6, N'JavaDevoloper', 5, N'aaaa', N'Active', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(2.000 AS Decimal(10, 3)), N'Java,CPP')
SET IDENTITY_INSERT [dbo].[vacancy] OFF
GO
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__proce__2C3393D0]  DEFAULT ((0)) FOR [ProcessId]
GO
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__date___2D27B809]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[recruitment_status] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((2)) FOR [type]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__status__300424B4]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__date_cr__30F848ED]  DEFAULT (getdate()) FOR [date_created]
GO
USE [master]
GO
ALTER DATABASE [HRSystem] SET  READ_WRITE 
GO
