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
    public class EmpleadosController : Controller
    {
        private ClientesModelContext db = new ClientesModelContext();


        public EmpleadosController()
        {
        }

        public EmpleadosController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
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

        // GET: Empleados
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Persona);
            return View(empleado.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(EmpleadoUsuario model)
        {

            var user = new ApplicationUser { UserName = model.Usuario.Email, Email = model.Usuario.Email };
            var result = await UserManager.CreateAsync(user, model.UsuarioR.Password);

            if (result.Succeeded)
            {
                var result2 = await UserManager.AddToRolesAsync(user.Id, "Empleado");
                Empleado empleado = new Empleado();
                empleado = model.Empleado;
                empleado.Persona = model.Empleado.Persona;
                empleado.fechaIngreso = DateTime.Now;
                empleado.Estatus = 1;
                empleado.Persona.CP = "00000";
                empleado.EmpleadoUser = user.Id;
                db.Personas.Add(empleado.Persona);
                db.Empleado.Add(empleado);
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

        // GET: Empleados/Edit/5

        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            var user = await UserManager.FindByIdAsync(empleado.EmpleadoUser);
            EmpleadoUsuario EmpleadoU = new EmpleadoUsuario();
            EmpleadoU.Empleado = empleado as Empleado;
            EmpleadoU.Usuario = user;
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre", empleado.PersonaID);
            return View(EmpleadoU);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit(EmpleadoUsuario EmpleadoU, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(EmpleadoU.Empleado.EmpleadoUser);
                user.UserName = EmpleadoU.Usuario.Email;
                user.Email = EmpleadoU.Usuario.Email;
                var userRoles = await UserManager.GetRolesAsync(user.Id);
                selectedRole = selectedRole ?? new string[] { "Empleado" };

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
                EmpleadoU.Empleado.PersonaID = EmpleadoU.Empleado.Persona.PersonaID;
                db.Entry(EmpleadoU.Empleado.Persona).State = EntityState.Modified;
                db.Entry(EmpleadoU.Empleado).State = EntityState.Modified;
                db.SaveChanges();



                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // ViewBag.ClienteDatos = new SelectList(db.Personas, "PersonaID", "Nombre", cliente.Persona);
            return View(EmpleadoU.Empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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