using MyApp.Infrastructure.DB;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.ElasticSearch.IndexDocuments
{
    public class AssetDocument
    {
        [Keyword(Name = nameof(AssetID))]
        public int AssetID { get; set; }

        [Text(Name = nameof(Name))]
        public string Name { get; set; }

        [Text(Name = nameof(Description))]
        public string Description { get; set; }


        [Nested(Name = nameof(AssetMetadatas), IncludeInRoot = true)]
        public List<AssetMetaData> AssetMetadatas { get; set; }

        [Nested(Name = nameof(AssetTags), IncludeInRoot = true)]
        public List<AssetTag> AssetTags { get; set; }

        public AssetDocument()
        {
            AssetMetadatas = new List<AssetMetaData>();
            AssetTags = new List<AssetTag>();
        }
    }
}
