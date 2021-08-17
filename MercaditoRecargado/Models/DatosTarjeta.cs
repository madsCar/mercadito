﻿using System;
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
        public string NumeroTarjeta { get; set; }
        public int FechaVencimiento { get; set; }
        public string CVV { get; set; }
        public int? ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
