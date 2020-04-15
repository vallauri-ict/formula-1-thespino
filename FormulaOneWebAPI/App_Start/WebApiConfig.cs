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

            // Route dell'API Web
            config.Routes.MapHttpRoute(
                name: "Countries",
                routeTemplate: "api/Countries/{code}",
                defaults: new { controller = "Countries", action = "Get" },
                constraints: new { code = @"\w+" }
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
