using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayoutViewsExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // routes.MapRoute(
            //    name: "products",
            //    url: "{controller}/{action}/{pname}",
            //    defaults: new { },
            //    constraints: new {pname =  @"^[A-Za-z]*$" } 
            //);

            //Combination of Attribute Routing adn Convention Routing

            //Attribute Routing
            routes.MapMvcAttributeRoutes();

            //Convention Routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
