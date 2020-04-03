using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class UsersController : Controller
    {
        private DOAMEntities db = new DOAMEntities();
        // GET: Administrateur/Users
        public ActionResult Index()
        {
            var aspNetUser = db.AspNetUsers.Include(a => a.AspNetRoles);
            return View(aspNetUser.ToList());
           // return View(MyApp.Application.Services.ServiceUsers.UserControllerService.GetListeUsers());
        }

        // GET: Administrateur/Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrateur/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrateur/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrateur/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrateur/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrateur/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
