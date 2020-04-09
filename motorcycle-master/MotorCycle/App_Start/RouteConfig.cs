using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MotorCycle
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("MotorBikes/Index", "MotorBikes/Index/{index}", new { controller = "MotorBikes", action = "Index", id = UrlParameter.Optional }


              );

            routes.MapRoute("MotorCycleDetails/Index", "MotorCycleDetails/Index/{index}", new { controller = "MotorCycleDetails", action = "Index", id = UrlParameter.Optional }


              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
