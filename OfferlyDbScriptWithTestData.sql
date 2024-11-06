USE [master]
GO
/****** Object:  Database [OfferlyDb]    Script Date: 6.11.2024. 18:39:49 ******/
CREATE DATABASE [OfferlyDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OfferlyDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OfferlyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OfferlyDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OfferlyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OfferlyDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OfferlyDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OfferlyDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OfferlyDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OfferlyDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OfferlyDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OfferlyDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [OfferlyDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OfferlyDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OfferlyDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OfferlyDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OfferlyDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OfferlyDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OfferlyDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OfferlyDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OfferlyDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OfferlyDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OfferlyDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OfferlyDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OfferlyDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OfferlyDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OfferlyDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OfferlyDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OfferlyDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OfferlyDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OfferlyDb] SET  MULTI_USER 
GO
ALTER DATABASE [OfferlyDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OfferlyDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OfferlyDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OfferlyDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OfferlyDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OfferlyDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OfferlyDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [OfferlyDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OfferlyDb]
GO
/****** Object:  Table [dbo].[OfferDetails]    Script Date: 6.11.2024. 18:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OfferId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductQuantity] [int] NOT NULL,
 CONSTRAINT [PK_OfferDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 6.11.2024. 18:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6.11.2024. 18:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OfferDetails] ON 
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (2, 1, 2, 1)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (3, 2, 1, 1)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (4, 2, 2, 1)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (5, 2, 3, 2)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (6, 2, 4, 3)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (9, 3, 1, 10)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (10, 3, 2, 2)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (13, 4, 1, 1)
GO
INSERT [dbo].[OfferDetails] ([Id], [OfferId], [ProductId], [ProductQuantity]) VALUES (14, 4, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[OfferDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Offers] ON 
GO
INSERT [dbo].[Offers] ([Id], [Date], [TotalAmount]) VALUES (1, CAST(N'2024-11-04T00:00:00.000' AS DateTime), CAST(26.24 AS Decimal(18, 2)))
GO
INSERT [dbo].[Offers] ([Id], [Date], [TotalAmount]) VALUES (2, CAST(N'2024-11-05T00:00:00.000' AS DateTime), CAST(161.90 AS Decimal(18, 2)))
GO
INSERT [dbo].[Offers] ([Id], [Date], [TotalAmount]) VALUES (3, CAST(N'2024-11-06T12:06:55.583' AS DateTime), CAST(176.48 AS Decimal(18, 2)))
GO
INSERT [dbo].[Offers] ([Id], [Date], [TotalAmount]) VALUES (4, CAST(N'2024-11-06T18:28:30.730' AS DateTime), CAST(59.41 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Offers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (1, N'Keyboard', CAST(15.45 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (2, N'Mouse', CAST(10.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (3, N'Monitor', CAST(30.23 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (4, N'Speaker', CAST(25.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (5, N'Headset', CAST(14.38 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[OfferDetails]  WITH CHECK ADD  CONSTRAINT [FK_OfferDetails_Offers] FOREIGN KEY([OfferId])
REFERENCES [dbo].[Offers] ([Id])
GO
ALTER TABLE [dbo].[OfferDetails] CHECK CONSTRAINT [FK_OfferDetails_Offers]
GO
ALTER TABLE [dbo].[OfferDetails]  WITH CHECK ADD  CONSTRAINT [FK_OfferDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OfferDetails] CHECK CONSTRAINT [FK_OfferDetails_Products]
GO
USE [master]
GO
ALTER DATABASE [OfferlyDb] SET  READ_WRITE 
GO
