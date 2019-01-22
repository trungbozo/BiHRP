using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithActionIdIdForm",
            //    routeTemplate: "bitecco/{controller}/{action}/{id}/{idForm}",
            //    defaults: new { id = RouteParameter.Optional}
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithActionId",
                routeTemplate: "bitecco/{controller}/{action}/{primaryKey}",
                defaults: new { primaryKey = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "bitecco/{controller}/{action}",
                defaults: null
            );
        }
    }
}
