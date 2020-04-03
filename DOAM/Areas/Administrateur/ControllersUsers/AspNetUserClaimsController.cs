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
    public class AspNetUserClaimsController : Controller
    {
        private DOAMEntities db = new DOAMEntities();

        // GET: Administrateur/AspNetUserClaims
        public ActionResult Index()
        {
            var aspNetUserClaims = db.AspNetUserClaims.Include(a => a.AspNetUser);
            return View(aspNetUserClaims.ToList());
        }

        // GET: Administrateur/AspNetUserClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaim aspNetUserClaim = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaim == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Administrateur/AspNetUserClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ClaimType,ClaimValue")] AspNetUserClaim aspNetUserClaim)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserClaims.Add(aspNetUserClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaim.UserId);
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaim aspNetUserClaim = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaim == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaim.UserId);
            return View(aspNetUserClaim);
        }

        // POST: Administrateur/AspNetUserClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ClaimType,ClaimValue")] AspNetUserClaim aspNetUserClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaim.UserId);
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaim aspNetUserClaim = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaim == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserClaim);
        }

        // POST: Administrateur/AspNetUserClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUserClaim aspNetUserClaim = db.AspNetUserClaims.Find(id);
            db.AspNetUserClaims.Remove(aspNetUserClaim);
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
