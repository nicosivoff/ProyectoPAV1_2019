USE [master]
GO
/****** Object:  Database [Canario]    Script Date: 18/09/2019 21:10:55 ******/
CREATE DATABASE [Canario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Canario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Canario.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Canario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Canario_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [Canario] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Canario]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 18/09/2019 21:10:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 18/09/2019 21:10:56 ******/
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
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[codVenta] [int] NOT NULL,
	[codPrenda] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[codVenta] ASC,
	[codPrenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 18/09/2019 21:10:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 18/09/2019 21:10:56 ******/
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
/****** Object:  Table [dbo].[Pedido]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[codPedido] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Prenda]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prenda](
	[codPrenda] [int] IDENTITY(1,1) NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 18/09/2019 21:10:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPago](
	[codTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[codTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPrenda](
	[codTipoPrenda] [int] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](50) NOT NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_tipoPrenda] PRIMARY KEY CLUSTERED 
(
	[codTipoPrenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/09/2019 21:10:56 ******/
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
	[borrado] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 18/09/2019 21:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[codVenta] [int] IDENTITY(1,1) NOT NULL,
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
SET ANSI_PADDING OFF
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
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Prenda] FOREIGN KEY([codPrenda])
REFERENCES [dbo].[Prenda] ([codPrenda])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Prenda]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([codVenta])
REFERENCES [dbo].[Venta] ([codVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Venta]
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
