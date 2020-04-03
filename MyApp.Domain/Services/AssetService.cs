using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
    public class AssetService
    {
        // Assets
        public static List<MyApp.Infrastructure.DB.Asset> GetAssets()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
              
                var assets = db.Assets.Include(a => a.MimeType);
                return(assets.ToList());
            }
        }

        public static Infrastructure.DB.Asset GetAssetID(int? AssetID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                return db.Assets.Find(AssetID);
            }
        }
        

        public static void AddAsset(Infrastructure.DB.Asset asset)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                db.Assets.Add(asset);
                db.SaveChanges();
            }
        }

        public static void UpdateAsset(Infrastructure.DB.Asset asset)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                db.Entry(asset).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAsset(int AssetID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var asset = db.Assets.Find(AssetID);
                db.Assets.Remove(asset);  
                db.SaveChanges();
            }
        }

        public static int GetTotalAssets()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                return db.Assets.Count();            
                
            }
        }

        public static List<Infrastructure.DB.Asset> SearchAssetByName(string searchString)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
             

                var assets = from s in db.Assets
                             select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    assets = assets.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
                }

                return assets.ToList();
            }
            
        }

        public static List<Infrastructure.DB.Asset> SortOrderAsset( string sortOrder)
        {
            using(Infrastructure.DB.DOAMEntities db= new Infrastructure.DB.DOAMEntities())
            {
                var assets = from s in db.Assets
                             select s;
            
                switch (sortOrder)
                {
                    case "name_desc":
                        assets = assets.OrderByDescending(s => s.Name);
                        break;
                    case "Date":
                        assets = assets.OrderBy(s => s.DateEncoded);
                        break;
                    case "date_desc":
                        assets = assets.OrderByDescending(s => s.DateEncoded);
                        break;
                    default:
                        assets = assets.OrderBy(s => s.Name);
                        break;
                }
                return assets.ToList();
            }
        }

        public static int GetTotalAssetParTypeId(int AssetTypeID)
        {

            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                int totalAudio = 0;
                var total = from asset in db.Assets
                            join mime in db.MimeTypes
                              on asset.MimeTypeID equals mime.MimeTypeID
                            where mime.AssetTypeID == AssetTypeID
                            select new { mime.AssetTypeID };

                foreach (var totalcomp in total)
                {

                    totalAudio = total.Count();
                }
                return totalAudio;
            }

        }

        public static string GetNameAssetParTypeId(int AssetID)
        {

            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                string totalAudio = "";
                var total = from asset in db.Assets
                            join mime in db.MimeTypes
                              on asset.MimeTypeID equals mime.MimeTypeID
                              join tpye in db.AssetTypes 
                                on mime.AssetTypeID equals tpye.AssetTypeID
                                where asset.AssetID==AssetID
                          
                            select new { tpye.TypeLabel };

                foreach (var totalcomp in total)
                {

                    totalAudio = totalcomp.TypeLabel;
                }
                return totalAudio;
            }

        }

    }
}
