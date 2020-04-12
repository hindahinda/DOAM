using MyApp.Infrastructure.ElasticSearch;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using MyApp.Application.Services;

namespace DOAM.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(/*int? page*/)
        {
            
            
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
        //[HttpPost]
        public ActionResult SearchAction(string recherche , string categorie, string currentFilter, int? page, string categories) 
        {
            
          
            var ListOfDataIndexed = new List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (string.IsNullOrEmpty(recherche) && string.IsNullOrEmpty(categorie))
            {
                    
                return View("DataNotFound");
            }
           
            else if (!string.IsNullOrEmpty(recherche))
            {
               
                ViewBag.recherche = recherche;
               
                var connectionToEs = ElasticSearchConnectionSettings.connection();

                var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                    (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                           .Size(50)
                           .Query(q => q.MultiMatch(m => m
                                                    .Query(recherche))

                       )
                    );

                ListOfDataIndexed = (from hits in reponse.Hits
                            select hits.Source).ToList();
                              

                if (!ListOfDataIndexed.Any())    
                {
                    return View("DataNotFound");
                }

                else return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));

            }
            else if (!string.IsNullOrEmpty(categorie))
            {
               
                ViewBag.categorie= categorie;
             
                var connectionToEs = ElasticSearchConnectionSettings.connection();

                var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                    (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                           .Size(50)
                           .Query(q => q.MultiMatch(m => m
                                                     .Query(categorie))
                      )
                    );

                ListOfDataIndexed = (from hits in reponse.Hits
                              select hits.Source).ToList();

                if (!ListOfDataIndexed.Any())    //on verifie si la listet est vide et on retourne: data non trouvé
                {
                    return View("DataNotFound");
                }

                else return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));

            }
            return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));
          
        }
        public ActionResult UpDateOfCompteurAsset(int id)
        {
           // var assetID = MyApp.Domain.Services.AssetService.GetAssetID(id);
           
            
                MyApp.Domain.Services.HomeService.UpDateAssetCompteur(id);
            
           
          

           // var asset = MyApp.Application.Services.HomeControllerService.GetHomeAssetsListe();
            return RedirectToAction("Index");
        }
    }
}