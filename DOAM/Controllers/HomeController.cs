using MyApp.Infrastructure.ElasticSearch;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

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
        [HttpPost]
        public ActionResult SearchAction(string recherche /*, string categorie*/) 
        {
            var datasearch = new List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>(); 
            
            if (recherche == "" /*&& categorie == ""*/)
            {
                //TempData["msg"] = "<script>alert('Provide Details to Search !');</script>";    
                return View("Index");
            }
           
            else
            {
                ViewBag.recherche = recherche;
                var connectionToEs = ElasticSearchConnectionSettings.connection();

                var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                    (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                           .Size(10)
                           .Query(q => q.MultiMatch(m => m
                                                    .Query(recherche)


                          //&& q.Match(m => m
                          //    .Field(f => f.)
                          //    .Query(categorie)
                          )
                       )
                    );

                datasearch = (from hits in reponse.Hits
                            select hits.Source).ToList();

                if (!datasearch.Any())    //on verifie si la listet est vide et on retourne: data non trouvé
                {
                    return View("DataNotFound");
                }

                else return View(datasearch);

            }
        }
    }
}