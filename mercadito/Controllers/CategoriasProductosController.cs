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
    public class CategoriasProductosController : Controller
    {
        private MercaditoEntities db = new MercaditoEntities();

        // GET: CategoriasProductos
        public ActionResult Index()
        {
            return View(db.CategoriasProductos.ToList());
        }

        // GET: CategoriasProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProductos.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // GET: CategoriasProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaID,Descripcion")] CategoriasProducto categoriasProducto)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasProductos.Add(categoriasProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriasProducto);
        }

        // GET: CategoriasProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProductos.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // POST: CategoriasProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaID,Descripcion")] CategoriasProducto categoriasProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriasProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriasProducto);
        }

        // GET: CategoriasProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasProducto categoriasProducto = db.CategoriasProductos.Find(id);
            if (categoriasProducto == null)
            {
                return HttpNotFound();
            }
            return View(categoriasProducto);
        }

        // POST: CategoriasProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriasProducto categoriasProducto = db.CategoriasProductos.Find(id);
            db.CategoriasProductos.Remove(categoriasProducto);
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
