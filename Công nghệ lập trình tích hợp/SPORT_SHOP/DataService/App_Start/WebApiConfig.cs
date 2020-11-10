using System.Web.Http;

namespace DataService
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "ApiSportCategory", routeTemplate: "api/sport/shop/category/add", defaults: new { controller = "ApiSportCategory" });


           
        }
    }
}
