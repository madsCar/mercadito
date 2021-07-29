using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int clienteFactura { get; set; }
        public int ventaFactura { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Venta Venta { get; set; }
    }
}