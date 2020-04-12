using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceUsers
{
   public class TableOfAssetDetailsControllerService
    {
        public static List<ViewModels.TableOfAssetDetailsViewModel> GetAllDetailsAssets(int AssetId)
        {
           
            List<ViewModels.TableOfAssetDetailsViewModel> AssetListe = new List<ViewModels.TableOfAssetDetailsViewModel>();
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                var details = (from asset in db.Assets
                               join assetMetaData in db.AssetMetaDatas
                                 on asset.AssetID equals assetMetaData.AssetID
                               join metaData in db.MetaDatas
                                 on assetMetaData.MetaDataID equals metaData.MetaDataID
                               join metaGroup in db.MetaDataGroups on metaData.MetaDataGroupID equals metaGroup.MetaDataGroupID
                               where assetMetaData.AssetID == AssetId
                               select new
                               {
                                   asset.AssetID,
                                   asset.Name,
                                   metaGroup.MetaDataGroupID,
                                   metaGroup.GroupName,
                                   metaData.Title,
                                   assetMetaData.Value,
                                   
                               });

                foreach (var totalcomp in details)
                {
                    ViewModels.TableOfAssetDetailsViewModel vm = new ViewModels.TableOfAssetDetailsViewModel()
                    {
                        MetaDataGroupID = totalcomp.MetaDataGroupID,
                        MetaGroupName = totalcomp.GroupName,
                        MetaDataTitle = totalcomp.Title,
                        AssetMetaDataValue = totalcomp.Value,
                        AssetID = totalcomp.AssetID,
                        Name=totalcomp.Name,
                    };
                    AssetListe.Add(vm);

                };
                return AssetListe;
            }

        }
    }
}
