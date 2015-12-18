using Microsoft.Practices.Unity;
using System.Web.Http;
using Microsoft.Practices.Unity.Mvc;
using ParkHelper.Api.Models;
using Unity.WebApi;
using UnityDependencyResolver = Unity.WebApi.UnityDependencyResolver;

namespace ParkHelper.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IParkHelperRepository, ParkHelperRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}