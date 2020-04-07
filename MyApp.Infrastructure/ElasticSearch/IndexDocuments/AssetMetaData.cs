using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.ElasticSearch.IndexDocuments
{
    public class AssetMetaData
    {
        public int AssetMetaDataID { get; set; }
        public Nullable<int> AssetID { get; set; }

        public Nullable<int> MetaDataID { get; set; }
        public string Value { get; set; }
        public string AssetName { get; set; }
    }
}
