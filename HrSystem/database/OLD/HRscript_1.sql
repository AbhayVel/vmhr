USE [master]
GO
/****** Object:  Database [HRSystem]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[application]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[Feeds]    Script Date: 17-05-2022 14:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feeds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextData] [nvarchar](max) NULL,
	[Heading] [nvarchar](500) NULL,
	[ShortNotes] [nvarchar](500) NULL,
	[FeedTypeId] [int] NULL,
	[Link] [nvarchar](2000) NULL,
	[UserName] [nvarchar](100) NULL,
	[FeedDate] [datetime] NULL,
 CONSTRAINT [PK_Feeds_Id] PRIMARY KEY CLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedType]    Script Date: 17-05-2022 14:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeText] [nvarchar](100) NULL,
 CONSTRAINT [PK_FeedType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Home]    Script Date: 17-05-2022 14:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Home](
	[NewApplicant] [int] NULL,
	[ActiveVacancy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[Stage]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[system_settings]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[TimeSheet]    Script Date: 17-05-2022 14:40:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextData] [nvarchar](max) NULL,
	[Heading] [nvarchar](500) NULL,
	[ShortNotes] [nvarchar](500) NULL,
	[TimeSpend] [numeric](10, 4) NULL,
	[TaskStartDate] [datetime] NULL,
	[TaskEndDate] [datetime] NULL,
	[TaskDate] [datetime] NULL,
 CONSTRAINT [PK_TimeSheet_Id] PRIMARY KEY CLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  Table [dbo].[vacancy]    Script Date: 17-05-2022 14:40:11 ******/
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
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__proce__2C3393D0]  DEFAULT ((0)) FOR [StageId]
GO
ALTER TABLE [dbo].[application] ADD  CONSTRAINT [DF__applicati__date___2D27B809]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__status__300424B4]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[vacancy] ADD  CONSTRAINT [DF__vacancy__date_cr__30F848ED]  DEFAULT (getdate()) FOR [date_created]
GO
/****** Object:  StoredProcedure [dbo].[GetNewStageData]    Script Date: 17-05-2022 14:40:11 ******/
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
/****** Object:  StoredProcedure [dbo].[GetStage]    Script Date: 17-05-2022 14:40:11 ******/
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
