using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class MetaDataControllerService
    {
        public static List<ViewModels.MetaDataViewModel> GetListeMetaData()
        {
            List<ViewModels.MetaDataViewModel> MetaDataListe = new List<ViewModels.MetaDataViewModel>();
            var metaData = Domain.Services.MetaDataService.GetMetaDatas();
            foreach (var meta in metaData)
            {
                ViewModels.MetaDataViewModel vm = new ViewModels.MetaDataViewModel()
                {
                    MetaDataID = meta.MetaDataID,
                    Title = meta.Title,
                    Description = meta.Description,
                    MetaDataGroupID = meta.MetaDataGroupID,
                    GroupName = MyApp.Domain.Services.MetaDataService.GetGroupNameMetaData(meta.MetaDataGroupID)
                };
                MetaDataListe.Add(vm);
            } 

            return MetaDataListe;
        }


        public static ViewModels.MetaDataViewModel GetMetaDataId(int? id)
        {
            var meta = MyApp.Domain.Services.MetaDataService.GetMetaDataID(id);
            ViewModels.MetaDataViewModel vm = new ViewModels.MetaDataViewModel()
            {
                MetaDataID = meta.MetaDataID,
                Title = meta.Title,
                Description = meta.Description,
                MetaDataGroupID = meta.MetaDataGroupID,
                GroupName = MyApp.Domain.Services.MetaDataService.GetGroupNameMetaData(meta.MetaDataGroupID)
            };
            return vm;
        }

        public static List<ViewModels.MetaDataViewModel> GetMetaDataByMethodeSearch(string searchString)
        {
            List<ViewModels.MetaDataViewModel> MetaDataListe = new List<ViewModels.MetaDataViewModel>();
            var metaData = Domain.Services.MetaDataService.SearchMetaDataByName(searchString);
            foreach (var meta in metaData)
            {
                ViewModels.MetaDataViewModel vm = new ViewModels.MetaDataViewModel()
                {
                    MetaDataID = meta.MetaDataID,
                    Title = meta.Title,
                    Description = meta.Description,
                    MetaDataGroupID = meta.MetaDataGroupID,
                    GroupName = MyApp.Domain.Services.MetaDataService.GetGroupNameMetaData(meta.MetaDataGroupID)
                };
                MetaDataListe.Add(vm);
            }

            return MetaDataListe;
        }
        public static List<ViewModels.MetaDataViewModel> GetMetaDataBySortingMethods(string sortOrder)
        {
            List<ViewModels.MetaDataViewModel> MetaDataListe = new List<ViewModels.MetaDataViewModel>();
            var metaData = Domain.Services.MetaDataService.SortOrderMetaData(sortOrder);
            foreach (var meta in metaData)
            {
                ViewModels.MetaDataViewModel vm = new ViewModels.MetaDataViewModel()
                {
                    MetaDataID = meta.MetaDataID,
                    Title = meta.Title,
                    Description = meta.Description,
                    MetaDataGroupID = meta.MetaDataGroupID,
                    GroupName = MyApp.Domain.Services.MetaDataService.GetGroupNameMetaData(meta.MetaDataGroupID)
                };
                MetaDataListe.Add(vm);
            }

            return MetaDataListe;
        }
    }
}
