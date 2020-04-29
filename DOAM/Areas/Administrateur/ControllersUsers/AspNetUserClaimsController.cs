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
      

        // GET: Administrateur/AspNetUserClaims
        public ActionResult Index()
        {
            var aspNetUserClaims = MyApp.Domain.UsersServices.UserClaims.GetAspNetUsersClaims();
            return View(aspNetUserClaims.ToList());
        }

        // GET: Administrateur/AspNetUserClaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUserClaim = MyApp.Domain.UsersServices.UserClaims.GetAspNetUserClaimID(id);
            if (aspNetUserClaim == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email");
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
                MyApp.Domain.UsersServices.UserClaims.AddAspNetUserClaim(aspNetUserClaim);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserClaim.UserId);
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var aspNetUserClaim =MyApp.Domain.UsersServices.UserClaims.GetAspNetUserClaimID(id);
            if (aspNetUserClaim == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserClaim.UserId);
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
                MyApp.Domain.UsersServices.UserClaims.UpdateAspNetUserClaim(aspNetUserClaim);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(MyApp.Domain.UsersServices.UsersService.GetAspNetUsers(), "Id", "Email", aspNetUserClaim.UserId);
            return View(aspNetUserClaim);
        }

        // GET: Administrateur/AspNetUserClaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUserClaim = MyApp.Domain.UsersServices.UserClaims.GetAspNetUserClaimID(id);
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
            MyApp.Domain.UsersServices.UserClaims.DeleteAspNetUserClaim(id);
            return RedirectToAction("Index");
        }

       
    }
}
