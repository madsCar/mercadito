using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Producto
    {
        public Producto()
        {
            this.VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int ProductoID { get; set; }
        public string nombre { get; set; }
        public int CategoriaID { get; set; }
        public int Estatus { get; set; }
        public decimal Precio { get; set; }

        public virtual CategoriasProducto CategoriasProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}