using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiVersioning.uAcceptHeaderParameter.Custom
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

            var routeData = request.GetRouteData();
            // Get the controller name passed
            var controllerName = routeData.Values["controller"].ToString();
            string apiVersion = "1";
            // Get Accept Header which contains version
            //Check version Accept Header exists
            var acceptHeader = request.Headers.Accept.Where(m => m.Parameters.Count(t => t.Name.ToLower() == "version") > 0);
            if (acceptHeader.Any())
            {
                //Get the first value of Version from the Accept Header Parameter
                apiVersion = acceptHeader.First().Parameters.First(x => x.Name.ToLower() == "version").Value;
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