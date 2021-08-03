using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
       
        public int Estatus { get; set; }
        public double Precio { get; set; }
        [Display(Name = "Categoría")]
        public int CategoriasProductoID { get; set; }

        public virtual CategoriasProducto CategoriasProducto { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}