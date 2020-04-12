using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
   public class TableOfAssetDetailsViewModel
    {
        public int AssetID { get; set; }
        public string Name { get; set; }
        public int MetaDataGroupID { get; set; }
        public string MetaGroupName { get; set; }
        public int MetaDataID { get; set; }
        public string MetaDataTitle { get; set; }
        public string AssetMetaDataValue { get; set; }

     
    }
}
