using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.Services
{
  public  class AssetMetaDataService
    {
        public static List<AssetMetaData> GetAssetMetaDatas()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var AssetmetaData = db.AssetMetaDatas.Include(a => a.Asset).Include(a => a.MetaData);
                return AssetmetaData.ToList();
            }
        }

        public static AssetMetaData GetAssetMetaDataID(int? AssetMetaDataID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AssetMetaDatas.Find(AssetMetaDataID);
            }
        }


        public static void AddAssetMetaData(AssetMetaData AssetmetaData)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AssetMetaDatas.Add(AssetmetaData);
                db.SaveChanges();
            }
        }

        public static void UpdateAssetMetaData(AssetMetaData AssetmetaData)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(AssetmetaData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAssetMetaData(int AssetMetaDataID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var AssetmetaData = db.AssetMetaDatas.Find(AssetMetaDataID);
                db.AssetMetaDatas.Remove(AssetmetaData);
                db.SaveChanges();
            }
        }
       
        public static List<Infrastructure.DB.AssetMetaData> SearchAssetMetaData(string searchString)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {


                var asssetMetada = from s in db.AssetMetaDatas
                           select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    asssetMetada = asssetMetada.Where(s => s.Value.ToUpper().Contains(searchString.ToUpper())
                                                || s.AssetID.ToString().Contains(searchString) );
                }

                return asssetMetada.ToList();
            }

        }
        public static List<Infrastructure.DB.AssetMetaData> SortOrderAssetMetaData(string sortOrder)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var assetMetaData = from s in db.AssetMetaDatas
                           select s;

                switch (sortOrder)
                {
                    case "name_desc":
                        assetMetaData = assetMetaData.OrderByDescending(s => s.Value);
                        break;

                    default:
                         assetMetaData= assetMetaData.OrderBy(s => s.AssetID);
                        break;
                }
                return assetMetaData.ToList();
            }
        }

        public static string GetAssetName(int? AssetID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                
               var nameAsset = db.Assets.Find(AssetID);
                if (AssetID is null)
                {
                    return null;
                }
                else
                {
                    return nameAsset.Name;
                }
              

            }
        }
        public static string GetMetaDataName(int? MetaDataID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var metaDataName = db.MetaDatas.Find(MetaDataID);
                return metaDataName.Title;

            }
        }


    }
}

