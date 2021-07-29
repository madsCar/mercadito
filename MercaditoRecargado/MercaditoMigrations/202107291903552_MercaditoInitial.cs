namespace MercaditoRecargado.MercaditoMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MercaditoInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasProductoes",
                c => new
                    {
                        CategoriasProductoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriasProductoID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        CategoriaID = c.Int(nullable: false),
                        Estatus = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriasProducto_CategoriasProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.CategoriasProductoes", t => t.CategoriasProducto_CategoriasProductoID)
                .Index(t => t.CategoriasProducto_CategoriasProductoID);
            
            CreateTable(
                "dbo.VentaDetalles",
                c => new
                    {
                        VentaDetalleID = c.Int(nullable: false, identity: true),
                        FolioVenta = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoID = c.Int(nullable: false),
                        Venta_VentaID = c.Int(),
                    })
                .PrimaryKey(t => t.VentaDetalleID)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.Venta_VentaID)
                .Index(t => t.ProductoID)
                .Index(t => t.Venta_VentaID);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        clienteVenta = c.Int(nullable: false),
                        fechaVenta = c.DateTime(nullable: false),
                        TarjetaVenta = c.Int(nullable: false),
                        DireccionVenta = c.Int(nullable: false),
                        RequirioFactura = c.Int(nullable: false),
                        DatosTarjeta_DatosTarjetaID = c.Int(),
                        DireccionCliente_DireccionClienteID = c.Int(),
                        Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.VentaID)
                .ForeignKey("dbo.DatosTarjetas", t => t.DatosTarjeta_DatosTarjetaID)
                .ForeignKey("dbo.DireccionClientes", t => t.DireccionCliente_DireccionClienteID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .Index(t => t.DatosTarjeta_DatosTarjetaID)
                .Index(t => t.DireccionCliente_DireccionClienteID)
                .Index(t => t.Cliente_ClienteID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        fechaRegistro = c.DateTime(),
                        Estatus = c.Int(nullable: false),
                        ClienteDatos = c.Int(nullable: false),
                        ClienteUser = c.String(),
                        Persona_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.Personas", t => t.Persona_PersonaID)
                .Index(t => t.Persona_PersonaID);
            
            CreateTable(
                "dbo.DatosTarjetas",
                c => new
                    {
                        DatosTarjetaID = c.Int(nullable: false, identity: true),
                        Last4 = c.Int(nullable: false),
                        NumeroTarjeta = c.Binary(),
                        FechaVencimiento = c.Int(nullable: false),
                        CVV = c.Binary(),
                        ClienteTarjeta = c.Int(nullable: false),
                        Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.DatosTarjetaID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .Index(t => t.Cliente_ClienteID);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        clienteFactura = c.Int(nullable: false),
                        ventaFactura = c.Int(nullable: false),
                        Cliente_ClienteID = c.Int(),
                        Venta_VentaID = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .ForeignKey("dbo.Ventas", t => t.Venta_VentaID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.Venta_VentaID);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApPaterno = c.String(),
                        ApMaterno = c.String(),
                        FechaNac = c.DateTime(),
                        Genero = c.String(),
                        CP = c.String(),
                        CURP = c.String(),
                        RFC = c.String(),
                    })
                .PrimaryKey(t => t.PersonaID);
            
            CreateTable(
                "dbo.DireccionClientes",
                c => new
                    {
                        DireccionClienteID = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        NumeroExterior = c.Int(nullable: false),
                        NumeroInterior = c.Int(nullable: false),
                        Referencia = c.String(),
                        Colonia = c.String(),
                        Municipio = c.String(),
                        Estado = c.String(),
                        CodigoPostal = c.String(),
                        PersonaDireccion = c.Int(nullable: false),
                        Persona_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => t.DireccionClienteID)
                .ForeignKey("dbo.Personas", t => t.Persona_PersonaID)
                .Index(t => t.Persona_PersonaID);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoID = c.Int(nullable: false, identity: true),
                        CodigoEmpleado = c.String(),
                        puesto = c.String(),
                        fechaIngreso = c.DateTime(),
                        salario = c.String(),
                        Estatus = c.Int(nullable: false),
                        EmpleadoDatos = c.Int(nullable: false),
                        EmlpleadoUser = c.String(),
                        Persona_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoID)
                .ForeignKey("dbo.Personas", t => t.Persona_PersonaID)
                .Index(t => t.Persona_PersonaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VentaDetalles", "Venta_VentaID", "dbo.Ventas");
            DropForeignKey("dbo.Ventas", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Empleadoes", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Ventas", "DireccionCliente_DireccionClienteID", "dbo.DireccionClientes");
            DropForeignKey("dbo.DireccionClientes", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Facturas", "Venta_VentaID", "dbo.Ventas");
            DropForeignKey("dbo.Facturas", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "DatosTarjeta_DatosTarjetaID", "dbo.DatosTarjetas");
            DropForeignKey("dbo.DatosTarjetas", "Cliente_ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.VentaDetalles", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "CategoriasProducto_CategoriasProductoID", "dbo.CategoriasProductoes");
            DropIndex("dbo.Empleadoes", new[] { "Persona_PersonaID" });
            DropIndex("dbo.DireccionClientes", new[] { "Persona_PersonaID" });
            DropIndex("dbo.Facturas", new[] { "Venta_VentaID" });
            DropIndex("dbo.Facturas", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.DatosTarjetas", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Clientes", new[] { "Persona_PersonaID" });
            DropIndex("dbo.Ventas", new[] { "Cliente_ClienteID" });
            DropIndex("dbo.Ventas", new[] { "DireccionCliente_DireccionClienteID" });
            DropIndex("dbo.Ventas", new[] { "DatosTarjeta_DatosTarjetaID" });
            DropIndex("dbo.VentaDetalles", new[] { "Venta_VentaID" });
            DropIndex("dbo.VentaDetalles", new[] { "ProductoID" });
            DropIndex("dbo.Productoes", new[] { "CategoriasProducto_CategoriasProductoID" });
            DropTable("dbo.Empleadoes");
            DropTable("dbo.DireccionClientes");
            DropTable("dbo.Personas");
            DropTable("dbo.Facturas");
            DropTable("dbo.DatosTarjetas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Ventas");
            DropTable("dbo.VentaDetalles");
            DropTable("dbo.Productoes");
            DropTable("dbo.CategoriasProductoes");
        }
    }
}
