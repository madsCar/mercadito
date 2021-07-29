using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Venta
    {
        public Venta()
        {
            this.Facturas = new HashSet<Factura>();
            this.VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int VentaID { get; set; }
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