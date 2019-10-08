USE [master]
GO
/****** Object:  Database [Canario]    Script Date: 10/08/2019 19:32:11 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 10/08/2019 19:32:12 ******/
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
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'69980', N'Martin', N'Oliverio', 0)
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'70409', N'Lucas', N'Martin', 0)
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'73841', N'Nicolas', N'Sivoff', 0)
/****** Object:  Table [dbo].[Marca]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (1, N'Adidas', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (2, N'Nike', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (3, N'Puma', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (4, N'UnderArmour', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (5, N'Lotto', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (6, N'Canterbury', 0)
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/08/2019 19:32:12 ******/
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
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Cliente_1] PRIMARY KEY CLUSTERED 
(
	[nroDoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39622719, 4701655, N'Lucas', N'Martin', N'Urquiza 2223', N'lucas@cliente.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39688520, 4801655, N'Martin', N'Oliveiro', N'Calle falsa 123', N'martin@gmail.com', 0)
/****** Object:  Table [dbo].[Perfil]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[idPerfil] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (1, N'Empleado', 0)
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (2, N'Administrador', 0)
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (3, N'Supervisor', 0)
SET IDENTITY_INSERT [dbo].[Perfil] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[perfil] [int] NULL,
	[email] [varchar](50) NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'admin', N'123', 1, N'admin@gmail.com', 0)
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'juan', N'456', 2, N'juan@gmail.com', 0)
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'martin', N'789', 2, N'martin@gmail.com', 0)
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPrenda](
	[codTipoPrenda] [int] NOT NULL,
	[descrip] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_tipoPrenda] PRIMARY KEY CLUSTERED 
(
	[codTipoPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (1, N'Abrigo', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (2, N'Pantalon', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (3, N'Short', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (4, N'Gorra', NULL)
/****** Object:  Table [dbo].[TipoPago]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPago](
	[codTipoPago] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[codTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (1, N'Credito', 0)
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (2, N'Debito', 0)
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (3, N'Efectivo', 0)
/****** Object:  Table [dbo].[TipoFactura]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoFactura](
	[codTipoFactura] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TipoFactura] ([codTipoFactura], [descripcion]) VALUES (N'A', N'Tipo de factura A')
INSERT [dbo].[TipoFactura] ([codTipoFactura], [descripcion]) VALUES (N'B', N'Tipo de factura B')
INSERT [dbo].[TipoFactura] ([codTipoFactura], [descripcion]) VALUES (N'C', N'Tipo de factura C')
/****** Object:  Table [dbo].[Proveedor]    Script Date: 10/08/2019 19:32:12 ******/
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
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[CUIL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (12313, 454896, N'sgdsgfsd', N'dsgsdg', 0)
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (23131, 78787, N'mmmm', N'jjj', 0)
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (123456, 45665, N'adnanf', N'afnuioasfba', 0)
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (545646, 454564, N'asdsad', N'asdas', 1)
/****** Object:  Table [dbo].[Prenda]    Script Date: 10/08/2019 19:32:12 ******/
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
	[descripcion] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[marca] [int] NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Prenda] PRIMARY KEY CLUSTERED 
(
	[codPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (1, 1, N'S         ', N'AA', 150, 2, 1, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (2, 2, N'L         ', N'AAA', 120, 3, 2, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (3, 1, N'S         ', N'LL', 1200, 11, 2, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (4, 2, N'L         ', N'asd', 150, 200, 3, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (5, 2, N'S         ', N'asd', 150, 150, 3, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (6, 1, N'M         ', N'ss', 150, 10, 1, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (7, 4, N'L         ', N'ss', 150, 20, 6, 0)
/****** Object:  Table [dbo].[Pedido]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[codPedido] [int] NOT NULL,
	[CUIL] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[total] [int] NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[codPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[codFactura] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [varchar](50) NOT NULL,
	[fecha] [date] NOT NULL,
	[codTipoPago] [int] NOT NULL,
	[total] [int] NOT NULL,
	[borrado] [bit] NULL,
	[tipoFactura] [varchar](50) NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[codFactura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[codPedido] [int] NOT NULL,
	[codPrenda] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[codPedido] ASC,
	[codPrenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 10/08/2019 19:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[codVenta] [int] NOT NULL,
	[codPrenda] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[borrado] [bit] NULL,
	[codDetalle] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DetalleVenta_1] PRIMARY KEY CLUSTERED 
(
	[codDetalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Prenda_tipoPrenda1]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[Prenda]  WITH CHECK ADD  CONSTRAINT [FK_Prenda_tipoPrenda1] FOREIGN KEY([tipoPrenda])
REFERENCES [dbo].[TipoPrenda] ([codTipoPrenda])
GO
ALTER TABLE [dbo].[Prenda] CHECK CONSTRAINT [FK_Prenda_tipoPrenda1]
GO
/****** Object:  ForeignKey [FK_Pedido_Proveedor]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Proveedor] FOREIGN KEY([CUIL])
REFERENCES [dbo].[Proveedor] ([CUIL])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Proveedor]
GO
/****** Object:  ForeignKey [FK_Venta_Usuario]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Pedido]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([codPedido])
REFERENCES [dbo].[Pedido] ([codPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
/****** Object:  ForeignKey [FK_DetallePedido_Prenda]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Prenda]
GO
/****** Object:  ForeignKey [FK_DetalleVenta_Prenda]    Script Date: 10/08/2019 19:32:12 ******/
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleVenta_Prenda]
GO
