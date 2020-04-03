using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class MetaDataGroupControllerServie
    {
        public static List<ViewModels.MetaDataGroupViewModel> GetListeMetaDataGroup()
        {
            List<ViewModels.MetaDataGroupViewModel> MetaDataGroupListe = new List<ViewModels.MetaDataGroupViewModel>();
           
            var metaDataGroup = Domain.Services.MetaDataGroupService.GetMetaDatasGroups();
         
            foreach (var MetaDataGroup in metaDataGroup)
            {
                ViewModels.MetaDataGroupViewModel vm = new ViewModels.MetaDataGroupViewModel()
                {
                    MetaDataGroupID= MetaDataGroup.MetaDataGroupID,
                    GroupName= MetaDataGroup.GroupName,
                    Description= MetaDataGroup.Description

                };

                MetaDataGroupListe.Add(vm);
            }

            return MetaDataGroupListe;
        }
        public static ViewModels.MetaDataGroupViewModel GetMetaDataGroupId(int? id) 
        {
            var metaDataGroup = MyApp.Domain.Services.MetaDataGroupService.GetMetaDataGroupID(id); 
            ViewModels.MetaDataGroupViewModel vm = new ViewModels.MetaDataGroupViewModel()
            {
                MetaDataGroupID = metaDataGroup.MetaDataGroupID,
                GroupName = metaDataGroup.GroupName,
                Description = metaDataGroup.Description
            };
            return vm;
        }

    }
}
