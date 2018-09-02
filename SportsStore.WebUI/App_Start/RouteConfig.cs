using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { Controller = "Product", Action = "ShowList", category = (string)null, page = 1 });

            routes.MapRoute(
                null,
                "Page{page}",
                new { Controller = "Product", Action = "ShowList", category = (string)null },
                new { page = @"\d+" }
                );

            routes.MapRoute(
                null,
                "{category}",
                new { Controller = "Product", Action = "ShowList", page = 1 }
            );

            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new { Controller = "Product", Action = "ShowList" },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "{control}/{action}"
                );

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Product", Action = "ShowList" }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //    defaults: new { controller = "Product", action = "ShowList", id = UrlParameter.Optional }
            //);
        }
    }
}
