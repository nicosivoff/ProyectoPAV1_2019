USE [Canario]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 13/11/2019 21:34:43 ******/
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
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[Pedido]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[Perfil]    Script Date: 13/11/2019 21:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[idPerfil] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prenda]    Script Date: 13/11/2019 21:34:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 13/11/2019 21:34:44 ******/
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
/****** Object:  Table [dbo].[TipoFactura]    Script Date: 13/11/2019 21:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoFactura](
	[codTipoFac] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoFactura] PRIMARY KEY CLUSTERED 
(
	[codTipoFac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 13/11/2019 21:34:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPrenda]    Script Date: 13/11/2019 21:34:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/11/2019 21:34:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 13/11/2019 21:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[idVenta] [int] NOT NULL,
	[idPrenda] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[borrado] [bit] NOT NULL,
	[idVentaDetalle] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_VentaDetalle] PRIMARY KEY CLUSTERED 
(
	[idVentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VentaTransaccion]    Script Date: 13/11/2019 21:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentaTransaccion](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[cliente] [varchar](50) NULL,
	[tipoFactura] [varchar](50) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[borrado] [bit] NOT NULL CONSTRAINT [DF_VentaTransaccion_borrado]  DEFAULT ((0)),
 CONSTRAINT [PK_VentaTransaccion] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (28654784, 4658596, N'Lucia', N'Cabello', N'Fuerza Aerea 3100', N'lucabello@gmail.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (31654856, 4602496, N'Dayro', N'Moreno', N'Velez Sarfield', N'dayromoreno@gmail.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (35625748, 4658795, N'Hector', N'Garcia', N'Esmeralda 3554', N'hgarcia@gmail.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39622450, 4651425, N'Gaston', N'Romag', N'Obispo Trejo 223', N'gasRo@gmail.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (39622725, 4701550, N'Gabriel', N'Boett', N'Urquiza 2230', N'gabBoet@gmail.com', 0)
INSERT [dbo].[Cliente] ([nroDoc], [telefono], [nombre], [apellido], [domicilio], [email], [borrado]) VALUES (40245888, 4657713, N'Ana', N'Sanchez', N'Tronador 1544', N'sanchezana@gmail.com', 0)
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'69980', N'Martin', N'Oliverio', 0)
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'70246', N'Lucas', N'Martin', 0)
INSERT [dbo].[Empleado] ([legajo], [nombre], [apellido], [borrado]) VALUES (N'73841', N'Nicolas', N'Sivoff', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (1, N'Adidas', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (2, N'Nike', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (3, N'Puma', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (4, N'UnderArmour', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (5, N'Lotto', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (6, N'Givova', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (7, N'Penalty', 0)
INSERT [dbo].[Marca] ([idMarca], [nombre], [borrado]) VALUES (8, N'Umbro', 0)
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Perfil] ([idPerfil], [nombre], [borrado]) VALUES (2, N'Empleado', 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (1, 1, N'S         ', N'Campera', 1200, 20, 1, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (2, 2, N'S         ', N'Jean', 3000, 120, 2, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (3, 1, N'S         ', N'Tapado', 3500, 20, 3, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (4, 2, N'L         ', N'Joggin', 800, 31, 2, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (5, 1, N'A         ', N'Buzo', 750, 12, 3, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (6, 1, N'S         ', N'Chaqueta', 750, 50, 4, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (7, 3, N'S         ', N'Short negro', 350, 25, 8, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (8, 3, N'S         ', N'Short gimnasia', 325, 15, 5, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (9, 3, N'M         ', N'Short blanco', 350, 25, 8, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (10, 4, N'M         ', N'Gorra violeta', 500, 10, 6, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (11, 4, N'M         ', N'Gorra verde', 550, 10, 7, 0)
INSERT [dbo].[Prenda] ([codPrenda], [tipoPrenda], [talle], [descripcion], [precio], [cantidad], [marca], [borrado]) VALUES (12, 4, N'S         ', N'Gorra rosa', 550, 10, 7, 0)
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (21546, 4657833, N'La Pampa 554', N'SportAR', 0)
INSERT [dbo].[Proveedor] ([CUIL], [telefono], [direccion], [razonSocial], [borrado]) VALUES (61854, 4501299, N'Buenos Aires 456', N'FitSport', 0)
INSERT [dbo].[TipoFactura] ([codTipoFac], [descripcion]) VALUES (N'A', N'Tipo de factura A')
INSERT [dbo].[TipoFactura] ([codTipoFac], [descripcion]) VALUES (N'B', N'Tipo de factura B')
INSERT [dbo].[TipoFactura] ([codTipoFac], [descripcion]) VALUES (N'C', N'Tipo de factura C')
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (0, N'Efectivo', 0)
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (1, N'Tarjeta', 0)
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (2, N'Debito', 0)
INSERT [dbo].[TipoPago] ([codTipoPago], [nombre], [borrado]) VALUES (3, N'Transaccion Bancaria', 0)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (1, N'Abrigo', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (2, N'Pantalon', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (3, N'Short', NULL)
INSERT [dbo].[TipoPrenda] ([codTipoPrenda], [descrip], [borrado]) VALUES (4, N'Gorra', NULL)
INSERT [dbo].[Usuario] ([idUsuario], [contraseña], [perfil], [email], [borrado]) VALUES (N'admin', N'123', 1, N'admin@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[VentaDetalle] ON 

INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (2, 2, 120, 1, 0, 1)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (3, 2, 120, 3, 0, 2)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (4, 2, 120, 2, 0, 3)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (4, 444, 120, 1, 0, 4)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (4, 500, 150, 2, 0, 5)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (5, 10, 500, 1, 0, 6)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (5, 6, 750, 1, 0, 7)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (6, 5, 750, 2, 0, 8)
INSERT [dbo].[VentaDetalle] ([idVenta], [idPrenda], [precio], [cantidad], [borrado], [idVentaDetalle]) VALUES (6, 12, 550, 1, 0, 9)
SET IDENTITY_INSERT [dbo].[VentaDetalle] OFF
SET IDENTITY_INSERT [dbo].[VentaTransaccion] ON 

INSERT [dbo].[VentaTransaccion] ([idVenta], [fecha], [cliente], [tipoFactura], [subtotal], [borrado]) VALUES (2, CAST(N'2019-10-21' AS Date), N'39622450', N'A', CAST(120.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[VentaTransaccion] ([idVenta], [fecha], [cliente], [tipoFactura], [subtotal], [borrado]) VALUES (3, CAST(N'2019-10-21' AS Date), N'39622450', N'C', CAST(360.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[VentaTransaccion] ([idVenta], [fecha], [cliente], [tipoFactura], [subtotal], [borrado]) VALUES (4, CAST(N'2019-10-21' AS Date), N'39622450', N'B', CAST(660.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[VentaTransaccion] ([idVenta], [fecha], [cliente], [tipoFactura], [subtotal], [borrado]) VALUES (5, CAST(N'2019-11-12' AS Date), N'31654856', N'C', CAST(1250.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[VentaTransaccion] ([idVenta], [fecha], [cliente], [tipoFactura], [subtotal], [borrado]) VALUES (6, CAST(N'2019-11-12' AS Date), N'28654784', N'C', CAST(2050.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[VentaTransaccion] OFF
ALTER TABLE [dbo].[DetalleVenta] ADD  CONSTRAINT [DF_DetalleVenta_borrado]  DEFAULT ((0)) FOR [borrado]
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
