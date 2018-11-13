using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SchoolAppToday.Configuration
{
    public class SchoolAppTodayAPIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}