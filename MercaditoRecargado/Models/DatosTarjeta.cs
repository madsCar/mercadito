using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class DatosTarjeta
    {
        public DatosTarjeta()
        {
            this.Ventas = new HashSet<Venta>();
        }

        public int DatosTarjetaID { get; set; }
        public int Last4 { get; set; }
        public byte[] NumeroTarjeta { get; set; }
        public int FechaVencimiento { get; set; }
        public byte[] CVV { get; set; }
        public int ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}