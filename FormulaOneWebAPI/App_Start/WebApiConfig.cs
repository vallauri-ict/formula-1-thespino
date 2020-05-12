using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FormulaOneWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Servizi e configurazione dell'API Web

            // Route specifiche delle API
            config.Routes.MapHttpRoute(
                name: "Countries",
                routeTemplate: "api/Countries/{code}",
                defaults: new { controller = "Countries", action = "Get" },
                constraints: new { code = @"\w+" }
            );

            config.Routes.MapHttpRoute(
                name: "ResultsOfRace",
                routeTemplate: "api/Results/of-race/{id}",
                defaults: new { controller = "Results", action = "OfRace" },
                constraints: new { id = @"\d+" }
            );

            config.MapHttpAttributeRoutes();

            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
