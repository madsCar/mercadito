using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Persona
    {
        public Persona()
        {
            this.Clientes = new HashSet<Cliente>();
            this.DireccionClientes = new HashSet<DireccionCliente>();
            this.Empleadoes = new HashSet<Empleado>();
        }

        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public Nullable<System.DateTime> FechaNac { get; set; }
        public string Genero { get; set; }
        public string CP { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DireccionCliente> DireccionClientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleadoes { get; set; }
    }
}
