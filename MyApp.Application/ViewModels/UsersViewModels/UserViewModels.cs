using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB; 


namespace MyApp.Application.ViewModels.UsersViewModels
{
   public class UserViewModels
    {

        public string Email { get; set; }
        public string UserName { get; set; }

        public string RoleName { get; set; }
        public List<AspNetRole> Role { get; set; }


    }
}
