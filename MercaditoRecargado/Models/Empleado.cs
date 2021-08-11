using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string CodigoEmpleado { get; set; }
        public string puesto { get; set; }
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public string salario { get; set; }
        public int Estatus { get; set; }
        public int PersonaID { get; set; }
        public string EmlpleadoUser { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual Persona Persona { get; set; }
    }
}