using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class DireccionCliente
    {
        public DireccionCliente()
        {
            this.Ventas = new HashSet<Venta>();
        }

        public int DireccionClienteID { get; set; }
        public string Calle { get; set; }
        public int NumeroExterior { get; set; }
        public int NumeroInterior { get; set; }
        public string Referencia { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public int PersonaDireccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual Persona Persona { get; set; }
    }
}