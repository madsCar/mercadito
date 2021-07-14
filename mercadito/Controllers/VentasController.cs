using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mercadito.Models;

namespace mercadito.Controllers
{
    public class VentasController : Controller
    {
        private MercaditoEntities db = new MercaditoEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Cliente).Include(v => v.DatosTarjeta).Include(v => v.DireccionCliente);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.clienteVenta = new SelectList(db.Clientes, "ClienteID", "ClienteUser");
            ViewBag.TarjetaVenta = new SelectList(db.DatosTarjetas, "DatosTarjetaID", "DatosTarjetaID");
            ViewBag.DireccionVenta = new SelectList(db.DireccionClientes, "DireccionClienteID", "Calle");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FolioVenta,clienteVenta,fechaVenta,TarjetaVenta,DireccionVenta,RequirioFactura")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteVenta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", venta.clienteVenta);
            ViewBag.TarjetaVenta = new SelectList(db.DatosTarjetas, "DatosTarjetaID", "DatosTarjetaID", venta.TarjetaVenta);
            ViewBag.DireccionVenta = new SelectList(db.DireccionClientes, "DireccionClienteID", "Calle", venta.DireccionVenta);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteVenta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", venta.clienteVenta);
            ViewBag.TarjetaVenta = new SelectList(db.DatosTarjetas, "DatosTarjetaID", "DatosTarjetaID", venta.TarjetaVenta);
            ViewBag.DireccionVenta = new SelectList(db.DireccionClientes, "DireccionClienteID", "Calle", venta.DireccionVenta);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FolioVenta,clienteVenta,fechaVenta,TarjetaVenta,DireccionVenta,RequirioFactura")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteVenta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", venta.clienteVenta);
            ViewBag.TarjetaVenta = new SelectList(db.DatosTarjetas, "DatosTarjetaID", "DatosTarjetaID", venta.TarjetaVenta);
            ViewBag.DireccionVenta = new SelectList(db.DireccionClientes, "DireccionClienteID", "Calle", venta.DireccionVenta);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
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
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
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
