using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IdentitySample.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MercaditoRecargado.Models
{
    public class ClientesModelContext :DbContext
    {
        public ClientesModelContext() : base("name=Mercadito") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
           

        //Definimos todos lo datasets
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<DatosTarjeta> DatosTarjeta { get; set; }
        public virtual DbSet<CategoriasProducto> CategoriasProducto { get; set; }
        public virtual DbSet<DireccionCliente> DireccionCliente { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }
      //  public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        

    }
}