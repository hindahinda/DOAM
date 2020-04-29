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
    public class AspNetUsersController : Controller
    {
       

        // GET: Administrateur/AspNetUsers
        public ActionResult Index()
        {
            var users = MyApp.Domain.UsersServices.UsersService.GetAspNetUsers();
            return View(users.ToList());
        }

        // GET: Administrateur/AspNetUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUser = MyApp.Domain.UsersServices.UsersService.GetAspNetUserID(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Administrateur/AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    MyApp.Domain.UsersServices.UsersService.AddAspNetUser(aspNetUser);
                    return RedirectToAction("Index");
                }

                return View(aspNetUser);
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AspNetUsers", "Create"));
            }
        }

        // GET: Administrateur/AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUser = MyApp.Domain.UsersServices.UsersService.GetAspNetUserID(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Administrateur/AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    MyApp.Domain.UsersServices.UsersService.UpdateAspNetUser(aspNetUser);
                    return RedirectToAction("Index");
                }
                return View(aspNetUser);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AspNetUsers", "Edit"));
            }
        }

        // GET: Administrateur/AspNetUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUser = MyApp.Domain.UsersServices.UsersService.GetAspNetUserID(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Administrateur/AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyApp.Domain.UsersServices.UsersService.DeleteAspNetUser(id);
            return RedirectToAction("Index");
        }

       
    }
}
