USE [master]
GO
/****** Object:  Database [Cocoppel]    Script Date: 2020-04-07 14:46:40 ******/
CREATE DATABASE [Cocoppel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cocoppel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Cocoppel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cocoppel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Cocoppel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cocoppel] SET COMPATIBILITY_LEVEL = 150
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
ALTER DATABASE [Cocoppel] SET AUTO_CLOSE OFF 
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
EXEC sys.sp_db_vardecimal_storage_format N'Cocoppel', N'ON'
GO
ALTER DATABASE [Cocoppel] SET QUERY_STORE = OFF
GO
USE [Cocoppel]
GO
/****** Object:  Table [dbo].[CuentaCheques]    Script Date: 2020-04-07 14:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaCheques](
	[IDNumeroDeCuenta] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[Valida] [bit] NOT NULL,
	[Balance] [money] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
 CONSTRAINT [PK_CuentaCheques] PRIMARY KEY CLUSTERED 
(
	[IDNumeroDeCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineaCredito]    Script Date: 2020-04-07 14:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaCredito](
	[IDLineaDeCredito] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[Valida] [bit] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[CantidadMaximaDisponible] [money] NOT NULL,
	[SaldoRestante] [money] NOT NULL,
 CONSTRAINT [PK_LineaCredito] PRIMARY KEY CLUSTERED 
(
	[IDLineaDeCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCredito]    Script Date: 2020-04-07 14:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaCredito](
	[IDLineaCredito] [int] NOT NULL,
	[Valida] [bit] NOT NULL,
	[EntidadEmisora] [varchar](50) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[FechaCaducidad] [date] NOT NULL,
	[CVV] [int] NOT NULL,
	[NIP] [int] NOT NULL,
	[MarcaInternacional] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[IDLineaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaDebito]    Script Date: 2020-04-07 14:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaDebito](
	[IDNumeroDeCuenta] [int] NOT NULL,
	[Valida] [bit] NOT NULL,
	[EntidadEmisora] [varchar](50) NOT NULL,
	[Titular] [varchar](50) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[FechaCaducidad] [date] NOT NULL,
	[CVV] [int] NOT NULL,
	[NIP] [int] NOT NULL,
	[MarcaInternacional] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TarjetaDebito] PRIMARY KEY CLUSTERED 
(
	[IDNumeroDeCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2020-04-07 14:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[FechaAfiliacion] [date] NOT NULL,
	[PuntajeCredito] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CuentaCheques] ON 

INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (1, 3, 1, 20000.0000, CAST(N'2030-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[CuentaCheques] OFF
SET IDENTITY_INSERT [dbo].[LineaCredito] ON 

INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (1, 2, 1, CAST(N'2021-01-01' AS Date), 40000.0000, 20000.0000)
SET IDENTITY_INSERT [dbo].[LineaCredito] OFF
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (1, 1, N'Cocoppel', N'Cristopher David Ceja Sánchez', N'4485361749026722', CAST(N'2020-09-01' AS Date), 604, 1234, N'VISA')
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (1, 1, N'Cocoppel', N'Cocoteca', N'5177015165311949
', CAST(N'2023-01-01' AS Date), 743, 1282, N'Master Card')
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (2, CAST(N'2020-04-07' AS Date), 600)
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (3, CAST(N'2020-04-07' AS Date), 700)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Index [UK_NumeroTarjetaCredito]    Script Date: 2020-04-07 14:46:40 ******/
ALTER TABLE [dbo].[TarjetaCredito] ADD  CONSTRAINT [UK_NumeroTarjetaCredito] UNIQUE NONCLUSTERED 
(
	[IDLineaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_NumeroTarjetaDebito]    Script Date: 2020-04-07 14:46:40 ******/
ALTER TABLE [dbo].[TarjetaDebito] ADD  CONSTRAINT [UK_NumeroTarjetaDebito] UNIQUE NONCLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
