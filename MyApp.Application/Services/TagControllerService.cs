using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
   public class TagControllerService
    {
        public static List<ViewModels.TagViewModel> GetListeTag()
        {
            List<ViewModels.TagViewModel> TagListe = new List<ViewModels.TagViewModel>();
            var customers = Domain.Services.TagService.GetTags();
            foreach (var Customs in customers)
            {
                ViewModels.TagViewModel vm = new ViewModels.TagViewModel()
                {
                    TagID = Customs.TagID,
                    Label = Customs.Label,
                    Status=Customs.Status, 
                    

                };
                TagListe.Add(vm);
            }

            return TagListe;
        }
        public static ViewModels.TagViewModel GetTagId(int? id)
        {
            var tag = MyApp.Domain.Services.TagService.GetTagID(id);
            ViewModels.TagViewModel vm = new ViewModels.TagViewModel()
            {
                TagID = tag.TagID,
                Label = tag.Label,
                Status = tag.Status,

            };
            return vm;
        }

        public static List<ViewModels.TagViewModel> GetTagBySortingMethods( string sortOrder)
        {
            List<ViewModels.TagViewModel> TagListe = new List<ViewModels.TagViewModel>();
            var customers = Domain.Services.TagService.SortOrderAsset(sortOrder);
            foreach (var Customs in customers)
            {
                ViewModels.TagViewModel vm = new ViewModels.TagViewModel()
                {
                    TagID = Customs.TagID,
                    Label = Customs.Label,
                    Status = Customs.Status,


                };
                TagListe.Add(vm);
            }

            return TagListe;
        }
        public static List<ViewModels.TagViewModel> GetTagByLabelSearch(string searchString)
        {
            List<ViewModels.TagViewModel> TagListe = new List<ViewModels.TagViewModel>();
            var customers = Domain.Services.TagService.SearchTagByName(searchString);
            foreach (var Customs in customers)
            {
                ViewModels.TagViewModel vm = new ViewModels.TagViewModel()
                {
                    TagID = Customs.TagID,
                    Label = Customs.Label,
                    Status = Customs.Status,


                };
                TagListe.Add(vm);
            }

            return TagListe;
        }

    }
}
