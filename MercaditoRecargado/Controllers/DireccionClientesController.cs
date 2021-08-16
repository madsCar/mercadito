using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MercaditoRecargado.Models;

namespace MercaditoRecargado.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class DireccionClientesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: DireccionClientes
        public ActionResult Index()
        {
            //var user = Membership.GetUser().ProviderUserKey;
            return View(db.DireccionCliente.ToList());
        }

        // GET: DireccionClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DireccionClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionClienteID,Calle,NumeroExterior,NumeroInterior,Referencia,Colonia,Municipio,Estado,CodigoPostal,PersonaID")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.DireccionCliente.Add(direccionCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direccionCliente);
        }

        // GET: DireccionClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionClienteID,Calle,NumeroExterior,NumeroInterior,Referencia,Colonia,Municipio,Estado,CodigoPostal,PersonaID")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccionCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
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
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            db.DireccionCliente.Remove(direccionCliente);
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
