using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class MetaDataGroupsController : Controller
    {
       

        // GET: Administrateur/MetaDataGroups
        public ActionResult Index()
        {
            return View(MyApp.Application.Services.MetaDataGroupControllerServie.GetListeMetaDataGroup());
        }

        // GET: Administrateur/MetaDataGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MetaDataGroup metaDataGroup = db.MetaDataGroups.Find(id);
            var metaDataGroup = MyApp.Application.Services.MetaDataGroupControllerServie.GetMetaDataGroupId(id);
            if (metaDataGroup == null)
            {
                return HttpNotFound();
            }
            return View(metaDataGroup);
        }

        // GET: Administrateur/MetaDataGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/MetaDataGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MetaDataGroupID,GroupName,Description")] MetaDataGroup metaDataGroup)
        {
            if (ModelState.IsValid)
            {
                //db.MetaDataGroups.Add(metaDataGroup);
                //db.SaveChanges();
                MyApp.Domain.Services.MetaDataGroupService.AddMetaDataGroup(metaDataGroup);
                return RedirectToAction("Index");
            }

            return View(metaDataGroup);
        }

        // GET: Administrateur/MetaDataGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var metaDataGroup = MyApp.Application.Services.MetaDataGroupControllerServie.GetMetaDataGroupId(id); 
            if (metaDataGroup == null)
            {
                return HttpNotFound();
            }
            return View(metaDataGroup);
        }

        // POST: Administrateur/MetaDataGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MetaDataGroupID,GroupName,Description")] MetaDataGroup metaDataGroup)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(metaDataGroup).State = EntityState.Modified;
                //db.SaveChanges();
                MyApp.Domain.Services.MetaDataGroupService.UpdateMetaDataGroup(metaDataGroup);
                return RedirectToAction("Index");
            }
            return View(metaDataGroup);
        }

        // GET: Administrateur/MetaDataGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var metaDataGroup = MyApp.Application.Services.MetaDataGroupControllerServie.GetMetaDataGroupId(id); 
            if (metaDataGroup == null)
            {
                return HttpNotFound();
            }
            return View(metaDataGroup);
        }

        // POST: Administrateur/MetaDataGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            MyApp.Domain.Services.MetaDataGroupService.DeleteMetaDataGroup(id);
            return RedirectToAction("Index");
        }

       
    }
}
