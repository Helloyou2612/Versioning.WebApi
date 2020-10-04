using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Version1",
            //    routeTemplate: "api/v1/employees/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "EmployeesV1" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Version2",
            //    routeTemplate: "api/v2/employees/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "EmployeesV2" }
            //);
        }
    }
}
