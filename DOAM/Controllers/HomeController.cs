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
    public enum eMovieCategories { Action, Drama, Comedy, Science_Fiction };
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
       
        public ActionResult UpDateOfCompteurClick(int id, string Urls)
        {

            MyApp.Domain.Services.HomeService.UpDateAssetCompteur(id);

              return Redirect(Urls); 

        }
        //[HttpPost]

        public ActionResult SearchAction(string recherche, string categorie, string currentFilter, int? page /*List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument> SearchResult*/)
        {

            var ListOfDataIndexed = new List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (string.IsNullOrEmpty(recherche) && string.IsNullOrEmpty(categorie) /*&& (SearchResult == null || SearchResult.Count == 0)*/)
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

                ViewBag.categorie = categorie;

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
            //else if(SearchResult != null)
            //{
            //    ListOfDataIndexed = SearchResult;
            //}

            return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));

        }
        public ActionResult UpDateOfCompteurAsset(int id)
        {

            MyApp.Domain.Services.HomeService.UpDateAssetCompteur(id);

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult SearchCategories(SelectListItem item)
        public ActionResult SearchAction2(string selectCategorie, int? page)
        {
            int pageSize = 50; 
            int pageNumber = (page ?? 1);
            var ListOfDataIndexed = new List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Audio", Value = "1" });
            items.Add(new SelectListItem { Text = "Video", Value = "2" });
            items.Add(new SelectListItem { Text = "Image", Value = "3" });
            items.Add(new SelectListItem { Text = "Streamers", Value = "4" });
            items.Add(new SelectListItem { Text = "Documents", Value = "5" });
            if (selectCategorie != null)
            {
                ViewBag.selectCategorie = selectCategorie;
            }

            var connectionToEs = ElasticSearchConnectionSettings.connection();
            if (items.Select(e => e.Text).Contains(selectCategorie))
            {
                ViewBag.selectCategorie = selectCategorie;
                var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                    (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                           .Size(50).Query(q => q.MultiMatch(m => m.Query(selectCategorie)))
                    );

                ListOfDataIndexed = (from hits in reponse.Hits select hits.Source).ToList();
              
                if (!ListOfDataIndexed.Any())    //on verifie si la listet est vide et on retourne: data non trouvé
                {
                    return View("DataNotFound");
                }

                else return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));
            }

            return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));

        }       
    }
}