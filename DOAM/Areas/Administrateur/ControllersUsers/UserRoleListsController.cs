using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Infrastructure.DB;
using MyApp.Application.Services;

namespace DOAM.Areas.Administrateur.ControllersUsers
{
    public class UserRoleListsController : Controller
    {
        // GET: Administrateur/UserRoleLists
        public ActionResult Index()
        {
            var roles = MyApp.Application.Services.ServiceUsers.UserControllerService.GetUserRoleList();
            return View(roles.ToList());
        }
    }
}