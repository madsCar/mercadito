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
    public class CategoriasProductoesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: CategoriasProductoes
        public ActionResult Index()
        {
            return View(db.CategoriasProducto.ToList());
        }

        // GET: CategoriasProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProducto.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // GET: CategoriasProductoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriasProductoID,Descripcion")] CategoriasProducto categoriasProducto)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasProducto.Add(categoriasProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriasProducto);
        }

        // GET: CategoriasProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProducto.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // POST: CategoriasProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriasProductoID,Descripcion")] CategoriasProducto categoriasProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriasProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriasProducto);
        }

        // GET: CategoriasProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProducto.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // POST: CategoriasProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriasProducto categoriasProducto = db.CategoriasProducto.Find(id);
            db.CategoriasProducto.Remove(categoriasProducto);
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
