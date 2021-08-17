using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class EmpleadoUsuario
    {
        public ApplicationUser Usuario { get; set; }
        public RegisterViewModel UsuarioR { get; set; }
        public Empleado Empleado { get; set; }
    }
}