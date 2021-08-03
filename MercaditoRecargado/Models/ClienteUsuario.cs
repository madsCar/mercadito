using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class ClienteUsuario
    {
        public  ApplicationUser Usuario { get; set; }
        public  Cliente Cliente { get; set; }
    }
}