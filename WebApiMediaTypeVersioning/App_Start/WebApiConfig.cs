using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebApiContrib.Formatting.Jsonp;
using WebApiMediaTypeVersioning.Services.Versioning;

namespace WebApiMediaTypeVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );


            // Remove XML
            var applicationXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes
               .FirstOrDefault(p => p.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(applicationXmlType);


            // Camel case names
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Support JsonP http://en.wikipedia.org/wiki/JSONP
            //Install-Package WebApiContrib.Formatting.Jsonp
            var jsonpFormatter = new JsonpMediaTypeFormatter(jsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);


            //Tell WebApi to create custom MediaTypes
            CreateMediaTypes(jsonFormatter);         


            //Use your own ControllerSelector
            config.Services.Replace(typeof(IHttpControllerSelector),
              new ApiVersioningSelector(config));
        }

        private static void CreateMediaTypes(JsonMediaTypeFormatter jsonFormatter)
        {
            //Register your media types
            //Vendor specific media types http://www.iana.org/cgi-bin/mediatypes.pl
            var mediaTypes = new List<string> { 
                "application/vnd.yournamespace.yourresource.v1+json",
                "application/vnd.yournamespace.yourresource.v2+json"
            };
            foreach (var mediaType in mediaTypes)
            {
                jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
            }
        }
    }
}
