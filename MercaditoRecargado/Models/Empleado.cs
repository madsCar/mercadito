using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string CodigoEmpleado { get; set; }
        public string puesto { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public string salario { get; set; }
        public int Estatus { get; set; }
        public int PersonaID { get; set; }
        public string EmpleadoUser { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}