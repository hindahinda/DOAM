using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
    public class TotalAssetByTypeViewModel
    {
        public int TotalVideo { get; set; }
        public int TotalAudio { get; set; }
        public int TotalImages { get; set; }
        public int TotalStreamers { get; set; }
        public int TotalOtherRessources { get; set; }
        public int TotalAssets { get; set; }


    }
}
