//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mercadito.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int EmpleadoID { get; set; }
        public string CodigoEmpleado { get; set; }
        public string puesto { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public string salario { get; set; }
        public int Estatus { get; set; }
        public int EmpleadoDatos { get; set; }
        public string EmlpleadoUser { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}