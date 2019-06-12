using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentSystem2016
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Login",
               url: "Login/Index",
               defaults: new { controller = "Login", action = "Index" }
               );

            routes.MapRoute(
              name: "Home",
              url: "Home/Index",
              defaults: new { controller = "Home", action = "Index" }
              );
            routes.MapRoute(
              name: "Contact",
              url: "Home/Conatct",
              defaults: new { controller = "Home", action = "Index" }
              );
            routes.MapRoute(
               name: "Default",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
               );


        }
    }
}
