using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MercaditoRecargado.Models;

namespace MercaditoRecargado.Controllers
{
    public class ClientesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();
        private string FechaTemp;
        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Cliente.Include(c => c.Persona);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {

            if (ModelState.IsValid)
            {



                // if (Request.IsAuthenticated && User.IsInRole("Admin") || User.IsInRole("Empleado"))
                // {
                //      cliente.ClienteUser = null;
                //  }
                try
                {
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.Estatus = 1;
                    var datos = TempData["data"] as string;
                    cliente.ClienteUser = datos;
                    db.Personas.Add(cliente.Persona);
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {

                    Console.WriteLine(e);
                }

                if (Request.IsAuthenticated && User.IsInRole("Admin") || User.IsInRole("Empleado"))
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    return Redirect("~/Account/Login");
                }




            }

            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.ClienteDatos);
            return View(cliente);
        }




        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            FechaTemp = cliente.Persona.FechaNac.ToString();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.ClienteDatos);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                 
                db.Entry(cliente.Persona).State = EntityState.Modified;
          
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.ClienteDatos);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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