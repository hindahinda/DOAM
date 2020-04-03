using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAM.Areas.Administrateur.Controllers
{
    public class AdminController : Controller
    {
        // GET: Administrateur/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}