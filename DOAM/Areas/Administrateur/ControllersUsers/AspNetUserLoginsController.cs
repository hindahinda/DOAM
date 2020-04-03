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
        private DOAMEntities db = new DOAMEntities();

        // GET: Administrateur/AspNetUserLogins
        public ActionResult Index()
        {
            var aspNetUserLogins = db.AspNetUserLogins.Include(a => a.AspNetUser);
            return View(aspNetUserLogins.ToList());
        }

        // GET: Administrateur/AspNetUserLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogin aspNetUserLogin = db.AspNetUserLogins.Find(id);
            if (aspNetUserLogin == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
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
                db.AspNetUserLogins.Add(aspNetUserLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogin.UserId);
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogin aspNetUserLogin = db.AspNetUserLogins.Find(id);
            if (aspNetUserLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogin.UserId);
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
                db.Entry(aspNetUserLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserLogin.UserId);
            return View(aspNetUserLogin);
        }

        // GET: Administrateur/AspNetUserLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserLogin aspNetUserLogin = db.AspNetUserLogins.Find(id);
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
            AspNetUserLogin aspNetUserLogin = db.AspNetUserLogins.Find(id);
            db.AspNetUserLogins.Remove(aspNetUserLogin);
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
