using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class CategoriasProducto
    {
        public CategoriasProducto()
        {
            this.Productoes = new HashSet<Producto>();
        }

        public int CategoriasProductoID { get; set; }
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}