using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.Facturas = new HashSet<Factura>();
            this.DatosTarjetas = new HashSet<DatosTarjeta>();
            this.Ventas = new HashSet<Venta>();
        }

        public int ClienteID { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaRegistro { get; set; }
        public int Estatus { get; set; }
        public int PersonaID { get; set; }
        public string ClienteUser { get; set; }

        public virtual Persona Persona { get; set; }
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Facturas { get; set; }
      //  public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosTarjeta> DatosTarjetas { get; set; }
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}