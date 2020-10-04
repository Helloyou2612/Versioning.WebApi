using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiVersioning.uQueryStringParameter.Custom
{
    // Derive the CustomControllerSelector from the DefaultHttpControllerSelector class
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;

        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // First fetch all the available Web API controllers
            var controllers = GetControllerMapping();
            // Get the controller name and the parameter values from the request URI
            var routeData = request.GetRouteData();
            // Get the controller name from route data.
            // The name of the controller in our case is "Employees"
            var controllerName = routeData.Values["controller"].ToString();
            // Set the Default version number to 1
            string apiVersion = "1";
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString["v"] != null)
            {
                apiVersion = versionQueryString["v"];
            }
            //append versionNumber to the controller name
            controllerName = controllerName + "V" + apiVersion;

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}