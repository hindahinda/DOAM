using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.Services
{
   public class AssetTagService
    {
        public static List<AssetTag> GetAssetTags()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var AssetTag = db.AssetTags.Include(a => a.Asset).Include(a => a.Tag);
                return AssetTag.ToList();
            }
        }

        public static AssetTag GetAssetTagID(int? AssetTagID) 
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AssetTags.Find(AssetTagID);
            }
        }


        public static void AddAssetTag(AssetTag assetTag)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AssetTags.Add(assetTag); 
                db.SaveChanges();
            }
        }

        public static void UpdateAssetTag(AssetTag assetTag)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(assetTag).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAssetTag(int AssetTagID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var AssetTag = db.AssetTags.Find(AssetTagID);
                db.AssetTags.Remove(AssetTag);
                db.SaveChanges();
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
        public static string GetTagLabel(int? TagID) 
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var Tag = db.Tags.Find(TagID); 
                return Tag.Label;

            }
        }
    }
}
