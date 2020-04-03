using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
   public class TotalAssetByTypeControllerService
    {
        public static int GetTotalAssetRegistered()
        {
                 
            ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {
                TotalAssets = Domain.Services.AssetService.GetTotalAssets(),
               
            };

            return vm.TotalAssets;
        }
        public static int GetTotalAssetVideo()
        {      
           ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {
             
                TotalVideo = Domain.Services.AssetService.GetTotalAssetParTypeId(1),
               
            };

            return vm.TotalVideo;
        }
        public static int GetTotalAssetAudio()
        {

            ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {

                TotalAudio = Domain.Services.AssetService.GetTotalAssetParTypeId(2),

            };

            return vm.TotalAudio;
        }

        public static int GetTotalAssetImage()
        {
            ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {
                TotalImages = Domain.Services.AssetService.GetTotalAssetParTypeId(3),
 
            };

            return vm.TotalImages;
        }
        public static int GetTotalAssetStreamers()
        {
            ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {
                TotalStreamers = Domain.Services.AssetService.GetTotalAssetParTypeId(4),
 
            };

            return vm.TotalStreamers;
        }
        public static int GetTotalAssetOtherAssetss()
        {

          
            ViewModels.TotalAssetByTypeViewModel vm = new ViewModels.TotalAssetByTypeViewModel()
            {
                TotalOtherRessources = Domain.Services.AssetService.GetTotalAssetParTypeId(5),
            };

            return vm.TotalOtherRessources;
        }

    }
}
