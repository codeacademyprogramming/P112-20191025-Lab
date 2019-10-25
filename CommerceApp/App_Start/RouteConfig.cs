using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CommerceApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{language}/{controller}/{action}/{id}",
                defaults: new { language = "az", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "CommerceApp.Controllers" }

            );
        }
    }
}
