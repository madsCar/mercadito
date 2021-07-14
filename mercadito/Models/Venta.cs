//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mercadito.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.Facturas = new HashSet<Factura>();
            this.VentaDetalles = new HashSet<VentaDetalle>();
        }
    
        public int FolioVenta { get; set; }
        public int clienteVenta { get; set; }
        public System.DateTime fechaVenta { get; set; }
        public int TarjetaVenta { get; set; }
        public int DireccionVenta { get; set; }
        public int RequirioFactura { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual DatosTarjeta DatosTarjeta { get; set; }
        public virtual DireccionCliente DireccionCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Facturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}