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
    public class MimeTypesController : Controller
    {
       

        // GET: Administrateur/MimeTypes
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

            var mimeTypes = MyApp.Application.Services.MimeTypeControllerService.SortingMimeType(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {
                mimeTypes = MyApp.Application.Services.MimeTypeControllerService.SearchMimeType(searchString);

            }    
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(mimeTypes.ToList().ToPagedList(pageNumber, pageSize)); 
        }

        // GET: Administrateur/MimeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mimeType = MyApp.Domain.Services.MimeTypeService.GetMimeTypeID(id);
            if (mimeType == null)
            {
                return HttpNotFound();
            }
            return View(mimeType);
        }

        // GET: Administrateur/MimeTypes/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeID = new SelectList(MyApp.Domain.Services.AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel");
            return View();
        }

        // POST: Administrateur/MimeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MimeTypeID,Mime,AssetTypeID")] MimeType mimeType)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.MimeTypeService.AddMimeType(mimeType);
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeID = new SelectList(MyApp.Domain.Services.AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", mimeType.AssetTypeID);
            return View(mimeType);
        }

        // GET: Administrateur/MimeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mimeType = MyApp.Application.Services.MimeTypeControllerService.GetMimeTypeId(id);
            if (mimeType == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeID = new SelectList(MyApp.Domain.Services.AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", mimeType.AssetTypeID);
            return View(mimeType);
        }

        // POST: Administrateur/MimeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MimeTypeID,Mime,AssetTypeID")] MimeType mimeType)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.MimeTypeService.UpdateMimeType(mimeType);
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeID = new SelectList(MyApp.Domain.Services.AssetTypeService.GetAssetTypes(), "AssetTypeID", "TypeLabel", mimeType.AssetTypeID);
            return View(mimeType);
        }

        // GET: Administrateur/MimeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mimeType = MyApp.Application.Services.MimeTypeControllerService.GetMimeTypeId(id);
            if (mimeType == null)
            {
                return HttpNotFound();
            }
            return View(mimeType);
        }

        // POST: Administrateur/MimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyApp.Domain.Services.MimeTypeService.DeleteMimeType(id);
            return RedirectToAction("Index");
        }

        
    }
}
