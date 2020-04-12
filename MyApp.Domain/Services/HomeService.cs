using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
   public class HomeService
    {
        public static List<MyApp.Infrastructure.DB.Asset> GetAssets()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                var assets = db.Assets;
                return (assets.ToList());
            }
        }
        public static int GetTotalAssets()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                return db.Assets.Count();

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
                            where asset.AssetID == AssetID

                            select new { tpye.TypeLabel };

                foreach (var totalcomp in total)
                {

                    totalAudio = totalcomp.TypeLabel;
                }
                return totalAudio;
            }

        }

        public static void UpDateAssetCompteur(int AssetID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                db.SP_UpDateAssetCompteur(AssetID);
            }
        }
    }
}
