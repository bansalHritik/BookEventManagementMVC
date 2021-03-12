using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebBookEventManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UserEvents",
                routeTemplate: "api/events/user/{id}",
                defaults: new { controller = "Events", action="UserEvents" }
            );
            config.Routes.MapHttpRoute(
                name: "Invited Events",
                routeTemplate: "api/events/user/invited/{id}",
                defaults: new { controller = "Events", action = "Invited" }
            );
        }
    }
}
