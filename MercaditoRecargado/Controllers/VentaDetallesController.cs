using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MercaditoRecargado.Models;
using Microsoft.AspNet.Identity;

namespace MercaditoRecargado.Controllers
{
    [Authorize(Roles = "Admin, Empleado, Cliente")]
    public class VentaDetallesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: VentaDetalles
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            var venta = db.Venta.Where(e => e.Estatus != "Finalizado").ToList();

            return View(venta.ToList());
        }

        public ActionResult PedidosEmpleado()
        {

            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
        
          
            var user = User.Identity.GetUserId();
            var empleado = db.Empleado.Where(e => e.EmpleadoUser == user).ToList();
           
            Empleado _empleado = new Empleado(); 
            
     
            foreach (var item in empleado)
            {
                _empleado = item;

            }

           
            var _venta = db.Venta.Where(e => e.EmpleadoID == _empleado.EmpleadoID).Where(e => e.Estatus !="Finalizado").ToList();
        
           
         

            return View(_venta);
        }

        // GET: VentaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            VentaDetalle ventaDetalle = new VentaDetalle();
            var vDetalle = db.VentaDetalle.ToList();
            foreach(VentaDetalle x in vDetalle)
            {
                if(x.VentaID == id)
                {
                    venta.VentaDetalles.Add(x);
                }
            }
            List<SelectListItem> listEmpleado;
            var empleado = db.Empleado.ToList();
            listEmpleado = new List<SelectListItem>();
            foreach (var item in empleado)
            {
                if (item.puesto.Equals("Repartidor")) {
                    listEmpleado.Add(new SelectListItem
                    {
                        Text = item.Persona.Nombre + " " + item.Persona.ApPaterno + " " + item.Persona.ApMaterno,
                        Value = item.EmpleadoID.ToString()
                    });
                }
            }
            ViewBag.EmpleadoID = listEmpleado;

            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Datails Post
        public ActionResult Details(Venta venta)
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (ModelState.IsValid)
            {
                venta.Estatus = "En proceso";
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

            // GET: VentaDetalles/Create
            public ActionResult Create()
        {
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Request.IsAuthenticated && User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Session["cart"] == null)
            {
                return RedirectToAction("ProductoCliente", "Productoes");


            }


            Venta venta = new Venta();
            Cliente client = new Cliente();
            var user = User.Identity.GetUserId();
            var clientesID = db.Cliente.Where(c => c.ClienteUser == user).ToList();
            List<SelectListItem> dir;
            List<SelectListItem> tar;
            dir = new List<SelectListItem>();
            tar = new List<SelectListItem>();
            foreach (var item in clientesID)
            {
                client = item;
               
            }
            client = db.Cliente.Find(client.ClienteID);
           // client.Persona = db.Personas.Find(client.PersonaID);
            var direccion = db.DireccionCliente.Where(c => c.PersonaID == client.PersonaID).ToList();
            var tarjeta = db.DatosTarjeta.Where(c => c.ClienteID == client.ClienteID).ToList();
            foreach (DatosTarjeta x in tarjeta)
            {

               

                    client.DatosTarjetas.Add(x);
                    tar.Add(new SelectListItem
                    {
                        Text = "**** **** **** "+x.Last4.ToString(),
                        Value = x.DatosTarjetaID.ToString()
                    });
                
            } 
            foreach (DireccionCliente x in direccion)
            {
                
                    client.Persona.DireccionClientes.Add(x);
                    dir.Add(new SelectListItem
                    {
                        Text = x.Calle+","+x.NumeroExterior+","+x.Colonia,
                        Value = x.DireccionClienteID.ToString()
                    });
                
            }
            List<SelectListItem> listHorarios;
            listHorarios = new List<SelectListItem>();
        
        
            ViewBag.DatosTarjetaID = tar;
            ViewBag.DireccionClienteID = dir;
            ViewBag.HoraEntrega = listHorarios;
            venta.Cliente = client;
            //ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre");
            return View(venta);
        }

        // POST: VentaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venta venta)
        {
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Request.IsAuthenticated && User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (venta.DireccionClienteID==0)
            {
                return RedirectToAction("Create", "VentaDetalles");
            }
            if (venta.DatosTarjetaID == 0)
            {
                return RedirectToAction("Create", "VentaDetalles");
            }
            List<Item> cart = (List<Item>)Session["cart"];
   
            VentaDetalle vdetalle = new VentaDetalle();
            Cliente client = new Cliente();
            var total = cart.Sum(item => item.Producto.Precio * item.Quantity);
            var user = User.Identity.GetUserId();
            var clientesID = db.Cliente.SqlQuery("select * from Clientes where Clientes.ClienteUser = '" + user + "'").ToList();
            foreach (Cliente item in clientesID)
            {
                venta.clienteID = item.ClienteID;
                client = item;
            }

            venta.fechaVenta = DateTime.Now;
            
            venta.Total = (decimal)total;
            venta.Estatus = "Creado";
            venta.RequirioFactura = 0;
            db.Venta.Add(venta);
            db.SaveChanges();
            // if (ModelState.IsValid)
            // {

            foreach (Item item in (List<Item>)Session["cart"])
                {

                vdetalle.VentaID = venta.VentaID;
                vdetalle.Precio = (decimal)item.Producto.Precio;
                vdetalle.Cantidad = item.Quantity;
                vdetalle.ProductoID = item.Producto.ProductoID;
                db.VentaDetalle.Add(vdetalle);
                db.SaveChanges();
                
            }
            Session["cart"] = null;
            return RedirectToAction("GraciasPorsuCompra", "Ventas");
           // }

           // ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre", ventaDetalle.ProductoID);
           // return View(ventaDetalle);
        }

        // GET: VentaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            VentaDetalle ventaDetalle = new VentaDetalle();
            var vDetalle = db.VentaDetalle.ToList();
            foreach (VentaDetalle x in vDetalle)
            {
                if (x.VentaID == id)
                {
                    venta.VentaDetalles.Add(x);
                }
            }
           

            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }


        // POST: VentaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venta venta)
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (ModelState.IsValid)
            {
                venta.Estatus = "Finalizado";
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PedidosEmpleado");
            }

            return View();
        }

        // GET: VentaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle ventaDetalle = db.VentaDetalle.Find(id);
            if (ventaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ventaDetalle);
        }

        // POST: VentaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaDetalle ventaDetalle = db.VentaDetalle.Find(id);
            db.VentaDetalle.Remove(ventaDetalle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
