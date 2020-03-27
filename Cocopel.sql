USE [master]
GO
/****** Object:  Database [Cocopel]    Script Date: 26/03/2020 05:06:50 p. m. ******/
CREATE DATABASE [Cocopel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cocopel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cocopel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cocopel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Cocopel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Cocopel] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cocopel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cocopel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cocopel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cocopel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cocopel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cocopel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cocopel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cocopel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cocopel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cocopel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cocopel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cocopel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cocopel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cocopel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cocopel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cocopel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cocopel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cocopel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cocopel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cocopel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cocopel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cocopel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cocopel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cocopel] SET RECOVERY FULL 
GO
ALTER DATABASE [Cocopel] SET  MULTI_USER 
GO
ALTER DATABASE [Cocopel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cocopel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cocopel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cocopel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cocopel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cocopel', N'ON'
GO
ALTER DATABASE [Cocopel] SET QUERY_STORE = OFF
GO
USE [Cocopel]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 26/03/2020 05:06:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Nombres] [varchar](40) NOT NULL,
	[Apellido_P] [varchar](20) NOT NULL,
	[Apellido_M] [varchar](20) NOT NULL,
	[TarjetaCredito] [bigint] NULL,
	[TarjetaDebito] [bigint] NULL,
	[ID_usuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 26/03/2020 05:06:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[ID_movimiento] [tinyint] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[ID_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCredito]    Script Date: 26/03/2020 05:06:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaCredito](
	[NumeroDeTarjeta] [bigint] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[CCV] [smallint] NOT NULL,
	[Limite] [int] NOT NULL,
	[Saldo] [int] NOT NULL,
 CONSTRAINT [PK_TarjetaCredito] PRIMARY KEY CLUSTERED 
(
	[NumeroDeTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaDebito]    Script Date: 26/03/2020 05:06:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaDebito](
	[NumeroDeTarjeta] [bigint] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[CCV] [smallint] NOT NULL,
	[Saldo] [bigint] NOT NULL,
 CONSTRAINT [PK_TarjetaDebito] PRIMARY KEY CLUSTERED 
(
	[NumeroDeTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 26/03/2020 05:06:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[ID_Transaccion] [bigint] NOT NULL,
	[TipoMovimiento] [tinyint] NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Tarjeta] [bigint] NOT NULL,
 CONSTRAINT [PK_Transaccion] PRIMARY KEY CLUSTERED 
(
	[ID_Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TarjetaCredito] FOREIGN KEY([TarjetaCredito])
REFERENCES [dbo].[TarjetaCredito] ([NumeroDeTarjeta])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TarjetaCredito]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TarjetaDebito] FOREIGN KEY([TarjetaDebito])
REFERENCES [dbo].[TarjetaDebito] ([NumeroDeTarjeta])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TarjetaDebito]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Movimiento] FOREIGN KEY([TipoMovimiento])
REFERENCES [dbo].[Movimiento] ([ID_movimiento])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Movimiento]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_TarjetaCredito] FOREIGN KEY([Tarjeta])
REFERENCES [dbo].[TarjetaCredito] ([NumeroDeTarjeta])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_TarjetaCredito]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_TarjetaDebito] FOREIGN KEY([Tarjeta])
REFERENCES [dbo].[TarjetaDebito] ([NumeroDeTarjeta])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_TarjetaDebito]
GO
USE [master]
GO
ALTER DATABASE [Cocopel] SET  READ_WRITE 
GO
