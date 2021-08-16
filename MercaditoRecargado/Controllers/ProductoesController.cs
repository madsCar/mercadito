using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MercaditoRecargado.Models;
using Microsoft.AspNet.Identity;

namespace MercaditoRecargado.Controllers
{
    

    public class ProductoesController : Controller
    {
       
        private ClientesModelContext db = new ClientesModelContext();

        // GET: Productoes
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }

            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            var producto = db.Producto.Include(c => c.CategoriasProducto);
            return View(producto.ToList());
        }

        public ActionResult ProductoCliente()
        {

            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            if (Request.IsAuthenticated && User.IsInRole("Empleado"))
            {
                return RedirectToAction("Index", "Productoes");


            }
            var producto = db.Producto.Include(c => c.CategoriasProducto);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


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
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
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
        public ActionResult Create([Bind(Include = "ProductoID,nombre,CategoriasProductoID,Precio,Imagen")] Producto producto)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (ModelState.IsValid)
            {
                producto.Precio = producto.Precio * 1.4;
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
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
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
        public ActionResult Edit([Bind(Include = "ProductoID,nombre,CategoriasProductoID,Estatus,Precio,Imagen")] Producto producto)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
            if (ModelState.IsValid)
            {
                producto.Precio = producto.Precio * 1.4;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


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
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");


            }
            if (Request.IsAuthenticated && User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index", "Home");


            }
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
