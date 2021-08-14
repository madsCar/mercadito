using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MercaditoRecargado.Models
{
    public class Venta
    {
        public Venta()
        {
            this.Facturas = new HashSet<Factura>();
            this.VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int VentaID { get; set; }

        public int clienteID { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime fechaVenta { get; set; }

        [Display(Name = "Subtotal")]
        public decimal Total { get; set; }

        [Display(Name = "Fecha de entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime FechaEntrega { get; set; }

        [StringLength(60, MinimumLength = 10)]
        [Required]
        public string HoraEntrega { get; set; }
        [Display(Name = "Estatus del Pedido")]
        public string Estatus { get; set; }

        [Required]
        public int DatosTarjetaID { get; set; }
        [Required]
        public int DireccionClienteID { get; set; }
        public int RequirioFactura { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual DatosTarjeta DatosTarjeta { get; set; }
        public virtual DireccionCliente DireccionCliente { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
 
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}