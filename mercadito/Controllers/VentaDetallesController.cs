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
    public class VentaDetallesController : Controller
    {
        private MercaditoEntities db = new MercaditoEntities();

        // GET: VentaDetalles
        public ActionResult Index()
        {
            var ventaDetalles = db.VentaDetalles.Include(v => v.Producto).Include(v => v.Venta);
            return View(ventaDetalles.ToList());
        }

        // GET: VentaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle ventaDetalle = db.VentaDetalles.Find(id);
            if (ventaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ventaDetalle);
        }

        // GET: VentaDetalles/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "nombre");
            ViewBag.FolioVenta = new SelectList(db.Ventas, "FolioVenta", "FolioVenta");
            return View();
        }

        // POST: VentaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaDetalleID,FolioVenta,Precio,cantidad,ProductoID")] VentaDetalle ventaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.VentaDetalles.Add(ventaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "nombre", ventaDetalle.ProductoID);
            ViewBag.FolioVenta = new SelectList(db.Ventas, "FolioVenta", "FolioVenta", ventaDetalle.FolioVenta);
            return View(ventaDetalle);
        }

        // GET: VentaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle ventaDetalle = db.VentaDetalles.Find(id);
            if (ventaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "nombre", ventaDetalle.ProductoID);
            ViewBag.FolioVenta = new SelectList(db.Ventas, "FolioVenta", "FolioVenta", ventaDetalle.FolioVenta);
            return View(ventaDetalle);
        }

        // POST: VentaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaDetalleID,FolioVenta,Precio,cantidad,ProductoID")] VentaDetalle ventaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.Productoes, "ProductoID", "nombre", ventaDetalle.ProductoID);
            ViewBag.FolioVenta = new SelectList(db.Ventas, "FolioVenta", "FolioVenta", ventaDetalle.FolioVenta);
            return View(ventaDetalle);
        }

        // GET: VentaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle ventaDetalle = db.VentaDetalles.Find(id);
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
            VentaDetalle ventaDetalle = db.VentaDetalles.Find(id);
            db.VentaDetalles.Remove(ventaDetalle);
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
