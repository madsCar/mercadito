using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MercaditoRecargado.Models;
using Microsoft.AspNet.Identity;

namespace MercaditoRecargado.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class DatosTarjetasController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        // GET: DatosTarjetas
        public async Task<ActionResult> IndexCliente()
        {
            var user = User.Identity.GetUserId();
            var ddb = new ClientesModelContext();
            //var cliente = ddb.Cliente.SqlQuery("select * from Clientes cl join  c  on c.ClienteID=dt.ClienteTarjeta where c.ClienteUser= ' " + user +"'");
            var clientesID = db.Cliente.SqlQuery("select * from Clientes where Clientes.ClienteUser = '" + user + "'").ToList();
            Cliente client = new Cliente();
            List<SelectListItem> tar;
            tar = new List<SelectListItem>();
            foreach (var item in clientesID)
            {
                client = item;
            }
            client = db.Cliente.Find(client.ClienteID);
            var tarjeta = db.DatosTarjeta.ToList();
            foreach (DatosTarjeta x in tarjeta)
            {
                if (x.ClienteID == client.ClienteID)
                {
                    client.DatosTarjetas.Add(x);
                    tar.Add(new SelectListItem
                    {
                        Text = "**** **** **** " + x.Last4.ToString(),
                        Value = x.DatosTarjetaID.ToString()
                    });
                }
            }
            //client.DatosTarjetas.tolistAs

            //db.DatosTarjeta = cliente;
            //var tarjetas = db.DatosTarjeta.Include(d => d.);
            //DatosTarjeta tarjeta =  db.DatosTarjeta.FindAsync(cliente);

            //var datos = db.DatosTarjeta.GroupJoin(db.DatosTarjeta, dt => dt.ClienteID, cl => cl.ClienteID, (dt, cl) => new { dt, cl }).Where(x => x.cl.ClienteUser == user);

            return View(client.DatosTarjetas.ToList().AsEnumerable());
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
                var user = User.Identity.GetUserId();

                //var cliente = ddb.Cliente.SqlQuery("select * from Clientes cl join  c  on c.ClienteID=dt.ClienteTarjeta where c.ClienteUser= ' " + user +"'");
                var clientesID = db.Cliente.SqlQuery("select * from Clientes where Clientes.ClienteUser = '" + user + "'").ToList();
                Cliente client = new Cliente();
                List<SelectListItem> tar;
                tar = new List<SelectListItem>();
                foreach (var item in clientesID)
                {
                    client = item;
                }
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
        public ActionResult Edit([Bind(Include = "DatosTarjetaID,Last4,NumeroTarjeta,FechaVencimiento,CVV,ClienteID")] DatosTarjeta datosTarjeta)
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
