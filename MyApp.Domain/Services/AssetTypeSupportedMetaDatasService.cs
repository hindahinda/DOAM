using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
    public class AssetTypeSupportedMetaDatasService
    {
        public static List<AssetTypeSupportedMetaData> Get() 
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var assetTypeSupported = db.AssetTypeSupportedMetaDatas.Include(a => a.AssetType).Include(a => a.MetaData);
                return assetTypeSupported.ToList();
            }
        }

        public static AssetTypeSupportedMetaData Get(int? AssetTypeID)  
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AssetTypeSupportedMetaDatas.Find(AssetTypeID);
            }
        }


        public static void Create(AssetTypeSupportedMetaData assetT) 
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AssetTypeSupportedMetaDatas.Add(assetT);
                db.SaveChanges();
            }
        }

        public static void Update(AssetTypeSupportedMetaData assetTag)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(assetTag).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(int Id)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var AssetTag = db.AssetTypeSupportedMetaDatas.Find(Id);
                db.AssetTypeSupportedMetaDatas.Remove(AssetTag);
                db.SaveChanges();
            }
        }

        public static string GetAssetTypeName(int? AssetID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var nameAsset = db.AssetTypes.Find(AssetID);
                if (AssetID is null)
                {
                    return null;
                }
                else
                {
                    return nameAsset.TypeLabel;
                }

            }
        }
        public static string GetMetaDataName(int? Id)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var Tag = db.MetaDatas.Find(Id);
                return Tag.Title;

            }
        }
    }
}
