USE [master]
GO
/****** Object:  Database [DBTextBook]    Script Date: 22.05.2022 22:50:53 ******/
CREATE DATABASE [DBTextBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBTextBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBTextBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBTextBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBTextBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBTextBook] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBTextBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBTextBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBTextBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBTextBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBTextBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBTextBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBTextBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBTextBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBTextBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBTextBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBTextBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBTextBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBTextBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBTextBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBTextBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBTextBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBTextBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBTextBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBTextBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBTextBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBTextBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBTextBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBTextBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBTextBook] SET RECOVERY FULL 
GO
ALTER DATABASE [DBTextBook] SET  MULTI_USER 
GO
ALTER DATABASE [DBTextBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBTextBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBTextBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBTextBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBTextBook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBTextBook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBTextBook', N'ON'
GO
ALTER DATABASE [DBTextBook] SET QUERY_STORE = OFF
GO
USE [DBTextBook]
GO
/****** Object:  Table [dbo].[Autorization]    Script Date: 22.05.2022 22:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorization](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NULL,
 CONSTRAINT [PK_Autorization] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 22.05.2022 22:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[IdTest] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Time] [time](7) NOT NULL,
	[CountQuestion] [int] NOT NULL,
	[CreatorTest] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[IdTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestAnswer]    Script Date: 22.05.2022 22:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAnswer](
	[IdAnswer] [int] IDENTITY(1,1) NOT NULL,
	[IdQuestion] [int] NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[Correct] [bit] NOT NULL,
 CONSTRAINT [PK_TestAnswer] PRIMARY KEY CLUSTERED 
(
	[IdAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestQuestion]    Script Date: 22.05.2022 22:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestQuestion](
	[IdQuestion] [int] IDENTITY(1,1) NOT NULL,
	[IdTest] [int] NOT NULL,
	[TitleQuestion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TestQuestion] PRIMARY KEY CLUSTERED 
(
	[IdQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestResult]    Script Date: 22.05.2022 22:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestResult](
	[IdResult] [int] IDENTITY(1,1) NOT NULL,
	[IdTest] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Time] [time](7) NOT NULL,
	[CorrectAnswers] [int] NOT NULL,
	[DateOfPassage] [datetime] NOT NULL,
 CONSTRAINT [PK_TestResult] PRIMARY KEY CLUSTERED 
(
	[IdResult] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autorization] ON 

INSERT [dbo].[Autorization] ([IdUser], [Login], [Password], [Name], [Surname], [Patronymic]) VALUES (1, N'Login', N'Password', N'Danil', N'Malyh', N'Vladimirovich')
SET IDENTITY_INSERT [dbo].[Autorization] OFF
GO
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([IdTest], [Title], [Time], [CountQuestion], [CreatorTest], [Description]) VALUES (1, N'Теория вероятности', CAST(N'00:10:00' AS Time), 5, 1, N'Пробный тест')
INSERT [dbo].[Test] ([IdTest], [Title], [Time], [CountQuestion], [CreatorTest], [Description]) VALUES (33, N'Proba#33', CAST(N'00:04:08' AS Time), 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
SET IDENTITY_INSERT [dbo].[TestAnswer] ON 

INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (1, 7, N'выборочная совокупность – часть генеральной', 1)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (2, 7, N'правильный ответ отсутствует', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (3, 7, N'выборочная и генеральная совокупности равны по численности', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (4, 7, N'генеральная совокупность – часть выборочной', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (5, 8, N'объему выборки n', 1)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (6, 8, N'единице', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (7, 8, N'нулю', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (8, 8, N'среднему арифметическому значений признака', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (9, 9, N'полигон', 1)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (10, 9, N'кумулята', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (11, 9, N'эмпирическая функция распределения', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (12, 9, N'гистограмма', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (13, 11, N'является несмещенной оценкой дисперсии случайной величины X', 1)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (14, 11, N'является несмещенной оценкой среднеквадратического отклонения случайной величины X', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (15, 11, N'является смещенной оценкой среднеквадратического отклонения случайной величины X', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (16, 11, N'является смещенной оценкой дисперсии случайной величины X', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (17, 10, N'выборочное среднее является точечной оценкой математического ожидания M(X), а выборочная дисперсия - точечной оценкой дисперсии D(X)', 1)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (18, 10, N'выборочное среднее является интервальной оценкой математического ожидания M(X), а выборочная дисперсия – точечной оценкой дисперсии D(X)', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (19, 10, N'выборочное среднее является точечной оценкой математического ожидания M(X), а выборочная дисперсия - интервальной оценкой дисперсии D(X)', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (20, 10, N'выборочное среднее является интервальной оценкой математического ожидания M(X), а выборочная дисперсия – интервальной оценкой дисперсии D(X)', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (65, 23, N'11', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (66, 23, N'11', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (67, 23, N'11', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (68, 23, N'11', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (69, 24, N'1121', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (70, 24, N'1121', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (71, 24, N'1121', 0)
INSERT [dbo].[TestAnswer] ([IdAnswer], [IdQuestion], [Answer], [Correct]) VALUES (72, 24, N'1121', 0)
SET IDENTITY_INSERT [dbo].[TestAnswer] OFF
GO
SET IDENTITY_INSERT [dbo].[TestQuestion] ON 

INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (7, 1, N'Какое из утверждений относительно генеральной и выборочной совокупностей является верным?')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (8, 1, N'Сумма частот признака равна:')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (9, 1, N'Ломаная, отрезки которой соединяют точки с координатами (xi,ni)(xi,ni), где xixi– значение вариационного ряда, nini – частота, – это:')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (10, 1, N'Какие из следующих утверждений являются верными?')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (11, 1, N'Уточненная выборочная дисперсия S2S2 случайной величины XX обладает следующими свойствами:')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (23, 33, N'Question#11')
INSERT [dbo].[TestQuestion] ([IdQuestion], [IdTest], [TitleQuestion]) VALUES (24, 33, N'Question#221')
SET IDENTITY_INSERT [dbo].[TestQuestion] OFF
GO
SET IDENTITY_INSERT [dbo].[TestResult] ON 

INSERT [dbo].[TestResult] ([IdResult], [IdTest], [Name], [Surname], [Time], [CorrectAnswers], [DateOfPassage]) VALUES (1, 1, N'Danil', N'Malyh', CAST(N'00:02:32' AS Time), 4, CAST(N'2022-05-10T00:00:00.000' AS DateTime))
INSERT [dbo].[TestResult] ([IdResult], [IdTest], [Name], [Surname], [Time], [CorrectAnswers], [DateOfPassage]) VALUES (2, 1, N'q', N'q', CAST(N'00:00:23' AS Time), 4, CAST(N'2022-05-20T13:41:29.000' AS DateTime))
INSERT [dbo].[TestResult] ([IdResult], [IdTest], [Name], [Surname], [Time], [CorrectAnswers], [DateOfPassage]) VALUES (3, 1, N'danil', N'malyh', CAST(N'00:00:14' AS Time), 5, CAST(N'2022-05-20T21:46:00.000' AS DateTime))
INSERT [dbo].[TestResult] ([IdResult], [IdTest], [Name], [Surname], [Time], [CorrectAnswers], [DateOfPassage]) VALUES (4, 1, N'Данил', N'Малых', CAST(N'00:00:36' AS Time), 3, CAST(N'2022-05-22T08:41:08.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TestResult] OFF
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Autorization] FOREIGN KEY([CreatorTest])
REFERENCES [dbo].[Autorization] ([IdUser])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Autorization]
GO
ALTER TABLE [dbo].[TestAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TestAnswer_TestQuestion] FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[TestQuestion] ([IdQuestion])
GO
ALTER TABLE [dbo].[TestAnswer] CHECK CONSTRAINT [FK_TestAnswer_TestQuestion]
GO
ALTER TABLE [dbo].[TestQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TestQuestion_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
GO
ALTER TABLE [dbo].[TestQuestion] CHECK CONSTRAINT [FK_TestQuestion_Test]
GO
ALTER TABLE [dbo].[TestResult]  WITH CHECK ADD  CONSTRAINT [FK_TestResult_Test] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Test] ([IdTest])
GO
ALTER TABLE [dbo].[TestResult] CHECK CONSTRAINT [FK_TestResult_Test]
GO
USE [master]
GO
ALTER DATABASE [DBTextBook] SET  READ_WRITE 
GO
