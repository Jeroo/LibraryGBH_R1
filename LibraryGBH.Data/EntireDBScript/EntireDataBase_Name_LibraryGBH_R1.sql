USE [master]
GO
/****** Object:  Database [LibraryGBH_R1]    Script Date: 4/12/2019 11:14:17 PM ******/
CREATE DATABASE [LibraryGBH_R1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryGBH_R1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LibraryGBH_R1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryGBH_R1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LibraryGBH_R1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibraryGBH_R1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryGBH_R1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryGBH_R1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryGBH_R1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryGBH_R1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryGBH_R1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryGBH_R1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryGBH_R1] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryGBH_R1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryGBH_R1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryGBH_R1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryGBH_R1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryGBH_R1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryGBH_R1] SET QUERY_STORE = OFF
GO
USE [LibraryGBH_R1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LibraryGBH_R1]
GO
/****** Object:  User [librarygbhuser01]    Script Date: 4/12/2019 11:14:17 PM ******/
CREATE USER [librarygbhuser01] FOR LOGIN [librarygbhuser01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [librarygbhuser00]    Script Date: 4/12/2019 11:14:17 PM ******/
CREATE USER [librarygbhuser00] FOR LOGIN [librarygbhuser00] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [librarygbhuser]    Script Date: 4/12/2019 11:14:17 PM ******/
CREATE USER [librarygbhuser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [adminUser]    Script Date: 4/12/2019 11:14:17 PM ******/
CREATE USER [adminUser] FOR LOGIN [adminUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_datareader] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [librarygbhuser01]
GO
ALTER ROLE [db_owner] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [librarygbhuser00]
GO
ALTER ROLE [db_owner] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [librarygbhuser]
GO
ALTER ROLE [db_owner] ADD MEMBER [adminUser]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/12/2019 11:14:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Author] [nvarchar](max) NULL,
	[CoverPageImg] [varbinary](max) NULL,
	[TotalPages] [int] NOT NULL,
	[BooksTypesId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CODE_BooksFormat]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CODE_BooksFormat](
	[BookFormatId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_CODE_BooksFormat] PRIMARY KEY CLUSTERED 
(
	[BookFormatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CODE_BooksTypes]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CODE_BooksTypes](
	[BookTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_CODE_BooksTypes] PRIMARY KEY CLUSTERED 
(
	[BookTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONF_BooksPages]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONF_BooksPages](
	[BookPageId] [bigint] IDENTITY(1,1) NOT NULL,
	[ActiveBookFlag] [bit] NOT NULL,
	[BooksId] [bigint] NULL,
	[BooksFormatId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_CONF_BooksPages] PRIMARY KEY CLUSTERED 
(
	[BookPageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individuos]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individuos](
	[IndividuoId] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NULL,
	[TicketId] [bigint] NULL,
	[TicketsId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Individuos] PRIMARY KEY CLUSTERED 
(
	[IndividuoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageId] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PageNumber] [bigint] NOT NULL,
	[BooksId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompraDate] [datetime2](7) NOT NULL,
	[PaypalReference] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[UpdatedById] [uniqueidentifier] NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 4/12/2019 11:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190412020211_InitialCreateDB', N'2.1.2-rtm-30932')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190412025655_DeleteDuplicity', N'2.1.2-rtm-30932')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190412030124_ChangeColumnName', N'2.1.2-rtm-30932')
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [Name], [Description], [Author], [CoverPageImg], [TotalPages], [BooksTypesId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (1, N'La vida de Lazarillo de Tormes', N'La vida de Lazarillo de Tormes y de sus fortunas y adversidades (más conocida como Lazarillo de Tormes) es una novela española anónima, escrita en primera persona y en estilo epistolar (como una sola y larga carta), cuyas ediciones conocidas más antiguas datan de 1554.1? En ella se cuenta de forma autobiográfica la vida de un niño, Lázaro de Tormes, en el siglo xvi d. C., desde su nacimiento y mísera infancia hasta su boda, ya en la edad adulta. Es considerada precursora de la novela picaresca1? por elementos como el realismo, la narración en primera persona, la estructura itinerante, el servicio a varios amos y la ideología moralizante y pesimista.', N'José de Sigüenza', NULL, 3, 1, CAST(N'2019-04-11T22:50:20.0400000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:50:20.0400000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Books] ([BookId], [Name], [Description], [Author], [CoverPageImg], [TotalPages], [BooksTypesId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (2, N'Breve historia del tiempo', N'Breve historia del tiempo: del Big Bang a los agujeros negros es un libro de divulgación científica publicado en 1988 y escrito por el físico teórico, astrofísico y cosmólogo británico Stephen Hawking y prologado por Carl Sagan.?', N'José de Sigüenza', NULL, 3, 2, CAST(N'2019-04-11T22:51:34.3900000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:51:34.3900000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Books] ([BookId], [Name], [Description], [Author], [CoverPageImg], [TotalPages], [BooksTypesId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (3, N'Don Quijote de la Mancha', N'Don Quijote de la Mancha? es una novela escrita por el español Miguel de Cervantes Saavedra. Publicada su primera parte con el título de El ingenioso hidalgo don Quijote de la Mancha a comienzos?', N'Miguel de Cervantes', NULL, 3, 3, CAST(N'2019-04-11T22:52:42.1633333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:52:42.1633333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[CODE_BooksFormat] ON 
GO
INSERT [dbo].[CODE_BooksFormat] ([BookFormatId], [Name], [Description], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (2, N'HTML', N'Formato HTML para ver los libros', CAST(N'2019-04-11T22:40:43.7900000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:40:43.7900000' AS DateTime2), N'ed5be076-ac85-4f3e-8017-ceb6b63fc753', 0)
GO
INSERT [dbo].[CODE_BooksFormat] ([BookFormatId], [Name], [Description], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (3, N'Text', N'Formato texto para ver los libros', CAST(N'2019-04-11T22:41:29.3233333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:41:29.3233333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
SET IDENTITY_INSERT [dbo].[CODE_BooksFormat] OFF
GO
SET IDENTITY_INSERT [dbo].[CODE_BooksTypes] ON 
GO
INSERT [dbo].[CODE_BooksTypes] ([BookTypeId], [Name], [Description], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (1, N'Libro de texto', N'Libro de texto', CAST(N'2019-04-11T22:42:46.0533333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:42:46.0533333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[CODE_BooksTypes] ([BookTypeId], [Name], [Description], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (2, N'Científicos', N'Científicos', CAST(N'2019-04-11T22:42:58.7533333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:42:58.7533333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[CODE_BooksTypes] ([BookTypeId], [Name], [Description], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (3, N'Literatura y lingüísticos', N'Literatura y lingüísticos', CAST(N'2019-04-11T22:43:08.0700000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T22:43:08.0700000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
SET IDENTITY_INSERT [dbo].[CODE_BooksTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Pages] ON 
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (1, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 1, 1, CAST(N'2019-04-11T23:03:26.5866667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:26.5866667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (2, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 2, 1, CAST(N'2019-04-11T23:03:35.9166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:35.9166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (3, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 3, 1, CAST(N'2019-04-11T23:03:39.5633333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:39.5633333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (4, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 1, 2, CAST(N'2019-04-11T23:03:48.1166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:48.1166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 2, 2, CAST(N'2019-04-11T23:03:51.3933333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:51.3933333' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 3, 2, CAST(N'2019-04-11T23:03:55.7000000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:03:55.7000000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (7, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 1, 3, CAST(N'2019-04-11T23:04:01.2300000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:04:01.2300000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (8, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 2, 3, CAST(N'2019-04-11T23:04:05.1166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:04:05.1166667' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
INSERT [dbo].[Pages] ([PageId], [Text], [Description], [PageNumber], [BooksId], [CreatedDate], [CreatedById], [UpdatedDate], [UpdatedById], [DeleteFlag]) VALUES (9, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
		   Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.
		   ', NULL, 3, 3, CAST(N'2019-04-11T23:04:08.9900000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', CAST(N'2019-04-11T23:04:08.9900000' AS DateTime2), N'a5b3b854-c1c8-4b8a-bb53-07491e821f12', 0)
GO
SET IDENTITY_INSERT [dbo].[Pages] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_BooksTypesId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_BooksTypesId] ON [dbo].[Books]
(
	[BooksTypesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CONF_BooksPages_BooksFormatId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CONF_BooksPages_BooksFormatId] ON [dbo].[CONF_BooksPages]
(
	[BooksFormatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CONF_BooksPages_BooksId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CONF_BooksPages_BooksId] ON [dbo].[CONF_BooksPages]
(
	[BooksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Individuos_TicketsId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Individuos_TicketsId] ON [dbo].[Individuos]
(
	[TicketsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pages_BooksId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pages_BooksId] ON [dbo].[Pages]
(
	[BooksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 4/12/2019 11:14:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_CODE_BooksTypes_BooksTypesId] FOREIGN KEY([BooksTypesId])
REFERENCES [dbo].[CODE_BooksTypes] ([BookTypeId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_CODE_BooksTypes_BooksTypesId]
GO
ALTER TABLE [dbo].[CONF_BooksPages]  WITH CHECK ADD  CONSTRAINT [FK_CONF_BooksPages_Books_BooksId] FOREIGN KEY([BooksId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[CONF_BooksPages] CHECK CONSTRAINT [FK_CONF_BooksPages_Books_BooksId]
GO
ALTER TABLE [dbo].[CONF_BooksPages]  WITH CHECK ADD  CONSTRAINT [FK_CONF_BooksPages_CODE_BooksFormat_BooksFormatId] FOREIGN KEY([BooksFormatId])
REFERENCES [dbo].[CODE_BooksFormat] ([BookFormatId])
GO
ALTER TABLE [dbo].[CONF_BooksPages] CHECK CONSTRAINT [FK_CONF_BooksPages_CODE_BooksFormat_BooksFormatId]
GO
ALTER TABLE [dbo].[Individuos]  WITH CHECK ADD  CONSTRAINT [FK_Individuos_Tickets_TicketsId] FOREIGN KEY([TicketsId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[Individuos] CHECK CONSTRAINT [FK_Individuos_Tickets_TicketsId]
GO
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Books_BooksId] FOREIGN KEY([BooksId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_Books_BooksId]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [LibraryGBH_R1] SET  READ_WRITE 
GO
