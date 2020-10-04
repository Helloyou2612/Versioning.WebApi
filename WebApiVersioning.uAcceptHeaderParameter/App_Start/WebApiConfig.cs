using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebApiVersioning.uAcceptHeaderParameter.Custom;

namespace WebApiVersioning.uAcceptHeaderParameter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Replace the default controller selector with our custom controller selector (Custom/CustomControllerSelector)
            config.Services.Replace(typeof(IHttpControllerSelector),
                               new CustomControllerSelector(config));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}