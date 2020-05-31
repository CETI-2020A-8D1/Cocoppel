USE [master]
GO
/****** Object:  Database [Cocoppel]    Script Date: 2020-05-31 17:55:50 ******/
CREATE DATABASE [Cocoppel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cocoppel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cocoppel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cocoppel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cocoppel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Cocoppel] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cocoppel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cocoppel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cocoppel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cocoppel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cocoppel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cocoppel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cocoppel] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Cocoppel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cocoppel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cocoppel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cocoppel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cocoppel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cocoppel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cocoppel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cocoppel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cocoppel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cocoppel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cocoppel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cocoppel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cocoppel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cocoppel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cocoppel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cocoppel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cocoppel] SET RECOVERY FULL 
GO
ALTER DATABASE [Cocoppel] SET  MULTI_USER 
GO
ALTER DATABASE [Cocoppel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cocoppel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cocoppel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cocoppel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cocoppel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cocoppel] SET QUERY_STORE = OFF
GO
USE [Cocoppel]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Cocoppel]
GO
/****** Object:  Table [dbo].[CuentaCheques]    Script Date: 2020-05-31 17:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCheques](
	[IDNumeroDeCuenta] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NULL,
	[Valida] [bit] NULL,
	[Balance] [money] NULL,
	[FechaVencimiento] [date] NULL,
 CONSTRAINT [PK_CuentaCheques] PRIMARY KEY CLUSTERED 
(
	[IDNumeroDeCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineaCredito]    Script Date: 2020-05-31 17:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaCredito](
	[IDLineaDeCredito] [int] NOT NULL,
	[IDUsuario] [int] NULL,
	[Valida] [bit] NULL,
	[FechaVencimiento] [date] NULL,
	[CantidadMaximaDisponible] [money] NULL,
	[SaldoRestante] [money] NULL,
 CONSTRAINT [PK_LineaCredito] PRIMARY KEY CLUSTERED 
(
	[IDLineaDeCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCredito]    Script Date: 2020-05-31 17:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaCredito](
	[IDLineaCredito] [int] NOT NULL,
	[Valida] [bit] NULL,
	[EntidadEmisora] [varchar](50) NULL,
	[Titular] [varchar](50) NULL,
	[Numero] [varchar](max) NULL,
	[FechaCaducidad] [date] NULL,
	[CVV] [int] NULL,
	[NIP] [int] NULL,
	[MarcaInternacional] [varchar](50) NULL,
 CONSTRAINT [PK_TarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[IDLineaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_NumeroTarjetaCredito] UNIQUE NONCLUSTERED 
(
	[IDLineaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaDebito]    Script Date: 2020-05-31 17:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaDebito](
	[IDNumeroDeCuenta] [int] NOT NULL,
	[Valida] [bit] NULL,
	[EntidadEmisora] [varchar](50) NULL,
	[Titular] [varchar](50) NULL,
	[Numero] [varchar](max) NULL,
	[FechaCaducidad] [date] NULL,
	[CVV] [int] NULL,
	[NIP] [int] NULL,
	[MarcaInternacional] [varchar](50) NULL,
 CONSTRAINT [PK_TarjetaDebito] PRIMARY KEY CLUSTERED 
(
	[IDNumeroDeCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2020-05-31 17:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] NOT NULL,
	[FechaAfiliacion] [date] NULL,
	[PuntajeCredito] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CuentaCheques]  WITH CHECK ADD  CONSTRAINT [FK_CuentaCheques_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO
ALTER TABLE [dbo].[CuentaCheques] CHECK CONSTRAINT [FK_CuentaCheques_Usuario]
GO
ALTER TABLE [dbo].[LineaCredito]  WITH CHECK ADD  CONSTRAINT [FK_LineaCredito_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO
ALTER TABLE [dbo].[LineaCredito] CHECK CONSTRAINT [FK_LineaCredito_Usuario]
GO
ALTER TABLE [dbo].[TarjetaCredito]  WITH CHECK ADD  CONSTRAINT [FK_TarjetaCredito_LineaCredito] FOREIGN KEY([IDLineaCredito])
REFERENCES [dbo].[LineaCredito] ([IDLineaDeCredito])
GO
ALTER TABLE [dbo].[TarjetaCredito] CHECK CONSTRAINT [FK_TarjetaCredito_LineaCredito]
GO
ALTER TABLE [dbo].[TarjetaDebito]  WITH CHECK ADD  CONSTRAINT [FK_TarjetaDebito_CuentaCheques] FOREIGN KEY([IDNumeroDeCuenta])
REFERENCES [dbo].[CuentaCheques] ([IDNumeroDeCuenta])
GO
ALTER TABLE [dbo].[TarjetaDebito] CHECK CONSTRAINT [FK_TarjetaDebito_CuentaCheques]
GO
USE [master]
GO
ALTER DATABASE [Cocoppel] SET  READ_WRITE 
GO
