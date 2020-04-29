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
    public class MetaDatasController : Controller
    {
      

        // GET: Administrateur/MetaDatas
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
                ViewBag.searchString = searchString;
            }
            var metaData = MyApp.Application.Services.MetaDataControllerService.GetMetaDataBySortingMethods(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {

                metaData = MyApp.Application.Services.MetaDataControllerService.GetMetaDataByMethodeSearch(searchString);

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(metaData.ToList().ToPagedList(pageNumber, pageSize)); 
          
        }

        // GET: Administrateur/MetaDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var metaData = MyApp.Application.Services.MetaDataControllerService.GetMetaDataId(id);
            if (metaData == null)
            {
                return HttpNotFound();
            }
            return View(metaData);
        }

        // GET: Administrateur/MetaDatas/Create 
        public ActionResult Create()
        {
            ViewBag.MetaDataGroupID = new SelectList(MyApp.Domain.Services.MetaDataGroupService.GetMetaDatasGroups(), "MetaDataGroupID", "GroupName");
            return View();
        }

        // POST: Administrateur/MetaDatas/Create 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MetaDataID,Title,Description,MetaDataGroupID")] MetaData metaData)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    MyApp.Domain.Services.MetaDataService.AddMetaData(metaData);
                    return RedirectToAction("Index");
                }

                ViewBag.MetaDataGroupID = new SelectList(MyApp.Domain.Services.MetaDataGroupService.GetMetaDatasGroups(), "MetaDataGroupID", "GroupName", metaData.MetaDataGroupID);
                return View(metaData);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MetaDatas", "Create"));
            }
        }

        // GET: Administrateur/MetaDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var metaData = MyApp.Application.Services.MetaDataControllerService.GetMetaDataId(id); 
            if (metaData == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetaDataGroupID = new SelectList(MyApp.Domain.Services.MetaDataGroupService.GetMetaDatasGroups(), "MetaDataGroupID", "GroupName", metaData.MetaDataGroupID);
            return View(metaData);
        }

        // POST: Administrateur/MetaDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MetaDataID,Title,Description,MetaDataGroupID")] MetaData metaData)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    MyApp.Domain.Services.MetaDataService.UpdateMetaData(metaData);
                    return RedirectToAction("Index");
                }
                ViewBag.MetaDataGroupID = new SelectList(MyApp.Domain.Services.MetaDataGroupService.GetMetaDatasGroups(), "MetaDataGroupID", "GroupName", metaData.MetaDataGroupID);
                return View(metaData);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MetaDatas", "Edit"));
            }
        }

        // GET: Administrateur/MetaDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var metaData = MyApp.Application.Services.MetaDataControllerService.GetMetaDataId(id);
            if (metaData == null)
            {
                return HttpNotFound();
            }
            return View(metaData);
        }

        // POST: Administrateur/MetaDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            MyApp.Domain.Services.MetaDataService.DeleteMetaData(id);
            return RedirectToAction("Index");
        }

        
    }
}
