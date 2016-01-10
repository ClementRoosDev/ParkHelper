using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ParkHelper.Data;

namespace ParkHelper.Apiv2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Lieu>("Lieux");
            builder.EntitySet<EtatLieu>("EtatLieux");
            builder.EntitySet<TypeDeLieu>("TypeDeLieux");
            builder.EntitySet<Indication>("Indications");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
