using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
    public class AssetTagViewModel
    {
        public int AssetTagID {get; set;}
        public int? TagID { get; set; }
        public int? AssetID { get; set; }

        public string AssetName { get; set; } 
        public string TagLabel { get; set; }


    }
}
