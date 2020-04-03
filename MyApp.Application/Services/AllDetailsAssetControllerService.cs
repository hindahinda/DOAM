using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class AllDetailsAssetControllerService
    {

        
        public static List<ViewModels.AssetDetailsViewModel> GetAllDetailsAssets(int AssetId)
        {
           // ViewModels.AssetDetailsViewModel vm = new ViewModels.AssetDetailsViewModel();
            List<ViewModels.AssetDetailsViewModel> AssetListe = new List<ViewModels.AssetDetailsViewModel>();
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                var details = (from asset in db.Assets join assetMetaData in db.AssetMetaDatas 
                               on asset.AssetID equals assetMetaData.AssetID
                              join metaData in db.MetaDatas
                                on assetMetaData.MetaDataID equals metaData.MetaDataID
                              join metaGroup in db.MetaDataGroups on metaData.MetaDataGroupID equals metaGroup.MetaDataGroupID
                              where assetMetaData.AssetID == AssetId
                              select new
                              {
                                  metaGroup.MetaDataGroupID,
                                  metaGroup.GroupName,
                                  metaData.Title,
                                  assetMetaData.Value
                              });

                foreach (var totalcomp in details)
                {
                    ViewModels.AssetDetailsViewModel vm = new ViewModels.AssetDetailsViewModel()
                    {
                    MetaDataGroupID = totalcomp.MetaDataGroupID,
                    MetaGroupName = totalcomp.GroupName,
                    MetaDataTitle = totalcomp.Title,
                    AssetMetaDataValue = totalcomp.Value,
                    };
                    AssetListe.Add(vm);
                
                };
                return AssetListe;
            }

        }
    }
}
