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
    public class AssetTypesController : Controller
    {
        //private DOAMEntities db = new DOAMEntities();

        // GET: Administrateur/AssetTypes
        public ActionResult Index()
        {
            return View(MyApp.Domain.Services.AssetTypeService.GetAssetTypes());
        }

        // GET: Administrateur/AssetTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AssetType assetType = db.AssetTypes.Find(id);
            var assetType = MyApp.Domain.Services.AssetTypeService.GetAssetTypeID(id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            return View(assetType);
        }

        // GET: Administrateur/AssetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/AssetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetTypeID,TypeLabel")] AssetType assetType)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    //db.AssetTypes.Add(assetType);
                    //db.SaveChanges();
                    MyApp.Domain.Services.AssetTypeService.AddAssetType(assetType);
                    return RedirectToAction("Index");
                }

                return View(assetType);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AssetTypes", "Create"));
            }
        }

        // GET: Administrateur/AssetTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetType = MyApp.Domain.Services.AssetTypeService.GetAssetTypeID(id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            return View(assetType);
        }

        // POST: Administrateur/AssetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetTypeID,TypeLabel")] AssetType assetType)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    //db.Entry(assetType).State = EntityState.Modified;
                    //db.SaveChanges();
                    MyApp.Domain.Services.AssetTypeService.UpdateAssetType(assetType);
                    return RedirectToAction("Index");
                }
                return View(assetType);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AssetTypes", "Edit"));
            }
        }

        // GET: Administrateur/AssetTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetType = MyApp.Domain.Services.AssetTypeService.GetAssetTypeID(id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            return View(assetType);
        }

        // POST: Administrateur/AssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //AssetType assetType = db.AssetTypes.Find(id);
            //db.AssetTypes.Remove(assetType);
            //db.SaveChanges();
            MyApp.Domain.Services.AssetTypeService.DeleteAssetType(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
