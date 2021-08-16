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

    [Authorize(Roles = "Admin")]
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
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
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
           
            //var user = User.Identity.GetUserId();
            // var clientes = db.Cliente.SqlQuery("select ClienteID from Clientes where Clientes.ClienteUser = '"+user+"'");
           // Cliente cliente = db.Cliente.Find(clientes);
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
        public async System.Threading.Tasks.Task<ActionResult> Create(ClienteUsuario model)
        {
           
                var user = new ApplicationUser { UserName = model.Usuario.Email, Email = model.Usuario.Email };
                var result = await UserManager.CreateAsync(user, model.UsuarioR.Password);

                if (result.Succeeded)
                {
                    var result2 = await UserManager.AddToRolesAsync(user.Id, "Cliente");
                    Cliente cliente = new Cliente();
                    cliente = model.Cliente;
                    cliente.Persona = model.Cliente.Persona;
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.Estatus = 1;
                    cliente.Persona.Ciudad = "XXX";
                    cliente.Persona.CP = "XXX";
                    cliente.Persona.Estado = "XXX";
                    cliente.Persona.Domicilio = "XXX";

                    cliente.ClienteUser = user.Id;
                    db.Personas.Add(cliente.Persona);
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    //ViewBag.Link = callbackUrl;
                  //  return View("DisplayEmail");
                
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index");
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