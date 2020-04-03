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
        const string assetIndexName = "jeanpierre_asset_index";
        public static void CreateIndex()
        {

            var connectionToEs = ElasticSearchConnectionSettings.EsClient();
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
                        Name = asset.Name,
                        Description = asset.Description,
                    };

                    var assetMetadata = asset.AssetMetaDatas.Select(t => t.Asset).Distinct();
                    //foreach (var assets in assetMetadata)
                    //{
                    //    assetDocument.AssetMetadatas.Add(new IndexDocuments.AssetDocument()
                    //    {
                           
                           
                    //    });
                    //}
                    var indexResponse = connectionToEs.Index(assetDocument, c => c.Index(assetIndexName));

                }
            }
        }
    }
}
