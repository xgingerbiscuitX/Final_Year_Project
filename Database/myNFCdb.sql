USE [master]
GO
/****** Object:  Database [myNFCdb]    Script Date: 08/04/2022 13:38:34 ******/
CREATE DATABASE [myNFCdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myNFCdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\myNFCdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'myNFCdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\myNFCdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [myNFCdb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myNFCdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myNFCdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myNFCdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myNFCdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myNFCdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myNFCdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [myNFCdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myNFCdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myNFCdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myNFCdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myNFCdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myNFCdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myNFCdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myNFCdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myNFCdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myNFCdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myNFCdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myNFCdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myNFCdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myNFCdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myNFCdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myNFCdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myNFCdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myNFCdb] SET RECOVERY FULL 
GO
ALTER DATABASE [myNFCdb] SET  MULTI_USER 
GO
ALTER DATABASE [myNFCdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myNFCdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myNFCdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myNFCdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [myNFCdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [myNFCdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'myNFCdb', N'ON'
GO
ALTER DATABASE [myNFCdb] SET QUERY_STORE = OFF
GO
USE [myNFCdb]
GO
/****** Object:  Table [dbo].[TagType]    Script Date: 08/04/2022 13:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagType](
	[TagTypeID] [varchar](50) NOT NULL,
	[TagType] [varchar](50) NULL,
	[TagUID] [varchar](255) NULL,
 CONSTRAINT [PK_TagType] PRIMARY KEY CLUSTERED 
(
	[TagTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestData]    Script Date: 08/04/2022 13:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestData](
	[TestID] [varchar](50) NOT NULL,
	[TagTypeID] [varchar](50) NOT NULL,
	[TestTypeID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestData] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestDetails]    Script Date: 08/04/2022 13:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestDetails](
	[TestID] [varchar](50) NOT NULL,
	[Details_of_Test] [varchar](50) NULL,
	[Result] [varchar](50) NULL,
	[DateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestType]    Script Date: 08/04/2022 13:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestType](
	[TestTypeID] [varchar](50) NOT NULL,
	[TestType] [varchar](50) NULL,
 CONSTRAINT [PK_TestType] PRIMARY KEY CLUSTERED 
(
	[TestTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestData]  WITH CHECK ADD  CONSTRAINT [FK_TestData_TagType] FOREIGN KEY([TagTypeID])
REFERENCES [dbo].[TagType] ([TagTypeID])
GO
ALTER TABLE [dbo].[TestData] CHECK CONSTRAINT [FK_TestData_TagType]
GO
ALTER TABLE [dbo].[TestData]  WITH CHECK ADD  CONSTRAINT [FK_TestData_TestType] FOREIGN KEY([TestTypeID])
REFERENCES [dbo].[TestType] ([TestTypeID])
GO
ALTER TABLE [dbo].[TestData] CHECK CONSTRAINT [FK_TestData_TestType]
GO
ALTER TABLE [dbo].[TestDetails]  WITH CHECK ADD  CONSTRAINT [FK_TestDetails_TestData] FOREIGN KEY([TestID])
REFERENCES [dbo].[TestData] ([TestID])
GO
ALTER TABLE [dbo].[TestDetails] CHECK CONSTRAINT [FK_TestDetails_TestData]
GO
USE [master]
GO
ALTER DATABASE [myNFCdb] SET  READ_WRITE 
GO
