USE [master]
GO
CREATE DATABASE [AddressRegistrations]
ALTER DATABASE [AddressRegistrations] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AddressRegistrations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AddressRegistrations] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AddressRegistrations] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AddressRegistrations] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AddressRegistrations] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AddressRegistrations] SET ARITHABORT OFF 
GO
ALTER DATABASE [AddressRegistrations] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AddressRegistrations] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AddressRegistrations] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AddressRegistrations] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AddressRegistrations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AddressRegistrations] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AddressRegistrations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AddressRegistrations] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AddressRegistrations] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AddressRegistrations] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AddressRegistrations] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AddressRegistrations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AddressRegistrations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AddressRegistrations] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AddressRegistrations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AddressRegistrations] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AddressRegistrations] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AddressRegistrations] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AddressRegistrations] SET RECOVERY FULL 
GO
ALTER DATABASE [AddressRegistrations] SET  MULTI_USER 
GO
ALTER DATABASE [AddressRegistrations] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AddressRegistrations] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AddressRegistrations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AddressRegistrations] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AddressRegistrations', N'ON'
GO
USE [AddressRegistrations]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 7/10/2013 3:08:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 7/10/2013 3:08:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7/10/2013 3:08:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 7/10/2013 3:08:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 7/10/2013 3:08:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [AddressText], [TownId]) VALUES (1, N'Address in Sofia', 6)
INSERT [dbo].[Addresses] ([Id], [AddressText], [TownId]) VALUES (2, N'Address in Tokyo', 3)
INSERT [dbo].[Addresses] ([Id], [AddressText], [TownId]) VALUES (3, N'Address in Berlin', 7)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'Europe')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'Nigeria', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'Japan', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (4, N'China', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (5, N'France', 3)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (6, N'Bulgaria', 3)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (7, N'Germany', 3)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Georgi', N'Petrov', 1)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (2, N'Jap', N'An', 2)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [AddressId]) VALUES (3, N'Rudolf', N'Smith', 3)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (2, N'Nigerian town', 2)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (3, N'Tokyo', 3)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (4, N'Beijing', 4)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (5, N'Paris', 5)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (6, N'Sofia', 6)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (7, N'Berlin', 7)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
