using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime? FechaNac { get; set; }



        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Domicilio { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(10)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Display(Name = "Género")]
        public string Genero { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Estado { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Ciudad { get; set; }


        [Display(Name = "Código postal")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string CP { get; set; }

        public string RFC { get; set; }

        public string CURP { get; set; }
    

       
        public virtual ICollection<Cliente> Clientes { get; set; }
      
        public virtual ICollection<DireccionCliente> DireccionClientes { get; set; }
      
        public virtual ICollection<Empleado> Empleadoes { get; set; }
    }
}