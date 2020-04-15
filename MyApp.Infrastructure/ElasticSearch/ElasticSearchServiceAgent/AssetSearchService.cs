using MyApp.Infrastructure.ElasticSearch.IndexDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.ElasticSearch.ElasticSearchServiceAgent
{
    public class AssetSearchService
    {
       public const string assetIndexName = "jeanpierre_asset_index";
        public static void CreateIndex()
        {

            var connectionToEs = ElasticSearchConnectionSettings.connection();
            if (connectionToEs.IndexExists(assetIndexName).Exists)
            {
                var response = connectionToEs.DeleteIndex(assetIndexName);
            }
            var createIndexResponse = connectionToEs.CreateIndex(assetIndexName,
                c => c.Map<AssetDocument>(m => m.AutoMap()));


            using (MyApp.Infrastructure.DB.DOAMEntities db = new MyApp.Infrastructure.DB.DOAMEntities())
            {
                foreach (var asset in db.Assets)
                {
                    var assetDocument = new AssetDocument()
                    {

                        AssetID = asset.AssetID,
                        TypeAssetName=GetNameAssetParTypeId(asset.AssetID),
                        Name = asset.Name,
                        Url= asset.Url,
                        ThumbnailUrl= asset.ThumbnailUrl,
                        Description = asset.Description,
                        Compteur=asset.Compteur 
                        
                    };

                    var assetMetadata = asset.AssetMetaDatas.Select(t => t).Distinct();
                    foreach (var assets in assetMetadata)
                    {
                        assetDocument.AssetMetadatas.Add(new IndexDocuments.AssetMetaData
                        {
                            AssetMetaDataID = assets.AssetMetaDataID,
                            AssetName= assets.MetaData.Title,
                            Value = assets.Value,

                        }) ;
                    }

                    var assetTag = asset.AssetTags.Select(t => t.Tag).Distinct();
                    foreach (var assetTags in assetTag)
                    {
                        assetDocument.Tags.Add(new IndexDocuments.Tag
                        {
                           TagID= assetTags.TagID,
                           Label = assetTags.Label,

                        });
                    }

                    var indexResponse = connectionToEs.Index(assetDocument, c => c.Index(assetIndexName));

                }
            }
        }
        private static string GetNameAssetParTypeId(int AssetID)
        {

            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                string typeName = "";
                var name = from asset in db.Assets
                            join mime in db.MimeTypes
                              on asset.MimeTypeID equals mime.MimeTypeID
                            join tpye in db.AssetTypes
                              on mime.AssetTypeID equals tpye.AssetTypeID
                            where asset.AssetID == AssetID

                            select new { tpye.TypeLabel };

                foreach (var typeAsset in name)
                {

                    typeName = typeAsset.TypeLabel;
                }
                return typeName;
            }

        }
    }
}
