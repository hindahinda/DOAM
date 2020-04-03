using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
   public class HomeViewModels
    {
        public int AssetID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
       
        public DateTime? DateEncoded { get; set; }

        public int TotalVideo { get; set; }
        public int TotalAudio { get; set; }
        public int TotalImages { get; set; }
        public int TotalStreamers { get; set; }
        public int TotalOtherRessources { get; set; }
        public int TotalAssets { get; set; }
        public string TypeAssetName { get; set; }
       

    }
}
