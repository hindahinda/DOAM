using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
    public class AllDetailsAssetsService
    {
        public static void GetAllDetailsAssets(int AssetId)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                
                var details = from assetMetaData in db.AssetMetaDatas
                            join metaData in db.MetaDatas
                              on assetMetaData.AssetMetaDataID equals metaData.MetaDataID
                              join metaGroup in db.MetaDataGroups on metaData.MetaDataGroupID equals metaGroup.MetaDataGroupID
                            where assetMetaData.AssetID == AssetId
                            select new { metaGroup.MetaDataGroupID,
                                         metaGroup.GroupName,
                                         metaData.Title,
                                         assetMetaData.Value
                            };
    //            select metg.MetaDataGroupID,metg.GroupName ,met.Title, ast.Name,aty.Value from asset ast inner join AssetMetaData aty on ast.AssetID = aty.AssetID

    //inner join MetaData met on aty.MetaDataID = met.MetaDataID

    //inner join MetaDataGroup metg on met.MetaDataGroupID = metg.MetaDataGroupID

    //where ast.AssetID = 1

    //group by metg.MetaDataGroupID,metg.GroupName, met.Title, ast.Name,aty.Value
                //foreach (var totalcomp in total)
                //{

                //    totalAudio = total.Count();
                //}
                //return totalAudio;
            }

        }
    }
}
