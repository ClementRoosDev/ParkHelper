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



            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Lieu>("Lieux");
            builder.EntitySet<TypeDeLieu>("TypeDeLieux");
            builder.EntitySet<Indication>("Indications");
            builder.EntitySet<Planning>("Plannings");
            builder.EntitySet<EtatLieu>("EtatLieux");
            builder.EntitySet<Horaire>("Horaires");
            builder.EntitySet<Jour>("Jours");
            builder.EntitySet<Mois>("Mois");
            builder.EntitySet<NumeroJour>("NumeroJours");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            json.UseDataContractJsonSerializer = true;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
