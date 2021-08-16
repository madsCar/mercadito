using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Administrator
    {
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public Venta Venta { get; set; }


    }
}