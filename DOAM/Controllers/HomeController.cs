using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAM.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(/*int? page*/)
        {

            //int pageSize = 10;
            //int pageNumber = (page ?? 1);
           // return View(assets.ToList().ToPagedList(pageNumber, pageSize));
            var asset = MyApp.Application.Services.HomeControllerService.GetHomeAssetsListe();
            return View(asset/*.ToPagedList(pageNumber, pageSize)*/);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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