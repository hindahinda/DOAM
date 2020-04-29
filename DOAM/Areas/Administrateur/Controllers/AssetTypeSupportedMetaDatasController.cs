using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;
using MyApp.Domain.Services;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class AssetTypeSupportedMetaDatasController : Controller
    {
       

        // GET: Administrateur/AssetTypeSupportedMetaDatas
        public ActionResult Index()
        {
            var assetTypeSupportedMetaDatas = AssetTypeSupportedMetaDatasService.Get();
            return View(assetTypeSupportedMetaDatas.ToList());
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetTypeSupportedMetaData = AssetTypeSupportedMetaDatasService.Get(id);
            if (assetTypeSupportedMetaData == null)
            {
                return HttpNotFound();
            }
           
            return View(assetTypeSupportedMetaData);
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeID = new SelectList(AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel");
            ViewBag.MetaDataID = new SelectList(MetaDataService.GetMetaDatas(), "MetaDataID", "Title");
            return View();
        }

        // POST: Administrateur/AssetTypeSupportedMetaDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetSupportedMetaDataID,AssetTypeID,MetaDataID")] AssetTypeSupportedMetaData assetTypeSupportedMetaData)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    AssetTypeSupportedMetaDatasService.Create(assetTypeSupportedMetaData);
                    return RedirectToAction("Index");
                }

                ViewBag.AssetTypeID = new SelectList(AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
                ViewBag.MetaDataID = new SelectList(MetaDataService.GetMetaDatas(), "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
                return View(assetTypeSupportedMetaData);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AssetTypeSupportedMetaDatas", "Create"));
            }
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetTypeSupportedMetaData = AssetTypeSupportedMetaDatasService.Get(id);
            if (assetTypeSupportedMetaData == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeID = new SelectList(AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
            ViewBag.MetaDataID = new SelectList(MetaDataService.GetMetaDatas(), "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
            return View(assetTypeSupportedMetaData);
        }

        // POST: Administrateur/AssetTypeSupportedMetaDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetSupportedMetaDataID,AssetTypeID,MetaDataID")] AssetTypeSupportedMetaData assetTypeSupportedMetaData)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    AssetTypeSupportedMetaDatasService.Update(assetTypeSupportedMetaData);
                    return RedirectToAction("Index");
                }
                ViewBag.AssetTypeID = new SelectList(AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", assetTypeSupportedMetaData.AssetTypeID);
                ViewBag.MetaDataID = new SelectList(MetaDataService.GetMetaDatas(), "MetaDataID", "Title", assetTypeSupportedMetaData.MetaDataID);
                return View(assetTypeSupportedMetaData);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AssetTypeSupportedMetaDatas", "Edit"));
            }
        }

        // GET: Administrateur/AssetTypeSupportedMetaDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var assetTypeSupportedMetaData = AssetTypeSupportedMetaDatasService.Get(id);
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
           
            AssetTypeSupportedMetaDatasService.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
