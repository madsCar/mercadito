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
    public class DireccionClientesController : Controller
    {
        private MercaditoEntities db = new MercaditoEntities();

        // GET: DireccionClientes
        public ActionResult Index()
        {
            var direccionClientes = db.DireccionClientes.Include(d => d.Persona);
            return View(direccionClientes.ToList());
        }

        // GET: DireccionClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionClientes.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Create
        public ActionResult Create()
        {
            ViewBag.PersonaDireccion = new SelectList(db.Personas, "PersonaID", "Nombre");
            return View();
        }

        // POST: DireccionClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionClienteID,Calle,NumeroExterior,NumeroInterior,Referencia,Colonia,Municipio,Estado,CodigoPostal,PersonaDireccion")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.DireccionClientes.Add(direccionCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaDireccion = new SelectList(db.Personas, "PersonaID", "Nombre", direccionCliente.PersonaDireccion);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionClientes.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaDireccion = new SelectList(db.Personas, "PersonaID", "Nombre", direccionCliente.PersonaDireccion);
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionClienteID,Calle,NumeroExterior,NumeroInterior,Referencia,Colonia,Municipio,Estado,CodigoPostal,PersonaDireccion")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccionCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaDireccion = new SelectList(db.Personas, "PersonaID", "Nombre", direccionCliente.PersonaDireccion);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionClientes.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DireccionCliente direccionCliente = db.DireccionClientes.Find(id);
            db.DireccionClientes.Remove(direccionCliente);
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
