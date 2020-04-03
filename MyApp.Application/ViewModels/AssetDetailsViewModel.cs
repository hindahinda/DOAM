using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
   public  class AssetDetailsViewModel
    {

        //public Asset Assets  { get; set; }
        public int MetaDataGroupID { get; set; }
        public string MetaGroupName { get; set; }
        public string MetaDataTitle { get; set; }
        public string AssetMetaDataValue { get; set; }

    }
}
