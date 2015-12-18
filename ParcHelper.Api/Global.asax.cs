using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ParkHelper.Api;
using ParkHelper.Api.App_Start;
using ParkHelper.Api.Controllers;
using ParkHelper.Api.Models;
using ParkHelper.Data;

namespace ProjectTrackingServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Create a new Unity dependency injection container
            /**var unity = new UnityContainer();

            // Register the Controllers that should be injectable
            unity.RegisterType<PTAttractionsController>();
            unity.RegisterType<PTParcoursController>();

            // Register instances to be used when resolving constructor parameter dependencies
            unity.RegisterInstance(new ParkHelperRepository(new ParcHelperEntities()));

            // Finally, override the default dependency resolver with Unity
            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(unity);*/
        }
    }
}
