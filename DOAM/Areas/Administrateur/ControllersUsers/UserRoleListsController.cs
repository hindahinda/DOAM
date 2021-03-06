﻿using System;
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
            try
            {


                var roles = MyApp.Application.Services.ServiceUsers.UserControllerService.GetUserRoleList();
                return View(roles.ToList());
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Admin", "Index"));
            }
        }
    }
}