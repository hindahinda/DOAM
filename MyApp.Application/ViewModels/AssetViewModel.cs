using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
    public class AssetViewModel
    {
        public int AssetID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public DateTime? DateEncoded { get; set; }
        public int? MimeTypeID { get; set; }
        public string MimeType { get; set; }  
        public int TotalAssets { get; set; }
        public string TypeAssetName { get; set; }

        public int Compteur { get; set; }
        public List<Asset> Assets { get; set; }

        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }

}
