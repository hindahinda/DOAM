using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
  public  class AssetMetaDataViewModel
    {
        public int AssetMetaDataID { get; set; }
        public Nullable<int> AssetID { get; set; }

        public Nullable<int> MetaDataID { get; set; }
        public string Value { get; set; }
       

        public string NameAsset { get; set; }
        public string MetaDataTitle { get; set; } 
    }
}
