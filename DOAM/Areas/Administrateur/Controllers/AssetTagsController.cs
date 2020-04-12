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
    public class AssetTagsController : Controller
    {
       

        // GET: Administrateur/AssetTags
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LabelSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                ViewBag.searchString = searchString;
            }

            var assetTags = MyApp.Application.Services.AssetTagControllerService.SortOrderTagAsset(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {
                assetTags = MyApp.Application.Services.AssetTagControllerService.SearchAssetTag(searchString);

            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(assetTags.ToList().ToPagedList(pageNumber, pageSize));

            //var assetTags = MyApp.Application.Services.AssetTagControllerService.GetListeAssetTags();
            //return View(assetTags.ToList());
        }

        // GET: Administrateur/AssetTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetTag =MyApp.Application.Services.AssetTagControllerService.GetAssetTagId(id);
            if (assetTag == null)
            {
                return HttpNotFound();
            }
            return View(assetTag);
        }

        // GET: Administrateur/AssetTags/Create
        public ActionResult Create()
        {
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name");
            ViewBag.TagID = new SelectList(MyApp.Application.Services.TagControllerService.GetListeTag(), "TagID", "Label");
            return View();
        }

        // POST: Administrateur/AssetTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetTagID,TagID,AssetID")] AssetTag assetTag)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.AssetTagService.AddAssetTag(assetTag);
                return RedirectToAction("Index");
            }

            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetTag.AssetID);
            ViewBag.TagID = new SelectList(MyApp.Application.Services.TagControllerService.GetListeTag(), "TagID", "Label", assetTag.TagID);
            return View(assetTag);
        }

        // GET: Administrateur/AssetTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetTag = MyApp.Application.Services.AssetTagControllerService.GetAssetTagId(id);
            if (assetTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetTag.AssetID);
            ViewBag.TagID = new SelectList(MyApp.Application.Services.TagControllerService.GetListeTag(), "TagID", "Label", assetTag.TagID);
            return View(assetTag);
        }

        // POST: Administrateur/AssetTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetTagID,TagID,AssetID")] AssetTag assetTag)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.AssetTagService.UpdateAssetTag(assetTag);
                return RedirectToAction("Index");
            }
            ViewBag.AssetID = new SelectList(MyApp.Application.Services.AssetControllerService.GetListeAsset(), "AssetID", "Name", assetTag.AssetID);
            ViewBag.TagID = new SelectList(MyApp.Application.Services.TagControllerService.GetListeTag(), "TagID", "Label", assetTag.TagID);
            return View(assetTag);
        }

        // GET: Administrateur/AssetTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assetTag = MyApp.Application.Services.AssetTagControllerService.GetAssetTagId(id);
            if (assetTag == null)
            {
                return HttpNotFound();
            }
            return View(assetTag);
        }

        // POST: Administrateur/AssetTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyApp.Domain.Services.AssetTagService.DeleteAssetTag(id);
         
            return RedirectToAction("Index");
        }

       
    }
}
