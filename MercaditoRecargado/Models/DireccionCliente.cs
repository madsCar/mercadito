using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace MercaditoRecargado.Models
{
    
    public class DireccionCliente
    {
        public DireccionCliente()
        {
            this.Ventas = new HashSet<Venta>();
        }

        public int DireccionClienteID { get; set; }

        [Display(Name = "Domicilio de entrega")]
        public string Calle { get; set; }
        public int NumeroExterior { get; set; }
        public int NumeroInterior { get; set; }
        public string Referencia { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public int? PersonaID { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual Persona Persona { get; set; }
    }
}