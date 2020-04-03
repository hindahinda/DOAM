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
        public static List<ViewModels.UsersViewModels.UserViewModels> GetListeUsers()
        {
            List<ViewModels.UsersViewModels.UserViewModels> usersListe = new List<ViewModels.UsersViewModels.UserViewModels>();
            var customers = Domain.UsersServices.UsersService.GetAspNetUsers();
            foreach (var Customs in customers)
            {
                ViewModels.UsersViewModels.UserViewModels vm = new ViewModels.UsersViewModels.UserViewModels()
                {
                    Email= Customs.Email,
                    
                    Role=MyApp.Domain.UsersServices.UserRolesService.GetAspNetRoles(), 
                };
               usersListe.Add(vm);
            }

            return usersListe;
        }
    }
}
