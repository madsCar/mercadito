using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class DireccionTarjetaCliente
    {
        public DatosTarjeta DatosTarjeta { get; set; }
        public  DireccionCliente DatoDireccionClientes{ get; set; }
    }
}