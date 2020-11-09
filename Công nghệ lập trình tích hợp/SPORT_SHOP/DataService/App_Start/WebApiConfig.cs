using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            //                                 controller                        /routeApi                                               /controller
            config.Routes.MapHttpRoute(name: "ApiSportBrand", routeTemplate: "api/sport/shop/brand/add", defaults: new { controller = "ApiSportBrand" });



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
