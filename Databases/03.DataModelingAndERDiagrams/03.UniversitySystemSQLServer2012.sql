USE [master]
GO
/****** Object:  Database [UniversitySystem]    Script Date: 7/10/2013 3:15:38 PM ******/
CREATE DATABASE [UniversitySystem]
GO
ALTER DATABASE [UniversitySystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversitySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversitySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversitySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversitySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversitySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversitySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversitySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversitySystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversitySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversitySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversitySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversitySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversitySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversitySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversitySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversitySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversitySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversitySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversitySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversitySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversitySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversitySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversitySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversitySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversitySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversitySystem] SET  MULTI_USER 
GO
ALTER DATABASE [UniversitySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversitySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversitySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversitySystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversitySystem', N'ON'
GO
USE [UniversitySystem]
GO
/****** Object:  Table [dbo].[CourseEnrolments]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseEnrolments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_CourseEnrolments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](15) NOT NULL,
	[TitleId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 7/10/2013 3:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CourseEnrolments] ON 

INSERT [dbo].[CourseEnrolments] ([Id], [StudentId], [CourseID]) VALUES (1, 1, 4)
INSERT [dbo].[CourseEnrolments] ([Id], [StudentId], [CourseID]) VALUES (2, 2, 2)
INSERT [dbo].[CourseEnrolments] ([Id], [StudentId], [CourseID]) VALUES (4, 2, 4)
INSERT [dbo].[CourseEnrolments] ([Id], [StudentId], [CourseID]) VALUES (5, 3, 2)
INSERT [dbo].[CourseEnrolments] ([Id], [StudentId], [CourseID]) VALUES (6, 3, 4)
SET IDENTITY_INSERT [dbo].[CourseEnrolments] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [DepartmentID]) VALUES (1, N'Linear Algebra', 3)
INSERT [dbo].[Courses] ([Id], [Name], [DepartmentID]) VALUES (2, N'Calculus', 3)
INSERT [dbo].[Courses] ([Id], [Name], [DepartmentID]) VALUES (4, N'Introduction to Programming', 5)
INSERT [dbo].[Courses] ([Id], [Name], [DepartmentID]) VALUES (5, N'Biology', 2)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (1, N'Mechanical Engineering ', 1)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (2, N'Biological Engineering', 1)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (3, N'Mathematics', 2)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (4, N'Physics', 2)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (5, N'Computer Science', 2)
INSERT [dbo].[Departments] ([Id], [Name], [FacultyId]) VALUES (6, N'Architecture', 3)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (1, N'School of Engineering')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (2, N'School of Science')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (3, N'School of Architecture')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Professors] ON 

INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [TitleId], [DepartmentId]) VALUES (2, N'Ivan', N'Ivanov', 2, 1)
INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [TitleId], [DepartmentId]) VALUES (3, N'Georgi', N'Petrov', 1, 2)
INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [TitleId], [DepartmentId]) VALUES (4, N'Petar', N'Georgiev', 3, 5)
INSERT [dbo].[Professors] ([Id], [FirstName], [LastName], [TitleId], [DepartmentId]) VALUES (5, N'Ivaylo', N'Petkov', 4, 4)
SET IDENTITY_INSERT [dbo].[Professors] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (1, N'Joro', N'Georgiev', 1)
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (2, N'Pesho', N'Petrov', 2)
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [FacultyId]) VALUES (3, N'Ivan', N'Ivanov', 2)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Titles] ON 

INSERT [dbo].[Titles] ([Id], [Name]) VALUES (1, N'Ph. D')
INSERT [dbo].[Titles] ([Id], [Name]) VALUES (2, N'Academician')
INSERT [dbo].[Titles] ([Id], [Name]) VALUES (3, N'Senior Assistant')
INSERT [dbo].[Titles] ([Id], [Name]) VALUES (4, N'Assistant')
SET IDENTITY_INSERT [dbo].[Titles] OFF
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnrolments_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseEnrolments] CHECK CONSTRAINT [FK_CourseEnrolments_Courses]
GO
ALTER TABLE [dbo].[CourseEnrolments]  WITH CHECK ADD  CONSTRAINT [FK_CourseEnrolments_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[CourseEnrolments] CHECK CONSTRAINT [FK_CourseEnrolments_Students]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Titles] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Titles] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
USE [master]
GO
ALTER DATABASE [UniversitySystem] SET  READ_WRITE 
GO
