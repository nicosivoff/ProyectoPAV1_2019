USE [master]
GO
/****** Object:  Database [Canario]    Script Date: 09/03/2019 17:31:02 ******/
CREATE DATABASE [Canario] ON  PRIMARY 
( NAME = N'Canario', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Canario.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Canario_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Canario_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Canario] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Canario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Canario] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Canario] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Canario] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Canario] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Canario] SET ARITHABORT OFF
GO
ALTER DATABASE [Canario] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Canario] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Canario] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Canario] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Canario] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Canario] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Canario] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Canario] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Canario] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Canario] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Canario] SET  DISABLE_BROKER
GO
ALTER DATABASE [Canario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Canario] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Canario] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Canario] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Canario] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Canario] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Canario] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Canario] SET  READ_WRITE
GO
ALTER DATABASE [Canario] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Canario] SET  MULTI_USER
GO
ALTER DATABASE [Canario] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Canario] SET DB_CHAINING OFF
GO
USE [Canario]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 09/03/2019 17:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[legajo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[nroDoc] [int] NOT NULL,
	[telefono] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[domicilio] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente_1] PRIMARY KEY CLUSTERED 
(
	[nroDoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPrenda](
	[codTipoPrenda] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tipoPrenda] PRIMARY KEY CLUSTERED 
(
	[codTipoPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPago](
	[codTipoPago] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[codTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[CUIL] [int] NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[CUIL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prenda]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prenda](
	[codPrenda] [int] NOT NULL,
	[tipoPrenda] [int] NOT NULL,
	[talle] [nchar](10) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Prenda] PRIMARY KEY CLUSTERED 
(
	[codPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[codPedido] [int] NOT NULL,
	[CUIL] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[total] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[codPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[legajo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[codVenta] [int] NOT NULL,
	[idUsuario] [varchar](50) NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[codTipoPago] [int] NOT NULL,
	[hora] [datetime] NOT NULL,
	[total] [int] NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[codVenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[codPedido] [int] NOT NULL,
	[codPrenda] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[codPedido] ASC,
	[codPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 09/03/2019 17:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[codVenta] [int] NOT NULL,
	[codPrenda] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[codVenta] ASC,
	[codPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Prenda_tipoPrenda1]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[Prenda]  WITH CHECK ADD  CONSTRAINT [FK_Prenda_tipoPrenda1] FOREIGN KEY([tipoPrenda])
REFERENCES [dbo].[TipoPrenda] ([codTipoPrenda])
GO
ALTER TABLE [dbo].[Prenda] CHECK CONSTRAINT [FK_Prenda_tipoPrenda1]
GO
/****** Object:  ForeignKey [FK_Pedido_Proveedor]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Proveedor] FOREIGN KEY([CUIL])
REFERENCES [dbo].[Proveedor] ([CUIL])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Proveedor]
GO
/****** Object:  ForeignKey [FK_Usuario_Empleado]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empleado] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleado] ([legajo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empleado]
GO
/****** Object:  ForeignKey [FK_Venta_TipoPago]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_TipoPago] FOREIGN KEY([codTipoPago])
REFERENCES [dbo].[TipoPago] ([codTipoPago])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_TipoPago]
GO
/****** Object:  ForeignKey [FK_Venta_Usuario]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Pedido]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([codPedido])
REFERENCES [dbo].[Pedido] ([codPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Prenda]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Prenda]
GO
/****** Object:  ForeignKey [FK_DetalleVenta_Prenda]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Prenda]
GO
/****** Object:  ForeignKey [FK_DetalleVenta_Venta]    Script Date: 09/03/2019 17:31:04 ******/
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([codVenta])
REFERENCES [dbo].[Venta] ([codVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Venta]
GO
