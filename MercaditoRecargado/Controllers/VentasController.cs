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
    [Authorize(Roles = "Cliente")]
    public class VentasController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: Ventas
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            var user = User.Identity.GetUserId();
            var cliente = db.Cliente.Where(e => e.ClienteUser == user).ToList();

            Cliente _cliente = new Cliente();


            foreach (var item in cliente)
            {
                _cliente = item;

            }


            var _venta = db.Venta.Where(e => e.clienteID == _cliente.ClienteID).OrderByDescending(e => e.HoraEntrega).OrderByDescending(e => e.FechaEntrega).ToList();




            return View(_venta);
        }
        public ActionResult GraciasPorsuCompra()
        {
            return View();
        }

            // GET: Ventas/Details/5
            public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated && User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Productoes");


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

        // GET: Ventas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaID,clienteVenta,fechaVenta,TarjetaVenta,DireccionVenta,RequirioFactura")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaID,clienteVenta,fechaVenta,TarjetaVenta,DireccionVenta,RequirioFactura")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
