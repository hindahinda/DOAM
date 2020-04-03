using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
   public class HomeControllerService
    {

        public static List<ViewModels.HomeViewModels> GetHomeAssetsListe() 
        {
            List<ViewModels.HomeViewModels> AssetListe = new List<ViewModels.HomeViewModels>();
            var assets = Domain.Services.HomeService.GetAssets();

            foreach (var asset in assets)
            {
                ViewModels.HomeViewModels vm = new ViewModels.HomeViewModels()
                {
                    AssetID = asset.AssetID,
                    Name = asset.Name,
                    Url = asset.Url,
                    ThumbnailUrl=asset.ThumbnailUrl,
                    TypeAssetName = MyApp.Domain.Services.HomeService.GetNameAssetParTypeId(asset.AssetID),
                    DateEncoded = asset.DateEncoded,
                    TotalAssets = Domain.Services.HomeService.GetTotalAssets(),
                    TotalVideo = Domain.Services.HomeService.GetTotalAssetParTypeId(1),
                    TotalAudio = Domain.Services.HomeService.GetTotalAssetParTypeId(2),
                    TotalImages = Domain.Services.HomeService.GetTotalAssetParTypeId(3),
                    TotalStreamers = Domain.Services.HomeService.GetTotalAssetParTypeId(4),
                    TotalOtherRessources = Domain.Services.HomeService.GetTotalAssetParTypeId(5),

                };
               
                AssetListe.Add(vm);

            }

            return AssetListe;
        }
        public static ViewModels.HomeViewModels GetTotalAssetRegisteredPerAsset() 
        {

            ViewModels.HomeViewModels vm = new ViewModels.HomeViewModels()
            {
                TotalAssets = Domain.Services.HomeService.GetTotalAssets(),
                TotalVideo = Domain.Services.HomeService.GetTotalAssetParTypeId(1),
                TotalAudio = Domain.Services.HomeService.GetTotalAssetParTypeId(2),
                TotalImages = Domain.Services.HomeService.GetTotalAssetParTypeId(3),
                TotalStreamers = Domain.Services.HomeService.GetTotalAssetParTypeId(4),
                TotalOtherRessources = Domain.Services.HomeService.GetTotalAssetParTypeId(5),
            };

            return vm;
        }
    }
}
