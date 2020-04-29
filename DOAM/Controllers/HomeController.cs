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
        /// <summary>
        /// afficher la liste des assets on home page
        /// </summary>
        /// <returns>Home view </returns>
        public ActionResult Index()
        {
            try
            {
                var asset = MyApp.Application.Services.HomeControllerService.GetHomeAssetsListe();
                return View(asset);
            }
            catch (Exception ex)
            {
                return View("SearchAction2", new HandleErrorInfo(ex, "Home", "Index"));
            }
                     
        }

        /// <summary>
        /// concerne les infos sur l'application
        /// </summary>
        /// <returns> about view </returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// concerne les infos de contact
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// avec identifiant on recupere les details d'une asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns> les détails d'asset </returns>
        public ActionResult ALLDetails(int id)
        {
            
            var asset = MyApp.Application.Services.AllDetailsAssetControllerService.GetAllDetailsAssets(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }
       
        /// <summary>
        /// méthode pour récuperer l'identifiant et l'urls de l'asset visité ou voté
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Urls"></param>
        /// <returns> et diriger vers le link de l'ulrs </returns>
        public ActionResult UpDateOfCompteurClick(int id, string Urls)
        {
            try
            {
                MyApp.Domain.Services.HomeService.UpDateAssetCompteur(id);

                return Redirect(Urls);
            }
            catch(Exception ex)
            {
                return View("SearchAction2", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }
        //[HttpPost]
        /// <summary>
        /// Méthode pour faire la recherche
        /// </summary>
        /// <param name="recherche"></param>
        /// <param name="categorie"></param>
        /// <param name="currentFilter"></param>
        /// <param name="page"></param>
        /// <returns>la liste des élément trouvées </returns>
        public ActionResult SearchAction(string recherche, string categorie, string motClé, int? page)
        {
            try
            {
                MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.CreateIndex();
                var connectionToEs = ElasticSearchConnectionSettings.connection();


                var ListOfDataIndexed = new List<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>();
                int pageSize = 6;
                int pageNumber = (page ?? 1);
                //on test si les schamps de rechercher sont vides
                if (string.IsNullOrEmpty(recherche) && string.IsNullOrEmpty(categorie) && string.IsNullOrEmpty(motClé))
                {

                    return View("DataNotFound");
                }

                //au cas ou les deux champs ne sont pas null 
                else if (!string.IsNullOrEmpty(recherche) && !string.IsNullOrEmpty(categorie))
                {

                    ViewBag.recherche = recherche;
                    ViewBag.categorie = categorie;
                    //on execute la connection pour élastic search 

                    var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                        (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                               .Size(50)
                               .Query(q => q.MultiMatch(m => m.Query(recherche).Fuzziness(Fuzziness.Auto))//première recherche

                                       && q.Match(m => m.Field(f => f.TypeAssetName) //filtrage de la prmiere recherche
                                           .Query(categorie))
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
                //au cas ou on fais la recherche sur un seul champs avec le système de fuzinness auto
                //Generates an edit distance based on the length of the term.
                //Low and high distance arguments may be optionally provided AUTO:[low],[high]
                // par défaut it takes [3 , 6]
                else if (!string.IsNullOrEmpty(recherche))
                {

                    ViewBag.recherche = recherche;

                    var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                        (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                               .Size(50)
                               .Query(q => q.MultiMatch(m => m
                                                        .Query(recherche).Fuzziness(Fuzziness.Auto))

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
                //faire une recherche sur base de type asset (vidéo, audio, image ...)
                else if (!string.IsNullOrEmpty(categorie))
                {

                    ViewBag.categorie = categorie;

                    var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                        (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                               .Size(50)
                               .Query(q => q
                              .Match(m => m
                                  .Field(f => f.TypeAssetName)
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

                //faire un recherche par mot clé le système chercher le mot exact 
                else if (!string.IsNullOrEmpty(motClé))
                {

                    ViewBag.motClé = motClé;

                    var reponse = connectionToEs.Search<MyApp.Infrastructure.ElasticSearch.IndexDocuments.AssetDocument>
                        (s => s.Index(MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent.AssetSearchService.assetIndexName)
                               .Size(50)
                               .Query(q => q.MultiMatch(m => m
                                                        .Query(motClé).Fuzziness(Fuzziness.EditDistance(0)))

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

                return View(ListOfDataIndexed.ToList().ToPagedList(pageNumber, pageSize));
            }
            catch(Exception ex)
            {
                return View("SearchAction2", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }
        /// <summary>
        /// pour mettre à jour les nombres de votes d'une asset
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpDateOfCompteurAsset(int id)
        {
            try
            {
                MyApp.Domain.Services.HomeService.UpDateAssetCompteur(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("SearchAction2", new HandleErrorInfo(ex, "Home", "Index"));
            }

           
        }
       
       
    }
}