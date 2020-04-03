using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.Services
{
   public class AssetTypeService
    {
        public static List<AssetType> GetAssetTypes()
        {
            using (DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var assetType = db.AssetTypes;
                return assetType.ToList();    
            }
        }

        public static AssetType GetAssetTypeID(int? AssetTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AssetTypes.Find(AssetTypeID);
            }
        }
        public static string GetAssetTypeName(int AssetTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var typeLabel= db.AssetTypes.Find(AssetTypeID);
                return typeLabel.TypeLabel;

            }
        }


        public static void AddAssetType(AssetType assetType)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AssetTypes.Add(assetType);
                db.SaveChanges();
            }
        }

        public static void UpdateAssetType(AssetType assetType)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(assetType).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAssetType(int AssetTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var assetType = db.AssetTypes.Find(AssetTypeID);
                db.AssetTypes.Remove(assetType);
                db.SaveChanges();
            }
        }
    }
}
