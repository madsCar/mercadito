using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace MercaditoRecargado.Models
{
    public class ClienteUsuario
    {
        public ApplicationUser Usuario { get; set; }
        public Cliente Cliente { get; set; }
    }
}