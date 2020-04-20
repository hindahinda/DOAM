using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;
using System.Net;
using System.Web.Mvc;

using System.Data.Entity;
using MyApp.Application.Services;

namespace MyApp.Application.Services
{
    public class AssetControllerService
    {

        public static List<ViewModels.AssetViewModel> GetListeAsset()
        {
            List<ViewModels.AssetViewModel> AssetListe = new List<ViewModels.AssetViewModel>();
            var assets = Domain.Services.AssetService.GetAssets();
            foreach (var asset in assets)
            {
                ViewModels.AssetViewModel vm = new ViewModels.AssetViewModel()
                {
                    AssetID = asset.AssetID,
                    Name = asset.Name,
                    Url = asset.Url,
                    ThumbnailUrl = asset.ThumbnailUrl,
                    Description = asset.Description,
                    DateEncoded = asset.DateEncoded,
                    MimeTypeID = asset.MimeTypeID, 
                    MimeType=MyApp.Domain.Services.MimeTypeService.GetMimeTypeName(asset.MimeTypeID),   
                    //Compteur= asset.Compteur,                                    
            };
                AssetListe.Add(vm);
            }

            return AssetListe;
        }

        public static List<ViewModels.AssetViewModel> GetListeAssetParURLetName()
        {
            List<ViewModels.AssetViewModel> AssetListe = new List<ViewModels.AssetViewModel>();
            var assets = Domain.Services.AssetService.GetAssets();
           
            foreach (var asset in assets)
            {
                ViewModels.AssetViewModel vm = new ViewModels.AssetViewModel()
                {
                    AssetID=asset.AssetID,
                    Name = asset.Name,
                    Url = asset.Url, 
                    TypeAssetName= MyApp.Domain.Services.AssetService.GetNameAssetParTypeId(asset.AssetID),
                    DateEncoded=asset.DateEncoded,
                    MimeType = MyApp.Domain.Services.MimeTypeService.GetMimeTypeName(asset.MimeTypeID),
                };
                AssetListe.Add(vm);
            }

            return AssetListe;
        }
        public static ViewModels.AssetViewModel GetAssetId(int? id)
        {
            var asset= MyApp.Domain.Services.AssetService.GetAssetID(id);
            ViewModels.AssetViewModel vm = new ViewModels.AssetViewModel()
            {
                AssetID = asset.AssetID,
                Name = asset.Name,
                Url = asset.Url,
                ThumbnailUrl = asset.ThumbnailUrl,
                Description = asset.Description,
                DateEncoded = asset.DateEncoded,
                MimeTypeID = asset.MimeTypeID,
                MimeType = MyApp.Domain.Services.MimeTypeService.GetMimeTypeName(asset.MimeTypeID),
            };
            return vm;
        }

        public static List<ViewModels.AssetViewModel> GetAssetByMethodeSearch(string searchString)
        {
            List<ViewModels.AssetViewModel> AssetListe = new List<ViewModels.AssetViewModel>();
            var assets = Domain.Services.AssetService.SearchAssetByName(searchString);
            foreach (var asset in assets)
            {
                ViewModels.AssetViewModel vm = new ViewModels.AssetViewModel()
                {
                    AssetID = asset.AssetID,
                    Name = asset.Name,
                    Url = asset.Url,
                    ThumbnailUrl = asset.ThumbnailUrl,
                    Description = asset.Description,
                    DateEncoded = asset.DateEncoded,
                    MimeTypeID = asset.MimeTypeID,
                    MimeType = MyApp.Domain.Services.MimeTypeService.GetMimeTypeName(asset.MimeTypeID),
                };
                AssetListe.Add(vm);
            }

            return AssetListe;
        }
        public static List<ViewModels.AssetViewModel> GetAssetBySortingMethods(string sortOrder) 
        {
            List<ViewModels.AssetViewModel> AssetListe = new List<ViewModels.AssetViewModel>();
            var assets = Domain.Services.AssetService.SortOrderAsset(sortOrder);
            foreach (var asset in assets)
            {
                ViewModels.AssetViewModel vm = new ViewModels.AssetViewModel()
                {
                    AssetID = asset.AssetID,
                    Name = asset.Name,
                    Url = asset.Url,
                    ThumbnailUrl = asset.ThumbnailUrl,
                    Description = asset.Description,
                    DateEncoded = asset.DateEncoded,
                    MimeTypeID = asset.MimeTypeID,
                    MimeType = MyApp.Domain.Services.MimeTypeService.GetMimeTypeName(asset.MimeTypeID),
                };
                AssetListe.Add(vm);
            }

            return AssetListe;
        }

    }
}
