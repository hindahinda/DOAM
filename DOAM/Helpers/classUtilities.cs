using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAMProjet.Helpers
{
    public static class classUtilities
    {
        public static string IsLinkActive(this UrlHelper url, string action, string controller)
        {
            if (url.RequestContext.RouteData.Values["Controller"].ToString() == controller && 
                    url.RequestContext.RouteData.Values["action"].ToString()== action)
            {
                return "action";
            }
            return"";
        }
    }
}