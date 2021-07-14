USE [master]
GO
/****** Object:  Database [Mercadito]    Script Date: 7/14/2021 12:06:08 AM ******/
CREATE DATABASE [Mercadito]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mercadito', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.S2012\MSSQL\DATA\Mercadito.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mercadito_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.S2012\MSSQL\DATA\Mercadito_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mercadito] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mercadito].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mercadito] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mercadito] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mercadito] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mercadito] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mercadito] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mercadito] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mercadito] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Mercadito] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mercadito] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mercadito] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mercadito] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mercadito] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mercadito] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mercadito] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mercadito] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mercadito] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mercadito] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mercadito] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mercadito] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mercadito] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mercadito] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mercadito] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mercadito] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mercadito] SET RECOVERY FULL 
GO
ALTER DATABASE [Mercadito] SET  MULTI_USER 
GO
ALTER DATABASE [Mercadito] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mercadito] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mercadito] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mercadito] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mercadito', N'ON'
GO
USE [Mercadito]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/14/2021 12:06:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoriasProductos]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriasProductos](
	[CategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[fechaRegistro] [datetime] NULL,
	[Estatus] [int] NOT NULL,
	[ClienteDatos] [int] NOT NULL,
	[ClienteUser] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DatosTarjeta]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DatosTarjeta](
	[DatosTarjetaID] [int] IDENTITY(1,1) NOT NULL,
	[Last4] [int] NOT NULL,
	[NumeroTarjeta] [binary](20) NOT NULL,
	[FechaVencimiento] [int] NOT NULL,
	[CVV] [binary](20) NOT NULL,
	[ClienteTarjeta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DatosTarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DireccionCliente]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DireccionCliente](
	[DireccionClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Calle] [varchar](25) NOT NULL,
	[NumeroExterior] [int] NOT NULL,
	[NumeroInterior] [int] NOT NULL,
	[Referencia] [varchar](25) NULL,
	[Colonia] [varchar](25) NOT NULL,
	[Municipio] [varchar](25) NOT NULL,
	[Estado] [varchar](25) NOT NULL,
	[CodigoPostal] [varchar](5) NOT NULL,
	[PersonaDireccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DireccionClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[CodigoEmpleado] [varchar](5) NOT NULL,
	[puesto] [varchar](15) NOT NULL,
	[fechaIngreso] [date] NULL,
	[salario] [varchar](10) NOT NULL,
	[Estatus] [int] NOT NULL,
	[EmpleadoDatos] [int] NOT NULL,
	[EmlpleadoUser] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CodigoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaID] [int] IDENTITY(1,1) NOT NULL,
	[clienteFactura] [int] NOT NULL,
	[ventaFactura] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FacturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[ApPaterno] [varchar](25) NOT NULL,
	[ApMaterno] [varchar](25) NOT NULL,
	[FechaNac] [date] NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Genero] [varchar](1) NULL,
	[Estado] [varchar](25) NOT NULL,
	[Ciudad] [varchar](25) NOT NULL,
	[CP] [varchar](5) NOT NULL,
	[CURP] [varchar](18) NULL,
	[RFC] [varchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](15) NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[Estatus] [int] NOT NULL,
	[Precio] [decimal](6, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[VentaDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[FolioVenta] [int] NOT NULL,
	[Precio] [decimal](6, 2) NOT NULL,
	[cantidad] [decimal](6, 3) NOT NULL,
	[ProductoID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VentaDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 7/14/2021 12:06:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[FolioVenta] [int] IDENTITY(1,1) NOT NULL,
	[clienteVenta] [int] NOT NULL,
	[fechaVenta] [datetime] NOT NULL,
	[TarjetaVenta] [int] NOT NULL,
	[DireccionVenta] [int] NOT NULL,
	[RequirioFactura] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FolioVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/14/2021 12:06:09 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((1)) FOR [Estatus]
GO
ALTER TABLE [dbo].[Empleado] ADD  DEFAULT ((0)) FOR [salario]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [Estatus]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT ((0)) FOR [RequirioFactura]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_ClienteDatos] FOREIGN KEY([ClienteDatos])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_ClienteDatos]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_ClienteUser] FOREIGN KEY([ClienteUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_ClienteUser]
GO
ALTER TABLE [dbo].[DatosTarjeta]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTarjeta] FOREIGN KEY([ClienteTarjeta])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[DatosTarjeta] CHECK CONSTRAINT [FK_ClienteTarjeta]
GO
ALTER TABLE [dbo].[DireccionCliente]  WITH CHECK ADD  CONSTRAINT [FK_PersonaDireccion] FOREIGN KEY([PersonaDireccion])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[DireccionCliente] CHECK CONSTRAINT [FK_PersonaDireccion]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmlpleadoUser] FOREIGN KEY([EmlpleadoUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmlpleadoUser]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDatos] FOREIGN KEY([EmpleadoDatos])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoDatos]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_clienteFactura] FOREIGN KEY([clienteFactura])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_clienteFactura]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_ventaFactura] FOREIGN KEY([ventaFactura])
REFERENCES [dbo].[Ventas] ([FolioVenta])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_ventaFactura]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaID] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[CategoriasProductos] ([CategoriaID])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_CategoriaID]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FolioVenta] FOREIGN KEY([FolioVenta])
REFERENCES [dbo].[Ventas] ([FolioVenta])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_FolioVenta]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ProductoID] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_ProductoID]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_clienteVenta] FOREIGN KEY([clienteVenta])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_clienteVenta]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_DireccionVenta] FOREIGN KEY([DireccionVenta])
REFERENCES [dbo].[DireccionCliente] ([DireccionClienteID])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_DireccionVenta]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_TarjetaVenta] FOREIGN KEY([TarjetaVenta])
REFERENCES [dbo].[DatosTarjeta] ([DatosTarjetaID])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_TarjetaVenta]
GO
USE [master]
GO
ALTER DATABASE [Mercadito] SET  READ_WRITE 
GO
