using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;
using MyApp.Application.Services;
using PagedList;    



namespace DOAM.Areas.Administrateur.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AssetsController : Controller
    {
       
        

        // GET: Administrateur/Assets
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
           
            if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    ViewBag.searchString= searchString;
                }
           var assets = MyApp.Application.Services.AssetControllerService.GetAssetBySortingMethods(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {

                 assets = MyApp.Application.Services.AssetControllerService.GetAssetByMethodeSearch(searchString);

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(assets.ToList().ToPagedList(pageNumber, pageSize));       

        }

        // GET: Administrateur/Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var asset = AssetControllerService.GetAssetId(id);
            if (asset == null)
            {
                return HttpNotFound();
            }

            return View(asset);
        }

        // GET: Administrateur/Assets/Create
        public ActionResult Create()
        {
            ViewBag.MimeTypeID = new SelectList(MimeTypeControllerService.GetListeMimeType(), "MimeTypeID", "Mime");
            
            return View();
        }

        // POST: Administrateur/Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetID,Name,Url,ThumbnailUrl,Description,DateEncoded,MimeTypeID,Compteur")] Asset asset)
      
        {
            if (ModelState.IsValid)
            {
              
                MyApp.Domain.Services.AssetService.AddAsset(asset);
                return RedirectToAction("Index");
            }

            ViewBag.MimeTypeID = new SelectList(MimeTypeControllerService.GetListeMimeType(), "MimeTypeID", "Mime", asset.MimeTypeID);
            return View(asset);
        }

        // GET: Administrateur/Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var asset = AssetControllerService.GetAssetId(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.MimeTypeID = new SelectList(MimeTypeControllerService.GetListeMimeType(), "MimeTypeID", "Mime", asset.MimeTypeID);
            return View(asset);
        }

        // POST: Administrateur/Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit([Bind(Include = "AssetID,Name,Url,ThumbnailUrl,Description,DateEncoded,MimeTypeID,Compteur")] Asset asset)
        {
            if (ModelState.IsValid)
            {
             
                MyApp.Domain.Services.AssetService.UpdateAsset(asset);
                return RedirectToAction("Index");
            }
            ViewBag.MimeTypeID = new SelectList(MimeTypeControllerService.GetListeMimeType(), "MimeTypeID", "Mime", asset.MimeTypeID);
            return View(asset);
        }

        // GET: Administrateur/Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             var asset = AssetControllerService.GetAssetId(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Administrateur/Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            MyApp.Domain.Services.AssetService.DeleteAsset(id);
            return RedirectToAction("Index");
        }

        public ActionResult ALLDetails(int id)
        {
           
            var asset = MyApp.Application.Services.AllDetailsAssetControllerService.GetAllDetailsAssets(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }
      
    }
}
