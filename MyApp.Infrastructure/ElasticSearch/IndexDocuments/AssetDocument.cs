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

       // [Text(Analyzer = "autocomplete", Name = nameof(TypeAssetName))]
        [Text(Name = nameof(TypeAssetName))]
        public string TypeAssetName { get; set; }
       
        //[Text(Analyzer = "autocomplete", Name = nameof(Name))]
        [Text(Name = nameof(Name))]      
        public string Name { get; set; }

        [Text(Name = nameof(Url))]
        public string Url { get; set; }
       
        [Text(Name= nameof(ThumbnailUrl))] 
        public string ThumbnailUrl { get; set; }

       // [Text(Analyzer = "autocomplete", Name = nameof(Description))]
        [Text(Name = nameof(Description))]
        public string Description { get; set; } 
      
        
        //[Text(Name = nameof(MetaDataID))]
        //public int MetaDataID { get; set; }
        
        //[Text(Name = nameof(Value))]
        //public string Value { get; set; }

        //[Text(Name = nameof(TagID))]
        //public int TagID { get; set; }

        //[Text(Name = nameof(Label))]
        //public string Label { get; set; }


        [Nested(Name = nameof(AssetMetadatas), IncludeInRoot = true)]
        public List<AssetMetaData> AssetMetadatas { get; set; }

        [Nested(Name = nameof(AssetTags), IncludeInRoot = true)]
        public List<AssetTag> AssetTags { get; set; }

        [Nested(Name = nameof(Tags), IncludeInRoot = true)]
        public List<Tag> Tags { get; set; }

        public AssetDocument()
        {
            AssetMetadatas = new List<AssetMetaData>();
            AssetTags = new List<AssetTag>();
            Tags = new List<Tag>();
        }
    }
}
