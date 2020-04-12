using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;
using PagedList;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class AssetMetaDatasController : Controller
    {
       

        // GET: Administrateur/AssetMetaDatas
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                ViewBag.searchString = searchString;
            }

            var assetsMetaData = MyApp.Application.Services.AssetMetaDataControllerService.GetFAssetMetaDataBySortingMethods(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {
                assetsMetaData = MyApp.Application.Services.AssetMetaDataControllerService.GetAssetMetaDataByLabelSearch(searchString);

            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(assetsMetaData.ToList().ToPagedList(pageNumber, pageSize));
           
        }

        // GET: Administrateur/AssetMetaDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetMetaData = MyApp.Application.Services.AssetMetaDataControllerService.GetAssetMetaDataId(id);
            if (assetMetaData == null)
            {
                return HttpNotFound();
            }
            return View(assetMetaData);
        }

        // GET: Administrateur/AssetMetaDatas/Create
        public ActionResult Create()
        {
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name");
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title");
            return View();
        }

        // POST: Administrateur/AssetMetaDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetMetaDataID,Value,MetaDataID,AssetID")] AssetMetaData assetMetaData)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.AssetMetaDataService.AddAssetMetaData(assetMetaData);
                return RedirectToAction("ALLDetails", "Assets", new { id = assetMetaData.AssetID });
            }

            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetMetaData.AssetID);
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title", assetMetaData.MetaDataID);
            return View(assetMetaData);
        }

        // GET: Administrateur/AssetMetaDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetMetaData = MyApp.Application.Services.AssetMetaDataControllerService.GetAssetMetaDataId(id);
            if (assetMetaData == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetMetaData.AssetID);
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title", assetMetaData.MetaDataID);
            return View(assetMetaData);
        }

        // POST: Administrateur/AssetMetaDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetMetaDataID,Value,MetaDataID,AssetID")] AssetMetaData assetMetaData)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.AssetMetaDataService.UpdateAssetMetaData(assetMetaData);
                return RedirectToAction("Index");
            }
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetMetaData.AssetID);
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title", assetMetaData.MetaDataID);
            return View(assetMetaData);
        }

        // GET: Administrateur/AssetMetaDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetMetaData = MyApp.Application.Services.AssetMetaDataControllerService.GetAssetMetaDataId(id);
            if (assetMetaData == null)
            {
                return HttpNotFound();
            }
            return View(assetMetaData);
        }

        // POST: Administrateur/AssetMetaDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyApp.Domain.Services.AssetMetaDataService.DeleteAssetMetaData(id);
           
            return RedirectToAction("Index");
        }
        public ActionResult CreateMetaData(int? id)
        {
            
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title");
            return View();
        }

        // POST: Administrateur/AssetMetaDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMetaData([Bind(Include = "AssetMetaDataID,Value,MetaDataID,AssetID")] AssetMetaData assetMetaData)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.AssetMetaDataService.AddAssetMetaData(assetMetaData);
                return RedirectToAction("ALLDetails", "Assets", new { id = assetMetaData.AssetID });
            }

            //ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetMetaData.AssetID);
            ViewBag.MetaDataID = new SelectList(MyApp.Application.Services.MetaDataControllerService.GetListeMetaData(), "MetaDataID", "Title", assetMetaData.MetaDataID);
            return View(assetMetaData);
        }


    }
}
