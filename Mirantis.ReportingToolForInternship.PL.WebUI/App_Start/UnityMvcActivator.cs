using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Mirantis.ReportingTool.PL.WebUI.Automapper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Mirantis.ReportingTool.PL.WebUI.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Mirantis.ReportingTool.PL.WebUI.App_Start.UnityWebActivator), "Shutdown")]

namespace Mirantis.ReportingTool.PL.WebUI.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();
			var mapper = AutoMapperProfile.InitializeAutoMapper().CreateMapper();
			container.RegisterInstance(typeof(IMapper), mapper);

			FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}