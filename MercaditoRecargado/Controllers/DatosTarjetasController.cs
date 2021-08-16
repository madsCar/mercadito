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
    [Authorize(Roles = "Cliente")]
    public class DatosTarjetasController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: DatosTarjetas
        public ActionResult Index()
        {
            return View(db.DatosTarjeta.ToList());
        }

        // GET: DatosTarjetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjeta.Find(id);
            if (datosTarjeta == null)
            {
                return HttpNotFound();
            }
            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatosTarjetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatosTarjetaID,Last4,NumeroTarjeta,FechaVencimiento,CVV,ClienteID")] DatosTarjeta datosTarjeta)
        {
            if (ModelState.IsValid)
            {
                db.DatosTarjeta.Add(datosTarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjeta.Find(id);
            if (datosTarjeta == null)
            {
                return HttpNotFound();
            }
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
            return View(datosTarjeta);
        }

        // GET: DatosTarjetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosTarjeta datosTarjeta = db.DatosTarjeta.Find(id);
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
            DatosTarjeta datosTarjeta = db.DatosTarjeta.Find(id);
            db.DatosTarjeta.Remove(datosTarjeta);
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
