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
    public class AssetTypeSupportedMetaDatasController : Controller
    {
        private DOAMEntities db = new DOAMEntities();

        // GET: Administrateur/AssetTypeSupportedMetaDatas
        public ActionResult Index()
        {
            var assetTypeSupportedMetaDatas = db.AssetTypeSupportedMetaDatas.Include(a => a.AssetType).Include(a => a.MetaData);
            return View(assetTypeSupportedMetaDatas.ToList());
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetTypeSupportedMetaData assetTypeSupportedMetaData = db.AssetTypeSupportedMetaDatas.Find(id);
            if (assetTypeSupportedMetaData == null)
            {
                return HttpNotFound();
            }
            return View(assetTypeSupportedMetaData);
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "AssetTypeID", "TypeLabel");
            ViewBag.MetaDataID = new SelectList(db.MetaDatas, "MetaDataID", "Title");
            return View();
        }

        // POST: Administrateur/AssetTypeSupportedMetaDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetSupportedMetaDataID,AssetTypeID,MetaDataID")] AssetTypeSupportedMetaData assetTypeSupportedMetaData)
        {
            if (ModelState.IsValid)
            {
                db.AssetTypeSupportedMetaDatas.Add(assetTypeSupportedMetaData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
            ViewBag.MetaDataID = new SelectList(db.MetaDatas, "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
            return View(assetTypeSupportedMetaData);
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetTypeSupportedMetaData assetTypeSupportedMetaData = db.AssetTypeSupportedMetaDatas.Find(id);
            if (assetTypeSupportedMetaData == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
            ViewBag.MetaDataID = new SelectList(db.MetaDatas, "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
            return View(assetTypeSupportedMetaData);
        }

        // POST: Administrateur/AssetTypeSupportedMetaDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetSupportedMetaDataID,AssetTypeID,MetaDataID")] AssetTypeSupportedMetaData assetTypeSupportedMetaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetTypeSupportedMetaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
            ViewBag.MetaDataID = new SelectList(db.MetaDatas, "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
            return View(assetTypeSupportedMetaData);
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetTypeSupportedMetaData assetTypeSupportedMetaData = db.AssetTypeSupportedMetaDatas.Find(id);
            if (assetTypeSupportedMetaData == null)
            {
                return HttpNotFound();
            }
            return View(assetTypeSupportedMetaData);
        }

        // POST: Administrateur/AssetTypeSupportedMetaDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetTypeSupportedMetaData assetTypeSupportedMetaData = db.AssetTypeSupportedMetaDatas.Find(id);
            db.AssetTypeSupportedMetaDatas.Remove(assetTypeSupportedMetaData);
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
