USE [master]
GO
/****** Object:  Database [HRSystem]    Script Date: 22-12-2021 08:53:47 ******/
CREATE DATABASE [HRSystem]
 
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
/****** Object:  Table [dbo].[application]    Script Date: 22-12-2021 08:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[application](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](100) NOT NULL,
	[middlename] [varchar](100) NOT NULL,
	[lastname] [varchar](100) NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[address] [text] NOT NULL,
	[cover_letter] [text] NOT NULL,
	[position_id] [int] NOT NULL,
	[resume_path] [text] NOT NULL,
	[process_id] [tinyint] NOT NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recruitment_status]    Script Date: 22-12-2021 08:53:47 ******/
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
/****** Object:  Table [dbo].[system_settings]    Script Date: 22-12-2021 08:53:47 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 22-12-2021 08:53:47 ******/
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
/****** Object:  Table [dbo].[vacancy]    Script Date: 22-12-2021 08:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacancy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [varchar](200) NOT NULL,
	[availability] [int] NOT NULL,
	[description] [text] NOT NULL,
	[status] [tinyint] NOT NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[application] ON 

INSERT [dbo].[application] ([id], [firstname], [middlename], [lastname], [gender], [email], [contact], [address], [cover_letter], [position_id], [resume_path], [process_id], [date_created]) VALUES (4, N'Nikita', N'a', N'Parve', N'F', N'n@gmail.com', N'123', N'a', N'a', 1, N'a', 1, CAST(N'2021-12-22T08:42:08.193' AS DateTime))
INSERT [dbo].[application] ([id], [firstname], [middlename], [lastname], [gender], [email], [contact], [address], [cover_letter], [position_id], [resume_path], [process_id], [date_created]) VALUES (5, N'ABhij', N'a', N'a', N'M', N'a', N'a', N'a', N'a', 2, N'a', 1, CAST(N'2021-12-22T08:43:36.667' AS DateTime))
SET IDENTITY_INSERT [dbo].[application] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [name], [address], [contact], [username], [password], [type], [Action]) VALUES (1, N'Nikita', N'aa', N'a', N'nikita', N'abc', 1, NULL)
INSERT [dbo].[users] ([id], [name], [address], [contact], [username], [password], [type], [Action]) VALUES (2, N'abhijit', N'a', N'a', N'abhijit', N'abc', 2, NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[application] ADD  DEFAULT ((0)) FOR [process_id]
GO
ALTER TABLE [dbo].[application] ADD  DEFAULT (getdate()) FOR [date_created]
GO
ALTER TABLE [dbo].[recruitment_status] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((2)) FOR [type]
GO
ALTER TABLE [dbo].[vacancy] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[vacancy] ADD  DEFAULT (getdate()) FOR [date_created]
GO
USE [master]
GO
ALTER DATABASE [HRSystem] SET  READ_WRITE 
GO
