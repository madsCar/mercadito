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

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();
        [HttpGet]
        public ActionResult Index()
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

        [HttpGet]
       
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}
