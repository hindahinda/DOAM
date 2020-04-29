using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;

namespace DOAM.Areas.Administrateur.ControllersUsers
{
    public class AspNetRolesController : Controller
    {
       

        // GET: Administrateur/AspNetRoles
        public ActionResult Index()
        {
            var userRole = MyApp.Domain.UsersServices.UserRolesService.GetAspNetRoles();
            return View(userRole.ToList());
        }

        // GET: Administrateur/AspNetRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetRole = MyApp.Domain.UsersServices.UserRolesService.GetAspNetRoleID(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // GET: Administrateur/AspNetRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/AspNetRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.UsersServices.UserRolesService.AddAspNetRole(aspNetRole);
                return RedirectToAction("Index");
            }

            return View(aspNetRole);
        }

        // GET: Administrateur/AspNetRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetRole = MyApp.Domain.UsersServices.UserRolesService.GetAspNetRoleID(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: Administrateur/AspNetRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.UsersServices.UserRolesService.UpdateAspNetRole(aspNetRole);
                return RedirectToAction("Index");
            }
            return View(aspNetRole);
        }

        // GET: Administrateur/AspNetRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetRole = MyApp.Domain.UsersServices.UserRolesService.GetAspNetRoleID(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: Administrateur/AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyApp.Domain.UsersServices.UserRolesService.DeleteAspNetRole(id);
            return RedirectToAction("Index");
        }

       
    }
}
