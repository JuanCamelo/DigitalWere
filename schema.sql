/*-- -----------------------------------------------------
Objetivo: Creacion de Database [Facturacion]  
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/

USE [master]
GO
CREATE DATABASE [Facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Facturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Facturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Facturacion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturacion] SET RECOVERY FULL 
GO
ALTER DATABASE [Facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [Facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Facturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Facturacion] SET QUERY_STORE = OFF
GO
USE [Facturacion]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Facturacion]
GO

/*-- -----------------------------------------------------
Objetivo: Creacion de la Table [dbo].[Cliente]   
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [varchar](50) NOT NULL,
	[Telefono] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/*-- -----------------------------------------------------
Objetivo: Creacion de la Table [dbo].[Detalle]    
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*-- -----------------------------------------------------
Objetivo: Creacion de la Table [dbo].[Factura]   
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[FechaFactura] [datetime] NULL,
	[FechaUltimaCompra] [datetime] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*-- -----------------------------------------------------
Objetivo: Creacion de la Table [dbo].[Producto]  
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Identificacion], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email]) VALUES (1, N'104326874', N'Camila', N'Rojas', N'1985-01-01', N'1234566', N'Correo@prueba.co')
INSERT [dbo].[Cliente] ([IdCliente], [Identificacion], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email]) VALUES (2, N'104326875', N'Paula', N'Perez', N'1980-01-01', N'1234566', N'Correo@prueba.co')
INSERT [dbo].[Cliente] ([IdCliente], [Identificacion], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email]) VALUES (3, N'104326876', N'Juan', N'Sanchez', N'1975-01-01', N'1234566', N'Correo@prueba.co')
INSERT [dbo].[Cliente] ([IdCliente], [Identificacion], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email]) VALUES (4, N'104326877', N'Raul', N'Jimenez', N'1970-01-01', N'1234566', N'Correo@prueba.co')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Detalle] ON 

INSERT [dbo].[Detalle] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioVenta]) VALUES (4, 3, 2, 2, 12000.0000)
INSERT [dbo].[Detalle] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioVenta]) VALUES (6, 5, 4, 3, 10500.0000)
INSERT [dbo].[Detalle] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioVenta]) VALUES (7, 6, 5, 1, 4000.0000)
INSERT [dbo].[Detalle] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioVenta]) VALUES (10, 7, 4, 2, 10000.0000)
INSERT [dbo].[Detalle] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioVenta]) VALUES (14, 7, 4, 2, 10000.0000)
SET IDENTITY_INSERT [dbo].[Detalle] OFF
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (1, 1, CAST(N'2000-02-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (2, 1, CAST(N'2000-03-06T00:00:00.000' AS DateTime), CAST(N'2000-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (3, 2, CAST(N'2000-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (4, 1, CAST(N'2000-04-10T00:00:00.000' AS DateTime), CAST(N'2000-03-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (5, 2, CAST(N'2001-01-01T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (6, 3, CAST(N'2000-05-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [FechaFactura], [FechaUltimaCompra]) VALUES (7, 4, CAST(N'2000-06-01T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Factura] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Precio], [Stock]) VALUES (2, N'Limpiador', 6000.0000, 44)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Precio], [Stock]) VALUES (4, N'Aromatizante', 3500.0000, 5)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Precio], [Stock]) VALUES (5, N'Jabon de Baño', 4000.0000, 4)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Precio], [Stock]) VALUES (6, N'Jabon liquido', 3.0000, 3)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Precio], [Stock]) VALUES (7, N'Detergente Liquido', 4510.0000, 74)
SET IDENTITY_INSERT [dbo].[Producto] OFF

/*-- -----------------------------------------------------
Objetivo:  Index [NonClusteredIndex-20190906-213445]   
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20190906-213445] ON [dbo].[Detalle]
(
	[IdFactura] ASC,
	[IdProducto] ASC,
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20190906-213528]    Script Date: 06/09/2019 21:36:52 ******/
/*-- -----------------------------------------------------
Objetivo: Index [NonClusteredIndex-20190906-213528   
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/

CREATE NONCLUSTERED INDEX [NonClusteredIndex-20190906-213528] ON [dbo].[Factura]
(
	[IdFactura] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Factura]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
USE [master]
GO
ALTER DATABASE [Facturacion] SET  READ_WRITE 
GO
