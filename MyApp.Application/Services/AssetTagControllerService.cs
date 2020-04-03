using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class AssetTagControllerService
    {
        public static List<ViewModels.AssetTagViewModel> GetListeAssetTags()
        {
            List<ViewModels.AssetTagViewModel> AssetTagListe = new List<ViewModels.AssetTagViewModel>();
            var tags = Domain.Services.AssetTagService.GetAssetTags();
            foreach (var tag in tags)
            {
                ViewModels.AssetTagViewModel vm = new ViewModels.AssetTagViewModel()
                {
                    AssetTagID = tag.AssetTagID,
                    TagID = tag.TagID,
                    AssetID = tag.AssetID,
                    AssetName = MyApp.Domain.Services.AssetTagService.GetAssetName(tag.AssetID),
                    TagLabel = MyApp.Domain.Services.AssetTagService.GetTagLabel(tag.TagID),
                };
                AssetTagListe.Add(vm);
            }

            return AssetTagListe;
        }
        public static ViewModels.AssetTagViewModel GetAssetTagId(int? id)
        {
            var tags = MyApp.Domain.Services.AssetTagService.GetAssetTagID(id);
            ViewModels.AssetTagViewModel vm = new ViewModels.AssetTagViewModel()
            {
                AssetTagID = tags.AssetTagID,
                TagID = tags.TagID,
                AssetID = tags.AssetID,
                AssetName = MyApp.Domain.Services.AssetTagService.GetAssetName(tags.AssetID),
                TagLabel = MyApp.Domain.Services.AssetTagService.GetTagLabel(tags.TagID),
            };
            return vm;
        }

        

        public static List<ViewModels.AssetTagViewModel> SearchAssetTag(string searchString)
        {
            var assetTagList = MyApp.Application.Services.AssetTagControllerService.GetListeAssetTags();
            var assetTag = from s in assetTagList
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                assetTag = assetTag.Where(s => s.AssetName.ToUpper().Contains(searchString.ToUpper())
                                                || s.TagLabel.ToUpper().Contains(searchString));
            }

            return assetTag.ToList();
        }


        public static List<ViewModels.AssetTagViewModel> SortOrderTagAsset(string sortOrder)
        {


            var assetTagList = MyApp.Application.Services.AssetTagControllerService.GetListeAssetTags();

            var assetTag = from s in assetTagList
                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    assetTag = assetTag.OrderByDescending(s => s.AssetName);
                    break;
                case "name_asc":
                    assetTag = assetTag.OrderBy(s => s.TagLabel);
                    break;
                default:
                    assetTag = assetTag.OrderBy(s => s.AssetTagID);
                    break;
            }
            return assetTag.ToList();
        }


    }   
    
}
