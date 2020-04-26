using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceUsers
{
    public class UserControllerService
    {
        public static List<ViewModels.UsersViewModels.UserViewModels> GetUserRoleList() 
        {
           
                List<ViewModels.UsersViewModels.UserViewModels> AssetListe = new List<ViewModels.UsersViewModels.UserViewModels>();
                var assets = MyApp.Domain.Services.AfficherUserRoleServiceNames.Get();
                foreach (var asset in assets)
                {
                    ViewModels.UsersViewModels.UserViewModels vm = new ViewModels.UsersViewModels.UserViewModels()
                    {
                        Id = asset.Id,
                        Email = asset.Email,
                        UserName = asset.UserName,
                        RoleName = asset.Name

                    };
                    AssetListe.Add(vm);
                }

                return AssetListe;
            
        }

    }
}
