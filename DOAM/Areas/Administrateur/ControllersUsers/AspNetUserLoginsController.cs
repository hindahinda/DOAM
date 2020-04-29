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
    public class AspNetUserLoginsController : Controller
    {
       

        // GET: Administrateur/AspNetUserLogins
        public ActionResult Index()
        {
            var aspNetUserLogins = MyApp.Domain.UsersServices.AspNetUserLoginsService.GetAspNetUserLogins();
            return View(aspNetUserLogins.ToList());
        }

        // GET: Administrateur/AspNetUserLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          var aspNetUserLogin = MyApp.Domain.UsersServices.AspNetUserLoginsService.GetAspNetUserLoginID(id);
            if (aspNetUserLogin == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email");
            return View();
        }

        // POST: Administrateur/AspNetUserLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginProvider,ProviderKey,UserId")] AspNetUserLogin aspNetUserLogin)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.UsersServices.AspNetUserLoginsService.AddAspNetUserLogin(aspNetUserLogin);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserLogin.UserId);
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUserLogin = MyApp.Domain.UsersServices.AspNetUserLoginsService.GetAspNetUserLoginID(id);
            if (aspNetUserLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserLogin.UserId);
            return View(aspNetUserLogin);
        }

        // POST: Administrateur/AspNetUserLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginProvider,ProviderKey,UserId")] AspNetUserLogin aspNetUserLogin)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.UsersServices.AspNetUserLoginsService.UpdateAspNetUserLogin(aspNetUserLogin);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserLogin.UserId);
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUserLogin = MyApp.Domain.UsersServices.AspNetUserLoginsService.GetAspNetUserLoginID(id);
            if (aspNetUserLogin == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserLogin);
        }

        // POST: Administrateur/AspNetUserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyApp.Domain.UsersServices.AspNetUserLoginsService.DeleteAspNetUserLogin(id);
            return RedirectToAction("Index");
        }

       
    }
}
