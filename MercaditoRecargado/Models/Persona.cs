using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MercaditoRecargado.Models
{
    public class Persona
    {
        public Persona()
        {
            this.Clientes = new HashSet<Cliente>();
            this.DireccionClientes = new HashSet<DireccionCliente>();
            this.Empleados = new HashSet<Empleado>();
        }

        public int PersonaID { get; set; }
        //Anotacion para definir una longitud maxima.
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Apellido paterno")]
        //Anotacion para definir una longitud maxima.
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string ApPaterno { get; set; }
        [Display(Name = "Apellido materno")]

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string ApMaterno { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaNac { get; set; }
        [Display(Name = "Género")]
        public string Genero { get; set; }
        [Display(Name = "Código Postal")]
        [StringLength(5, MinimumLength = 5)]
        [Required]
        public string CP { get; set; }
        [Display(Name = "CURP")]
        [StringLength(18, MinimumLength = 18)]
        public string CURP { get; set; }
        [Display(Name = "RFC")]
        [StringLength(13, MinimumLength = 13)]
        public string RFC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DireccionCliente> DireccionClientes { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
