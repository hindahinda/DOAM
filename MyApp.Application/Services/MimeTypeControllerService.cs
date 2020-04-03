using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
   public class MimeTypeControllerService
    {

        public static List<ViewModels.MimeTypeViewModel> GetListeMimeType()
        {
            List<ViewModels.MimeTypeViewModel> MimeTypeListe = new List<ViewModels.MimeTypeViewModel>();
            List<ViewModels.AssetTypeViewModel> assetTypeListe = new List<ViewModels.AssetTypeViewModel>(); 
            var mimeTypes = Domain.Services.MimeTypeService.GetMimeTypes();
            var asseTypes = Domain.Services.AssetTypeService.GetAssetTypes();
            foreach (var mimeTpye in mimeTypes)
            {
                ViewModels.MimeTypeViewModel vm = new ViewModels.MimeTypeViewModel()
                {
                    MimeTypeID = mimeTpye.MimeTypeID,
                    Mime = mimeTpye.Mime,
                    AssetTypeID = mimeTpye.AssetTypeID,

                    TypeLabel = MyApp.Domain.Services.AssetTypeService.GetAssetTypeName(mimeTpye.AssetTypeID),

                };
                
           

            MimeTypeListe.Add(vm);
            }

            return MimeTypeListe;
        }
        public static ViewModels.MimeTypeViewModel GetMimeTypeId(int? id)
        {
            var mime = MyApp.Domain.Services.MimeTypeService.GetMimeTypeID(id);
            ViewModels.MimeTypeViewModel vm = new ViewModels.MimeTypeViewModel()
            {
                MimeTypeID = mime.MimeTypeID,
                Mime = mime.Mime,
                AssetTypeID = mime.AssetTypeID,
                TypeLabel = MyApp.Domain.Services.AssetTypeService.GetAssetTypeName(mime.AssetTypeID),
            };
            return vm;
        }
        public static List<ViewModels.MimeTypeViewModel> SearchMimeType(string searchString)
        {
            List<ViewModels.MimeTypeViewModel> MimeTypeListe = new List<ViewModels.MimeTypeViewModel>();
            var mimeTypes = Domain.Services.MimeTypeService.SearchMimeTypeByName(searchString);
            var asseTypes = Domain.Services.AssetTypeService.GetAssetTypes();
            foreach (var mimeTpye in mimeTypes)
            {
                ViewModels.MimeTypeViewModel vm = new ViewModels.MimeTypeViewModel()
                {
                    MimeTypeID = mimeTpye.MimeTypeID,
                    Mime = mimeTpye.Mime,
                    AssetTypeID = mimeTpye.AssetTypeID,

                    TypeLabel = MyApp.Domain.Services.AssetTypeService.GetAssetTypeName(mimeTpye.AssetTypeID),
                };
                MimeTypeListe.Add(vm);
            }

            return MimeTypeListe;
        }
        public static List<ViewModels.MimeTypeViewModel> SortingMimeType(string sortOrder)
        {
            List<ViewModels.MimeTypeViewModel> MimeTypeListe = new List<ViewModels.MimeTypeViewModel>();
            var mimeTypes = Domain.Services.MimeTypeService.SortOrderMimeType(sortOrder);
            //var asseTypes = Domain.Services.AssetTypeService.GetAssetTypes();
            foreach (var mimeTpye in mimeTypes)
            {
                ViewModels.MimeTypeViewModel vm = new ViewModels.MimeTypeViewModel()
                {
                    MimeTypeID = mimeTpye.MimeTypeID,
                    Mime = mimeTpye.Mime,
                    AssetTypeID = mimeTpye.AssetTypeID,

                    TypeLabel = MyApp.Domain.Services.AssetTypeService.GetAssetTypeName(mimeTpye.AssetTypeID),
                };
                MimeTypeListe.Add(vm);
            }

            return MimeTypeListe;
        }
    }
}
