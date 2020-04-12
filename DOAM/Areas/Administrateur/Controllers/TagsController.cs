using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;
using MyApp.Application;
using PagedList;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class TagsController : Controller
    {
      

        // GET: Administrateur/Tags
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var tags = MyApp.Application.Services.TagControllerService.GetTagBySortingMethods(sortOrder);

            if (!String.IsNullOrEmpty(searchString))
            {
                tags = MyApp.Application.Services.TagControllerService.GetTagByLabelSearch(searchString);

            }
            int pageSize = 10; 
            int pageNumber = (page ?? 1);
            return View(tags.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Administrateur/Tags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tag = MyApp.Application.Services.TagControllerService.GetTagId(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
           
            return View(tag);
        }

        // GET: Administrateur/Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateur/Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagID,Label,Status")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.TagService.AddTag(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Administrateur/Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tag = MyApp.Application.Services.TagControllerService.GetTagId(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Administrateur/Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagID,Label,Status")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                MyApp.Domain.Services.TagService.UpdateTag(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Administrateur/Tags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tag = MyApp.Application.Services.TagControllerService.GetTagId(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Administrateur/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            MyApp.Domain.Services.TagService.DeleteTag(id);
            return RedirectToAction("Index");
        }

       
    }
}
