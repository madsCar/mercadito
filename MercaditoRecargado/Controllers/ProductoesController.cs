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
    public class ProductoesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(c => c.CategoriasProducto);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            List<SelectListItem> listCategorias;
        // CARGAMOS EL DropDownList DE REGIONES
        var categoria = db.CategoriasProducto.ToList();
            listCategorias = new List<SelectListItem>();
            foreach (var item in categoria)
            {
                listCategorias.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.CategoriasProductoID.ToString()
                });
            }
            ViewBag.CategoriasProductoID = listCategorias;
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoID,nombre,CategoriasProductoID,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Estatus = 1;
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> listCategorias;
            var categoria = db.CategoriasProducto.ToList();
            listCategorias = new List<SelectListItem>();
            foreach (var item in categoria)
            {
                listCategorias.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.CategoriasProductoID.ToString()
                });
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriasProductoID = listCategorias;
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoID,nombre,CategoriasProductoID,Estatus,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
