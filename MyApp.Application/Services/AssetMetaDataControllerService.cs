using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class AssetMetaDataControllerService
    {
        public static List<ViewModels.AssetMetaDataViewModel> GetListeMetaData()
        {
            List<ViewModels.AssetMetaDataViewModel> MetaDataListe = new List<ViewModels.AssetMetaDataViewModel>();
            var metaData = Domain.Services.AssetMetaDataService.GetAssetMetaDatas();
            foreach (var meta in metaData)
            {
                ViewModels.AssetMetaDataViewModel vm = new ViewModels.AssetMetaDataViewModel()
                {
                    AssetMetaDataID=meta.AssetMetaDataID,
                    AssetID=meta.AssetID,
                    MetaDataID= meta.MetaDataID,
                    Value=meta.Value,
                    NameAsset= MyApp.Domain.Services.AssetMetaDataService.GetAssetName(meta.AssetID),
                    MetaDataTitle= MyApp.Domain.Services.AssetMetaDataService.GetMetaDataName(meta.MetaDataID),

                };
                MetaDataListe.Add(vm);
            }

            return MetaDataListe;
        }
        public static ViewModels.AssetMetaDataViewModel GetAssetMetaDataId(int? id) 
        {
            var metaData = MyApp.Domain.Services.AssetMetaDataService.GetAssetMetaDataID(id);
            ViewModels.AssetMetaDataViewModel vm = new ViewModels.AssetMetaDataViewModel()
            {
                AssetMetaDataID = metaData.AssetMetaDataID,
                AssetID = metaData.AssetID,
                MetaDataID = metaData.MetaDataID,
                Value = metaData.Value,
                NameAsset = MyApp.Domain.Services.AssetMetaDataService.GetAssetName(metaData.AssetID),
                MetaDataTitle = MyApp.Domain.Services.AssetMetaDataService.GetMetaDataName(metaData.MetaDataID),

            };
            return vm;
        }

        public static List<ViewModels.AssetMetaDataViewModel> GetFAssetMetaDataBySortingMethods(string sortOrder)
        {
            List<ViewModels.AssetMetaDataViewModel> MetaDataListe = new List<ViewModels.AssetMetaDataViewModel>();
            var customers = Domain.Services.AssetMetaDataService.SortOrderAssetMetaData(sortOrder);
            foreach (var Customs in customers)
            {
                ViewModels.AssetMetaDataViewModel vm = new ViewModels.AssetMetaDataViewModel()
                {
                    AssetMetaDataID = Customs.AssetMetaDataID,
                    AssetID = Customs.AssetID,
                    MetaDataID = Customs.MetaDataID,
                    Value = Customs.Value,
                    NameAsset = MyApp.Domain.Services.AssetMetaDataService.GetAssetName(Customs.AssetID),
                    MetaDataTitle = MyApp.Domain.Services.AssetMetaDataService.GetMetaDataName(Customs.MetaDataID),

                };
                MetaDataListe.Add(vm);
            }

            return MetaDataListe;
        }
        public static List<ViewModels.AssetMetaDataViewModel> GetAssetMetaDataByLabelSearch(string searchString) 
        {
            List<ViewModels.AssetMetaDataViewModel> MetaDataListe = new List<ViewModels.AssetMetaDataViewModel>();
            var customers = Domain.Services.AssetMetaDataService.SearchAssetMetaData(searchString);
            foreach (var Customs in customers)
            {
                ViewModels.AssetMetaDataViewModel vm = new ViewModels.AssetMetaDataViewModel()
                {
                    AssetMetaDataID = Customs.AssetMetaDataID,
                    AssetID = Customs.AssetID,
                    MetaDataID = Customs.MetaDataID,
                    Value = Customs.Value,
                    NameAsset = MyApp.Domain.Services.AssetMetaDataService.GetAssetName(Customs.AssetID),
                    MetaDataTitle = MyApp.Domain.Services.AssetMetaDataService.GetMetaDataName(Customs.MetaDataID),

                };
                MetaDataListe.Add(vm);
            }

            return MetaDataListe;
        }
    }
}
