using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using MercaditoRecargado.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MercaditoRecargado.Controllers
{
    public class ClientesController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();

        public ClientesController()
        {
        }

        public ClientesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

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

            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.PersonaID);
            return View(cliente);
        }




        // GET: Clientes/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Cliente cliente = db.Cliente.Find(id);
            var user = await UserManager.FindByIdAsync(cliente.ClienteUser);
            ClienteUsuario ClienteU = new ClienteUsuario();
            ClienteU.Cliente = cliente as Cliente;
            ClienteU.Usuario = user;
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.PersonaID);
            return View(ClienteU);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit(ClienteUsuario clienteU,  params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(clienteU.Cliente.ClienteUser);
                user.UserName = clienteU.Usuario.Email;
                user.Email = clienteU.Usuario.Email;
                

                var userRoles = await UserManager.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] {"Cliente"};

                var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                db.Entry(clienteU.Cliente.Persona).State = EntityState.Modified;
          
               // db.Entry(clienteU.Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.Persona);
            return View(clienteU.Cliente);
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
        public async System.Threading.Tasks.Task<ActionResult> DeleteConfirmedAsync(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            Persona persona = db.Personas.Find(cliente.PersonaID);

            var user = await UserManager.FindByIdAsync(cliente.ClienteUser);
            if (user == null)
            {
                return HttpNotFound();
            }
            var result = await UserManager.DeleteAsync(user);
            db.Cliente.Remove(cliente);
            db.Personas.Remove(persona);
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