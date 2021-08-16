using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Categoría")]
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productoes { get; set; }
    }
}