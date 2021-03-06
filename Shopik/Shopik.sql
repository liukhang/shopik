USE [master]
GO
/****** Object:  Database [Shopik]    Script Date: 11/11/2016 3:58:49 PM ******/
CREATE DATABASE [Shopik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shopik', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Shopik.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Shopik_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Shopik_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Shopik] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shopik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shopik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Shopik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Shopik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Shopik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Shopik] SET ARITHABORT OFF 
GO
ALTER DATABASE [Shopik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Shopik] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Shopik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Shopik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Shopik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Shopik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Shopik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Shopik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Shopik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Shopik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Shopik] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Shopik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Shopik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Shopik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Shopik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Shopik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Shopik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Shopik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Shopik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Shopik] SET  MULTI_USER 
GO
ALTER DATABASE [Shopik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Shopik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Shopik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Shopik] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Shopik]
GO
/****** Object:  Table [dbo].[Cate]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cate](
	[id] [int] NOT NULL,
	[CateName] [nvarchar](50) NULL,
	[ChuDe_id] [int] NULL,
 CONSTRAINT [PK_Cate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[id] [int] NOT NULL,
	[Product_id] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[DonHang_id] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[id] [int] NOT NULL,
	[ChuDeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [datetime] NULL,
	[User_id] [int] NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayCapNhat] [datetime] NULL,
	[SoLuong] [int] NULL,
	[Cate_id] [int] NULL,
	[ChuDe_id] [int] NULL,
	[AnhBia] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/11/2016 3:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[Level] [tinyint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (1, N'Jeans', 1)
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (2, N'T-shirt', 1)
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (3, N'Shoes', 1)
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (4, N'Áo Khoác', 2)
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (5, N'Shoes G', 2)
INSERT [dbo].[Cate] ([id], [CateName], [ChuDe_id]) VALUES (6, N'Bootees Bags', 2)
INSERT [dbo].[ChuDe] ([id], [ChuDeName]) VALUES (1, N'Men')
INSERT [dbo].[ChuDe] ([id], [ChuDeName]) VALUES (2, N'Women')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (1, N'Áo Sơ Mi', CAST(70000 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6B800000000 AS DateTime), 45, 1, 1, N'2.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (2, N'Random', CAST(100000 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6B800000000 AS DateTime), 14, 4, 2, N'2.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (3, N'Random 1', CAST(20000 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6B800000000 AS DateTime), 12, 3, 1, N'2.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (4, N'Random Shopik', CAST(123456 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6B800000000 AS DateTime), 5, 6, 2, N'1.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (5, N'Random Shopik 1', CAST(123123 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6B800000000 AS DateTime), 2, 5, 2, N'5.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (6, N'Random vvv', CAST(23231 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6D600000000 AS DateTime), 43, 2, 2, N'2.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (7, N'ABCXYZ', CAST(122222 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6BB00000000 AS DateTime), 4, 4, 1, N'5.jpg')
INSERT [dbo].[Product] ([id], [ProductName], [Price], [MoTa], [NgayCapNhat], [SoLuong], [Cate_id], [ChuDe_id], [AnhBia]) VALUES (8, N'AAAAAAAAAAAAA', CAST(111111 AS Decimal(18, 0)), N'Easy! You should check out MoxieManager!', CAST(0x0000A6BB00000000 AS DateTime), 2, 1, 2, N'1A.jpg')
INSERT [dbo].[User] ([id], [Username], [Password], [HoTen], [Email], [NgaySinh], [Level]) VALUES (1, N'LiuKhang', N'123', N'LiuKhang', N'admin@gmail.com', NULL, 1)
ALTER TABLE [dbo].[Cate]  WITH CHECK ADD  CONSTRAINT [FK_Cate_ChuDe] FOREIGN KEY([ChuDe_id])
REFERENCES [dbo].[ChuDe] ([id])
GO
ALTER TABLE [dbo].[Cate] CHECK CONSTRAINT [FK_Cate_ChuDe]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([DonHang_id])
REFERENCES [dbo].[DonHang] ([id])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_Product] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_Product]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_User]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Cate] FOREIGN KEY([Cate_id])
REFERENCES [dbo].[Cate] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Cate]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ChuDe] FOREIGN KEY([ChuDe_id])
REFERENCES [dbo].[ChuDe] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ChuDe]
GO
USE [master]
GO
ALTER DATABASE [Shopik] SET  READ_WRITE 
GO
