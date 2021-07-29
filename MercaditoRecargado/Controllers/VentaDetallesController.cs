using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MercaditoRecargado.Models;

namespace MercaditoRecargado.Controllers
{
    public class VentaDetallesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: VentaDetalles
        public ActionResult Index()
        {
            var ventaDetalle = db.VentaDetalle.Include(v => v.Producto);
            return View(ventaDetalle.ToList());
        }

        // GET: VentaDetalles/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: VentaDetalles/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre");
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
                db.VentaDetalle.Add(ventaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre", ventaDetalle.ProductoID);
            return View(ventaDetalle);
        }

        // GET: VentaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaDetalle ventaDetalle = db.VentaDetalle.Find(id);
            if (ventaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre", ventaDetalle.ProductoID);
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
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "nombre", ventaDetalle.ProductoID);
            return View(ventaDetalle);
        }

        // GET: VentaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
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
