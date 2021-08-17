using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MercaditoRecargado.Models;
using Microsoft.AspNet.Identity;

namespace MercaditoRecargado.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class CartController : Controller
    {
       
        private ClientesModelContext db = new ClientesModelContext();
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("ProductoCliente", "Productoes");
            }
          /*  DireccionTarjetaCliente datos = new DireccionTarjetaCliente();
            var user = User.Identity.GetUserId();
            var clientesID = db.Cliente.SqlQuery("select * from Clientes where Clientes.ClienteUser = '"+user+"'").ToList();
         
            int id = 0;
            foreach (var item in clientesID)
            {
              id = item.ClienteID;
            }
            var personaID = db.Cliente.SqlQuery("select * from Personas where Personas.ClienteID = '" + id + "'").ToList();
            int perID = 0;
            foreach (var item in personaID)
            {
                perID = item.PersonaID;
            }
            datos.DatoDireccionClientes = db.DireccionCliente.Find(perID);
            datos.DatosTarjeta = db.DatosTarjeta.Find(id);*/
            return View();
        }

        public ActionResult Buy(int id)
        {
            List<Item> cart = new List<Item>();
            Producto producto = new Producto();
            if (Session["cart"] == null)
            {
             
                 producto = db.Producto.Find(id);
                cart.Add(new Item { Producto = producto, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                 cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    producto = db.Producto.Find(id);
                    cart.Add(new Item { Producto = producto, Quantity = 1 });
                    Session["cart"] = cart;
                }
                Session["cart"] = cart;

            }
            return RedirectToAction("ProductoCliente","Productoes",cart);
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            
            if (cart.Count == 0)
            {
                Session["cart"] = null;
                return RedirectToAction("ProductoCliente", "Productoes");

                
            }
            else
            {
                Session["cart"] = cart;
                return RedirectToAction("Create", "VentaDetalles");
            }
           
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Producto.ProductoID.Equals(id))
                    return i;
            return -1;
        }

    }
}