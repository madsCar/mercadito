﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class VentaDetalle
    {
        public int VentaDetalleID { get; set; }
        public int VentaID { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int ProductoID { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}