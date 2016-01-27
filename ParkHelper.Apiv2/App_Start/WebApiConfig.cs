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
            builder.EntitySet<Lieu>("Lieux").EntityType.HasKey(p => p.Id);
            builder.EntitySet<TypeDeLieu>("TypeDeLieux").EntityType.HasKey(p => p.Id);
            builder.EntitySet<Indication>("Indications").EntityType.HasKey(p => p.Id);
            builder.EntitySet<Planning>("Plannings").EntityType.HasKey(p => p.id);
            builder.EntitySet<EtatLieu>("EtatLieux").EntityType.HasKey(p => p.IdEtat);
            builder.EntitySet<Horaire>("Horaires").EntityType.HasKey(p => p.Id);
            builder.EntitySet<Jour>("Jours").EntityType.HasKey(p => p.Id);
            builder.EntitySet<Mois>("Mois").EntityType.HasKey(p => p.Id); ;
            builder.EntitySet<NumeroJour>("NumeroJours").EntityType.HasKey(p => p.Id);
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            //json.UseDataContractJsonSerializer = true;
            //json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
