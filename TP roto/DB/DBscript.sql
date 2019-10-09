USE [master]
GO
/****** Object:  Database [Canario]    Script Date: 08/10/2019 22:53:09 ******/
CREATE DATABASE [Canario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Canario', FILENAME = N'C:\Users\Lucas\Canario.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Canario_log', FILENAME = N'C:\Users\Lucas\Canario_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Canario] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [Canario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Canario] SET  MULTI_USER 
GO
ALTER DATABASE [Canario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Canario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Canario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Canario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Canario]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 08/10/2019 22:53:09 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idVentaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NOT NULL,
	[idPrenda] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[cantidad] [decimal](18, 0) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[idVentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[legajo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 08/10/2019 22:53:09 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[idPerfil] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prenda]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[codTipoPago] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[codTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPrenda](
	[codTipoPrenda] [int] NOT NULL,
	[descrip] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_tipoPrenda] PRIMARY KEY CLUSTERED 
(
	[codTipoPrenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[codVenta] [int] NOT NULL,
	[idUsuario] [varchar](50) NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[codTipoPago] [int] NOT NULL,
	[hora] [datetime] NOT NULL,
	[total] [int] NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[codVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaTransaccion]    Script Date: 08/10/2019 22:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaTransaccion](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[nroFactura] [int] NULL,
	[fecha] [date] NOT NULL,
	[cliente] [varchar](50) NULL,
	[tipoFactura] [char](1) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_VentaTransaccion] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (5555555, 44455522, N'Hola', N'Chau', N'CALLE FALSA 123', N'asd@gmail.com', 0)
GO
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39622450, 47011155, N'Gaston', N'Romag', N'VCP 2223', N'gasRo@gmail.com', 0)
GO
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39622725, 4701550, N'Gabriel', N'Boett', N'Urquiza 2230', N'gabBoet@gmail.com', 0)
GO
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'73841', N'Nicolas', N'Sivoff', 0)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (1, N'Adidas', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (2, N'Nike', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (3, N'Puma', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (4, N'UnderArmour', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (5, N'Lotto', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (6, N'Canterbury', NULL)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (99, N'Samsung', 1)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (100, N'vevo', 0)
GO
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (123, N'vevolante', 0)
GO
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (1, N'Administrador', 0)
GO
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (2, N'Empleado1', 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (1, 1, N'S         ', N'AA', 150, 2, 1, 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (2, 2, N'S         ', N'Anda', 120, 120, 2, 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (3, 1, N'S         ', N'andoasdd', 500, 2, 3, 1)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (222, 2, N'L         ', N'AAA', 120, 3, 2, 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (444, 1, N'A         ', N'LL', 120, 1, 3, 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (500, 1, N'S         ', N'asd', 150, 50, 4, 0)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (8999, 2, N'S         ', N'1233', 123, 123, 3, 1)
GO
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (9999, 2, N'S         ', N'asd', 5, 10, 2, 1)
GO
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (0, N'Efectivo', 0)
GO
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (1, N'Tarjeta', 0)
GO
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (2, N'Debito', 0)
GO
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (3, N'Transaccion Bancaria', 0)
GO
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (1, N'Abrigo', NULL)
GO
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (2, N'Pantalon', NULL)
GO
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (3, N'Short', NULL)
GO
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (4, N'Gorra', NULL)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'123', N'123', 1, N'123', 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'123333', N'123', 1, N'1233', 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'333', N'33', 1, N'333', 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'admin', N'123', 1, N'admin@gmail.com', 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'juan', N'456', 2, N'juan@gmail.com', 0)
GO
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'martin', N'789', 2, N'martin@gmail.com', 0)
GO
ALTER TABLE [dbo].[DetalleVenta] ADD  CONSTRAINT [DF_DetalleVenta_borrado]  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[VentaTransaccion] ADD  CONSTRAINT [DF_VentaTransaccion_borrado]  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([codPedido])
REFERENCES [dbo].[Pedido] ([codPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Prenda]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Proveedor] FOREIGN KEY([CUIL])
REFERENCES [dbo].[Proveedor] ([CUIL])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Proveedor]
GO
ALTER TABLE [dbo].[Prenda]  WITH CHECK ADD  CONSTRAINT [FK_Prenda_tipoPrenda1] FOREIGN KEY([tipoPrenda])
REFERENCES [dbo].[TipoPrenda] ([codTipoPrenda])
GO
ALTER TABLE [dbo].[Prenda] CHECK CONSTRAINT [FK_Prenda_tipoPrenda1]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Canario] SET  READ_WRITE 
GO
