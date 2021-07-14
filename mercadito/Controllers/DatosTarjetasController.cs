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
    public class DatosTarjetasController : Controller
    {
        private MercaditoEntities db = new MercaditoEntities();

        // GET: DatosTarjetas
        public ActionResult Index()
        {
            var datosTarjetas = db.DatosTarjetas.Include(d => d.Cliente);
            return View(datosTarjetas.ToList());
        }

        // GET: DatosTarjetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjetas.Find(id);
            if (datosTarjeta == null)
            {
                return HttpNotFound();
            }
            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteTarjeta = new SelectList(db.Clientes, "ClienteID", "ClienteUser");
            return View();
        }

        // POST: DatosTarjetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosTarjetaID,Last4,NumeroTarjeta,FechaVencimiento,CVV,ClienteTarjeta")] DatosTarjeta datosTarjeta)
        {
            if (ModelState.IsValid)
            {
                db.DatosTarjetas.Add(datosTarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteTarjeta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", datosTarjeta.ClienteTarjeta);
            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjetas.Find(id);
            if (datosTarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteTarjeta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", datosTarjeta.ClienteTarjeta);
            return View(datosTarjeta);
        }

        // POST: DatosTarjetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatosTarjetaID,Last4,NumeroTarjeta,FechaVencimiento,CVV,ClienteTarjeta")] DatosTarjeta datosTarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosTarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteTarjeta = new SelectList(db.Clientes, "ClienteID", "ClienteUser", datosTarjeta.ClienteTarjeta);
            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjetas.Find(id);
            if (datosTarjeta == null)
            {
                return HttpNotFound();
            }
            return View(datosTarjeta);
        }

        // POST: DatosTarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosTarjeta datosTarjeta = db.DatosTarjetas.Find(id);
            db.DatosTarjetas.Remove(datosTarjeta);
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
